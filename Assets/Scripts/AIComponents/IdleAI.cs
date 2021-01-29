public class IdleAI : BaseAIComponent
{
    public override string AiName => "Idle";

    public override int GetAiValue(string currentAiName)
    {
        return 10;
    }


    public override void StartAi()
    {
    }

    public override void StopAi()
    {
    }
}
