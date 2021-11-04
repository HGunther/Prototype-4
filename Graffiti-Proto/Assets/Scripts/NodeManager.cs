using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeManager : MonoBehaviour
{
    [SerializeField] public List<Node> nodes;
    [SerializeField] public List<Edge> edges;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnNewDay(){
        foreach(Edge e in edges){
            e.OnNewDay();
        }
        foreach(Node n in nodes){
            n.OnNewDay();
        }
    }
}
