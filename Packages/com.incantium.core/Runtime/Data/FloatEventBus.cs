using UnityEngine;

namespace Incantium.Data
{
    /// <summary>
    /// Class for the float event bus. Subscribe and invoke <see cref="EventBus{T}.onChange"/> to connect multiple
    /// objects together without a direct dependency.
    /// </summary>
    /// <seealso href="https://github.com/Incantium/Incantium-Core/blob/main/Documentation~/Data/EventBus.md">
    /// EventBus</seealso>
    [CreateAssetMenu(menuName = "Events/Float", order = 3)]
    public sealed class FloatEventBus : EventBus<float> {}
}