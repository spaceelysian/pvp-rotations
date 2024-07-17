namespace PvPRotations.Melee;
[Rotation("Rpr-PvP", CombatType.PvP, GameVersion = "7", Description = "PvP")]
[Api(2)]

public sealed class RPRPvP : ReaperRotation
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

        if (Player.HasStatus(true, StatusID.Enshrouded_2863))
        {
            if (ArcaneCrestPvP.CanUse(out act)) return true;
        }

        if ((Player.CurrentHp < Player.MaxHp) & ArcaneCrestPvP.CanUse(out act) && HasHostilesInRange) return true;

        return base.EmergencyAbility(nextGCD, out act);
    }

    protected override bool AttackAbility(IAction nextGCD, out IAction? act)
    {
        var NoResilience = CurrentTarget != null && !CurrentTarget.HasStatus(false, StatusID.Resilience);
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;

        if (HostileTarget.DistanceToPlayer() <= 5 && DeathWarrantPvP.CanUse(out act)) return true;

        if (Player.HasStatus(true, StatusID.Soulsow_2750))
        {
            if (HarvestMoonPvP.CanUse(out act, skipAoeCheck: true) && HarvestMoonPvP.Target.Target?.GetHealthRatio() < 0.5) return true;
            if (Player.WillStatusEnd(5, true, StatusID.Soulsow_2750) && HarvestMoonPvP.CanUse(out act, skipAoeCheck: true)) return true;
        }

        if (NoResilience && GrimSwathePvP.CanUse(out act)) return true;

        return base.AttackAbility(nextGCD, out act);
    }

    protected override bool GeneralAbility(IAction nextGCD, out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;
        if (UseSprint) { if (!InCombat && SprintPvP.CanUse(out act)) return true; }

        return base.GeneralAbility(nextGCD, out act);
    }

    protected override bool GeneralGCD(out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;

        if (SoulSlicePvP.CanUse(out act, usedUp: true)) return true;
        if (PlentifulHarvestPvP.CanUse(out act)) return true;

        if (InfernalSlicePvP.CanUse(out act)) return true;
        if (WaxingSlicePvP.CanUse(out act)) return true;
        if (SlicePvP.CanUse(out act)) return true;

        return base.GeneralGCD(out act);
    }
}