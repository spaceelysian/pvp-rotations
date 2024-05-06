namespace PvPRotations.Ranged;
[Rotation("Mch-PvP", CombatType.PvP, GameVersion = "6.58", Description = "PvP")]
[Api(1)]

public class MCHPvP : MachinistRotation
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

        if (BishopAutoturretPvP.CanUse(out act, skipAoeCheck: true)) return true;

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

        if (InCombat && !Player.HasStatus(true, StatusID.Overheated_3149) && AnalysisPvP.CanUse(out act)) return true;

        return base.GeneralAbility(nextGCD, out act);
    }

    protected override bool GeneralGCD(out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;

        if (!Player.HasStatus(true, StatusID.Overheated_3149) && ScattergunPvP.CanUse(out act,skipAoeCheck: true) && HostileTarget.DistanceToPlayer() <= 10) return true;

        if (Player.HasStatus(true, StatusID.Analysis))
        {
            var NoResilience = CurrentTarget != null && !CurrentTarget.HasStatus(false, StatusID.Resilience);

            if (NoResilience && Player.HasStatus(true, StatusID.AirAnchorPrimed) && !Player.HasStatus(true, StatusID.BioblasterPrimed, StatusID.ChainSawPrimed, StatusID.DrillPrimed, StatusID.Overheated_3149) && AirAnchorPvP.CanUse(out act, usedUp: true)) return true;
            if (Player.HasStatus(true, StatusID.BioblasterPrimed) && !Player.HasStatus(true, StatusID.AirAnchorPrimed, StatusID.ChainSawPrimed, StatusID.DrillPrimed, StatusID.Overheated_3149) && BioblasterPvP.CanUse(out act, skipAoeCheck: true, usedUp: true)) return true;
            if (Player.HasStatus(true, StatusID.ChainSawPrimed) && !Player.HasStatus(true, StatusID.BioblasterPrimed, StatusID.BioblasterPrimed, StatusID.DrillPrimed, StatusID.Overheated_3149) && ChainSawPvP.CanUse(out act, skipAoeCheck: true)) return true;
            if (Player.HasStatus(true, StatusID.DrillPrimed) && !Player.HasStatus(true, StatusID.BioblasterPrimed, StatusID.ChainSawPrimed, StatusID.AirAnchorPrimed, StatusID.Overheated_3149) && DrillPvP.CanUse(out act, usedUp: true)) return true;
        }

        if (AirAnchorPvP.Cooldown.CurrentCharges == 2 && Player.HasStatus(true, StatusID.AirAnchorPrimed) && !Player.HasStatus(true, StatusID.BioblasterPrimed, StatusID.ChainSawPrimed, StatusID.DrillPrimed, StatusID.Overheated_3149) && AirAnchorPvP.CanUse(out act)) return true;
        if (BioblasterPvP.Cooldown.CurrentCharges == 2 && Player.HasStatus(true, StatusID.BioblasterPrimed) && !Player.HasStatus(true, StatusID.AirAnchorPrimed, StatusID.ChainSawPrimed, StatusID.DrillPrimed, StatusID.Overheated_3149) && BioblasterPvP.CanUse(out act, skipAoeCheck: true)) return true;
        if (ChainSawPvP.Cooldown.CurrentCharges == 2 &&Player.HasStatus(true, StatusID.ChainSawPrimed) && !Player.HasStatus(true, StatusID.BioblasterPrimed, StatusID.BioblasterPrimed, StatusID.DrillPrimed, StatusID.Overheated_3149) && ChainSawPvP.CanUse(out act, skipAoeCheck: true)) return true;
        if (DrillPvP.Cooldown.CurrentCharges == 2 &&Player.HasStatus(true, StatusID.DrillPrimed) && !Player.HasStatus(true, StatusID.BioblasterPrimed, StatusID.ChainSawPrimed, StatusID.AirAnchorPrimed, StatusID.Overheated_3149) && DrillPvP.CanUse(out act)) return true;

        if (Player.HasStatus(true, StatusID.Overheated_3149))
        {
            act = null;
            
            {
                if (WildfirePvP.CanUse(out act)) return true;
            }
            if (WildfirePvP.IsInCooldown)
            {
                if (BlastChargePvP.CanUse(out act, skipCastingCheck: true)) return true;
            }
            return false;
        }

        if (BlastChargePvP.CanUse(out act, skipCastingCheck: true)) return true;

        return base.GeneralGCD(out act);
    }
}
