using UnityEngine;
using TMPro; // Import the TextMeshPro namespace
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneTextDisplay : MonoBehaviour
{
    public TMP_Text sceneText; // Reference to the TMP_Text component
    public float displayDuration = 7f; // Duration to display the text

    void Start()
    {
        // Ensure the text is initially invisible
        sceneText.gameObject.SetActive(false);

        // Subscribe to the sceneLoaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDestroy()
    {
        // Unsubscribe from the sceneLoaded event
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Start the coroutine to display the text
        StartCoroutine(DisplayTextForDuration());
    }

    IEnumerator DisplayTextForDuration()
    {
        // Make the text visible
        sceneText.gameObject.SetActive(true);

        // Wait for the specified duration
        yield return new WaitForSeconds(displayDuration);

        // Make the text invisible
        sceneText.gameObject.SetActive(false);
    }
}
