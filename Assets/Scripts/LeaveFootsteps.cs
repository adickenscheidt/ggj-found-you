using System;
using UnityEngine;

public class LeaveFootsteps : MonoBehaviour
{
    public Footstep FootstepPrefab;
    public float footstepDistance = 3f;

    private Victim _victim;
    private Vector3 _lastFootstepPosition;

    private void Start()
    {
        _victim = GetComponent<Victim>();
        _lastFootstepPosition = transform.position;
    }

    private void Update()
    {
        if (!_victim.alive || _victim.hidden)
            return;

        if (CanLeaveNewFootstep())
            LeaveNewFootstep();
    }

    private void LeaveNewFootstep()
    {
        var footstep = Instantiate(FootstepPrefab, transform.position,
            Quaternion.FromToRotation(_lastFootstepPosition, transform.position));
        Destroy(footstep.gameObject, 20f);
        _lastFootstepPosition = transform.position;
    }

    private bool CanLeaveNewFootstep()
    {
        return Vector3.Distance(_lastFootstepPosition, transform.position) > footstepDistance;
    }
}
