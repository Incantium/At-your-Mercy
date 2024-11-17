using System.Collections;
using UnityEngine;

namespace Incantium.Components
{
    /// <summary>
    /// Class to automatically destroy the current game object after a couple of seconds.
    /// </summary>
    /// <seealso href="https://github.com/Incantium/Incantium-Core/blob/main/Documentation~/Components/DestroyOnTime.md">
    /// DestroyOnTime</seealso>
    [DisallowMultipleComponent]
    [HelpURL("https://github.com/Incantium/Incantium-Core/blob/main/Documentation~/Components/DestroyOnTime.md")]
    internal sealed class DestroyOnTime : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("The amount of seconds before this game object is automatically destroyed.")]
        [Min(0f)]
        private float seconds;
        
        /// <summary>
        /// Method called at initialization. This method will destroy the current game object after the allotted
        /// seconds have expired.
        /// </summary>
        private IEnumerator Start()
        {
            yield return new WaitForSeconds(seconds);
            
            Destroy(gameObject);
        }
    }
}