public class VictimInteractable : BaseInteractable
{
    public delegate void OnVictimKilled();
    public static event OnVictimKilled VictimKilled;

    private VictimDeath _victimDeath;

    public override void Start()
    {
        base.Start();
        _victimDeath = GetComponent<VictimDeath>();
    }

    public override void Interact()
    {
        Kill();
    }

    private void Kill()
    {
        _victimDeath.VictimDies();
        VictimKilled?.Invoke();
    }
}
