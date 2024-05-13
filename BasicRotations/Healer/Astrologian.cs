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
        if (Player.GetHealthRatio() < 0.7 && RecuperatePvP.CanUse(out act)) return true;

        if (IsLastGCD((ActionID)AspectedBeneficPvP.ID) && AspectedBeneficPvP_29247.CanUse(out act)) return true;

        return base.EmergencyAbility(nextGCD, out act);
    }

    protected override bool AttackAbility(IAction nextGCD, out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;

        if (MacrocosmosPvP.CanUse(out act)) return true;

        if (GravityIiPvP_29248.CanUse(out act, skipAoeCheck: true, usedUp: true)) return true;

        return base.AttackAbility(nextGCD, out act);
    }

    protected override bool GeneralAbility(IAction nextGCD, out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;
        if (UseSprint) { if (!InCombat && SprintPvP.CanUse(out act)) return true; }

        if (DrawPvP.CanUse(out act)) return true;
        if (DrawnCard == CardType.ARROW)
        {
            if (TheArrowPvP.CanUse(out act)) return true;
            if (Player.WillStatusEnd(10, true, StatusID.ArrowDrawn_3404) && TheArrowPvP.CanUse(out act, skipAoeCheck: true)) return true;
        }
        if (DrawnCard == CardType.BALANCE) 
        {
            if (TheBalancePvP.CanUse(out act)) return true;
            if (Player.WillStatusEnd(10, true, StatusID.ArrowDrawn_3404) && TheBalancePvP.CanUse(out act, skipAoeCheck: true)) return true;
        }
        if (DrawnCard == CardType.BOLE) 
        {
            if (TheBolePvP.CanUse(out act)) return true;
            if (Player.WillStatusEnd(10, true, StatusID.BoleDrawn_3403) && TheBolePvP.CanUse(out act, skipAoeCheck: true)) return true;
        }

        if (Player.HasStatus(true, StatusID.Macrocosmos_3104))
        { 
        if (Player.WillStatusEnd(3, true, StatusID.Macrocosmos_3104) && MicrocosmosPvP.CanUse(out act, skipAoeCheck: true)) return true;
        if (Player.GetHealthRatio() < 0.75 && MicrocosmosPvP.CanUse(out act, skipAoeCheck: true)) return true;
        }

        return base.GeneralAbility(nextGCD, out act);
    }

   protected override bool GeneralGCD(out IAction? act)
   {
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;

        if (Player.GetHealthRatio() < 0.5 && AspectedBeneficPvP.CanUse(out act)) return true;

        if (GravityIiPvP.CanUse(out act)) return true;

        if (FallMaleficPvP.CanUse(out act)) return true;

        return base.GeneralGCD(out act);
   }
}