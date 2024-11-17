using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    /// <summary>
    /// Class handling the rotation of the player around its local y-axis.
    /// </summary>
    [DisallowMultipleComponent]
    [RequireComponent(typeof(PlayerInput))]
    internal sealed class PlayerRotation : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("The rotation speed of the player around the local y-axis.")]
        [Min(0f)]
        private float rotationSpeed;
        
        /// <summary>
        /// Method called when using the look buttons (mouse). This method will update the rotation of the player by
        /// the amount the player has rotated on the screen.
        /// </summary>
        /// <param name="value">The input value of the mouse.</param>
        private void OnLook(InputValue value)
        {
            var rotation = value.Get<Vector2>();
        
            transform.Rotate(new Vector3(0, rotation.x, 0) * rotationSpeed);
        }
    }
}