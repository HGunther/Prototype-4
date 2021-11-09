using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetailsButton : MonoBehaviour
{
    [SerializeField] NodeManager nodeManager;
    [SerializeField] GameObject detailsPanel;
    bool interactable = true;
    bool detailsShowing = false;

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

    public void OnDetailsClicked()
    {
        if(!detailsShowing)
        {
            detailsShowing = true;
            detailsPanel.SetActive(true);
        }
        else if(detailsShowing)
        {
            CloseDetailsPanel();
        }
    }

    public void CloseDetailsPanel()
    {
        detailsShowing = false;
        detailsPanel.SetActive(false);
    }
}
