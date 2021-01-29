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
    public float runStartRange = 10f;
    public float runStopRange = 20f;
    public float runToHideRange = 15f;

    public float movementSpeed;
    [SerializeField] private VictimAIState currentState = VictimAIState.Fleeing;
    public bool IsHidden => currentState == VictimAIState.Hidden;

    private GameObject _player;
    private HideObject _targetHideObject;

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
                if (IsPlayerInRange(runStartRange))
                    currentState = VictimAIState.Fleeing;
                break;
            case VictimAIState.Fleeing:
                if (!IsPlayerInRange(runStopRange))
                {
                    currentState = VictimAIState.Idle;
                    break;
                }

                if (TryFindObjectToHide(runToHideRange))
                {
                    currentState = VictimAIState.RunningToHide;
                    break;
                }

                FleeFromPlayer();
                break;
            case VictimAIState.RunningToHide:
                if (_targetHideObject == null)
                {
                    currentState = VictimAIState.Fleeing;
                    break;
                }
                else if (HideObjectInRange())
                {
                    HideInHideObject();
                }

                RunTowardsHideObject();
                break;
            case VictimAIState.Hidden:
                // While inside object do nothing (except fear for your life)
                break;
            case VictimAIState.Dead:
                break;
        }
    }

    private void RunTowardsHideObject()
    {
        var transformPosition = _targetHideObject.transform.position - transform.position;
        transformPosition.y = 0;
        transform.Translate(transformPosition.normalized * (Time.fixedDeltaTime * movementSpeed), Space.World);
    }

    private void HideInHideObject()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        currentState = VictimAIState.Hidden;
        _targetHideObject.HideIn(this);
    }

    private bool HideObjectInRange()
    {
        var hideRange = 0.2f;
        return (transform.position - _targetHideObject.transform.position).magnitude < hideRange;
    }

    private void FleeFromPlayer()
    {
        var transformPosition = transform.position - _player.transform.position;
        transformPosition.y = 0;
        var awayFromPlayer = transformPosition.normalized;
        transform.Translate(awayFromPlayer * (Time.fixedDeltaTime * movementSpeed), Space.World);
    }

    private bool TryFindObjectToHide(float hideRange)
    {
        if (_targetHideObject != null)
            return true;
        var hideObjects = new Collider[5];
        var size = Physics.OverlapSphereNonAlloc(transform.position, hideRange, hideObjects);
        foreach (var currHideObject in hideObjects)
        {
            var hideObject = currHideObject?.GetComponent<HideObject>();
            if (hideObject != null)
            {
                _targetHideObject = hideObject;
                return true;
            }
        }

        return false;
    }

    // private void OnDrawGizmosSelected()
    // {
    //     Gizmos.DrawWireSphere(transform.position, runStartRange);
    // }

    private bool IsPlayerInRange(float range)
    {
        return (_player.transform.position - transform.position).magnitude < range;
    }
}
