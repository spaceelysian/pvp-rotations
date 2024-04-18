namespace DefaultRotations.Tank;
[Rotation("Gnb-PvP", CombatType.PvP, GameVersion = "6.58", Description = "PvP")]
[Api(1)]

public sealed class GNBPvP : GunbreakerRotation
{
    protected override bool EmergencyAbility(IAction nextGCD, out IAction? act)
    {

        return base.EmergencyAbility(nextGCD, out act);
    }

    protected override bool AttackAbility(IAction nextGCD, out IAction? act)
    {

        if (Player.HasStatus(true, StatusID.ReadyToBlast_3041) && HypervelocityPvP_29111.CanUse(out act)) return true;

        if (Player.HasStatus(true, StatusID.ReadyToGouge_2004) && EyeGougePvP_29114.CanUse(out act)) return true;
        if (Player.HasStatus(true, StatusID.ReadyToTear_2003) && AbdomenTearPvP_29113.CanUse(out act)) return true;
        if (Player.HasStatus(true, StatusID.ReadyToRip_2002) && JugularRipPvP_29112.CanUse(out act)) return true;

        return base.AttackAbility(nextGCD, out act);
    }

    protected override bool GeneralAbility(IAction nextGCD, out IAction? act)
    {

        return base.GeneralAbility(nextGCD, out act);
    }

    protected override bool GeneralGCD(out IAction? act)
    {

        if (Player.HasStatus(true, StatusID.PowderBarrel) && BurstStrikePvP.CanUse(out act)) return true;

        if (IsLastGCD((ActionID)SavageClawPvP.ID) && WickedTalonPvP.CanUse(out act, skipComboCheck: true)) return true;
        if (IsLastGCD((ActionID)GnashingFangPvP.ID) && SavageClawPvP.CanUse(out act, skipComboCheck: true)) return true;
        if (GnashingFangPvP.CanUse(out act)) return true;

        if (IsLastAbility((ActionID)RoughDividePvP.ID) && DoubleDownPvP.CanUse(out act) && HasHostilesInRange) return true;

        if (SolidBarrelPvP.CanUse(out act)) return true;
        if (BrutalShellPvP.CanUse(out act)) return true;
        if (KeenEdgePvP.CanUse(out act)) return true;

        return base.GeneralGCD(out act);
    }
}
