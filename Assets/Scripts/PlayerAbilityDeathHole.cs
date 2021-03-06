using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityDeathHole : MonoBehaviour
{
    //Object to instantiate
    [SerializeField]
    GameObject deathTrap;

    [SerializeField]
    Transform playerTransform;

    private void Update()
    {
        CreateTrap();
    }

    private void CreateTrap()
    {
        //Hotkey 3 erstellt die deathtrap
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Instantiate(deathTrap, playerTransform.position, Quaternion.identity);
        }
    }
}
