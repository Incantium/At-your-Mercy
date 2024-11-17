using Incantium.Attributes;
using UnityEngine;

namespace UI
{
    /// <summary>
    /// Class representing a simple fade in/out transition.
    /// </summary>
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Animator))]
    internal sealed class Transitioner : MonoBehaviour
    {
        private static readonly int TRANSITION = Animator.StringToHash("Transition");

        /// <summary>
        /// True if the transition has completed fading in or out, otherwise false.
        /// </summary>
        [HideInInspector]
        public bool isCompleted;

        [SerializeField]
        [AutoReference]
        private Animator animator;

        /// <summary>
        /// Method to fade in the transition screen.
        /// </summary>
        public void FadeIn()
        {
            isCompleted = false;
            animator.SetBool(TRANSITION, true);
        }

        /// <summary>
        /// Method to fade out the transition screen.
        /// </summary>
        public void FadeOut()
        {
            isCompleted = false;
            animator.SetBool(TRANSITION, false);
        }

        /// <summary>
        /// Method called when the fading in or out has been completed.
        /// </summary>
        public void Completed() => isCompleted = true;
    }
}