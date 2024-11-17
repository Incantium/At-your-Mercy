using Incantium.Data;
using UnityEditor;
using UnityEngine;

namespace Incantium.Editor.Data
{
    [CustomEditor(typeof(StringEventBus))]
    public class StringEventBusDrawer : EventBusDrawer<string>
    {
        protected override string DrawParameterField(string current)
        {
            return EditorGUILayout.TextField(GUIContent.none, current);
        }
    }
}