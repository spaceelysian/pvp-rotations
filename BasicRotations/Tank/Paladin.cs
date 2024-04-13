namespace DefaultRotations.Tank;
[Rotation("pld-pvp", CombatType.PvP, GameVersion = "6.58", Description = "pvp skills")]
public class PLDPvP : PaladinRotation
{
    protected override bool EmergencyAbility(IAction nextGCD, out IAction? act)
    {

        return base.EmergencyAbility(nextGCD, out act);
    }
    protected override bool AttackAbility(IAction nextGCD, out IAction? act)
    {
        if (ShieldBashPvP.CanUse(out act)) return true;

        return base.AttackAbility(nextGCD, out act);
    }

    protected override bool GeneralGCD(out IAction? act)
    {
        if (ConfiteorPvP.CanUse(out act, skipAoeCheck:true)) return true;

        if (RoyalAuthorityPvP.CanUse(out act)) return true;
        if (RiotBladePvP.CanUse(out act)) return true;
        if (FastBladePvP.CanUse(out act)) return true;

        return base.GeneralGCD(out act);
    }
}