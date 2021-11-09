using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu]
public class GameState : ScriptableObject
{
    public GameObject edgePrefab, graphParent;
    public List<Vector2Int> initEdges;
    public Dictionary<int, Node> nodes;

    public void CreateEdges()
    {
        nodes = new Dictionary<int, Node>();

        Node[] nodesArray = FindObjectsOfType<Node>();
        foreach(Node node in nodesArray)
        {
            nodes[node.id] = node;
        }

        foreach(Vector2Int edgeEnds in initEdges)
        {
            //Debug.Log(edgeEnds);
            Edge edge = Instantiate(edgePrefab, graphParent.transform).GetComponent<Edge>();
            edge.nodes = new List<Node> { nodes[edgeEnds[0]], nodes[edgeEnds[1]] };
            edge.SetupEdge();
            edge.gameObject.name = "Edge " + edgeEnds[0] + "-" + edgeEnds[1];

            nodes[edgeEnds[0]].edges.Add(edge);
            nodes[edgeEnds[1]].edges.Add(edge);
            nodes[edgeEnds[0]].connectedNodes.Add(nodes[edgeEnds[1]]);
            nodes[edgeEnds[1]].connectedNodes.Add(nodes[edgeEnds[0]]);
        }
    }
}
