using Incantium.Data;
using UnityEditor;
using UnityEngine;

namespace Incantium.Editor.Data
{
    [CustomEditor(typeof(Vector2EventBus))]
    public class Vector2EventBusDrawer : EventBusDrawer<Vector2>
    {
        protected override Vector2 DrawParameterField(Vector2 current)
        {
            return EditorGUILayout.Vector2Field(GUIContent.none, current);
        }
    }
}