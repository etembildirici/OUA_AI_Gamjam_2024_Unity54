using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowdownSound : MonoBehaviour
{
    public AudioSource audioSource;  // Reference to the AudioSource component
    public AudioClip musicClip;      // Reference to the AudioClip you want to play

    void Start()
    {
        if (audioSource == null)
        {
            // Try to get the AudioSource component from the same GameObject
            audioSource = GetComponent<AudioSource>();
        }

        // Check if the AudioSource component is assigned
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component is missing from this GameObject.");
        }
    }

    void Update()
    {
        // Check if the 'E' key is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Check if the AudioSource component and the AudioClip are assigned
            if (audioSource != null && musicClip != null)
            {
                // Assign the music clip to the audio source and play it
                audioSource.clip = musicClip;
                audioSource.Play();
            }
            else
            {
                Debug.LogError("AudioSource or AudioClip is not assigned.");
            }
        }
    }
}
