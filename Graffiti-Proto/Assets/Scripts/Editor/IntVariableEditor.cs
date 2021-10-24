using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(IntVariable), editorForChildClasses: true)]
public class IntVariableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        IntVariable i = target as IntVariable;
        GUILayout.Label("Value: " + i.Value.ToString());
    }
}
