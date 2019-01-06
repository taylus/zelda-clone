using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Tooltip("The target this camera follows.")]
    public Transform Target;

    [Tooltip("How quickly the camera snaps to its target. 0 = never, 1 = instantly.")]
    public float Smoothing;

    [Tooltip("Area within which the camera should remain.")]
    public Rect Bounds;

    public void LateUpdate()
    {
        if (transform.position != Target.position)
        {
            //keep the camera's z coordinate to prevent it from moving into the 2D plane and showing nothing
            Vector3 targetPosition = new Vector3(Target.position.x, Target.position.y, transform.position.z);
            targetPosition.x = Mathf.Clamp(targetPosition.x, Bounds.xMin, Bounds.xMax);
            targetPosition.y = Mathf.Clamp(targetPosition.y, Bounds.yMin, Bounds.yMax);
            transform.position = Vector3.Lerp(transform.position, targetPosition, Smoothing);
        }
    }
}
