using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeSeperator : MonoBehaviour
{
    bool isCutting = false;
    Rigidbody2D nodeSeperatorRigidBody;
    public GameObject seperatorTrailPrefab;
    GameObject currentSeperatorTrail;
    List<GameObject> connectionsToDelete = new List<GameObject>();


    private void Start()
    {
        nodeSeperatorRigidBody = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //print(connectionsToDelete.Count);
        if(Input.GetMouseButtonDown(0))
        {
            StartCutting();
        }
        else if(Input.GetMouseButtonUp(0))
        {
            StopCutting();
        }

        if(isCutting)
        {
            nodeSeperatorRigidBody.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    void StartCutting()
    {
        isCutting = true;
        currentSeperatorTrail=Instantiate(seperatorTrailPrefab,transform);
    }

    void StopCutting()
    {
        isCutting = false;
        currentSeperatorTrail.transform.parent = null;
        Destroy(currentSeperatorTrail, 0.2f);
        RemoveConnections();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Connection")
        {
            connectionsToDelete.Add(collision.gameObject);
        }
    }

    void RemoveConnections()
    {
        if(connectionsToDelete.Count>0)
        {
            for(int i=0;i<connectionsToDelete.Count;i++)
            {
                Destroy(connectionsToDelete[i]);
            }
            connectionsToDelete.Clear();
        }    
    }
}
