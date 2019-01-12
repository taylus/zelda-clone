using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages the game's message/dialogue system so that individual scripts for
/// things like signs, NPCs, etc don't have to concern themselves with UI elements.
/// </summary>
[RequireComponent(typeof(Text), typeof(AudioSource))]
public class DialogueSystem : MonoBehaviour
{
    //the UI text component this script should be placed on
    private Text textComponent;

    //attached AudioSource for playing sound effects
    private AudioSource audioSource;

    [Tooltip("A UI image component to show/hide underneath the text.")]
    public GameObject MessageBoxImageComponent;

    //[Tooltip("The page(s) of text currently being displayed.")]
    //public List<string> Messages;

    [Tooltip("How long to wait in between displaying individual characters.")]
    public float SecondsBetweenCharacters = 0.1f;

    [Tooltip("Sound to play when each character of the message is displayed.")]
    public AudioClip CharacterShownSound;

    [Tooltip("Sound to play when the entire message is displayed.")]
    public AudioClip MessageCompleteSound;

    public bool Visible => MessageBoxImageComponent.activeInHierarchy;

    public void Awake()
    {
        textComponent = GetComponent<Text>();
        textComponent.text = "";
        audioSource = GetComponent<AudioSource>();
    }

    public void Show(string stringToDisplay)
    {
        MessageBoxImageComponent.SetActive(true);
        StartCoroutine(DisplayCharacters(UnescapeNewlines(stringToDisplay)));
    }

    public void Hide()
    {
        MessageBoxImageComponent.SetActive(false);
    }

    /// <summary>
    /// Progresses through the given string, displaying each successive character
    /// one at a time with a delay in between.
    /// </summary>
    private IEnumerator DisplayCharacters(string stringToDisplay)
    {
        textComponent.text = "";
        foreach (char c in stringToDisplay)
        {
            if (!char.IsWhiteSpace(c))
            {
                PlaySound(CharacterShownSound);
            }
            textComponent.text += c;
            yield return new WaitForSeconds(SecondsBetweenCharacters);
        }
        PlaySound(MessageCompleteSound);
    }

    /// <summary>
    /// Plays the given audio clip using the attached audio source.
    /// </summary>
    private void PlaySound(AudioClip sound)
    {
        if (sound == null) return;
        audioSource.clip = sound;
        audioSource.Play();
    }

    /// <summary>
    /// Convert newlines from Unity's inspector into actual newlines that
    /// will cause the UI text component to line wrap.
    /// </summary>
    private static string UnescapeNewlines(string s)
    {
        return s.Replace("\\n", "\n");
    }
}
