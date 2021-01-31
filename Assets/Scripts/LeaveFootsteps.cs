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
        var direction = (transform.position - _lastFootstepPosition).normalized;
        var rotation = Quaternion.LookRotation(direction);
        var footstep = Instantiate(FootstepPrefab, transform.position, rotation * Quaternion.Euler(90, 0, 180));
        // footstep.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        // footstep.transform.rotation = Quaternion.Euler(footstep.transform.rotation.x, 0, );


        Destroy(footstep.gameObject, 20f);
        _lastFootstepPosition = transform.position;
    }

    private bool CanLeaveNewFootstep()
    {
        return Vector3.Distance(_lastFootstepPosition, transform.position) > footstepDistance;
    }
}
