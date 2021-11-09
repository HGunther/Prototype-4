using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeManager : MonoBehaviour
{
    GameObject[] nodes;
    void Start()
    {
        nodes = GameObject.FindGameObjectsWithTag("Node");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnNewDay(){
        foreach(GameObject child in nodes){
            child.GetComponent<Node>().OnNewDay();
        }
    }
}
