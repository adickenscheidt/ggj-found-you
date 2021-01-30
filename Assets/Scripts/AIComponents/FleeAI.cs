using UnityEngine;

public class FleeAI : BaseAIComponent
{
    public override string AiName => "Fleeing";
    public override FinishMode FinishMode => FinishMode.PointReached;

    public float fleeStartRange = 10f;
    public float fleeDistance = 5f;

    public override int GetAiValue(string currentAiName)
    {
        return IsPlayerInRange(fleeStartRange) ? 70 : 0;
    }

    public override void StartAi()
    {
        base.StartAi();
        if (!RunAway())
            Finish();
    }

    private bool RunAway()
    {
        var transformPosition = GetParentTransform().position - player.transform.position;
        transformPosition.y = 0;
        var awayFromPlayer = GetParentTransform().position + transformPosition.normalized * fleeDistance;

        return WalkToPoint(awayFromPlayer);
    }
}
