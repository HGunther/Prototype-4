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
            //Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            //if (Physics2D.Raycast(mousePos, out raycastHit, 100f))
            var hit = Physics2D.GetRayIntersection(ray);
            if (hit.transform)
            {
                CurrentClickedGameObject(hit.transform.gameObject);
            }
        }
    }

    public void CurrentClickedGameObject(GameObject gameObject)
    {
        var node = gameObject.GetComponent<Node>();
        if (node == null)
        { return; }

        if(node == selectedNode)
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
