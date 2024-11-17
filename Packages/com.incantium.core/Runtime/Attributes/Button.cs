using System;
using JetBrains.Annotations;

namespace Incantium.Attributes
{
    /// <summary>
    /// Attribute to create a simple button at the bottom of the Unity Inspector component view.
    /// </summary>
    /// <seealso href="https://github.com/Incantium/Incantium-Core/blob/main/Documentation~/Attributes/Button.md">
    /// Button</seealso>
    [MeansImplicitUse]
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class Button : Attribute
    {
        /// <summary>
        /// A custom name for the simple button.
        /// </summary>
        public string name { get; set; }
    }
}