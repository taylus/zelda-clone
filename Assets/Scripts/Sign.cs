using UnityEngine;

/// <summary>
/// An intractable sign the player can read if standing within its trigger.
/// </summary>
public class Sign : MonoBehaviour
{
    [Tooltip("The string of text to display.")]
    public string Message;

    [Tooltip("The DialogueSystem script to use for displaying text.")]
    public DialogueSystem DialogueSystem;

    private bool playerInRange;

    public void Update()
    {
        if (Input.GetButtonDown("Submit") && playerInRange)
        {
            if (DialogueSystem.Visible)
            {
                DialogueSystem.Hide();
            }
            else
            {
                DialogueSystem.Show(Message);
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        playerInRange = true;
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        playerInRange = false;
        DialogueSystem.Hide();
    }
}
