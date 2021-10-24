using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DelayedInvoke : MonoBehaviour
{
    public FloatReference delay;
    public GameEvent gameEvent;
    public UnityEvent unityEvent;

    public void Invoke()
    {
        StartCoroutine("_Invoke");
    }

    IEnumerator _Invoke()
    {
        yield return new WaitForSeconds(delay);
        if (gameEvent != null) gameEvent.Raise();
        unityEvent.Invoke();
    }
}
