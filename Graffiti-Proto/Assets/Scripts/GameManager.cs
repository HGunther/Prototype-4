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
    [SerializeField] GameObject confirmButton;
    [SerializeField] GameObject confirmNamesPanel;
    [SerializeField] TextMeshProUGUI dayCounter;
    [SerializeField] GameObject[] clusters;

    // Start is called before the first frame update
    void Start()
    {
        int nodeIndex;
        
        for(int i=0;i<clusters.Length;i++)
        {
            nodeIndex = Random.Range(0, 5);
            clusters[i].transform.GetChild(0).transform.GetChild(3).GetComponent<Node>().exposed = true;
        }
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
