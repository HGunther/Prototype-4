using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField] public List<Edge> edges;

    public bool exposed = false;
    public int days_since_exposure = 0;
    public bool is_contagous = false;
    public bool is_symptomatic = false;
    public bool would_test_positive = false;

    public bool isSelected = false;

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

    public void OnNewDay()
    {
        if (exposed)
        {
            days_since_exposure += 1;
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
        }
    }

    void UpdateRender()
    {
        if (isSelected)
        {
            GetComponent<SpriteRenderer>().color = Colors.selected;
            return;
        }
        if (is_symptomatic)
        {
            GetComponent<SpriteRenderer>().color = Colors.symptomatic;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Colors.asymptomatic;
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
