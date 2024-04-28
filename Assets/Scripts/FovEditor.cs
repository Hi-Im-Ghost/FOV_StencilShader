using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(FieldOfView))]
public class FovEditor : Editor
{
    private void OnSceneGUI()
    {
        FieldOfView fov = (FieldOfView)target;

        Handles.color = Color.white;
        Handles.DrawWireArc(fov.transform.position, Vector3.forward, Vector3.up, 360, fov.viewRadius);

        Vector2 viewAngleA = fov.DirFromAngle(-fov.viewAngle / 2, false);
        Vector2 viewAngleB = fov.DirFromAngle(fov.viewAngle / 2, false);


        Handles.DrawLine(fov.transform.position, new Vector2(fov.transform.position.x, fov.transform.position.y) + viewAngleA * fov.viewRadius);

        Handles.DrawLine(fov.transform.position, new Vector2(fov.transform.position.x, fov.transform.position.y) + viewAngleB * fov.viewRadius);

        Handles.color = Color.red;

        foreach (Transform visibleTarget in fov.visibleObjects)
        {
            Handles.DrawLine(fov.transform.position, visibleTarget.position);
        }
    }
}
