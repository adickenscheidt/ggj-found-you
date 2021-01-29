using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour {
    [SerializeField] private AudioClip[] footstepsSoundFiles;
    private AudioSource audioSrc;

    private void Start() {
        audioSrc = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Gets called from AnimatorEvent
    /// </summary>
    private void PlayFootstep() {
        audioSrc.PlayOneShot(footstepsSoundFiles[Random.Range(0, footstepsSoundFiles.Length)]);
    }
}
