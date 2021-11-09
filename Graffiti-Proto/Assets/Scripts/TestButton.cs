using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestButton : MonoBehaviour
{
    public NodeManager nodeManager;
    public GameManager gameManager;
    bool interactable = true;

    // Update is called once per frame
    void Update()
    {
        if (nodeManager.selectedNode != null && !interactable)
        {
            AllowInteractions();
        }
        else if (nodeManager.selectedNode == null && interactable)
        {
            DisallowInteractions();
        }
    }

    void AllowInteractions()
    {
        GetComponent<Button>().interactable = true;
        interactable = true;
    }

    void DisallowInteractions()
    {
        GetComponent<Button>().interactable = false;
        interactable = false;
    }

    public void OnTestClicked()
    {
        print("clickedTest");
        if (nodeManager.selectedNode == null) { return; }
        var newTestData = new TestResult();
        newTestData.testDate = gameManager.numberOfDays;
        newTestData.testResult = nodeManager.selectedNode.would_test_positive;

        nodeManager.selectedNode.testResults.Add(newTestData);
        nodeManager.selectedNode.UpdateRender();
    }
}