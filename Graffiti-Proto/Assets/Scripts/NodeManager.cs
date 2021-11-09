using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeManager : MonoBehaviour
{
    [SerializeField] public List<Node> nodes;
    [SerializeField] public List<Edge> edges;

    bool isNodeSelected = false;
    Node selectedNode;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            var mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
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

    public void SelectNode(Node node) {
        if (node == selectedNode)
        { return; }

        // deselect previous
        if (isNodeSelected)
        {
            selectedNode.isSelected = false;
            selectedNode.OnUnselected();
        }

        // select new
        node.isSelected = true;
        node.OnSelected();

        isNodeSelected = true;
        selectedNode = node;
    }

    public void DeselectNode()
    {
        if (isNodeSelected)
        {
            selectedNode.isSelected = false;
            selectedNode.OnUnselected();
        }
        isNodeSelected = false;
        selectedNode = null;
    }

    public void OnNewDay(){
        foreach(Edge e in edges){
            if (e){
            e.OnNewDay();
            }
        }
        foreach(Node n in nodes){
            if (n){
            n.OnNewDay();
            }
        }
    }
}
