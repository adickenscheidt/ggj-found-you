using System;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private bool _isInteractable;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    // private void OnDrawGizmos()
    // {
    //     if (_isInteractable)
    //         Gizmos.DrawSphere(transform.position + Vector3.up, 0.5f);
    // }

    public void HightlightAsInteractable(bool highlight)
    {
        _isInteractable = highlight;
        // TODO: Outline ver�ndern oder so
    }
}
