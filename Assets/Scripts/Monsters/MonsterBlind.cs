using System.Collections;
using Incantium.Attributes;
using UnityEngine;
using UnityEngine.AI;

namespace Monsters
{
    /// <summary>
    /// Class representing the "Blind" state of a monster. This class will freeze the monster's movement when it is
    /// blinded. Blinded is not a state in the state machine, as it is a global state with transitions to and from any
    /// other state.
    /// </summary>
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(FieldOfView))]
    internal sealed class MonsterBlind : MonoBehaviour, IBlindable
    {
        [SerializeField]
        [Tooltip("The amount of seconds the monster freezes when blinded.")]
        [Min(0f)]
        private float seconds;
        
        [SerializeField]
        [AutoReference]
        private Animator animator;
        
        [SerializeField]
        [AutoReference]
        private NavMeshAgent agent;

        [SerializeField]
        [AutoReference]
        private FieldOfView sensor;
        
        /// <summary>
        /// Method called when the monster is blinded. This method will freeze the current monster from moving.
        /// </summary>
        public void Blind()
        {
            StopAllCoroutines();
            StartCoroutine(Freeze());
        }

        /// <summary>
        /// Method to freeze the monster for a couple of seconds by stopping the <see cref="Animator"/> and
        /// <see cref="NavMeshAgent"/>. After the time has elapsed, this method will re-enable both.
        /// </summary>
        private IEnumerator Freeze()
        {
            animator.speed = 0f;
            agent.isStopped = true;
            sensor.paused = true;
            
            yield return new WaitForSeconds(seconds);
            
            animator.speed = 1f;
            agent.isStopped = false;
            sensor.paused = false;
        }
    }
}