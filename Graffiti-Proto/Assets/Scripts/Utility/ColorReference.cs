using UnityEngine;
using System;

[Serializable]
public class ColorReference
{
    public bool UseConstant = true;
    public Color ConstantValue;
    public ColorVariable Variable;

    public ColorReference()
    { }

    public ColorReference(Color color)
    {
        UseConstant = true;
        ConstantValue = color;
    }

    public Color Value
    {
        get { return UseConstant ? ConstantValue : Variable.Value; }
    }
}
