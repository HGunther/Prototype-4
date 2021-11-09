using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventInvoker : MonoBehaviour
{
    public UnityEvent unityEvent;
    
    public void Invoke()
    {
        unityEvent.Invoke();
    }
}
