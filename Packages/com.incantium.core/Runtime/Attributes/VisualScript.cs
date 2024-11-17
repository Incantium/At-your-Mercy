using System;
using JetBrains.Annotations;
using UnityEngine.Scripting;

namespace Incantium.Attributes
{
    /// <summary>
    /// Attribute for methods used by Unity's Visual Scripting. This attribute will preserve the code from being striped.
    /// </summary>
    /// <seealso href="https://github.com/Incantium/Incantium-Core/blob/main/Documentation~/Attributes/VisualScript.md">
    /// VisualScript</seealso>
    [MeansImplicitUse]
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class VisualScript : PreserveAttribute {}
}