using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages the game's message/dialogue system so that individual scripts for
/// things like signs, NPCs, etc don't have to concern themselves with UI elements.
/// </summary>
[RequireComponent(typeof(Text))]
public class DialogueSystem : MonoBehaviour
{
    //the UI text component this script should be placed on
    private Text TextComponent;

    [Tooltip("A UI image component to show/hide underneath the text.")]
    public GameObject MessageBoxImageComponent;

    //[Tooltip("The page(s) of text currently being displayed.")]
    //public List<string> Messages;

    [Tooltip("How long to wait in between displaying individual characters.")]
    public float SecondsBetweenCharacters = 0.1f;

    public bool Visible => MessageBoxImageComponent.activeInHierarchy;

    public void Awake()
    {
        TextComponent = GetComponent<Text>();
        TextComponent.text = "";
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
        TextComponent.text = "";
        for (int i = 0; i < stringToDisplay.Length; i++)
        {
            TextComponent.text += stringToDisplay[i];
            yield return new WaitForSeconds(SecondsBetweenCharacters);
            //TODO: play "single letter displayed" sound
        }
        //TODO: play "page of text complete" sound
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
