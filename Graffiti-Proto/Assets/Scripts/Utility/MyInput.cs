using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyInput : MonoBehaviour
{
    public static bool GetInputDown()
    {
#if UNITY_EDITOR
        return Input.GetMouseButtonDown(0);
#else
        if (Input.touchCount > 0)
            if (Input.GetTouch(0).phase == TouchPhase.Began)
                return true;
        return false;
#endif
    }

    public static bool GetInputUp()
    {
#if UNITY_EDITOR
        return Input.GetMouseButtonUp(0);
#else
        if (Input.touchCount > 0)
            if ((Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled))
                    return true;
        return false;
#endif
    }

    public static bool GetInputHeld()
    {
#if UNITY_EDITOR
        return Input.GetMouseButton(0);
#else
        if (Input.touchCount > 0)
            if (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(0).phase == TouchPhase.Stationary)
                return true;
        return false;
#endif
    }

    public static Vector3 GetInputPoint()
    {
#if UNITY_EDITOR
        return Input.mousePosition;
#else
        return Input.GetTouch(0).position;
#endif
    }
}
