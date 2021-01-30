using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class VictimDeath : MonoBehaviour
{
    //Can be called from anywhere, destroys the player sprite and instantiates blood splatter on that spot (+sound)

    //Bloodsplatter graphic
    [SerializeField]
    GameObject bloodSplatter;

    //Sound
    [SerializeField]
    private AudioClip[] deathSoundsVictim;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void VictimDies()
    {
        //Instantiates the bloodsplatter prefab
        Instantiate(bloodSplatter, this.transform.position, Quaternion.identity);
        //Play Death sound
        audioSource.PlayOneShot(deathSoundsVictim[Random.Range(0, deathSoundsVictim.Length)]);
        //Play death animation

        //Disables Victim
        this.gameObject.SetActive(false);
    }
}
