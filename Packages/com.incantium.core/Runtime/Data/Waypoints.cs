using System;
using System.Collections.Generic;
using UnityEngine;

namespace Incantium.Data
{
    /// <summary>
    /// Class representing a path of points in 3D space. 
    /// </summary>
    /// <seealso href="https://github.com/Incantium/Incantium-Core/blob/main/Documentation~/Data/Waypoints.md">
    /// Waypoints</seealso>
    [CreateAssetMenu(menuName = "Data/Waypoints")]
    public sealed class Waypoints : ScriptableObject
    {
        public static readonly List<Waypoints> set = new();
        
        [Tooltip("The type of path in use.")]
        public PathType type = PathType.Linear;

        [Tooltip("The list of waypoints.")]
        public List<Vector3> points = new();

        [SerializeField]
        [Tooltip("The configurations for visualizing the waypoints.")]
        internal DrawConfigs configurations;

        public int Count => points.Count;
        public Vector3 this[int index] => points[index];

        private void OnEnable()
        {
            if (!set.Contains(this)) set.Add(this);
        }

        private void OnDestroy()
        {
            if (set.Contains(this)) set.Remove(this);
        }

        /// <summary>
        /// Enum for the different types of waypoint paths.
        /// </summary>
        public enum PathType
        {
            /// <summary>
            /// A waypoint path that is one line.
            /// </summary>
            Linear,
        
            /// <summary>
            /// A waypoint path that loops back on itself.
            /// </summary>
            Loop
        }
        
        /// <summary>
        /// Class for the internal configuration how to draw the waypoints.
        /// </summary>
        [Serializable]
        internal sealed class DrawConfigs
        {
            [SerializeField] 
            [Tooltip("Specify to draw start & end labels.")]
            internal bool drawLabels;
            
            [SerializeField]
            [Tooltip("The color of the labels.")]
            internal Color labelColor = Color.white;
        
            [SerializeField]
            [Tooltip("The color of the line in the path.")]
            internal Color lineColor = Color.blue;
            
            [SerializeField]
            [Tooltip("The color of the points in the path.")]
            internal Color pointColor = Color.green;
        
            [SerializeField]
            [Tooltip("The size of the points.")]
            [Min(0)]
            internal float pointSize = 0.5f;
        }
    }
}