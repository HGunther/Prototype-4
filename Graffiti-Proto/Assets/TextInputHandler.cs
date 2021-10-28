using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextInputHandler : MonoBehaviour
{
    [SerializeField] GameObject[] inputFields;
    [SerializeField] TextMeshProUGUI[] nameFields;
    void Start()
    {
        
    }

    public void PlaceNames()
    {
        for(int i=0;i<inputFields.Length;i++)
        {
            nameFields[i].text=inputFields[i].transform.GetChild(0).transform.GetChild(2).GetComponent<TextMeshProUGUI>().text;
            inputFields[i].SetActive(false);
        }
    }
}
