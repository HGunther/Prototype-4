using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeDisplay : MonoBehaviour
{
    public NodeManager nodeManager;
    Node displayingNode;
    bool enabled = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (nodeManager.selectedNode == null && enabled)
        {
            Disable();
        }
        if (nodeManager.selectedNode != null && nodeManager.selectedNode != displayingNode)
        {
            DisplayNode();
        }
    }

    void Enable()
    {
        GetComponent<Image>().enabled = true;
        var children = GetComponentsInChildren<Text>();
        foreach (Text text in children)
        {
            text.enabled = true;
        }

        enabled = true;
    }

    void Disable() {
        GetComponent<Image>().enabled = false;
        var children = GetComponentsInChildren<Text>();
        foreach(Text text in children)
        {
            text.enabled = false;
        }

        enabled = false;
    }

    void DisplayNode()
    {
        Enable();

    }
}
