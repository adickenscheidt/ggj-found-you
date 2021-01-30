using UnityEngine;
using UnityEngine.AI;

public enum AIState
{
    Inactive,
    Running,
    Finished
}

public enum FinishMode
{
    PointReached,
    TimePassed,
    Manual
}

public abstract class BaseAIComponent : MonoBehaviour
{
    public abstract string AiName { get; }
    public abstract FinishMode FinishMode { get; }
    public virtual float FinishTime => 1f;

    public AIState currentState = AIState.Inactive;
    protected GameObject player;
    protected Victim victim;
    protected NavMeshAgent navMeshAgent;
    protected float finishTime;

    public abstract int GetAiValue(string currentAiName);

    public virtual void StartAi()
    {
        currentState = AIState.Running;
        finishTime = Time.time + FinishTime;
    }

    public virtual void StopAi()
    {
        currentState = AIState.Inactive;
    }

    public virtual void Finish()
    {
        currentState = AIState.Finished;
    }

    public virtual void Start()
    {
        player = GameObject.Find("PlayerObject");
        victim = GetComponentInParent<Victim>();
        navMeshAgent = GetComponentInParent<NavMeshAgent>();
    }

    public void Update()
    {
        if (currentState != AIState.Running)
            return;
        AIUpdate();
        if (FinishMode == FinishMode.PointReached && HasReachedWalkDestination())
            Finish();
        else if (FinishMode == FinishMode.TimePassed && TimePassedToFinish())
            Finish();
    }

    private bool TimePassedToFinish()
    {
        return Time.time > finishTime;
    }

    public virtual void AIUpdate()
    {
    }

    protected bool IsPlayerInRange(float range)
    {
        if (player == null)
            return false;
        return (player.transform.position - transform.position).magnitude < range;
    }

    protected Transform GetParentTransform()
    {
        return transform.parent;
    }

    protected bool WalkToPoint(Vector3 target)
    {
        return navMeshAgent.SetDestination(target);
    }

    protected bool HasReachedWalkDestination()
    {
        return !navMeshAgent.pathPending && navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance &&
               (!navMeshAgent.hasPath || navMeshAgent.velocity.sqrMagnitude == 0f);
    }
}
