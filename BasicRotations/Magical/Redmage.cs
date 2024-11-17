namespace PvPRotations.Magical;
[Rotation("Rdm-PvP", CombatType.PvP, GameVersion = "7.1", Description = "PvP")]
[Api(4)]

public class RDMPvP : RedMageRotation
{
    #region Settings
    [RotationConfig(CombatType.PvP, Name = "Use Sprint out of combat?")]
    public bool UseSprint { get; set; } = true;
    #endregion

    protected override bool EmergencyAbility(IAction nextGCD, out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;
        if (Player.GetHealthRatio() < 0.7 && RecuperatePvP.CanUse(out act)) return true;

        if (Player.GetHealthRatio() < 0.9 && FortePvP.CanUse(out act)) return true;

        return base.EmergencyAbility(nextGCD, out act);
    }

    protected override bool AttackAbility(IAction nextGCD, out IAction? act)
    {
        var NoResilience = CurrentTarget != null && !CurrentTarget.HasStatus(false, StatusID.Resilience);

        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;

        if (NoResilience && Player.HasStatus(true, StatusID.ThornedFlourish_4321) && ViceOfThornsPvP.CanUse(out act, skipAoeCheck: true)) return true;

        return base.AttackAbility(nextGCD, out act);
    }

    protected override bool GeneralAbility(IAction nextGCD, out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;
        if (UseSprint) { if (!InCombat && SprintPvP.CanUse(out act)) return true; }

        if (InCombat && HasHostilesInRange && EmboldenPvP.CanUse(out act)) return true;

        return base.GeneralAbility(nextGCD, out act);
    }

    protected override bool GeneralGCD(out IAction? act)
    {
        var NoResilience = CurrentTarget != null && !CurrentTarget.HasStatus(false, StatusID.Resilience);
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;

        if (NoResilience && ResolutionPvP.CanUse(out act)) return true;

        if (ScorchPvP.CanUse(out act, skipAoeCheck: true)) return true;
        if (EnchantedRedoublementPvP.CanUse(out act)) return true;
        if (EnchantedZwerchhauPvP.CanUse(out act)) return true;
        if (EnchantedRipostePvP.CanUse(out act)) return true;

        if (Player.HasStatus(true, StatusID.PrefulgenceReady_4322) && PrefulgencePvP.CanUse(out act, skipAoeCheck: true)) return true;

        if (Player.HasStatus(true, StatusID.Dualcast_1393) && GrandImpactPvP.CanUse(out act, skipAoeCheck: true)) return true;

        if (JoltIiiPvP.CanUse(out act)) return true;

        return base.GeneralGCD(out act);
    }
}