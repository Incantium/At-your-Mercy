using Incantium.Data;
using UnityEditor;
using UnityEngine;

namespace Incantium.Editor.Data
{
    [CustomEditor(typeof(Waypoints))]
    public class WaypointsDrawer: UnityEditor.Editor
    {
        private Waypoints waypoints;

        private void OnEnable()
        {
            waypoints = target as Waypoints;
            
            SceneView.duringSceneGui += OnSceneUpdate;
        }
        
        private void OnDisable()
        {
            SceneView.duringSceneGui -= OnSceneUpdate;
        }
        
        private void OnSceneUpdate(SceneView view)
        {
            DrawPath();
            DrawLabels();
        }

        private void DrawPath()
        {
            for (var i = 0; i < waypoints.Count; i++)
            {
                Handles.color = waypoints.configurations.pointColor;
                Handles.DrawWireCube(waypoints[i], Vector3.one * waypoints.configurations.pointSize);
                    
                if (i >= waypoints.Count - 1) continue;
                    
                Handles.color = waypoints.configurations.lineColor;
                Handles.DrawLine(waypoints[i], waypoints[i + 1]);
            }
            
            if (waypoints.type != Waypoints.PathType.Loop || waypoints.Count <= 2) return;
                
            Handles.color = waypoints.configurations.lineColor;
            Handles.DrawLine(waypoints[^1], waypoints[0]);
        }

        private void DrawLabels()
        {
            if (!waypoints.configurations.drawLabels || waypoints.Count <= 0) return;
            
            var style = new GUIStyle
            {
                normal = { textColor = waypoints.configurations.labelColor }
            };
            
            Handles.Label(waypoints[0], "Start", style);

            if (waypoints.Count >= 2 && waypoints.type != Waypoints.PathType.Loop)
            {
                Handles.Label(waypoints[^1], "End", style);
            }
        }
    }
}