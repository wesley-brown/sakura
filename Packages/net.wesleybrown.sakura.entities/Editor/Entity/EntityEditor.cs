using UnityEditor;
using UnityEngine;

namespace Sakura.Entities
{
    [CustomEditor(typeof(Entity))]
    public sealed class EntityEditor : Editor
	{
        SerializedProperty forGameObject;
        SerializedProperty forParentOf;

        private void OnEnable()
        {
            forGameObject = serializedObject.FindProperty("forGameObject");
            forParentOf = serializedObject.FindProperty("forParentOf");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            if (forGameObject.objectReferenceValue != null)
            {
                EditorGUILayout.PropertyField(forGameObject);
                GUI.enabled = false;
                EditorGUILayout.PropertyField(forParentOf);
                GUI.enabled = true;
            }
            else if (forParentOf.objectReferenceValue != null)
            {
                GUI.enabled = false;
                EditorGUILayout.PropertyField(forGameObject);
                GUI.enabled = true;
                EditorGUILayout.PropertyField(forParentOf);
            }
            else
            {
                EditorGUILayout.PropertyField(forGameObject);
                EditorGUILayout.PropertyField(forParentOf);
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}
