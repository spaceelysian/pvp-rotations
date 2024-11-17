namespace PvPRotations.Healer;
[Rotation("Ast-PvP", CombatType.PvP, GameVersion = "7.1", Description = "PvP")]
[Api(4)]

public class ASTPvP : AstrologianRotation
{
    #region Settings
    [RotationConfig(CombatType.PvP, Name = "Use Sprint out of combat?")]
    public bool UseSprint { get; set; } = false;
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
        var NoResilience = CurrentTarget != null && !CurrentTarget.HasStatus(false, StatusID.Resilience);

        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;

        if (MinorArcanaPvP.CanUse(out act)) return true;
        if (Player.HasStatus(true, StatusID.LadyOfCrowns_4328) && LadyOfCrownsPvP.CanUse(out act, skipAoeCheck: true)) return true;
        if (Player.HasStatus(true, StatusID.LordOfCrowns_4329) && LordOfCrownsPvP.CanUse(out act, skipAoeCheck: true)) return true;

        if (MacrocosmosPvP.CanUse(out act)) return true;
        if (FallMaleficPvP_29246.CanUse(out act)) return true;
        if (GravityIiPvP_29248.CanUse(out act)) return true;

        if (Player.HasStatus(true, StatusID.Divining_4332) && NoResilience && OraclePvP.CanUse(out act, skipAoeCheck: true)) return true;

        return base.AttackAbility(nextGCD, out act);
    }

    protected override bool GeneralAbility(IAction nextGCD, out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;
        if (UseSprint) { if (!InCombat && SprintPvP.CanUse(out act)) return true; }
        
        if (Player.HasStatus(true, StatusID.Macrocosmos_3104))
        { 
        if (Player.WillStatusEnd(3, true, StatusID.Macrocosmos_3104) && MicrocosmosPvP.CanUse(out act, skipAoeCheck: true)) return true;
        if (Player.GetHealthRatio() < 0.75 && MicrocosmosPvP.CanUse(out act, skipAoeCheck: true)) return true;
        }

        return base.GeneralAbility(nextGCD, out act);
    }

   protected override bool GeneralGCD(out IAction? act)
   {
        var NoResilience = CurrentTarget != null && !CurrentTarget.HasStatus(false, StatusID.Resilience);

        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;

        if (Player.GetHealthRatio() < 0.5 && AspectedBeneficPvP.CanUse(out act)) return true;

        if (NoResilience && GravityIiPvP.CanUse(out act, skipAoeCheck: true)) return true;

        if (FallMaleficPvP.CanUse(out act)) return true;

        return base.GeneralGCD(out act);
   }
}