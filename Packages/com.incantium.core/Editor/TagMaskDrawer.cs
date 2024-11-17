using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Incantium.Editor
{
    /// <summary>
    /// Class that handles the drawing and updating of the <see cref="TagMask"/>.
    /// </summary>
    [CustomPropertyDrawer(typeof(TagMask))]
    internal sealed class TagMaskDrawer : PropertyDrawer
    {
        private const int TAG_LIMIT = 32;
        
        /// <inheritdoc cref="PropertyDrawer.OnGUI"/>
        /// <summary>
        /// Method to draw and update the <see cref="TagMask"/> with new tags. This method will firstly
        /// convert the current set tags into a bitwise flag, then create a multi-select field, and then convert the new
        /// flags back into usable tags.
        /// </summary>
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (!ValidTagLimit()) return;
            
            var list = property.FindPropertyRelative("tags");
            var flags = TagsToFlags(list);
            
            EditorGUI.BeginChangeCheck();
            flags = EditorGUI.MaskField(position, label, flags, UnityEditorInternal.InternalEditorUtility.tags);
            if (!EditorGUI.EndChangeCheck()) return;
            
            FlagsToTags(list, flags);
        }

        /// <summary>
        /// Method to validate if there are not more tags than an integer bitmask can handle.
        /// </summary>
        /// <returns>True if the amount of tags used in the project doesn't override the <see cref="TAG_LIMIT"/>,
        /// otherwise false.</returns>
        private static bool ValidTagLimit()
        {
            if (UnityEditorInternal.InternalEditorUtility.tags.Length <= TAG_LIMIT) return true;

            EditorGUILayout.HelpBox("The amount of existing tags is too large. TagMask only allows a " +
                                    $"maximum of {TAG_LIMIT} tags to exist.", MessageType.Error);
            
            return false;
        }

        /// <summary>
        /// Method to convert the current list of tags into a bitwise flag.
        /// </summary>
        /// <param name="list">The current list of tags.</param>
        /// <returns>A bitwise flag noting which tags have already been selected.</returns>
        private static int TagsToFlags(SerializedProperty list)
        {
            var flags = 0;
            var tags = UnityEditorInternal.InternalEditorUtility.tags;
            var set = new List<string>();
            
            for (var i = 0; i < list.arraySize; i++)
            {
                set.Add(list.GetArrayElementAtIndex(i).stringValue);
            }
            
            for (var i = 0; i < tags.Length; i++)
            {
                var tag = tags[i];

                if (!set.Contains(tag)) continue;
                
                flags += (int) Math.Pow(2, i);
            }
            
            return flags;
        }

        /// <summary>
        /// Method to convert the bitwise flags back into the list of tags.
        /// </summary>
        /// <param name="list">The list with the tags to be added.</param>
        /// <param name="flags">The flags which tags are set.</param>
        private static void FlagsToTags(SerializedProperty list, int flags)
        {
            var tags = UnityEditorInternal.InternalEditorUtility.tags;
            
            list.ClearArray();
            
            if (flags == 0) return;
            
            for (var i = 0; i < tags.Length; i++)
            {
                if ((flags & (1 << i)) == 0) continue;
                
                list.InsertArrayElementAtIndex(list.arraySize);
                list.GetArrayElementAtIndex(list.arraySize - 1).stringValue = tags[i];
            }
        }
    }
}