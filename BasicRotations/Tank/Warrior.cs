namespace DefaultRotations.Tank;
[Rotation("War-PvP", CombatType.PvP, GameVersion = "6.58", Description = "PvP")]
[Api(1)]

public sealed class WARPvP : WarriorRotation
{
    #region Settings
    [RotationConfig(CombatType.PvP, Name = "Use Sprint?")]
    public bool UseSprint { get; set; } = true;
    #endregion

    protected override bool EmergencyAbility(IAction nextGCD, out IAction? act)
    {

        return base.EmergencyAbility(nextGCD, out act);
    }

    protected override bool AttackAbility(IAction nextGCD, out IAction? act)
    {

        if (OrogenyPvP.CanUse(out act)) return true;

        return base.AttackAbility(nextGCD, out act);
    }
    protected override bool GeneralAbility(IAction nextGCD, out IAction? act)
    {

        if (UseSprint)
        {
            if (!InCombat && SprintPvP.CanUse(out act)) return true;

            if (TimeSinceLastAction.TotalSeconds > 5)
            {
                if (SprintPvP.CanUse(out act)) return true;
            }
        }

        if ((Player.CurrentHp < Player.MaxHp) && BloodwhettingPvP.CanUse(out act)) return true;

        return base.GeneralAbility(nextGCD, out act);
    }
    protected override bool GeneralGCD(out IAction? act)
    {

        if ((Player.CurrentHp < Player.MaxHp) && ChaoticCyclonePvP.CanUse(out act, skipAoeCheck: true) && HasHostilesInRange) return true;

        if (StormsPathPvP.CanUse(out act)) return true;
        if (MaimPvP.CanUse(out act)) return true;
        if (HeavySwingPvP.CanUse(out act)) return true;

        return base.GeneralGCD(out act);
    }
}