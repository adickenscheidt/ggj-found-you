public class VictimInteractable : BaseInteractable
{
    public delegate void OnVictimKilled();

    public static event OnVictimKilled VictimKilled;

    private VictimDeath _victimDeath;
    protected Victim Victim;

    public override void Start()
    {
        base.Start();
        _victimDeath = GetComponent<VictimDeath>();
        Victim = GetComponent<Victim>();
    }

    public override void Interact()
    {
        Kill();
    }

    private void Kill()
    {
        VictimKilled?.Invoke();
        _victimDeath.VictimDies();
        Victim.alive = false;
        ResetColor();
        IsActive = false;
    }
}
