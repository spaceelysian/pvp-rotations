namespace PvPRotations.Healer;
[Rotation("Ast-PvP", CombatType.PvP, GameVersion = "6.58", Description = "PvP")]
[Api(1)]

public class ASTPvP : AstrologianRotation
{
    #region Settings
    [RotationConfig(CombatType.PvP, Name = "Use Sprint out of combat?")]
    public bool UseSprint { get; set; } = true;
    #endregion

    protected override bool EmergencyAbility(IAction nextGCD, out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;

        if (TheBolePvP.CanUse(out act) && Player.HasStatus(true, StatusID.BoleDrawn_3403)) return true;
        if (TheArrowPvP.CanUse(out act) && Player.HasStatus(true, StatusID.ArrowDrawn_3404)) return true;
        if (TheBalancePvP.CanUse(out act) && Player.HasStatus(true, StatusID.BalanceDrawn_3101)) return true;

        return base.EmergencyAbility(nextGCD, out act);
    }

    protected override bool AttackAbility(IAction nextGCD, out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;

        if (!HostileTarget.HasStatus(true, StatusID.Resilience) && GravityIiPvP_29248.CanUse(out act, skipAoeCheck: true, usedUp: true)) return true;

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

        if (DrawPvP.CanUse(out act)) return true;

        if (AspectedBeneficPvP_29247.CanUse(out act)) return true;

        if (MacrocosmosPvP.CanUse(out act)) return true;
        if (MicrocosmosPvP.CanUse(out act)) return true;

        return base.GeneralAbility(nextGCD, out act);
    }

    protected override bool GeneralGCD(out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;

        if (!HostileTarget.HasStatus(false, StatusID.Resilience) && GravityIiPvP.CanUse(out act)) return true;

        if (FallMaleficPvP.CanUse(out act)) return true;

        if ((Player.CurrentHp < (Player.MaxHp-15000)) && AspectedBeneficPvP.CanUse(out act)) return true;

        if (AspectedBeneficPvP.CanUse(out act) && AspectedBeneficPvP.Target.Target?.GetHealthRatio() < 0.75) return true;

        return base.GeneralGCD(out act);
    }
}