using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeManager : MonoBehaviour
{
    GameObject[] nodes;
    GameObject[] edges;
    void Start()
    {
        nodes = GameObject.FindGameObjectsWithTag("Node");
        edges = GameObject.FindGameObjectsWithTag("Edge");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnNewDay(){

        foreach (GameObject child in nodes)
        {
            child.GetComponent<Node>().OnNewDay();
        }

        foreach (GameObject child in edges)
        {
            child.GetComponent<Edge>().OnNewDay();
        }

       

     
    }
}
