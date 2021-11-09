using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public NodeManager nodeManager;
    int numberOfDays = 1;
    [SerializeField] GameObject day1Panel;

    [Header("Buttons")]
    [SerializeField] GameObject confirmButton;
    [SerializeField] GameObject detailsButton;
    [SerializeField] GameObject testButton;

    [SerializeField] GameObject confirmNamesPanel;
    [SerializeField] TextMeshProUGUI dayCounter;
    [SerializeField] GameObject[] clusters;

    // Start is called before the first frame update
    void Start()
    {
        int clusterIndex = Random.Range(0, 4);
        int nodeIndex = Random.Range(0, 5);
        clusters[0].transform.GetChild(0).transform.GetChild(nodeIndex).GetComponent<Node>().exposed = true;
        clusters[0].transform.GetChild(0).transform.GetChild(nodeIndex).GetComponent<Node>().OnNewDay();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewDay(){
        Debug.Log("Starting new day");        
        nodeManager.OnNewDay();
    }
    
    public void StartDay1()
    {
        day1Panel.SetActive(false);
        confirmButton.SetActive(true);
        detailsButton.SetActive(true);
        testButton.SetActive(true);
    }

    public void DoneEditingEvent()
    {
        confirmNamesPanel.SetActive(true);
        confirmButton.GetComponent<Button>().interactable = false;
    }

    public void RetryNaming()
    {
        confirmNamesPanel.SetActive(false);
        confirmButton.GetComponent<Button>().interactable = true;
    }

    public void UpdateDayCounter()
    {
        numberOfDays++;
        dayCounter.text = "DAY: " + numberOfDays;
    }
}
