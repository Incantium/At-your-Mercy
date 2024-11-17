using Incantium.Attributes;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    /// <summary>
    /// Class handling the enabling and disabling of the player choosing to use the <see cref="Flashlight"/>.
    /// </summary>
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(PlayerInput))]
    internal sealed class PlayerFlash : MonoBehaviour
    {
        private static readonly int FLASH = Animator.StringToHash("Flash");
        
        [SerializeField]
        [Tooltip("The flashlight of the player.")]
        [Required]
        private Flashlight flashlight;
        
        [SerializeField]
        [Tooltip("True if the player is using the flashlight, otherwise false.")]
        [ReadOnly]
        private bool isFlashing;

        [SerializeField]
        [AutoReference]
        private Animator animator;
        
        /// <summary>
        /// Method called when the flash button is pressed. This will toggle between flashlight on or off in the
        /// animator.
        /// </summary>
        private void OnFlash()
        {
            isFlashing = !isFlashing;
            
            animator.SetBool(FLASH, isFlashing);
        }

        /// <summary>
        /// Method called by the grab flashlight animation to turn on the flashlight. This will ask the
        /// <see cref="Flashlight"/>to turn on.
        /// </summary>
        public void OnFlashLightOn() => flashlight.OnLightOn();
        
        /// <summary>
        /// Method called by the put away flashlight animation to turn off the flashlight. This will ask the
        /// <see cref="Flashlight"/> to turn off.
        /// </summary>
        public void OnFlashLightOff() => flashlight.OnLightOff();
    }
}