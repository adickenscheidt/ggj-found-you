using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public float interactRange = 2f;
    private BaseInteractable _currentBaseInteractable;

    void Start()
    {
    }

    void Update()
    {
        if (FindClosestInteractable(out var foundInteractable))
        {
            if(foundInteractable != _currentBaseInteractable)
                SwitchToNewInteractable(foundInteractable);
        }
        else
        {
            if(_currentBaseInteractable != null)
                SwitchToNewInteractable(null);
                
        }

        if (Input.GetKeyDown(KeyCode.Space) && _currentBaseInteractable != null)
        {
            _currentBaseInteractable.Interact();
        }
    }

    private void SwitchToNewInteractable(BaseInteractable foundBaseInteractable)
    {
        if (_currentBaseInteractable != null)
            _currentBaseInteractable.HightlightAsInteractable(false);
        _currentBaseInteractable = foundBaseInteractable;
        if (_currentBaseInteractable != null)
            _currentBaseInteractable.HightlightAsInteractable(true);
    }

    private bool FindClosestInteractable(out BaseInteractable baseInteractable)
    {
        var colliders = new Collider[10];
        var count = Physics.OverlapSphereNonAlloc(transform.position, interactRange, colliders);
        var closestDistance = float.MaxValue;
        BaseInteractable closestBaseInteractable = null;
        foreach (var foundCollider in colliders)
        {
            var foundInteractable = foundCollider?.GetComponent<BaseInteractable>();
            if (foundInteractable == null || !foundInteractable.IsActive)
                continue;
            var distanceToInteractable = (foundInteractable.transform.position - transform.position).magnitude;
            if (distanceToInteractable > closestDistance)
                continue;
            closestDistance = distanceToInteractable;
            closestBaseInteractable = foundInteractable;
        }

        baseInteractable = closestBaseInteractable;
        return baseInteractable != null;
    }
}
