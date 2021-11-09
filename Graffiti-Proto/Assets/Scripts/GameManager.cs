using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameState GS;

    // Start is called before the first frame update
    void Start()
    {
        GS.CreateEdges();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewDay()
    {
        Debug.Log("Starting new day");
        foreach(Node node in GS.nodes.Values)
        {
            node.NewDay();
        }
    }
}
