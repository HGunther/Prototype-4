using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeManager : MonoBehaviour
{
    GameObject[] nodes;
    GameObject[] edges;

    public Node selectedNode;
    void Start()
    {
        nodes = GameObject.FindGameObjectsWithTag("Node");
        edges = GameObject.FindGameObjectsWithTag("Edge");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // var mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            var hits = Physics2D.GetRayIntersectionAll(ray);
            bool background = false;
            bool foundNode = false;
            foreach (var hit in hits)
            {
                var gameObject = hit.transform.gameObject;
                if (gameObject.tag == "Background")
                {
                    background = true;
                }
                else
                {
                    var node = gameObject.GetComponent<Node>();
                    if (node != null)
                    {
                        foundNode = true;
                        SelectNode(node);
                    }
                }
            }
            if (!foundNode && background)
            {
                DeselectNode();
            }
        }
    }

    public void SelectNode(Node node)
    {
        if (node == selectedNode)
        { return; }

        // deselect previous
        if (selectedNode != null)
        {
            selectedNode.isSelected = false;
            selectedNode.OnUnselected();
        }

        // select new
        node.isSelected = true;
        node.OnSelected();

        selectedNode = node;
    }

    public void DeselectNode()
    {
        if (selectedNode != null)
        {
            selectedNode.isSelected = false;
            selectedNode.OnUnselected();
        }
        selectedNode = null;
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
