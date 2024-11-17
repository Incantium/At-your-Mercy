using System.Collections;
using Incantium;
using Incantium.Attributes;
using Incantium.Audio;
using Incantium.Data;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    /// <summary>
    /// Class handling the "Game Over" screen when the player is killed by an enemy.
    /// </summary>
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Animator))]
    internal sealed class GameOver : MonoBehaviour
    {
        private static readonly int FINISHED = Animator.StringToHash("Finished");

        [SerializeField]
        [Tooltip("The scene to reload.")]
        private SceneField overworld;
        
        [SerializeField]
        [Tooltip("The audio clip to play when the game is over.")]
        [Required]
        private MusicClip clip;
        
        [SerializeField]
        [Tooltip("The transition implementation.")]
        [Required]
        private Transitioner transitioner;
        
        [Header("Events")]
        [SerializeField]
        [Tooltip("The event to which a game over is triggered to.")]
        [Required]
        private StringEventBus gameOver;

        [SerializeField]
        [AutoReference]
        private Animator animator;
        
        [SerializeField]
        [AutoReference(Target.Children)]
        private TextMeshProUGUI text;

        /// <summary>
        /// Method to update the initial text to the name of the game.
        /// </summary>
        private void Awake() => text.text = Application.productName;

        /// <summary>
        /// Method to subscribe to the "Game Over" event.
        /// </summary>
        private void OnEnable() => gameOver.onChange += OnGameOver;

        /// <summary>
        /// Method to unsubscribe from the "Game Over" event.
        /// </summary>
        private void OnDisable() => gameOver.onChange -= OnGameOver;

        /// <summary>
        /// Method called when the "Game Over" event is triggered. This method will make the cursor visible again,
        /// play a sound effect, and trigger the "Game Over" animation.
        /// </summary>
        /// <param name="message">The reason how the game has come to an end.</param>
        private void OnGameOver(string message)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            
            text.text = message;
            clip.Play();
            animator.SetBool(FINISHED, true);
        }

        /// <summary>
        /// Method called when the "Restart" button is clicked. This will restart the game from the beginning.
        /// </summary>
        public void RestartGame() => StartCoroutine(Restart());

        /// <summary>
        /// Method to restart the game to the start. This is done in the following steps:
        /// <ul>
        ///     <li>It will make the transition screen fade it.</li>
        ///     <li>After the transition screen has faded in completely, it will unload the current over world scene.
        ///     </li>
        ///     <li>After the overworld scene has completely unloaded, it will load it in again.</li>
        ///     <li>After the overworld scene has loaded in again, it will reset the "Game Over" screen to its initial
        ///     state.</li>
        /// </ul>
        /// </summary>
        private IEnumerator Restart()
        {
            animator.SetBool(FINISHED, false);
            transitioner.FadeIn();
            
            yield return new WaitUntil(() => transitioner.isCompleted);
            
            var unloading = SceneManager.UnloadSceneAsync(overworld);
            if (unloading == null) yield break;

            yield return new WaitUntil(() => unloading.isDone);

            var loading = overworld.LoadAsync(LoadSceneMode.Additive);
            if (loading == null) yield break;

            yield return new WaitUntil(() => loading.isDone);

            SceneManager.SetActiveScene(SceneManager.GetSceneByName(overworld));
            animator.Rebind();
            animator.Update(0f);
            text.text = Application.productName;
            
            transitioner.FadeOut();
        }

        /// <summary>
        /// Method called when the "Exit" button is clicked. This will stop the game.
        /// </summary>
        public void ExitGame() => GameManager.Quit();
    }
}