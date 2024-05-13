namespace PvPRotations.Melee;
[Rotation("Nin-PvP", CombatType.PvP, GameVersion = "6.58", Description = "PvP")]
[Api(1)]

public class NINPvP : NinjaRotation
{
    #region Settings
    [RotationConfig(CombatType.PvP, Name = "Use Sprint out of combat?")]
    public bool UseSprint { get; set; } = true;
    #endregion

    protected override bool EmergencyAbility(IAction nextGCD, out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;
        if (Player.HasStatus(true, StatusID.Hidden_1316)) return false;
        if (Player.GetHealthRatio() < 0.7 && RecuperatePvP.CanUse(out act)) return true;

        return base.EmergencyAbility(nextGCD, out act);
    }

    protected override bool AttackAbility(IAction nextGCD, out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;
        if (Player.HasStatus(true, StatusID.Hidden_1316)) return false;

        if (!Player.HasStatus(true, StatusID.ThreeMudra) && FumaShurikenPvP.Cooldown.CurrentCharges <= 1 && MugPvP.CanUse(out act)) return true;

        return base.AttackAbility(nextGCD, out act);
    }

    protected override bool GeneralAbility(IAction nextGCD, out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;
        if (Player.HasStatus(true, StatusID.Hidden_1316)) return false;
        if (UseSprint) { if (!InCombat && SprintPvP.CanUse(out act)) return true; }

        if (IsLastGCD((ActionID)SpinningEdgePvP.ID) && BunshinPvP.CanUse(out act)) return true;
        if (!Player.HasStatus(true, StatusID.ThreeMudra) && HostileTarget.DistanceToPlayer() <= 19 && ThreeMudraPvP.CanUse(out act, usedUp: true)) return true;

        return base.GeneralAbility(nextGCD, out act);
    }

    protected override bool GeneralGCD(out IAction? act)
    {
        var NoResilience = CurrentTarget != null && !CurrentTarget.HasStatus(false, StatusID.Resilience);
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;
        if (Player.HasStatus(true, StatusID.Hidden_1316))
        {
            act = null;
            if (AssassinatePvP.CanUse(out act)) return true;
            return false;
        }

        if (Player.HasStatus(true, StatusID.ThreeMudra))
        {
            act = null;

            if (!Player.HasStatus(true, StatusID.SealedMeisui) && (MeisuiPvP.Target.Target?.GetHealthRatio() < 0.4) && MeisuiPvP.CanUse(out act)) return true;

            if (NoResilience && !Player.HasStatus(true, StatusID.SealedForkedRaiju) && HostileTarget.DistanceToPlayer() <= 4 && ForkedRaijuPvP.CanUse(out act)) return true;

            if (!Player.HasStatus(true, StatusID.SealedGokaMekkyaku) && GokaMekkyakuPvP.CanUse(out act, skipAoeCheck: true)) return true;
            if (!Player.HasStatus(true, StatusID.SealedHyoshoRanryu) && HyoshoRanryuPvP.CanUse(out act)) return true;

            if (Player.GetHealthRatio() < 0.33)
            {
                if (!Player.HasStatus(true, StatusID.SealedHuton) && HutonPvP.CanUse(out act)) return true;
                if (!Player.HasStatus(true, StatusID.SealedMeisui) && MeisuiPvP.CanUse(out act)) return true;
            }

            if (Player.WillStatusEnd(2, true, StatusID.ThreeMudra) && !Player.HasStatus(true, StatusID.SealedHuton) && HutonPvP.CanUse(out act)) return true;
            if (Player.WillStatusEnd(2, true, StatusID.ThreeMudra) && !Player.HasStatus(true, StatusID.SealedMeisui) && MeisuiPvP.CanUse(out act)) return true;

            return false;
        }

        if (FumaShurikenPvP.Cooldown.CurrentCharges == 3 && FumaShurikenPvP.CanUse(out act) && !Player.HasStatus(true, StatusID.Hidden_1316)) return true;

        if (Player.HasStatus(true, StatusID.FleetingRaijuReady_3211))
        {
             if (NoResilience && FleetingRaijuPvP.CanUse(out act) && HostileTarget.DistanceToPlayer() <= 3) return true;
        }

        if (!Player.HasStatus(true, StatusID.FleetingRaijuReady_3211))
        {
            if (AeolianEdgePvP.CanUse(out act)) return true;
            if (GustSlashPvP.CanUse(out act)) return true;
            if (SpinningEdgePvP.CanUse(out act)) return true;
        }

        if (FumaShurikenPvP.Cooldown.CurrentCharges > 1 && FumaShurikenPvP.CanUse(out act, usedUp: true )&& !Player.HasStatus(true, StatusID.Hidden_1316)) return true;
        if (FumaShurikenPvP.Target.Target?.GetHealthRatio() < 0.55 && FumaShurikenPvP.CanUse(out act, usedUp: true) && !Player.HasStatus(true, StatusID.Hidden_1316)) return true;

        return base.GeneralGCD(out act);
    }
}