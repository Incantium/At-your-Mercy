using Incantium.Data;
using UnityEditor;
using UnityEngine;

namespace Incantium.Editor.Data
{
    [CustomEditor(typeof(BooleanEventBus))]
    public class BooleanEventBusDrawer : EventBusDrawer<bool>
    {
        protected override bool DrawParameterField(bool current)
        {
            return EditorGUILayout.Toggle(GUIContent.none, current);
        }
    }
}