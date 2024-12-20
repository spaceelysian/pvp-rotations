namespace PvPRotations.Ranged;
[Rotation("Brd-pvp", CombatType.PvP, GameVersion = "7.1", Description = "PvP")]
[Api(4)]

public sealed class BRDPvP : BardRotation
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

        if (Player.HasStatus(false, StatusID.Stun_1343) || Player.HasStatus(false, StatusID.Bind_1345))
        {
            if (TheWardensPaeanPvP.CanUse(out act)) return true;
        }

        return base.EmergencyAbility(nextGCD, out act);
    }

    protected override bool AttackAbility(IAction nextGCD, out IAction? act)
    {
        var NoResilience = CurrentTarget != null && !CurrentTarget.HasStatus(false, StatusID.Resilience);
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;

        if (!Player.HasStatus(true, StatusID.Repertoire) && NoResilience && SilentNocturnePvP.CanUse(out act)) return true;

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

        if (PitchPerfectPvP.CanUse(out act)) return true;

        if (Player.HasStatus(true, StatusID.FrontlinersMarch))
        {
            if (HarmonicArrowPvP.CanUse(out act)) return true;
            if (HarmonicArrowPvP_41465.CanUse(out act)) return true;
            if (HarmonicArrowPvP_41466.CanUse(out act)) return true;
            if (HarmonicArrowPvP_41964.CanUse(out act)) return true;
        }

        if (HostileTarget.DistanceToPlayer() <= 4 && BlastArrowPvP.CanUse(out act, skipAoeCheck: true)) return true;
        if (Player.WillStatusEndGCD(2, 3, true, StatusID.BlastArrowReady_3142) && BlastArrowPvP.CanUse(out act, skipAoeCheck: true)) return true;
        if (BlastArrowPvP.CanUse(out act)) return true;
        if (ApexArrowPvP.CanUse(out act)) return true;

        if (PowerfulShotPvP.CanUse(out act)) return true;

        return base.GeneralGCD(out act);
    }
}
