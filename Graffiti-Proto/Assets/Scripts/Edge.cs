using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge : MonoBehaviour
{
    [SerializeField] List<GameObject> Nodes;
    bool isConnected = true;
    Gradient gradient = new Gradient();

void Start()
    {
       // gradient.SetKeys(
       //    new GradientColorKey[] { new GradientColorKey(Color.green, 0.0f), new GradientColorKey(Color.red, 1.0f) },
       //    new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
       //);
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
            foreach (GameObject n in Nodes)
            {
                n.GetComponent<Node>().exposed = true;
                n.GetComponent<Node>().days_since_exposure = Mathf.Max(n.GetComponent<Node>().days_since_exposure, 1);
            }
        }
    }

    private void OnMouseDown()
    {
        if(isConnected)
        {
            isConnected = false;
            //gameObject.GetComponent<TrailRenderer>().colorGradient
        }
        else if(!isConnected)
        {
            isConnected = true;
            //makeopaque
        }
    }
}
