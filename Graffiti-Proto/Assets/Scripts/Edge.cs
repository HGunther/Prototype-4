using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge : MonoBehaviour
{
    [SerializeField] public List<Node> nodes;

    // Start is called before the first frame update
    void Start()
    {
        // Move between all nodes
        Vector3 midPoint = Vector3.zero;
        foreach(Node node in nodes)
        {
            midPoint += node.transform.position;
        }
        float scale = 1.0f / nodes.Count;
        midPoint = midPoint * scale;

        transform.position = midPoint;

        // Rotate to correct angle
        Vector3 dif = nodes[1].transform.position - nodes[0].transform.position;
        float angle_degrees = Vector3.Angle(dif, Vector3.right);
        transform.Rotate(new Vector3(0, 0, angle_degrees));

        // Scale to match distance
        float distance = Vector3.Distance(nodes[0].transform.position, nodes[1].transform.position);
        var temp = transform.localScale;
        var node_size = nodes[0].transform.localScale.x;
        temp.x = distance * 0.1f - node_size;
        transform.localScale = temp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
