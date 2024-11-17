using System;
using JetBrains.Annotations;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Incantium.Attributes
{
    /// <summary>
    /// Attribute to auto reference a component attached to the same or a close family member of the current game
    /// object.
    /// </summary>
    /// <seealso href="https://github.com/Incantium/Incantium-Core/blob/main/Documentation~/Attributes/AutoReference.md">
    /// AutoReference</seealso>
    [BaseTypeRequired(typeof(Object))]
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class AutoReference : PropertyAttribute
    {
        /// <summary>
        /// The target where the component that needs to be automatically reference is situated.
        /// </summary>
        internal Target target { get; private set; }

        /// <summary>
        /// Constructor to create a new automatic reference attribute.
        /// </summary>
        /// <param name="target">The target where the component that needs to be automatically reference is situated.
        /// </param>
        public AutoReference(Target target = Target.Current) => this.target = target;
    }
    
    public enum Target {
        /// <summary>
        /// Auto reference the component on the current game object.
        /// </summary>
        Current,
        
        /// <summary>
        /// Auto reference the component on a child of the current game object.
        /// </summary>
        Children,
        
        /// <summary>
        /// Auto reference the component on the parent of the current game object.
        /// </summary>
        Parent
    }
}