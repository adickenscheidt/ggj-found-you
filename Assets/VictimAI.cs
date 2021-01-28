using System;
using UnityEngine;

public enum VictimAIState
{
    Idle,
    Fleeing,
    RunningToHide,
    Hidden,
    Dead
}

public class VictimAI : MonoBehaviour
{
    public float sightRange;
    public float movementSpeed;
    [SerializeField] private VictimAIState currentState = VictimAIState.Fleeing;

    private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("PlayerObject");
    }

    void FixedUpdate()
    {
        switch (currentState)
        {
            case VictimAIState.Idle:
                if (IsPlayerInRange())
                    currentState = VictimAIState.Fleeing;
                break;
            case VictimAIState.Fleeing:
                if (!IsPlayerInRange())
                    currentState = VictimAIState.Idle;
                var awayFromPlayer = (transform.position - _player.transform.position).normalized;
                transform.Translate(awayFromPlayer * (Time.fixedDeltaTime * movementSpeed));
                break;
            case VictimAIState.RunningToHide:
                // When object to hide in is in range, try to run towards it and hide
                break;
            case VictimAIState.Hidden:
                // While inside object
                break;
            case VictimAIState.Dead:
                break;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    private bool IsPlayerInRange()
    {
        return (_player.transform.position - transform.position).magnitude < sightRange;
    }
}
