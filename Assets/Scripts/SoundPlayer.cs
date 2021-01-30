using UnityEngine;

public class SoundPlayer : MonoBehaviour {
    [SerializeField] private AudioClip[] soundFiles;
    private AudioSource audioSrc;

    private void Start() {
        audioSrc = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Gets called from AnimatorEvent
    /// </summary>
    private void PlayRandomFromArray() {
        audioSrc.PlayOneShot(soundFiles[Random.Range(0, soundFiles.Length)]);
    }
}
