using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStep : MonoBehaviour
{
    private AudioSource source;

    [Header("FootStep Source")]
    [SerializeField] private AudioClip[] footStepSound;

    private void Awake()
    {
        source = GetComponent<AudioSource>();   
    }

    private AudioClip GetRandomFootStep()
    {
        return footStepSound[UnityEngine.Random.Range(0,footStepSound.Length)];
    }

    private void Step()
    {
        AudioClip clip = GetRandomFootStep();
        source.PlayOneShot(clip);
    }
}
