using System.Collections.Generic;
using System.Reflection;
using Incantium.Attributes;
using UnityEditor;
using UnityEngine;

namespace Incantium.Editor.Attributes
{
    /// <summary>
    /// Class for the drawing of a simple button for each method with the <see cref="Button"/> attribute.
    /// </summary>
    /// <remarks>This class uses a custom editor for type Object and everything derived. This clashes with any other
    /// custom editor of this typing. However, this is a general standard to make buttons on buttons visible in the
    /// Unity Editor.</remarks>
    [CanEditMultipleObjects]
    [CustomEditor(typeof(Object), true)]
    internal sealed class ButtonDrawer : UnityEditor.Editor
    {
        /// <summary>
        /// A list of buttons with their names.
        /// </summary>
        private readonly List<(MethodInfo, string)> buttons = new();
        
        /// <summary>
        /// Method to find all buttons in the inspected component and search for any <see cref="Button"/> attribute.
        /// </summary>
        private void OnEnable()
        {
            var methods = target.GetType()
                .GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

            foreach (var method in methods)
            {
                var attribute = method.GetCustomAttribute<Button>();
                
                if (attribute == null) continue;
                
                var name = string.IsNullOrEmpty(attribute.name)
                    ? ObjectNames.NicifyVariableName(method.Name)
                    : attribute.name;

                buttons.Add((method, name));
            }
        }

        /// <summary>
        /// Method to draw the found buttons after the rest has been drawn. If the button has been clicked, the method
        /// attached to that button will be invoked.
        /// </summary>
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            
            foreach (var (method, name) in buttons)
            {
                if (!GUILayout.Button(name)) continue;
                
                method.Invoke(target, null);
            }
        }
    }
}