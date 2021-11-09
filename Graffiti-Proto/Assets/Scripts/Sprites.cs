using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprites : MonoBehaviour
{
    public Sprite asymptomatic;
    public Sprite symptomatic;
    public Sprite testedPositive;

    // Start is called before the first frame update
    void Awake()
    {
        asymptomatic = Resources.Load<Sprite>("Sprites/CovidNegative_GraffitiArt");
        symptomatic = Resources.Load<Sprite>("Sprites/AsymptomaticCovidPositive_GraffitiArt");
        testedPositive = Resources.Load<Sprite>("Sprites/SymptomaticCovidPositive_GraffitiArt");
    }

    // Update is called once per frame
    void Update()
    {

    }
};