namespace DefaultRotations.Ranged;
[Rotation("Mch-PvP", CombatType.PvP, GameVersion = "6.58", Description = "PvP")]
[Api(1)]

public class MCHPvP : MachinistRotation
{
    protected override bool EmergencyAbility(IAction nextGCD, out IAction? act)
    {

        return base.EmergencyAbility(nextGCD, out act);
    }

    protected override bool AttackAbility(IAction nextGCD, out IAction? act)
    {

        return base.AttackAbility(nextGCD, out act);
    }

    protected override bool GeneralAbility(IAction nextGCD, out IAction? act)
    {

        if (InCombat && !Player.HasStatus(true, StatusID.Overheated_3149) && AnalysisPvP.CanUse(out act)) return true;

        if (!InCombat && SprintPvP.CanUse(out act)) return true;

        if (TimeSinceLastAction.TotalSeconds > 4.5)
        {
            if (SprintPvP.CanUse(out act)) return true;
        }

        return base.GeneralAbility(nextGCD, out act);
    }
    protected override bool GeneralGCD(out IAction? act)
    {

        if (!Player.HasStatus(true, StatusID.Overheated_3149) && ScattergunPvP.CanUse(out act,skipAoeCheck: true) && HostileTarget.DistanceToPlayer() <= 10) return true;

        if (Player.HasStatus(true, StatusID.Analysis))
        {
            if (Player.HasStatus(true, StatusID.AirAnchorPrimed) && !Player.HasStatus(true, StatusID.BioblasterPrimed, StatusID.ChainSawPrimed, StatusID.DrillPrimed, StatusID.Overheated_3149) && AirAnchorPvP.CanUse(out act)) return true;
            if (Player.HasStatus(true, StatusID.BioblasterPrimed) && !Player.HasStatus(true, StatusID.AirAnchorPrimed, StatusID.ChainSawPrimed, StatusID.DrillPrimed, StatusID.Overheated_3149) && BioblasterPvP.CanUse(out act, skipAoeCheck: true)) return true;
            if (Player.HasStatus(true, StatusID.ChainSawPrimed) && !Player.HasStatus(true, StatusID.BioblasterPrimed, StatusID.BioblasterPrimed, StatusID.DrillPrimed, StatusID.Overheated_3149) && ChainSawPvP.CanUse(out act, skipAoeCheck: true)) return true;
            if (Player.HasStatus(true, StatusID.DrillPrimed) && !Player.HasStatus(true, StatusID.BioblasterPrimed, StatusID.ChainSawPrimed, StatusID.AirAnchorPrimed, StatusID.Overheated_3149) && DrillPvP.CanUse(out act)) return true;
        }

        if (AirAnchorPvP.Cooldown.CurrentCharges == 2 && Player.HasStatus(true, StatusID.AirAnchorPrimed) && !Player.HasStatus(true, StatusID.BioblasterPrimed, StatusID.ChainSawPrimed, StatusID.DrillPrimed, StatusID.Overheated_3149) && AirAnchorPvP.CanUse(out act)) return true;
        if (BioblasterPvP.Cooldown.CurrentCharges == 2 && Player.HasStatus(true, StatusID.BioblasterPrimed) && !Player.HasStatus(true, StatusID.AirAnchorPrimed, StatusID.ChainSawPrimed, StatusID.DrillPrimed, StatusID.Overheated_3149) && BioblasterPvP.CanUse(out act, skipAoeCheck: true)) return true;
        if (ChainSawPvP.Cooldown.CurrentCharges == 2 &&Player.HasStatus(true, StatusID.ChainSawPrimed) && !Player.HasStatus(true, StatusID.BioblasterPrimed, StatusID.BioblasterPrimed, StatusID.DrillPrimed, StatusID.Overheated_3149) && ChainSawPvP.CanUse(out act, skipAoeCheck: true)) return true;
        if (DrillPvP.Cooldown.CurrentCharges == 2 &&Player.HasStatus(true, StatusID.DrillPrimed) && !Player.HasStatus(true, StatusID.BioblasterPrimed, StatusID.ChainSawPrimed, StatusID.AirAnchorPrimed, StatusID.Overheated_3149) && DrillPvP.CanUse(out act)) return true;

        if (Player.StatusStack(true, StatusID.Heat) == 4)
        {
            act = null;
            
            {
                if (WildfirePvP.CanUse(out act)) return true;
            }
            if (WildfirePvP.IsInCooldown)
            {
                if (BlastChargePvP.CanUse(out act)) return true;
            }
            return false;
        }

        if (BlastChargePvP.CanUse(out act)) return true;

        return base.GeneralGCD(out act);
    }
}
