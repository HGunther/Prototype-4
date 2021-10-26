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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        print("Touched");
    }

    public void OnNewDay()
    {
        if (exposed){
            days_since_exposure += 1;
        }
        if (days_since_exposure >= Constants.days_until_contagous){
            is_contagous = true;
        }
        if (days_since_exposure >= Constants.days_until_symptomatic){
            is_symptomatic = true;
            GetComponent<SpriteRenderer>().color = Colors.symptomatic;
        }
        if (days_since_exposure >= Constants.days_until_would_test_positive){
            would_test_positive = true;
        }

        if (days_since_exposure >= Constants.days_until_can_get_again){
            exposed = false;
            days_since_exposure = 0;
            is_contagous = false;
            is_symptomatic = false;
            GetComponent<SpriteRenderer>().color = Colors.asymptomatic;
            would_test_positive = false;
        }

    }
}
