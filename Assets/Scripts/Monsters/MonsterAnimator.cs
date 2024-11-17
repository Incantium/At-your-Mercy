using Incantium.Attributes;
using UnityEngine;
using UnityEngine.AI;

namespace Monsters
{
    /// <summary>
    /// Class handling the animations of the monster.
    /// </summary>
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(NavMeshAgent))]
    internal sealed class MonsterAnimator : MonoBehaviour
    {
        private static readonly int SPEED = Animator.StringToHash("Speed");
        
        [SerializeField]
        [AutoReference]
        private Animator animator;

        [SerializeField]
        [AutoReference]
        private NavMeshAgent agent;
        
        /// <summary>
        /// Method to update the speed factor in the <see cref="Animator"/> with the current speed of the
        /// <see cref="NavMeshAgent"/>
        /// </summary>
        private void Update() => animator.SetFloat(SPEED, agent.velocity.magnitude);
    }
}