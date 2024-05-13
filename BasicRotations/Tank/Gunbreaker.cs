namespace PvPRotations.Tank;
[Rotation("Gnb-PvP", CombatType.PvP, GameVersion = "6.58", Description = "PvP")]
[Api(1)]

public sealed class GNBPvP : GunbreakerRotation
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
        if (Player.HasStatus(true, StatusID.JunctionHealer))
        {
            if (Player.CurrentHp < Player.MaxHp && AuroraPvP.CanUse(out act)) return true;
            if (AuroraPvP.CanUse(out act) && AuroraPvP.Target.Target?.GetHealthRatio() < 0.8) return true;
        }

        if (Player.CurrentHp < Player.MaxHp && NebulaPvP.CanUse(out act) && HasHostilesInMaxRange) return true;

        return base.EmergencyAbility(nextGCD, out act);
    }

    protected override bool AttackAbility(IAction nextGCD, out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;

        if (!Player.HasStatus(true, StatusID.JunctionTank) && !Player.HasStatus(true, StatusID.JunctionDps) && !Player.HasStatus(true, StatusID.JunctionHealer))
        {
            if (Player.HasStatus(true, StatusID.ReadyToBlast_3041) && HypervelocityPvP.CanUse(out act)) return true;

            if (Player.HasStatus(true, StatusID.ReadyToGouge_2004) && EyeGougePvP.CanUse(out act)) return true;
            if (Player.HasStatus(true, StatusID.ReadyToTear_2003) && AbdomenTearPvP.CanUse(out act)) return true;
            if (Player.HasStatus(true, StatusID.ReadyToRip_2002) && JugularRipPvP.CanUse(out act)) return true;
        }

        if (Player.HasStatus(true, StatusID.JunctionTank))
        {
            if (Player.HasStatus(true, StatusID.ReadyToBlast_3041) && HypervelocityPvP_29111.CanUse(out act)) return true;

            if (Player.HasStatus(true, StatusID.ReadyToGouge_2004) && EyeGougePvP_29114.CanUse(out act)) return true;
            if (Player.HasStatus(true, StatusID.ReadyToTear_2003) && AbdomenTearPvP_29113.CanUse(out act)) return true;
            if (Player.HasStatus(true, StatusID.ReadyToRip_2002) && JugularRipPvP_29112.CanUse(out act)) return true;
        }

        if (Player.HasStatus(true, StatusID.JunctionDps))
        {
            if (Player.HasStatus(true, StatusID.ReadyToBlast_3041) && HypervelocityPvP_29115.CanUse(out act)) return true;

            if (Player.HasStatus(true, StatusID.ReadyToGouge_2004) && EyeGougePvP_29118.CanUse(out act)) return true;
            if (Player.HasStatus(true, StatusID.ReadyToTear_2003) && AbdomenTearPvP_29117.CanUse(out act)) return true;
            if (Player.HasStatus(true, StatusID.ReadyToRip_2002) && JugularRipPvP_29116.CanUse(out act)) return true;

            if (BlastingZonePvP.CanUse(out act)) return true;
        }

        if (Player.HasStatus(true, StatusID.JunctionHealer))
        {
            if (Player.HasStatus(true, StatusID.ReadyToBlast_3041) && HypervelocityPvP_29119.CanUse(out act, skipAoeCheck: true)) return true;

            if (Player.HasStatus(true, StatusID.ReadyToGouge_2004) && EyeGougePvP_29122.CanUse(out act, skipAoeCheck: true)) return true;
            if (Player.HasStatus(true, StatusID.ReadyToTear_2003) && AbdomenTearPvP_29121.CanUse(out act, skipAoeCheck: true)) return true;
            if (Player.HasStatus(true, StatusID.ReadyToRip_2002) && JugularRipPvP_29120.CanUse(out act, skipAoeCheck: true)) return true;
        }

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

        if (Player.HasStatus(true, StatusID.NoMercy_3042) && DoubleDownPvP.CanUse(out act) && HasHostilesInRange) return true;

        if (Player.HasStatus(true, StatusID.NoMercy_3042) && GnashingFangPvP.CanUse(out act)) return true;

        if (Player.HasStatus(true, StatusID.PowderBarrel) && BurstStrikePvP.CanUse(out act)) return true;

        if (SolidBarrelPvP.CanUse(out act)) return true;
        if (BrutalShellPvP.CanUse(out act)) return true;
        if (KeenEdgePvP.CanUse(out act)) return true;

        return base.GeneralGCD(out act);
    }
}
