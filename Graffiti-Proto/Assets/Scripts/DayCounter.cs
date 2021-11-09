using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayCounter : MonoBehaviour
{
    public GameManager gameManager;
    int dayRendered = -1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dayRendered != gameManager.day)
        {
            var day = gameManager.day;
            GetComponent<Text>().text = "Day: " + day;
            dayRendered = day;
        }
    }
}
