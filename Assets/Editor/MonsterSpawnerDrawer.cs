using Incantium.Data;
using UnityEditor;

namespace Editor
{
    [CustomEditor(typeof(MonsterSpawner))]
    public class MonsterSpawnerDrawer : UnityEditor.Editor
    {
        private MonsterSpawner spawner;
        
        private void OnEnable() => spawner = target as MonsterSpawner;

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            spawner.waypoints = Waypoints.set;
        }
    }
}