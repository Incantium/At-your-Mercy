using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Incantium.Attributes;
using Incantium.Data;
using Monsters;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// Class handling the spawning of monsters.
/// </summary>
[DisallowMultipleComponent]
internal sealed class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The delay in seconds between the spawning of new monsters.")]
    private float delay;
    
    [SerializeField]
    [Tooltip("A list of monster prefabs.")]
    private List<SpawnRate> prefabs = new();

    [SerializeField] 
    [ReadOnly] 
    internal List<Waypoints> waypoints;

    /// <summary>
    /// Method to spawn a new monster at each path.
    /// </summary>
    private IEnumerator Start()
    {
        var totalWeight = CalculateTotalWeight();
        
        foreach (var waypoint in waypoints)
        {
            var prefab = GetWeightedRandomPrefab(totalWeight);
            
            Spawn(prefab.prefab, waypoint);
            
            yield return new WaitForSeconds(delay);
        }
    }

    /// <summary>
    /// Method to calculate the total weight of all the prefabs.
    /// </summary>
    /// <returns>The total weight.</returns>
    private int CalculateTotalWeight() => prefabs.Sum(prefab => prefab.weight);
    
    /// <summary>
    /// Method to randomly choose a prefab to spawn in, based upon the weights given to each prefab.
    /// </summary>
    /// <param name="totalWeight">The total weight of all the prefabs.</param>
    /// <returns>A randomly chosen monster prefab.</returns>
    private SpawnRate GetWeightedRandomPrefab(int totalWeight)
    { 
        var randomWeight = Random.Range(0, totalWeight);
        
        foreach (var prefab in prefabs)
        {
            if (randomWeight < prefab.weight) return prefab;
            
            randomWeight -= prefab.weight;
        }
        
        return prefabs[0];
    }

    /// <summary>
    /// Method to spawn in a new monster walking on a certain path.
    /// </summary>
    /// <param name="monster">The monster to spawn in.</param>
    /// <param name="path">The path the monster will take.</param>
    private void Spawn(Monster monster, Waypoints path)
    {
        var gameObject = Instantiate(monster, path.points[0], Quaternion.identity);

        gameObject.transform.parent = transform;
        gameObject.path = path;
    }
    
    /// <summary>
    /// Internal class for keeping track of the monster prefabs and their weights.
    /// </summary>
    [Serializable]
    private struct SpawnRate
    {
        public Monster prefab;
        public int weight;
    }
}