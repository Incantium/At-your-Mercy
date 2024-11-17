using UnityEngine;

namespace Incantium.Data
{
    /// <summary>
    /// Class for the <see cref="Vector3"/> event bus. Subscribe and invoke <see cref="EventBus{T}.onChange"/> to
    /// connect multiple objects together without a direct dependency.
    /// </summary>
    /// <seealso href="https://github.com/Incantium/Incantium-Core/blob/main/Documentation~/Data/EventBus.md">
    /// EventBus</seealso>
    [CreateAssetMenu(menuName = "Events/Vector3", order = 7)]
    public sealed class Vector3EventBus : EventBus<Vector3> {}
}