using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BoolVariable), editorForChildClasses: true)]
public class BoolVariableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        BoolVariable b = target as BoolVariable;
        GUILayout.Label("Value: " + b.Value.ToString());
    }
}
