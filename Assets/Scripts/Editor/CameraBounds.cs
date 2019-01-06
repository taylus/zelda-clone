using UnityEngine;
using UnityEditor;

/// <summary>
/// This script draws a <see cref="CameraMovement.Bounds"/> rect in the scene view
/// when the camera is selected in the Unity editor. This helps visualize where
/// the camera can and cannot go during gameplay.
/// </summary>
[CustomEditor(typeof(CameraMovement))]
public class CameraBounds : Editor
{
    public void OnSceneGUI()
    {
        var script = target as CameraMovement;
        var camera = script.gameObject.GetComponent<Camera>();
        if (camera == null || !camera.orthographic) return;

        float cameraHeight = camera.orthographicSize * 2;
        float cameraWidth = cameraHeight * camera.aspect;

        var bounds = new Rect(
            x: script.Bounds.xMin - (cameraWidth / 2), 
            y: script.Bounds.yMin - (cameraHeight / 2),
            width: script.Bounds.width + cameraWidth,
            height: script.Bounds.height + cameraHeight);
        Handles.DrawSolidRectangleWithOutline(bounds, Color.clear, Color.green);
    }
}
