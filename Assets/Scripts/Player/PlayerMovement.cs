using Incantium.Attributes;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    /// <summary>
    /// Class that handles the movement of the player. This class specifically handles the horizontal movement,
    /// sprinting and gravity. For the player rotation, see <see cref="PlayerRotation"/>.
    /// </summary>
    [DisallowMultipleComponent]
    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(CharacterController))]
    internal sealed class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("The walking speed of the player.")]
        [Min(0f)]
        private float walkingSpeed;
        
        [SerializeField]
        [Tooltip("The running speed of the player.")]
        [Min(0f)]
        private float runningSpeed;
        
        [SerializeField]
        [AutoReference]
        private CharacterController controller;

        /// <summary>
        /// The current velocity of the player.
        /// </summary>
        private Vector3 playerVelocity;
        
        /// <summary>
        /// True if the player is running, otherwise false.
        /// </summary>
        private bool isRunning;

        /// <summary>
        /// Method to hide the cursor when starting to play.
        /// </summary>
        private void Start()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        /// <summary>
        /// Method to update the player's position and create a gravity effect.
        /// </summary>
        private void Update()
        {
            if (controller.isGrounded && playerVelocity.y < 0) playerVelocity.y = 0f;

            var movementSpeed = isRunning ? runningSpeed : walkingSpeed;
            playerVelocity.y += Physics.gravity.y * Time.deltaTime;
            
            controller.Move(transform.TransformDirection(playerVelocity) * (Time.deltaTime * movementSpeed));
        }

        /// <summary>
        /// Method called when using the move buttons. This will update the player velocity in the correct direction.
        /// </summary>
        /// <param name="value">The new input values.</param>
        private void OnMove(InputValue value)
        {
            var movement = value.Get<Vector2>();
        
            playerVelocity = new Vector3(movement.x, playerVelocity.y, movement.y);
        }

        /// <summary>
        /// Method called when pressed and release of the sprint button. This will toggle between walking and running
        /// speed.
        /// </summary>
        private void OnSprint() => isRunning = !isRunning;
    }
}