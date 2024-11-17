using Incantium.Data;
using UnityEditor;
using UnityEngine;

namespace Incantium.Editor.Data
{
    [CustomEditor(typeof(IntegerEventBus))]
    public class IntegerEventBusDrawer : EventBusDrawer<int>
    {
        protected override int DrawParameterField(int current)
        {
            return EditorGUILayout.IntField(GUIContent.none, current);
        }
    }
}