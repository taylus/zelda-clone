using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class RoomTransition : MonoBehaviour
{
    [Tooltip("How much to move the camera when this transition is triggered.")]
    public Vector2 CameraChange;

    [Tooltip("How much to move the player when this transition is triggered.")]
    public Vector2 PlayerChange;

    private CameraMovement cameraMovementScript;

    public void Start()
    {
        cameraMovementScript = Camera.main.GetComponent<CameraMovement>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        other.transform.position += (Vector3)PlayerChange;
        cameraMovementScript.Bounds.position += CameraChange;
    }
}
