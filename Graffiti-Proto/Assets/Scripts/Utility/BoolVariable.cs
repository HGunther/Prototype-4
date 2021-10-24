using UnityEngine;

[CreateAssetMenu]
public class BoolVariable : ScriptableObject
{
#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif

    public bool assignInitialValue = false;
    public bool initValue;

    void OnEnable()
    {
        if (assignInitialValue) SetValue(initValue);
    }

    public bool Value { get; private set; }

    public void SetValue(bool value)
    {
        Value = value;
    }

    public void SetValue(BoolVariable value)
    {
        Value = value.Value;
    }
}
