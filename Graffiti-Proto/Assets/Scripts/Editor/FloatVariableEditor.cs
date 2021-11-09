using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FloatVariable), editorForChildClasses: true)]
public class FloatVariableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        FloatVariable f = target as FloatVariable;
        GUILayout.Label("Value: " + f.Value.ToString());
    }
}
