using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    [Tooltip("A UI image to show/hide underneath the text.")]
    public GameObject UIMessageBox;

    [Tooltip("A UI text element to display the text.")]
    public Text UIText;

    [Tooltip("The string of text to display on the UI.")]
    public string Message;

    private bool playerInRange;

    public void Update()
    {
        if (Input.GetButtonDown("Submit") && playerInRange)
        {
            if (UIMessageBox.activeInHierarchy)
            {
                UIMessageBox.SetActive(false);
            }
            else
            {
                UIMessageBox.SetActive(true);
                UIText.text = Message;
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
        UIMessageBox.SetActive(false);
    }
}
