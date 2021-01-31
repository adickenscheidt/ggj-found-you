public class IdleAI : BaseAIComponent
{
    public override string AiName => "Idle";
    public override float FinishTime => 0.25f;
    public override FinishMode FinishMode => FinishMode.TimePassed;

    public override int GetAiValue(string currentAiName)
    {
        return 10;
    }
}
