using Incantium.Attributes;
using Incantium.Data;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace Player
{
    /// <summary>
    /// Class representing the implementation when the player is killed by an enemy. This will make the player animate
    /// dying while making it unable to kill it again.
    /// </summary>
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(PlayerInput))]
    internal sealed class PlayerDeath : MonoBehaviour, IKillable
    {
        private static readonly int DEATH = Animator.StringToHash("Death");

        [FormerlySerializedAs("selection")]
        [SerializeField]
        [Tooltip("A random selection of texts to show when the game is over.")]
        [Required]
        private TextCollection collection;

        [SerializeField]
        [Tooltip("True if the player is dead, otherwise false.")]
        [ReadOnly]
        private bool dead;
        
        [Header("Events")]
        [SerializeField]
        [Tooltip("Event to trigger when the game is over.")]
        [Required]
        private StringEventBus gameOver;

        [SerializeField]
        [AutoReference]
        private Animator animator;

        [SerializeField]
        [AutoReference]
        private PlayerInput input;
        
        /// <summary>
        /// Method called when the player presses on the "Die" button. This will instantly kill the player.
        /// </summary>
        private void OnDie() => Kill("Pausing in real life means death in your future.");
        
        /// <summary>
        /// Method called when the player is killed by an external source. This method will do the following:
        /// <ul>
        ///     <li>Select a reason for dying if none is given.</li>
        ///     <li>Disabling enemies from targeting a dead player.</li>
        ///     <li>Disabling player inputs and enabling UI controls.</li>
        ///     <li>Trigger game over screen.</li>
        /// </ul>
        /// </summary>
        /// <param name="reason">The reason why it was killed.</param>
        /// <remarks>This method works only once. Any subsequent calls at a later moment will be ignored.</remarks>
        public void Kill(string reason = null)
        {
            if (dead) return;
            if (string.IsNullOrEmpty(reason)) reason = collection.Random();
            
            animator.SetTrigger(DEATH);
            
            gameObject.tag = "Untagged";
            gameObject.layer = LayerMask.NameToLayer("Default");
            
            input.SwitchCurrentActionMap("UI");
            
            gameOver.onChange.Invoke(reason);
            
            dead = true;
        }
    }
}