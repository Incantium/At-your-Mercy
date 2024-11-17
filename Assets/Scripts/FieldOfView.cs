using System;
using Incantium.Attributes;
using UnityEngine;

/// <summary>
/// Class representing a field of view area in the game. This class handles the complex system to efficiently look for
/// new targets in its field of view without slowing down the game.
/// </summary>
/// <seealso cref="StartSearching"/>
[DisallowMultipleComponent]
internal sealed class FieldOfView : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The maximum radius from the game object to look for targets.")]
    [Min(0f)]
    public float radius = 10f;
            
    [SerializeField]
    [Tooltip("The angle at which the game object will search for targets.")]
    [Range(0f, 360f)]
    public float angle = 30f;

    [SerializeField]
    [Tooltip("The maximum amount of found targets to validate for active use.")]
    [Range(1, 25)]
    private int maxSearches = 5;
            
    [SerializeField]
    [Tooltip("The amount of seconds between subsequent searches for a target.")]
    [Min(0f)]
    private float repeatRate = 0.2f;
            
    [SerializeField]
    [Tooltip("The layers at which the targets need to be searched.")]
    private LayerMask targetMask;
            
    [SerializeField]
    [Tooltip("The layers which needs to be removed from calculation.")]
    private LayerMask obstacleMask;
    
    [Header("Internal")]
    [SerializeField]
    [Tooltip("True if the searching should be done continuously, otherwise false for one target search.")]
    [ReadOnly]
    private bool repeating;
    
    [Tooltip("True if the searching is temporarily paused, otherwise false.")]
    [ReadOnly]
    public bool paused;
    
    [Header("Editor")]
    [SerializeField]
    [Tooltip("The color of the field of view gizmo.")]
    internal Color color = Color.red;
    
    /// <summary>
    /// The current colliders found at its search.
    /// </summary>
    private Collider[] results;
    
    /// <summary>
    /// Event triggered when a new target game object has been found in the field of view.
    /// </summary>
    public event Action<GameObject> onTargetFound;

    /// <summary>
    /// Method called at initialization to create a new list of the maximum amount of colliders.
    /// </summary>
    private void Start() => results = new Collider[maxSearches];
    
    /// <summary>
    /// Method to stop the field of view search when the game object is disabled.
    /// </summary>
    private void OnDisable() => StopSearching();

    /// <summary>
    /// Method to start the search for new targets in the field of view.
    /// </summary>
    /// <param name="repeating">True if the searching should be done continuously, otherwise false for one target
    /// search.</param>
    /// <seealso cref="StopSearching"/>
    public void StartSearching(bool repeating)
    {
        this.repeating = repeating;
        InvokeRepeating(nameof(Search), repeatRate, repeatRate);
    }

    /// <summary>
    /// Method to stop the search for new targets in the field of view.
    /// </summary>
    /// <seealso cref="StartSearching"/>
    public void StopSearching() => CancelInvoke();

    /// <summary>
    /// Method to search for new game object targets. This method works in the following steps:
    /// <ul>
    ///     <li>Firstly, it searches for all game objects with a collider in its <see cref="radius"/> of influence with
    ///     the correct <see cref="targetMask"/>.</li>
    ///     <li>Next, it will look for each found game object if it is within its angle of field.</li>
    ///     <li>Further, it will check for immediate visibility with a raycast, including any in the
    ///     <see cref="obstacleMask"/>.</li>
    /// </ul>
    /// </summary>
    private void Search()
    {
        if (paused) return;
        
        var size = Physics.OverlapSphereNonAlloc(transform.position, radius, results, targetMask);
        
        if (size == 0) return;
        
        foreach (var result in results)
        {
            if (result == null) break;

            var target = result.transform;
            var targetDirection = (target.position - transform.position).normalized;
            
            if (Vector3.Angle(transform.forward, targetDirection) > angle / 2) continue;
            
            var targetDistance = Vector3.Distance(transform.position, target.position);
            
            if (Physics.Raycast(transform.position, targetDirection, targetDistance, obstacleMask)) continue;
            
            onTargetFound?.Invoke(target.gameObject);
            
            if (!repeating) StopSearching();
            
            return;
        }
    }
}