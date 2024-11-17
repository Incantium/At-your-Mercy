using System.Collections.Generic;
using Incantium.Attributes;
using Unity.AI.Navigation;
using UnityEngine;

/// <summary>
/// Class for baking a <see cref="NavMeshSurface"/> combined with trees of a <see cref="Terrain"/>.
/// </summary>
[DisallowMultipleComponent]
[RequireComponent(typeof(Terrain))]
[RequireComponent(typeof(NavMeshSurface))]
internal sealed class TreeBaker : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The collider of the tree.")]
    [Required]
    private GameObject treeCollider;
    
    [SerializeField]
    [AutoReference]
    private Terrain terrain;
    
    [SerializeField]
    [AutoReference]
    private NavMeshSurface surface;

    /// <summary>
    /// Temporary list of colliders where the trees are located.
    /// </summary>
    private readonly List<GameObject> colliders = new();
    
    /// <summary>
    /// Method to bake a new <see cref="NavMeshSurface"/> with the trees included in that calculation. This method will
    /// do the following:
    /// <ul>
    ///     <li>Remove the old navmesh data.</li>
    ///     <li>Create new colliders at each position of a tree in the <see cref="Terrain"/>.</li>
    ///     <li>Bake a new navmesh.</li>
    ///     <li>Remove all temporary tree colliders.</li>
    ///     <li>Save the new navmesh data.</li>
    /// </ul>
    /// </summary>
    [Button]
    private void Bake()
    {
        surface.RemoveData();
        
        CreateColliders();
        surface.BuildNavMesh();
        DeleteColliders();
        
        surface.AddData();
    }

    /// <summary>
    /// Method to create the tree colliders at each location of the tree in the <see cref="Terrain"/>.
    /// </summary>
    private void CreateColliders()
    {
        var data = terrain.terrainData;

        foreach (var tree in data.treeInstances)
        {
            var localPosition = tree.position;
            
            var worldPosition = new Vector3(
                localPosition.x * data.size.x,
                localPosition.y * data.size.y,
                localPosition.z * data.size.z
            ) + terrain.transform.position;
            
            var obj = Instantiate(treeCollider, worldPosition, Quaternion.identity, terrain.transform);
            colliders.Add(obj);
        }
    }

    /// <summary>
    /// Method to delete all the temporary tree colliders from the scene.
    /// </summary>
    private void DeleteColliders()
    {
        foreach (var tree in colliders)
        {
            DestroyImmediate(tree);
        }
        
        colliders.Clear();
    }
}