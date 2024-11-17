using Incantium.Attributes;
using UnityEditor;
using UnityEngine;

namespace Incantium.Editor.Attributes
{
    /// <summary>
    /// Class to draw the property field in the Unity Inspector while keeping it read only.
    /// </summary>
    [CustomPropertyDrawer(typeof(ReadOnly))]
    internal sealed class ReadOnlyDrawer : PropertyDrawer
    {
        /// <summary>
        /// Method to draw the <see cref="ReadOnly"/> field to the Unity Inspector. This will temporarily disable the
        /// <see cref="GUI"/> to draw a field that cannot be edited.
        /// </summary>
        /// <inheritdoc cref="PropertyDrawer.OnGUI"/>
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var state = GUI.enabled;
            
            GUI.enabled = false;
            EditorGUI.PropertyField(position, property, label, true);
            GUI.enabled = state;
        }
    
        /// <summary>
        /// Method to calculate the height of the field, including its children, needed for drawing.
        /// </summary>
        /// <inheritdoc cref="PropertyDrawer.GetPropertyHeight"/>
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property, label, true);
        }
    }
}