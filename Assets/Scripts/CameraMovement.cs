using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform Target;
    public float Smoothing;
    public Vector2 MinPosition;
    public Vector2 MaxPosition;

    public void LateUpdate()
    {
        if (transform.position != Target.position)
        {
            //keep the camera's z coordinate to prevent it from moving into the 2D plane and showing nothing
            Vector3 targetPosition = new Vector3(Target.position.x, Target.position.y, transform.position.z);
            targetPosition.x = Mathf.Clamp(targetPosition.x, MinPosition.x, MaxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, MinPosition.y, MaxPosition.y);
            transform.position = Vector3.Lerp(transform.position, targetPosition, Smoothing);
        }
    }
}
