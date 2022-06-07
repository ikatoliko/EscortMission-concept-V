using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(BaseSO), true)]
public class BaseSOCustomEditor : Editor {
    public override void OnInspectorGUI() {
        EditorGUILayout.LabelField("Name of the SO: " + ((BaseSO)target).GetNameOfTheSO());
        
        if(ToggleNameButton(serializedObject.FindProperty("_useCustomName")))
            EditorGUILayout.PropertyField(serializedObject.FindProperty("_customName"));
        
        serializedObject.ApplyModifiedProperties();

        EditorGUILayout.Space();

        base.OnInspectorGUI();
    }

    private bool ToggleNameButton(SerializedProperty serP) {
        if (GUILayout.Button(serP.boolValue ? "Use Default Name" : "Use Custom Name", GUILayout.Width(120))) {
            serP.boolValue = !serP.boolValue;
        }
        return serP.boolValue;
    }
}
