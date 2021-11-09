using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge : MonoBehaviour
{
    [SerializeField] List<GameObject> Nodes;
    List<GameObject> currentNodes;
    bool isConnected = true;
    Gradient translucent = new Gradient();
    Gradient opaque = new Gradient();

void Start()
    {
        currentNodes = Nodes;
        translucent.SetKeys(new GradientColorKey[] { new GradientColorKey(Color.white, 0.0f), new GradientColorKey(Color.white, 1.0f)},
                            new GradientAlphaKey[] { new GradientAlphaKey(0.3f, 0.0f), new GradientAlphaKey(0.3f, 1.0f) });

        opaque.SetKeys(new GradientColorKey[] { new GradientColorKey(Color.white, 0.0f), new GradientColorKey(Color.white, 1.0f) },
                            new GradientAlphaKey[] { new GradientAlphaKey(1f, 0.0f), new GradientAlphaKey(1f, 1.0f) });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnNewDay()
    {
        bool eitherContageious = false;
        foreach (GameObject n in Nodes)
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
            currentNodes = Nodes;
        }
    }
}
