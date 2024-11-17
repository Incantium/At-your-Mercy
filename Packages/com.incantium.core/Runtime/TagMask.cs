using System;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

namespace Incantium
{
    /// <summary>
    /// Class representing one or multiple tags set in the editor.
    /// </summary>
    /// <remarks>Due to using an integer bitmask, this class can only handle 32 tags (7 build-in, 25 custom). Any tag
    /// above this limit will make this class unusable.</remarks>
    /// <seealso href="https://github.com/Incantium/Incantium-Core/blob/main/Documentation~/TagMask.md">TagMask</seealso>
    [Serializable]
    public sealed class TagMask
    {
        [SerializeField]
        private string[] tags;
        
        /// <summary>
        /// Method to check if a tag is set in this reference.
        /// </summary>
        /// <param name="tag">The tag to find in this reference.</param>
        /// <returns>True if the tag in this reference, otherwise false.</returns>
        public bool Compare(string tag) => tags.Contains(tag);

        /// <summary>
        /// Method to check if a game object has any of the tags set in this reference.
        /// </summary>
        /// <param name="gameObject">The game object to compare.</param>
        /// <returns>True if any tag in this reference matches the game object's tag, otherwise false.</returns>
        public bool Compare([NotNull] GameObject gameObject) => tags.Any(gameObject.CompareTag);

        public override string ToString()
        {
            if (tags == null || tags.Length == 0) return "No tags assigned.";
            return string.Join(", ", tags);
        }
    }
}