using UnityEngine;

public abstract class BaseAIComponent : MonoBehaviour
{
    public abstract string AiName { get; }
    public float executionTime = 1f;

    private bool _isActive;
    protected GameObject player;
    protected Victim victim;

    public abstract int GetAiValue(string currentAiName);

    public virtual float GetExecutionTime()
    {
        return executionTime;
    }

    public virtual void StartAi()
    {
        _isActive = true;
    }

    public virtual void StopAi()
    {
        _isActive = false;
    }

    public virtual void Start()
    {
        player = GameObject.Find("PlayerObject");
        victim = GetComponentInParent<Victim>();
    }

    public void Update()
    {
        if (_isActive)
            AIUpdate();
    }

    public virtual void AIUpdate()
    {
    }

    internal bool IsPlayerInRange(float range)
    {
        return (player.transform.position - transform.position).magnitude < range;
    }

    internal Transform GetParentTransform()
    {
        return transform.parent;
    }
}
