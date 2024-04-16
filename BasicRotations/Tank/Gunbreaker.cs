namespace DefaultRotations.Tank;
[Rotation("Gnb-PvP", CombatType.PvP, GameVersion = "6.58", Description = "PvP")]
public sealed class GNBPvP : GunbreakerRotation
{
    protected override bool EmergencyAbility(IAction nextGCD, out IAction? act)
    {

        return base.EmergencyAbility(nextGCD, out act);
    }

    protected override bool AttackAbility(IAction nextGCD, out IAction? act)
    {
        //if (ContinuationPvP.CanUse(out act)) return true;

        //if (EyeGougePvP_29114.CanUse(out act) && Player.HasStatus(true, StatusID.ReadyToGouge_2004)) return true;
        //if (AbdomenTearPvP_29113.CanUse(out act) && Player.HasStatus(true, StatusID.ReadyToTear_2003)) return true;
        //if (JugularRipPvP_29112.CanUse(out act) && Player.HasStatus(true, StatusID.ReadyToRip_2002)) return true;

        return base.AttackAbility(nextGCD, out act);
    }

    protected override bool GeneralAbility(IAction nextGCD, out IAction? act)
    {

        return base.GeneralAbility(nextGCD, out act);
    }

    protected override bool GeneralGCD(out IAction? act)
    {

        if (SolidBarrelPvP.CanUse(out act)) return true;
        if (BrutalShellPvP.CanUse(out act)) return true;
        if (KeenEdgePvP.CanUse(out act)) return true;

        return base.GeneralGCD(out act);
    }
}
