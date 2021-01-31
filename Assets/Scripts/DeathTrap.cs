using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrap : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Victim")
        {
            //kill the victim
            Debug.Log("You died by death trap bro!");
        }
    }
}
