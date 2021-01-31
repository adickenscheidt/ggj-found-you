using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictimDeath : MonoBehaviour
{
    //Can be called from anywhere, destroys the player sprite and instantiates blood splatter on that spot (+sound)

    //Bloodsplatter graphic
    [SerializeField] Sprite bloodSplatter;

    //Sound
    [SerializeField] private AudioClip[] deathSoundsVictim;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        this.gameObject.SetActive(true);
    }

    public void VictimDies()
    {
        //Instantiates the bloodsplatter prefab
        // Instantiate(bloodSplatter, this.transform.position, Quaternion.identity);
        var child = transform.GetChild(0);
        child.GetComponent<Animator>().enabled = false;
        child.GetComponent<SpriteRenderer>().sprite = bloodSplatter;
        //Play Death sound
        if (deathSoundsVictim.Length > 0)
            audioSource.PlayOneShot(deathSoundsVictim[Random.Range(0, deathSoundsVictim.Length)]);
        //Disables Victim AI
        GetComponentInChildren<AIController>()?.gameObject.SetActive(false);
    }
}
