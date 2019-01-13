using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An intractable sign the player can read if standing within its trigger.
/// </summary>
public class Sign : MonoBehaviour
{
    [Tooltip("The string(s) of text to display.")]
    public List<string> Messages;

    [Tooltip("The DialogueSystem script to use for displaying text.")]
    public DialogueSystem DialogueSystem;

    private PlayerMovement player;
    private bool playerInRange;
    private int currentMessageIndex = 0;
    private bool HaveMoreMessages => currentMessageIndex < Messages.Count - 1;

    public void Update()
    {
        if (!playerInRange) return;

        if (Input.GetButtonDown("Submit"))
        {
            if (!DialogueSystem.Visible && player.CurrentState == PlayerState.Walking)
            {
                currentMessageIndex = 0;
                DialogueSystem.Show(Messages[currentMessageIndex]);
                player.CurrentState = PlayerState.Interacting;
                player.StopAnimations();
            }
            else if (!DialogueSystem.DonePrintingMessage)
            {
                DialogueSystem.SpeedUp();
            }
            else if (HaveMoreMessages)
            {
                DialogueSystem.Show(Messages[++currentMessageIndex]);
            }
            else
            {
                DialogueSystem.Hide();
                player.CurrentState = PlayerState.Walking;
            }
        }
        else if (Input.GetButtonUp("Submit"))
        {
            DialogueSystem.SlowDown();
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        playerInRange = true;

        if (player != null) return;
        player = other.gameObject.GetComponent<PlayerMovement>();
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        playerInRange = false;
        DialogueSystem.Hide();
    }
}
