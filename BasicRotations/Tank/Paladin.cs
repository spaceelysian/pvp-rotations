namespace PvPRotations.Tank;
[Rotation("Pld-PvP", CombatType.PvP, GameVersion = "7.1", Description = "PvP")]
[Api(4)]

public class PLDPvP : PaladinRotation
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

        //if (GuardianPvP.Target.Target?.GetHealthRatio() < 0.3 && GuardianPvP.CanUse(out act)) return true;

        return base.EmergencyAbility(nextGCD, out act);
    }

    protected override bool AttackAbility(IAction nextGCD, out IAction? act)
    {
        var NoResilience = CurrentTarget != null && !CurrentTarget.HasStatus(false, StatusID.Resilience);
        var SacredClaim = CurrentTarget != null && CurrentTarget.HasStatus(true, StatusID.SacredClaim);
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;

        return base.AttackAbility(nextGCD, out act);
    }

    protected override bool GeneralAbility(IAction nextGCD, out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;
        if (UseSprint) { if (!InCombat && SprintPvP.CanUse(out act)) return true; }

        if (HolySheltronPvP.CanUse(out act) && HasHostilesInRange) return true;

        return base.GeneralAbility(nextGCD, out act);
    }

    protected override bool GeneralGCD(out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;

        if (ShieldSmitePvP.CanUse(out act)) return true;

        if (ImperatorPvP.CanUse(out act)) return true;
        if (Player.HasStatus(true, StatusID.ConfiteorReady_3028) && ConfiteorPvP.CanUse(out act)) return true;

        if ((Player.CurrentHp < Player.MaxHp) && HolySpiritPvP.CanUse(out act)) return true;

        if (Player.HasStatus(true, StatusID.AtonementReady_2015) && AtonementPvP.CanUse(out act)) return true;
        if (Player.HasStatus(true, StatusID.SupplicationReady_4281) && SupplicationPvP.CanUse(out act)) return true;
        if (Player.HasStatus(true, StatusID.SepulchreReady_4282) && SepulchrePvP.CanUse(out act)) return true;

        if (RoyalAuthorityPvP.CanUse(out act)) return true;
        if (RiotBladePvP.CanUse(out act)) return true;
        if (FastBladePvP.CanUse(out act)) return true;

        return base.GeneralGCD(out act);
    }
}