namespace PvPRotations.Tank;
[Rotation("Gnb-PvP", CombatType.PvP, GameVersion = "7.1", Description = "PvP")]
[Api(4)]

public sealed class GNBPvP : GunbreakerRotation
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

        return base.EmergencyAbility(nextGCD, out act);
    }

    protected override bool AttackAbility(IAction nextGCD, out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;

        if (BlastingZonePvP.CanUse(out act)) return true;

        if (Player.HasStatus(true, StatusID.ReadyToRip_2002) && JugularRipPvP.CanUse(out act, skipAoeCheck: true)) return true;
        if (Player.HasStatus(true, StatusID.ReadyToTear_2003) && AbdomenTearPvP.CanUse(out act, skipAoeCheck: true)) return true;
        if (Player.HasStatus(true, StatusID.ReadyToGouge_2004) && EyeGougePvP.CanUse(out act, skipAoeCheck: true)) return true;

        if (Player.HasStatus(true, StatusID.ReadyToBlast_3041) && HypervelocityPvP.CanUse(out act, skipAoeCheck: true)) return true;
        if (Player.HasStatus(true, StatusID.ReadyToRaze_4293) && FatedBrandPvP.CanUse(out act, skipAoeCheck: true)) return true;

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
        if (Player.HasStatus(true, StatusID.RelentlessRush)) return false;

        if (GnashingFangPvP.Cooldown.IsCoolingDown)
        {
            if (IsLastGCD((ActionID)SavageClawPvP.ID) && WickedTalonPvP.CanUse(out act, skipComboCheck: true)) return true;
            if (IsLastGCD((ActionID)GnashingFangPvP.ID) && SavageClawPvP.CanUse(out act, skipComboCheck: true)) return true;
        }

        if (Player.HasStatus(true, StatusID.NoMercy_3042) && GnashingFangPvP.CanUse(out act)) return true;
        if (FatedCirclePvP.CanUse(out act)) return true;

        if (BurstStrikePvP.CanUse(out act)) return true;
        if (SolidBarrelPvP.CanUse(out act)) return true;
        if (BrutalShellPvP.CanUse(out act)) return true;
        if (KeenEdgePvP.CanUse(out act)) return true;

        return base.GeneralGCD(out act);
    }
}
