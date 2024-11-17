using UnityEngine;
using UnityEngine.Events;

namespace Incantium.Data 
{
    /// <summary>
    /// Class for the default event bus. Subscribe and invoke <see cref="onChange"/> to connect multiple objects
    /// together without a direct dependency.
    /// </summary>
    /// <seealso href="https://github.com/Incantium/Incantium-Core/blob/main/Documentation~/Data/EventBus.md">
    /// EventBus</seealso>
    [CreateAssetMenu(menuName = "Events/Default", order = 1)]
    public sealed class EventBus : ScriptableObject
    {
        /// <summary>
        /// Event to be subscribed and invoked.
        /// </summary>
        public UnityAction onChange;
    }
    
    /// <summary>
    /// Class for the default typed event bus. Inherit this class to create a custom typed event bus. Subscribe and
    /// invoke <see cref="onChange"/> to connect multiple objects together without a direct dependency.
    /// </summary>
    /// <typeparam name="T">The event bus typing.</typeparam>
    /// <seealso href="https://github.com/Incantium/Incantium-Core/blob/main/Documentation~/Events/EventBus.md">
    /// EventBus</seealso>
    public abstract class EventBus<T> : ScriptableObject
    {
        /// <summary>
        /// Event to be subscribed and invoked.
        /// </summary>
        public UnityAction<T> onChange;
    }
    
    /// <summary>
    /// Class for a dual default typed event bus. Inherit this class to create a custom typed event bus. Subscribe and
    /// invoke <see cref="onChange"/> to connect multiple objects together without a direct dependency.
    /// </summary>
    /// <typeparam name="T1">The first event bus typing.</typeparam>
    /// <typeparam name="T2">The second event bus typing.</typeparam>
    /// <seealso href="https://github.com/Incantium/Incantium-Core/blob/main/Documentation~/Events/EventBus.md">
    /// EventBus</seealso>
    public abstract class EventBus<T1, T2> : ScriptableObject
    {
        /// <summary>
        /// Event to be subscribed and invoked.
        /// </summary>
        public UnityAction<T1, T2> onChange;
    }
    
    /// <summary>
    /// Class for a triple default typed event bus. Inherit this class to create a custom typed event bus. Subscribe and
    /// invoke <see cref="onChange"/> to connect multiple objects together without a direct dependency.
    /// </summary>
    /// <typeparam name="T1">The first event bus typing.</typeparam>
    /// <typeparam name="T2">The second event bus typing.</typeparam>
    /// <typeparam name="T3">The third event bus typing.</typeparam>
    /// <seealso href="https://github.com/Incantium/Incantium-Core/blob/main/Documentation~/Events/EventBus.md">
    /// EventBus</seealso>
    public abstract class EventBus<T1, T2, T3> : ScriptableObject
    {
        /// <summary>
        /// Event to be subscribed and invoked.
        /// </summary>
        public UnityAction<T1, T2, T3> onChange;
    }
}