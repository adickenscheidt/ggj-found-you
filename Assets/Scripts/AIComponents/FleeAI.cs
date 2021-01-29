using UnityEngine;

public class FleeAI : BaseAIComponent
{
    public override string AiName => "Fleeing";
    public float fleeStartRange = 10f;
    public float fleeMovementSpeed = 15f;

    public override int GetAiValue(string currentAiName)
    {
        return IsPlayerInRange(fleeStartRange) ? 70 : 0;
    }

    public override void AIUpdate()
    {
        FleeFromPlayer();
    }

    private void FleeFromPlayer()
    {
        var transformPosition = GetParentTransform().position - player.transform.position;
        transformPosition.y = 0;
        var awayFromPlayer = transformPosition.normalized;
        GetParentTransform().Translate(awayFromPlayer * (Time.fixedDeltaTime * fleeMovementSpeed), Space.World);
    }
}
