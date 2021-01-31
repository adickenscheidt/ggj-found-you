using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFollowPlayer : MonoBehaviour
{
    [SerializeField]
    Transform playerTransform;

    //Offset vector of the Lamp towards the player
    Vector3 offset = new Vector3(0, 12, 0);

    private void Update()
    {
        //makes the lamp follow the player
        transform.position = playerTransform.position + offset;
    }
}
