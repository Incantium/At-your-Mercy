#if UNITY_EDITOR
using UnityEditor;
#else
using UnityEngine;
#endif

/// <summary>
/// Class handling the basic functions within a game.
/// </summary>
public static class GameManager
{
    /// <summary>
    /// Method to stop the game from playing. This works in two different ways:
    /// <ul>
    ///     <li>If the current game is a build, it will close the game.</li>
    ///     <li>If the current game is the Unity Editor, it will stop the play modes.</li>
    /// </ul>
    /// </summary>
    public static void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}