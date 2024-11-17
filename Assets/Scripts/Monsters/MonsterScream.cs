using Incantium.Attributes;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

namespace Monsters
{
    /// <summary>
    /// Class representing the "Scream" state of a monster. This class will make the monster scream before going to the
    /// "Chase" state.
    /// </summary>
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(NavMeshAgent))]
    internal sealed class MonsterScream : MonoBehaviour
    {
        private static readonly int SCREAM = Animator.StringToHash("Scream");

        [SerializeField]
        [Tooltip("The audio clip that will be played when the monster is screaming.")]
        [Required]
        private AudioClip scream;
        
        [SerializeField]
        [AutoReference]
        private Animator animator;
        
        [SerializeField]
        [AutoReference]
        private AudioSource source;
        
        [SerializeField]
        [AutoReference]
        private NavMeshAgent agent;

        /// <summary>
        /// Method called when entering the "Scream" state. This method will stop the monster from moving and triggers
        /// the scream animation.
        /// </summary>
        [VisualScript]
        public void OnEnter()
        {
            animator.SetTrigger(SCREAM);
            source.PlayOneShot(scream);
            agent.isStopped = true;
        }
        
        /// <summary>
        /// Method called when completing the scream animation. This will make the monster move again and transition to
        /// the "Chase" state.
        /// </summary>
        public void OnExit()
        {
            agent.isStopped = false;
            CustomEvent.Trigger(gameObject, "Chase");
        }
    }
}