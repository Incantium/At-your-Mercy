using UnityEngine;

/// <summary>
/// Class handling the poisonous ocean. This game object will kill any game object that is killable when touching it.
/// </summary>
[DisallowMultipleComponent]
[RequireComponent(typeof(Collider))]
public class EvilOcean : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The message to show when a player takes a dive.")]
    [TextArea]
    private string message;
    
    /// <summary>
    /// Method called when a game object collides with the ocean. This will kill the game object instantly if it is
    /// possible.
    /// </summary>
    /// <param name="other">The game object colliding with the ocean.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent<IKillable>(out var killable)) return;
        
        killable.Kill(message);
    }
}