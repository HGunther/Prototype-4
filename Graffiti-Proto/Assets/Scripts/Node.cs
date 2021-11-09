using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public int id;
    public List<Edge> edges;
    public List<Node> connectedNodes;

    public bool exposed = false;
    public int daysSinceExposure = 0;
    public bool isContagious = false;
    public bool isSymptomatic = false;
    public bool wouldTestPositive = false;
    public bool canGetCovid = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnEnable()
    {
        UpdateRender();
    }

    private void OnMouseDown()
    {
        print("Touched");
    }

    public void NewDay()
    {
        if (exposed)
        {
            canGetCovid = false;
            daysSinceExposure += 1;
        }
        UpdateData();

        if(isContagious)
        {
            foreach(Node node in connectedNodes)
            {
                if (!node.exposed)
                    node.exposed = true;
            }
        }
    }

    void UpdateData()
    {
        if (daysSinceExposure >= Constants.days_until_contagious)
        {
            isContagious = true;
        }
        if (daysSinceExposure >= Constants.days_until_symptomatic)
        {
            isSymptomatic = true;
            UpdateRender();
        }
        if (daysSinceExposure >= Constants.days_until_would_test_positive)
        {
            wouldTestPositive = true;
        }
        if (daysSinceExposure >= Constants.days_until_not_contagous)
        {
            isContagious = false;
        }
        if (daysSinceExposure >= Constants.days_until_would_not_test_positive)
        {
            wouldTestPositive = false;
        }

        if (daysSinceExposure >= Constants.days_until_can_get_again)
        {
            exposed = false;
            daysSinceExposure = 0;
            isContagious = false;
            isSymptomatic = false;
            UpdateRender();
            wouldTestPositive = false;
        }
    }

    void UpdateRender()
    {
        if (isSymptomatic)
        {
            GetComponent<SpriteRenderer>().color = Colors.symptomatic;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Colors.asymptomatic;
        }
    }
}
