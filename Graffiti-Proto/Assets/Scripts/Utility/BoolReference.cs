﻿using System;

[Serializable]
public class BoolReference
{
    public bool UseConstant = true;
    public bool ConstantValue;
    public BoolVariable Variable;

    public BoolReference()
    { }

    public BoolReference(bool value)
    {
        UseConstant = true;
        ConstantValue = value;
    }

    public bool Value
    {
        get { return UseConstant ? ConstantValue : Variable.Value; }
    }

    public static implicit operator bool(BoolReference reference)
    {
        return reference.Value;
    }
}
