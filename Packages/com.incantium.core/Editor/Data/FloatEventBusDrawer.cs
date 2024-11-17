using Incantium.Data;
using UnityEditor;
using UnityEngine;

namespace Incantium.Editor.Data
{
    [CustomEditor(typeof(FloatEventBus))]
    public class FloatEventBusDrawer : EventBusDrawer<float>
    {
        protected override float DrawParameterField(float current)
        {
            return EditorGUILayout.FloatField(GUIContent.none, current);
        }
    }
}