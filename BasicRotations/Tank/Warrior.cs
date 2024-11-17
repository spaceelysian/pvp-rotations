namespace PvPRotations.Tank;
[Rotation("War-PvP", CombatType.PvP, GameVersion = "7.1", Description = "PvP")]
[Api(4)]

public sealed class WARPvP : WarriorRotation
{
    #region Settings
    [RotationConfig(CombatType.PvP, Name = "Use Sprint out of combat?")]
    public bool UseSprint { get; set; } = false;
    #endregion

    protected override bool EmergencyAbility(IAction nextGCD, out IAction? act)
    {
        var NoResilience = CurrentTarget != null && !CurrentTarget.HasStatus(false, StatusID.Resilience);
        var NoIR = CurrentTarget != null && !CurrentTarget.HasStatus(false, StatusID.InnerRelease_1303);

        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;
        if (Player.GetHealthRatio() < 0.7 && RecuperatePvP.CanUse(out act)) return true;

        //if (NoIR && NoResilience && BlotaPvP.CanUse(out act) && BlotaPvP.Target.Target?.DistanceToPlayer() >= 13) return true;

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
        if (UseSprint) { if (!InCombat && SprintPvP.CanUse(out act)) return true; }

        if (Player.CurrentHp < Player.MaxHp && BloodwhettingPvP.CanUse(out act) && HasHostilesInRange) return true;

        return base.GeneralAbility(nextGCD, out act);

    }

    protected override bool GeneralGCD(out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;

        if (Player.HasStatus(true, StatusID.InnerRelease_1303) && PrimalRendPvP.CanUse(out act, skipAoeCheck: true)) return true;

        if (Player.HasStatus(true, StatusID.ChaoticCycloneReady) && Player.CurrentHp < Player.MaxHp && ChaoticCyclonePvP.CanUse(out act, skipAoeCheck: true) && HasHostilesInRange) return true;
        if (Player.HasStatus(true, StatusID.PrimalRuinationReady_4285) && PrimalRuinationPvP.CanUse(out act, skipAoeCheck: true)) return true;

        if (StormsPathPvP.CanUse(out act)) return true;
        if (MaimPvP.CanUse(out act)) return true;
        if (HeavySwingPvP.CanUse(out act)) return true;

        return base.GeneralGCD(out act);
    }
}