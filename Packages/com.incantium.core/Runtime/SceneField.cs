using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace Incantium
{
    /// <summary>
    /// Class representing a reference field for scenes.
    /// </summary>
    /// <seealso href="https://github.com/Incantium/Incantium-Core/blob/main/Documentation~/SceneField.md">
    /// SceneField</seealso>
    [Serializable]
    public sealed class SceneField : ISerializationCallbackReceiver
    {
        /// <summary>
        /// Reference to a scene that is engine-safe.
        /// </summary>
        [SerializeField] 
        private Object scene;

        /// <summary>
        /// The scene name stored internally for referencing.
        /// </summary>
        [field: SerializeField] 
        public string name { get; private set; }
        
        /// <inheritdoc cref="Scene.isLoaded"/>
        public bool isLoaded => SceneManager.GetSceneByName(name).isLoaded;
        
        /// <summary>
        /// Loads the scene asynchronously in the background.
        /// </summary>
        /// <param name="mode">If LoadSceneMode. Single then all current Scenes will be unloaded before loading.</param>
        /// <returns>Use the AsyncOperation to determine if the operation has completed.</returns>
        public AsyncOperation LoadAsync(LoadSceneMode mode = LoadSceneMode.Single) => SceneManager.LoadSceneAsync(name, mode);
       
        /// <summary>
        /// Method to serialize this scene reference. Will update the reference if the scene has changed name.
        /// </summary>
        [Obsolete("This method is only meant for running on build")]
        public void OnBeforeSerialize() => name = scene ? scene.name : null;

        /// <summary>
        /// Method to deserialize this scene reference.
        /// </summary>
        /// <remarks>This method is meant only for running on build.</remarks>
        [Obsolete("This method is only meant for running on build")]
        public void OnAfterDeserialize() {}
        
        /// <summary>
        /// Implicit conversion of a scene reference to its scene name.
        /// </summary>
        /// <param name="scene">The scene reference.</param>
        /// <returns>The scene name.</returns>
        public static implicit operator string(SceneField scene) => scene.name;
    }
}