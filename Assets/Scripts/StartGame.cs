using Incantium;
using UnityEngine;

#if !UNITY_EDITOR
using System.Collections;
using UnityEngine.SceneManagement;
#endif

/// <summary>
/// Class handling the starting of the game in a build.
/// </summary>
[DisallowMultipleComponent]
internal sealed class StartGame : MonoBehaviour
{
    [SerializeField]
    private SceneField overworld;

#if !UNITY_EDITOR
    /// <summary>
    /// Method to load in the overworld scene at startup.
    /// </summary>
    private void Awake()
    {
        StartCoroutine(StartingGame());
        return;

        IEnumerator StartingGame()
        {
            if (overworld.isLoaded) yield break;
        
            var loading = overworld.LoadAsync(LoadSceneMode.Additive);
            if (loading == null) yield break;

            yield return new WaitUntil(() => loading.isDone);

            SceneManager.SetActiveScene(SceneManager.GetSceneByName(overworld));
        }
    }
#endif
}