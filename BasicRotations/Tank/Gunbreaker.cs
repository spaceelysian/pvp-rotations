using RotationSolver.Basic.Actions;

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

        if (Player.HasStatus(true, StatusID.JunctionTank))
        {
            if (Player.HasStatus(true, StatusID.ReadyToBlast_3041) && HypervelocityPvP_29111.CanUse(out act)) return true;

            if (Player.HasStatus(true, StatusID.ReadyToGouge_2004) && EyeGougePvP_29114.CanUse(out act)) return true;
            if (Player.HasStatus(true, StatusID.ReadyToTear_2003) && AbdomenTearPvP_29113.CanUse(out act)) return true;
            if (Player.HasStatus(true, StatusID.ReadyToRip_2002) && JugularRipPvP_29112.CanUse(out act)) return true;
        }

        if (Player.HasStatus(true, StatusID.JunctionHealer))
        {
            if (Player.HasStatus(true, StatusID.ReadyToBlast_3041) && HypervelocityPvP_29115.CanUse(out act)) return true;

            if (Player.HasStatus(true, StatusID.ReadyToGouge_2004) && EyeGougePvP_29118.CanUse(out act)) return true;
            if (Player.HasStatus(true, StatusID.ReadyToTear_2003) && AbdomenTearPvP_29117.CanUse(out act)) return true;
            if (Player.HasStatus(true, StatusID.ReadyToRip_2002) && JugularRipPvP_29116.CanUse(out act)) return true;
        }
        if (Player.HasStatus(true, StatusID.JunctionDps))
        {
            if (Player.HasStatus(true, StatusID.ReadyToBlast_3041) && HypervelocityPvP_29119.CanUse(out act)) return true;

            if (Player.HasStatus(true, StatusID.ReadyToGouge_2004) && EyeGougePvP_29122.CanUse(out act)) return true;
            if (Player.HasStatus(true, StatusID.ReadyToTear_2003) && AbdomenTearPvP_29121.CanUse(out act)) return true;
            if (Player.HasStatus(true, StatusID.ReadyToRip_2002) && JugularRipPvP_29120.CanUse(out act)) return true;
        }

        return base.AttackAbility(nextGCD, out act);
    }

    protected override bool GeneralAbility(IAction nextGCD, out IAction? act)
    {

        if (!InCombat && SprintPvP.CanUse(out act)) return true;

        if (TimeSinceLastAction.TotalSeconds > 4.5)
        {
            if (SprintPvP.CanUse(out act)) return true;
        }

        return base.GeneralAbility(nextGCD, out act);
    }

    protected override bool GeneralGCD(out IAction? act)
    {
        if (Player.HasStatus(true, StatusID.RelentlessRush))
        {
            act = null;
            return false;
        }

        if (GnashingFangPvP.Cooldown.IsCoolingDown)
        {
            if (IsLastGCD((ActionID)SavageClawPvP.ID) && WickedTalonPvP.CanUse(out act, skipComboCheck: true)) return true;
            if (IsLastGCD((ActionID)GnashingFangPvP.ID) && SavageClawPvP.CanUse(out act, skipComboCheck: true)) return true;
        }

        if (GnashingFangPvP.CanUse(out act)) return true;

        if (Player.HasStatus(true, StatusID.PowderBarrel) && BurstStrikePvP.CanUse(out act)) return true;

        if (Player.HasStatus(true, StatusID.NoMercy_3042) && DoubleDownPvP.CanUse(out act) && HasHostilesInRange) return true;

        if (SolidBarrelPvP.CanUse(out act)) return true;
        if (BrutalShellPvP.CanUse(out act)) return true;
        if (KeenEdgePvP.CanUse(out act)) return true;

        return base.GeneralGCD(out act);
    }
}
