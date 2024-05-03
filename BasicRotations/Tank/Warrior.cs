namespace PvPRotations.Tank;
[Rotation("War-PvP", CombatType.PvP, GameVersion = "6.58", Description = "PvP")]
[Api(1)]

public sealed class WARPvP : WarriorRotation
{
    #region Settings
    [RotationConfig(CombatType.PvP, Name = "Use Sprint out of combat?")]
    public bool UseSprint { get; set; } = true;
    #endregion

    protected override bool EmergencyAbility(IAction nextGCD, out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;
        if ((Player.CurrentHp < (Player.MaxHp - 22222)) && RecuperatePvP.CanUse(out act)) return true;

        return base.EmergencyAbility(nextGCD, out act);
    }

    protected override bool AttackAbility(IAction nextGCD, out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;

        if (OrogenyPvP.CanUse(out act)) return true;

        return base.AttackAbility(nextGCD, out act);
    }
    protected override bool GeneralAbility(IAction nextGCD, out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;

        if (UseSprint)
        {
            if (!InCombat && SprintPvP.CanUse(out act)) return true;
        }

        if ((Player.CurrentHp < Player.MaxHp) &&BloodwhettingPvP.CanUse(out act) && HasHostilesInRange) return true;

        return base.GeneralAbility(nextGCD, out act);
    }
    protected override bool GeneralGCD(out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;

        if ((Player.CurrentHp < Player.MaxHp) && ChaoticCyclonePvP.CanUse(out act, skipAoeCheck: true) && HasHostilesInRange) return true;
        if (Player.WillStatusEnd(6, true, StatusID.NascentChaos_1992) && ChaoticCyclonePvP.CanUse(out act, skipAoeCheck: true) && HasHostilesInRange) return true;

        if (StormsPathPvP.CanUse(out act)) return true;
        if (MaimPvP.CanUse(out act)) return true;
        if (HeavySwingPvP.CanUse(out act)) return true;

        return base.GeneralGCD(out act);
    }
}