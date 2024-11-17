using Incantium.Attributes;
using Incantium.Data;
using UnityEngine;

namespace Monsters
{
    /// <summary>
    /// Class for the central information for each monster state.
    /// </summary>
    [DisallowMultipleComponent]
    internal sealed class Monster : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("The game object this monster is targeting.")]
        [ReadOnly] 
        public GameObject target;

        [SerializeField]
        [Tooltip("The path of the monster it will walk.")]
        [ReadOnly]
        public Waypoints path;
    }
}