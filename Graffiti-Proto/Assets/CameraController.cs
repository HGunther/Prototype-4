using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] SpriteRenderer background;
    Vector3 initialTouchPos;
    Vector2 maxPos;
    Vector2 minPos;
    void Start()
    {
        float cameraHeight = 2f * mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * mainCamera.aspect;
        maxPos = new Vector2(background.bounds.max.x-cameraWidth/2,background.bounds.max.y - cameraHeight/2);
        minPos = new Vector2(background.bounds.min.x+cameraWidth/2,background.bounds.min.y+cameraHeight/2);
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            initialTouchPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        }
        if(Input.GetMouseButton(0))
        {
            Vector3 direction = initialTouchPos - mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mainCamera.transform.position += direction*15f*Time.deltaTime;
            mainCamera.transform.position = new Vector3(Mathf.Clamp(mainCamera.transform.position.x,minPos.x,maxPos.x),Mathf.Clamp(mainCamera.transform.position.y,minPos.y,maxPos.y),mainCamera.transform.position.z);
        }
       
    }
}
