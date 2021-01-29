using UnityEngine;

public abstract class BaseAIComponent : MonoBehaviour
{
    internal GameObject player;
    public abstract string AiName { get; }
    public float executionTime = 1f;

    public abstract int GetAiValue(string currentAiName);

    public virtual float GetExecutionTime()
    {
        return executionTime;
    }

    private bool _isActive;

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
    }

    public void Update()
    {
        if(_isActive)
            AIUpdate();
    }

    public virtual void AIUpdate() { }

    internal bool IsPlayerInRange(float range)
    {
        return (player.transform.position - transform.position).magnitude < range;
    }

    internal Transform GetParentTransform()
    {
        return transform.parent;
    }
}
