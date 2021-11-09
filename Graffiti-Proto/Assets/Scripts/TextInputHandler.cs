using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextInputHandler : MonoBehaviour
{
    [SerializeField] GameObject[] inputFields;
    [SerializeField] TextMeshProUGUI[] nameFields;
    [SerializeField] GameObject confirmNamePanel;
    [SerializeField] GameObject confirmButton;
    [SerializeField] GameObject endDayButton;
    GameManager gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void PlaceNames()
    {
        confirmNamePanel.SetActive(false);
        confirmButton.SetActive(false);
        endDayButton.SetActive(true);
        gameManager.NewDay();
        for(int i=0;i<inputFields.Length;i++)
        {
            if (inputFields[i].transform.GetChild(0).transform.GetChild(2).GetComponent<TextMeshProUGUI>().text.Length !=1)
            {
                nameFields[i].text = inputFields[i].transform.GetChild(0).transform.GetChild(2).GetComponent<TextMeshProUGUI>().text;
            }
            inputFields[i].SetActive(false);
        }
    }
}
