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
        var children = gameObject.GetComponentsInChildren<Text>();
        foreach (var text in children)
        {
            if (text.gameObject.name == "Name")
            {
                text.text = nodeManager.selectedNode.gameObject.name;
            } else if (text.gameObject.name == "Date")
            {
                var size = nodeManager.selectedNode.testResults.Count;
                if (size == 0)
                {
                    text.text = "None";
                }
                else
                {
                    text.text = "Day " + nodeManager.selectedNode.testResults[size - 1].testDate.ToString();
                }
            }
            else if (text.gameObject.name == "Result")
            {
                var size = nodeManager.selectedNode.testResults.Count;
                if (size == 0)
                {
                    text.text = "";
                }
                else
                {
                    var result = nodeManager.selectedNode.testResults[size - 1].testResult;
                    if (result)
                    {
                        text.text = "Positive";
                    }
                    else
                    {
                        text.text = "Negative";
                    }
                }
            }
        }
    }
}
