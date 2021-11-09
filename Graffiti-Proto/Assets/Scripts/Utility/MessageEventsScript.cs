using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MessageEventsScript : MonoBehaviour
{
    public GameEvent awakeEvent, startEvent;
    public UnityEvent onAwakeEvent, onStartEvent;

    void Awake()
    {
        if(awakeEvent != null)
            awakeEvent.Raise();
        onAwakeEvent.Invoke();
    }

    void Start()
    {
        if(startEvent != null)
            startEvent.Raise();
        onStartEvent.Invoke();
    }
}
