namespace PvPRotations.Ranged;
[Rotation("Brd-pvp", CombatType.PvP, GameVersion = "6.58", Description = "PvP")]
[Api(1)]

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

        if (Player.HasStatus(false, StatusID.Stun_1343) || Player.HasStatus(false, StatusID.Bind_1345))
        {
            if (TheWardensPaeanPvP.CanUse(out act)) return true;
        }

        return base.EmergencyAbility(nextGCD, out act);
    }

    protected override bool AttackAbility(IAction nextGCD, out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;

        if (Player.HasStatus(true, StatusID.FrontlineForte))
        {
            if (EmpyrealArrowPvP.Cooldown.CurrentCharges == 3 && EmpyrealArrowPvP.CanUse(out act)) return true;

            if (!HostileTarget.HasStatus(true, StatusID.Resilience) && SilentNocturnePvP.CanUse(out act)) return true;
        }

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

        return base.GeneralAbility(nextGCD, out act);
    }

    protected override bool GeneralGCD(out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;

        if (PitchPerfectPvP.CanUse(out act) && !HostileTarget.HasStatus(false, StatusID.Resilience)) return true;

        if (BlastArrowPvP.CanUse(out act)) return true;
        if (ApexArrowPvP.CanUse(out act)) return true;

        if (PowerfulShotPvP.CanUse(out act)) return true;

        return base.GeneralGCD(out act);
    }
}
