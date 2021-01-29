using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFollowPlayer : MonoBehaviour
{
    [SerializeField]
    Transform playerTransform;

    Vector3 offset = new Vector3(0, 12, 0);

    private void Update()
    {
        transform.position = playerTransform.position + offset;
    }
}
