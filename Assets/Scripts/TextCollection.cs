using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class representing a list of text pieces that can be selected at random.
/// </summary>
[CreateAssetMenu(menuName = "Data/Text Collection")]
internal sealed class TextCollection : ScriptableObject
{
    [SerializeField]
    [Tooltip("The texts to be randomly selected")]
    private List<string> collection = new();

    /// <summary>
    /// Method to get a random piece of text.
    /// </summary>
    /// <returns>A random piece of text.</returns>
    public string Random() => collection[UnityEngine.Random.Range(0, collection.Count)];
}