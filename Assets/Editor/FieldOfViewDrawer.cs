using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(FieldOfView))]
    public class FieldOfViewDrawer : UnityEditor.Editor
    {
        private FieldOfView sensor;

        private void OnEnable()
        {
            sensor = target as FieldOfView;
        }

        private void OnSceneGUI()
        {
            Handles.color = sensor.color;
            Handles.DrawWireArc(sensor.transform.position, Vector3.up, Vector3.forward, 360, sensor.radius);

            var left = CreateDirection(sensor.transform.eulerAngles.y, -sensor.angle / 2);
            var right = CreateDirection(sensor.transform.eulerAngles.y, sensor.angle / 2);
            
            Handles.DrawLine(sensor.transform.position, sensor.transform.position + left * sensor.radius);
            Handles.DrawLine(sensor.transform.position, sensor.transform.position + right * sensor.radius);
        }

        private static Vector3 CreateDirection(float eulerY, float angle)
        {
            angle += eulerY;
            
            return new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), 0, Mathf.Cos(angle * Mathf.Deg2Rad));
        }
    }
}