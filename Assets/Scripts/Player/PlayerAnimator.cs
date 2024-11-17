using Incantium.Attributes;
using UnityEngine;

namespace Player
{
    /// <summary>
    /// Class handling the animations of the player. This class will use an acceleration factor to transition between
    /// animations to smoothly transition in blend trees.
    /// </summary>
    [DisallowMultipleComponent]
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(Animator))]
    internal sealed class PlayerAnimator : MonoBehaviour
    {
        private static readonly int HORIZONTAL = Animator.StringToHash("Horizontal");
        private static readonly int VERTICAL = Animator.StringToHash("Vertical");
        
        [SerializeField]
        [Tooltip("The acceleration of transitioning to other animations.")]
        [Min(0f)]
        private float acceleration;
        
         [SerializeField]
         [AutoReference]
         private CharacterController controller;
        
        [SerializeField]
        [AutoReference]
        private Animator animator;

        /// <summary>
        /// The current velocity of the player as represented by the acceleration of the animator.
        /// </summary>
        private Vector3 currentVelocity;

        /// <summary>
        /// Method to update the horizontal and vertical velocity of the animator with the current velocity of the
        /// player.
        /// </summary>
        private void Update()
        {
            var targetVelocity = transform.InverseTransformDirection(controller.velocity);
            
            currentVelocity = Vector3.Lerp(currentVelocity, targetVelocity, acceleration * Time.deltaTime);
            
            animator.SetFloat(HORIZONTAL, currentVelocity.x);
            animator.SetFloat(VERTICAL, currentVelocity.z);
        }
    }
}