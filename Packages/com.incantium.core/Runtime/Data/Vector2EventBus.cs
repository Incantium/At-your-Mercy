using UnityEngine;

namespace Incantium.Data
{
    /// <summary>
    /// Class for the <see cref="Vector2"/> event bus. Subscribe and invoke <see cref="EventBus{T}.onChange"/> to
    /// connect multiple objects together without a direct dependency.
    /// </summary>
    /// <seealso href="https://github.com/Incantium/Incantium-Core/blob/main/Documentation~/Data/EventBus.md">
    /// EventBus</seealso>
    [CreateAssetMenu(menuName = "Events/Vector2", order = 6)]
    public sealed class Vector2EventBus : EventBus<Vector2> {}
}