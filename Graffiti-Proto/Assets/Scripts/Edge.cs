using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge : MonoBehaviour
{
    [SerializeField] List<GameObject> nodes;
    List<GameObject> currentNodes;
    bool isConnected = true;
    Gradient translucent = new Gradient();
    Gradient opaque = new Gradient();

    void Start()
    {
        currentNodes = nodes;
        translucent.SetKeys(new GradientColorKey[] { new GradientColorKey(Color.white, 0.0f), new GradientColorKey(Color.white, 1.0f)},
                            new GradientAlphaKey[] { new GradientAlphaKey(0.3f, 0.0f), new GradientAlphaKey(0.3f, 1.0f) });

        opaque.SetKeys(new GradientColorKey[] { new GradientColorKey(Color.white, 0.0f), new GradientColorKey(Color.white, 1.0f) },
                            new GradientAlphaKey[] { new GradientAlphaKey(1f, 0.0f), new GradientAlphaKey(1f, 1.0f) });
    }

    //void SetupEdge()
    //{
    //    Vector3 midPoint = (nodes[0].transform.position + nodes[1].transform.position) / 2;

    //    transform.position = midPoint;

    //    // Rotate to correct angle
    //    Vector3 dif = nodes[1].transform.position - nodes[0].transform.position;
    //    float angle_degrees = Vector3.SignedAngle(dif, Vector3.right, Vector3.back);
    //    transform.Rotate(new Vector3(0, 0, angle_degrees));

    //    // Scale to match distance
    //    float distance = Vector3.Distance(nodes[0].transform.position, nodes[1].transform.position);
    //    var temp = transform.localScale;
    //    var node_size = nodes[0].transform.lossyScale.x;
    //    temp.x = distance * 0.1f - node_size;
    //    transform.localScale = temp;
    //}

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnNewDay()
    {
        bool eitherContageious = false;
        foreach (GameObject n in nodes)
        {
            eitherContageious = eitherContageious || n.GetComponent<Node>().is_contagous;
        }

        if (eitherContageious)
        {
            foreach (GameObject n in currentNodes)
            {
                if(n.GetComponent<Node>().exposed == false)
                {
                    n.GetComponent<Node>().exposed = true;
                    n.GetComponent<Node>().OnNewDay();
                }
                //n.GetComponent<Node>().days_since_exposure = Mathf.Max(n.GetComponent<Node>().days_since_exposure, 1);
            }
        }
    }

    private void OnMouseDown()
    {
        if(isConnected)
        {
            isConnected = false;
            gameObject.GetComponent<LineRenderer>().colorGradient = translucent;
            currentNodes = new List<GameObject>();
        }
        else if(!isConnected)
        {
            isConnected = true;
            gameObject.GetComponent<LineRenderer>().colorGradient = opaque;
            currentNodes = nodes;
        }
    }
}
