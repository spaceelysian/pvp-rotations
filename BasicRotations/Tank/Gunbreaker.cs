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

        return base.AttackAbility(nextGCD, out act);
    }

    protected override bool GeneralAbility(IAction nextGCD, out IAction? act)
    {

        return base.GeneralAbility(nextGCD, out act);
    }

    protected override bool GeneralGCD(out IAction? act)
    {

        if (DoubleDownPvP.CanUse(out act)) return true;

        if (SolidBarrelPvP.CanUse(out act)) return true;
        if (BrutalShellPvP.CanUse(out act)) return true;
        if (KeenEdgePvP.CanUse(out act)) return true;

        return base.GeneralGCD(out act);
    }
}
