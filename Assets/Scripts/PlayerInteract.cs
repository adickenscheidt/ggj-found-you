using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public float interactRange = 0.5f;
    private Interactable _currentInteractable;

    void Start()
    {
    }

    void Update()
    {
        if (FindClosestInteractable(out var foundInteractable) && foundInteractable != _currentInteractable)
            SwitchToNewInteractable(foundInteractable);
    }

    private void SwitchToNewInteractable(Interactable foundInteractable)
    {
        if (_currentInteractable != null)
            _currentInteractable.HightlightAsInteractable(false);
        _currentInteractable = foundInteractable;
        if (_currentInteractable != null)
            _currentInteractable.HightlightAsInteractable(true);
    }

    private bool FindClosestInteractable(out Interactable interactable)
    {
        var colliders = new Collider[5];
        Physics.OverlapSphereNonAlloc(transform.position, interactRange, colliders);
        var closestDistance = float.MaxValue;
        Interactable closestInteractable = null;
        foreach (var foundCollider in colliders)
        {
            var foundInteractable = foundCollider?.GetComponent<Interactable>();
            if (foundInteractable == null)
                continue;
            var distanceToInteractable = (foundInteractable.transform.position - transform.position).magnitude;
            if (distanceToInteractable > closestDistance)
                continue;
            closestDistance = distanceToInteractable;
            closestInteractable = foundInteractable;
        }

        interactable = closestInteractable;
        return interactable != null;
    }
}