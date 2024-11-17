using UnityEngine;

namespace Incantium.Components
{
    /// <summary>
    /// Class for game objects that need to be disabled at start up or as soon as possible.
    /// </summary>
    /// <seealso href="https://github.com/Incantium/Incantium-Core/blob/main/Documentation~/Components/DisableAtStartup.md">
    /// DisableAtStartup</seealso>
    [DisallowMultipleComponent]
    [HelpURL("https://github.com/Incantium/Incantium-Core/blob/main/Documentation~/Components/DisableAtStartup.md")]
    internal sealed class DisableAtStartup : MonoBehaviour
    {
        /// <summary>
        /// Method to disable this game object at start up.
        /// </summary>
        private void Start() => gameObject.SetActive(false);
    }
}