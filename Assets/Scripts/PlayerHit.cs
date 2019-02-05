using UnityEngine;

/// <summary>
/// Attached to the player's sword hitboxes to register hits.
/// </summary>
public class PlayerHit : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Breakable"))
        {
            other.GetComponent<Breakable>().Break();
        }
    }
}
