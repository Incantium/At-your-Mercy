using System;
using Incantium.Attributes;
using UnityEditor;
using UnityEngine;

namespace Incantium.Editor.Attributes
{
    /// <summary>
    /// Class for a custom inspector for every field that is auto referenced. This class handles the drawing of an
    /// warning when the auto referencing has failed. Otherwise, it will not display a property field.
    /// </summary>
    [CustomPropertyDrawer(typeof(AutoReference))]
    internal sealed class AutoReferenceDrawer : PropertyDrawer
    {
        /// <summary>
        /// The height of the error message in the Unity Inspector.
        /// </summary>
        private const int HEIGHT = 30;
        
        /// <inheritdoc cref="PropertyDrawer.OnGUI"/>
        /// <summary>
        /// Searches for a component required by its auto reference if applicable. When not found, it will create an
        /// error box with an error message.
        /// </summary>
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (!typeof(Component).IsAssignableFrom(fieldInfo.FieldType))
            {
                EditorGUI.HelpBox(position, "Auto referencing is only applicable to component derived objects.", MessageType.Warning);
                return;
            }
            
            if (IsAlreadySet(property) || attribute is not AutoReference reference) return;

            var gameObject = property.serializedObject.targetObject as Component;
            var component = GetComponent(gameObject, reference.target);

            if (component)
            {
                property.objectReferenceValue = component;
            }
            else
            {
                EditorGUI.HelpBox(position, $"Unable to locate missing '{fieldInfo.FieldType}' for auto referencing at the {GenerateMessage(reference.target)}.", MessageType.Error);
            }
        }

        /// <inheritdoc cref="PropertyDrawer.GetPropertyHeight"/>
        /// <summary>
        /// Calculates the height requires. If there is an error, it will display it. Otherwise, it will remove the
        /// entire property field.
        /// </summary>
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return !typeof(Component).IsAssignableFrom(fieldInfo.FieldType) || !IsAlreadySet(property) ? HEIGHT : 0f;
        }

        /// <summary>
        /// Checks if there is already an object referenced to the field with the auto reference attribute.
        /// </summary>
        /// <param name="property">The property of the auto reference.</param>
        /// <returns>True if it already holds a reference, otherwise false.</returns>
        private static bool IsAlreadySet(SerializedProperty property) => property.objectReferenceValue != null;

        /// <summary>
        /// Get the required component from the game object.
        /// </summary>
        /// <param name="gameObject">The game object at which to seek the required component.</param>
        /// <param name="target">The location at which to seek the required component.</param>
        /// <returns>The required component or null if not found.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the given target is not valid.</exception>
        private Component GetComponent(Component gameObject, Target target) => target switch
        {
            Target.Current => gameObject.GetComponent(fieldInfo.FieldType),
            Target.Children => gameObject.GetComponentInChildren(fieldInfo.FieldType),
            Target.Parent => gameObject.GetComponentInParent(fieldInfo.FieldType),
            _ => throw new System.ArgumentOutOfRangeException(nameof(target), target, null)
        };

        private string GenerateMessage(Target target) => target switch
        {
            Target.Current => "current game object",
            Target.Children => "children game objects",
            Target.Parent => "parent game object",
            _ => throw new ArgumentOutOfRangeException(nameof(target), target, null)
        };
    }
}