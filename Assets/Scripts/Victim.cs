using UnityEngine;
using UnityEngine.AI;

public class Victim : MonoBehaviour
{
    public float movementSpeed = 15f;
    private NavMeshAgent _navAgent;

    // Start is called before the first frame update
    void Start()
    {
        _navAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetNavTarget(Vector3 target)
    {
        if (_navAgent == null)
            return;
        _navAgent.path = new NavMeshPath();
        // _navAgent.destination = target;
    }
}
