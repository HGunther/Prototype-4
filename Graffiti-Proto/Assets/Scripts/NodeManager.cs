﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnNewDay(){
        foreach(Transform child in transform){
            child.GetComponent<Node>().OnNewDay();
        }
    }
}
