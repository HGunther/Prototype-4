using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BackButton : MonoBehaviour
{
    [SerializeField] bool backEnabled = true;
    public GameEvent backButtonPressedEvent;
    public UnityEvent onBackButtonPressed;

    public void EnableBack()
    {
        backEnabled = true;
    }

    public void DisableBack()
    {
        backEnabled = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && backEnabled)
        {
            Press();
        }
    }

    public void Press()
    {
        if (backButtonPressedEvent != null) backButtonPressedEvent.Raise();
        onBackButtonPressed.Invoke();
    }
}
