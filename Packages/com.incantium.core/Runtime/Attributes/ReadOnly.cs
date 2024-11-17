using System;
using UnityEngine;

namespace Incantium.Attributes
{
    /// <summary>
    /// Attribute for disabling the editing of a field in the Unity Inspector.
    /// </summary>
    /// <seealso href="https://github.com/Incantium/Incantium-Core/blob/main/Documentation~/Attributes/ReadOnly.md">
    /// ReadOnly</seealso>
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class ReadOnly : PropertyAttribute {}
}