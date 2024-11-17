using UnityEngine;

namespace Incantium.Data
{
    /// <summary>
    /// Class for the integer event bus. Subscribe and invoke <see cref="EventBus{T}.onChange"/> to connect multiple
    /// objects together without a direct dependency.
    /// </summary>
    /// <seealso href="https://github.com/Incantium/Incantium-Core/blob/main/Documentation~/Data/EventBus.md">
    /// EventBus</seealso>
    [CreateAssetMenu(menuName = "Events/Integer", order = 2)]
    public sealed class IntegerEventBus : EventBus<int> {}
}