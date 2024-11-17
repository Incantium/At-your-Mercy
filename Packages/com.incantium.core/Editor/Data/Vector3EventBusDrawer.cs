using Incantium.Data;
using UnityEditor;
using UnityEngine;

namespace Incantium.Editor.Data
{
    [CustomEditor(typeof(Vector3EventBus))]
    public class Vector3EventBusDrawer : EventBusDrawer<Vector3>
    {
        protected override Vector3 DrawParameterField(Vector3 current)
        {
            return EditorGUILayout.Vector3Field(GUIContent.none, current);
        }
    }
}