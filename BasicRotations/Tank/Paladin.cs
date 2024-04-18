namespace DefaultRotations.Tank;
[Rotation("Pld-PvP", CombatType.PvP, GameVersion = "6.58", Description = "PvP")]
[Api(1)]

public class PLDPvP : PaladinRotation
{

    protected override bool EmergencyAbility(IAction nextGCD, out IAction? act)
    {

        if (GuardianPvP.Target.Target?.GetHealthRatio() < 0.3 && GuardianPvP.CanUse(out act)) return true;

        return base.EmergencyAbility(nextGCD, out act);
    }
    protected override bool AttackAbility(IAction nextGCD, out IAction? act)
    {

        if (ShieldBashPvP.CanUse(out act)) return true;

        return base.AttackAbility(nextGCD, out act);
    }

    protected override bool GeneralAbility(IAction nextGCD, out IAction? act)
    {

        if (HolySheltronPvP.CanUse(out act)) return true;

        return base.GeneralAbility(nextGCD, out act);
    }

    protected override bool GeneralGCD(out IAction? act)
    {

        if (ConfiteorPvP.CanUse(out act, skipAoeCheck: true)) return true;

        if (RoyalAuthorityPvP.CanUse(out act)) return true;
        if (RiotBladePvP.CanUse(out act)) return true;
        if (FastBladePvP.CanUse(out act)) return true;

        return base.GeneralGCD(out act);
    }
}