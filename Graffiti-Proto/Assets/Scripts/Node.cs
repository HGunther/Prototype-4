using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public bool exposed = false;
    public int days_since_exposure = 0;
    public bool is_contagous = false;
    public bool is_symptomatic = false;
    public bool would_test_positive = false;
    bool is_exposed_firstTime = false;

    public List<TestResult> testResults;
    public bool isSelected = false;

    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        testResults = new List<TestResult>();
        UpdateRender();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnEnable()
    {
        //UpdateRender();
    }

    public void OnNewDay()
    {
        if (exposed)
        {
            if(!is_exposed_firstTime)
            {
                is_exposed_firstTime = true;
            }
            else if(is_exposed_firstTime)
            {
                days_since_exposure += 1;
            }
        }
        UpdateData();
    }

    void UpdateData()
    {
        if (days_since_exposure >= Constants.days_until_contagous)
        {
            is_contagous = true;
        }
        if (days_since_exposure >= Constants.days_until_symptomatic)
        {
            is_symptomatic = true;
            UpdateRender();
        }
        if (days_since_exposure >= Constants.days_until_would_test_positive)
        {
            would_test_positive = true;
        }
        if (days_since_exposure >= Constants.days_until_not_contagous)
        {
            is_contagous = false;
        }
        if (days_since_exposure >= Constants.days_until_would_not_test_positive)
        {
            would_test_positive = false;
        }

        if (days_since_exposure >= Constants.days_until_can_get_again)
        {
            exposed = false;
            days_since_exposure = 0;
            is_contagous = false;
            is_symptomatic = false;
            UpdateRender();
            would_test_positive = false;
            is_exposed_firstTime = false;
        }
    }
    public void UpdateRender()
    {
        if (isSelected)
        {
            transform.localScale = Vector3.one * 0.002090968f;
        }
        else
        {
            transform.localScale = Vector2.one * 0.001238065f;
        }


        bool testedPositiveRecently = false;
        if (testResults.Count != 0)
        {
            if (testResults[testResults.Count - 1].testResult)
            {
                if (gameManager.numberOfDays - testResults[testResults.Count - 1].testDate < Constants.days_to_show_sick_after_test) { testedPositiveRecently = true; }
            }
        }

        if (testedPositiveRecently)
        {
            GetComponent<SpriteRenderer>().sprite = gameManager.GetComponent<Sprites>().testedPositive;
        }
        else if (is_symptomatic)
        {
            GetComponent<SpriteRenderer>().sprite = gameManager.GetComponent<Sprites>().symptomatic;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = gameManager.GetComponent<Sprites>().asymptomatic;
        }
    }

    public void OnSelected()
    {
        UpdateRender();
    }

    public void OnUnselected()
    {
        UpdateRender();
    }
}
