using Incantium.Attributes;
using Incantium.Audio;
using Monsters;
using UnityEngine;

/// <summary>
/// Class representing the flashlight of the player. This class handles to turn the light on and off and the searching
/// of game objects that can be blinded.
/// </summary>
[DisallowMultipleComponent]
internal sealed class Flashlight : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The layers that the light of this flashlight can interact with.")]
    private LayerMask mask;
    
    [SerializeField]
    [Tooltip("The amount of seconds between subsequent searches for blinding.")]
    [Min(0f)]
    private float repeatRate = 0.2f;
    
    [SerializeField]
    [Tooltip("The audio clip to play when the flashlight is turned on.")]
    [Required]
    private MusicClip on;
    
    [SerializeField]
    [Tooltip("The audio clip to play when the flashlight is turned off.")]
    [Required]
    private MusicClip off;
    
    [SerializeField]
    [AutoReference(Target.Children)]
    private Light lighting;
    
    /// <summary>
    /// Method called when to turn the flashlight on. This method will do the following:
    /// <ul>
    ///     <li>It turns the <see cref="Light"/> on.</li>
    ///     <li>It will play the flashlight on audio clip.</li>
    ///     <li>It will start looking for game objects that can be blinded.</li>
    /// </ul>
    /// </summary>
    public void OnLightOn()
    {
        lighting.enabled = true;
        on.Play();
        
        InvokeRepeating(nameof(Search), 0f, repeatRate);
    }

    /// <summary>
    /// Method called when to turn the flashlight off. This method will do the following:
    /// <ul>
    ///     <li>It turns the <see cref="Light"/> off.</li>
    ///     <li>It will play the flashlight off audio clip.</li>
    ///     <li>It will stop looking for game objects that can be blinded.</li>
    /// </ul>
    /// </summary>
    public void OnLightOff()
    {
        lighting.enabled = false;
        off.Play();
        
        CancelInvoke();
    }

    /// <summary>
    /// Method to search for game objects that can be blinded. This method only works on a game object in the correct
    /// layer <see cref="mask"/> and that has an implementation of the <see cref="IBlindable"/> interface.
    /// </summary>
    private void Search()
    {
        if (!Physics.Raycast(transform.position, transform.right, out var hit, Mathf.Infinity, mask)) return;
        if (!hit.collider.TryGetComponent<IBlindable>(out var target)) return;
        
        target.Blind();
    }
}