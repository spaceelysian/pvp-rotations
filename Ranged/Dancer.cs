namespace DefaultRotations.Ranged;
[Rotation("dnc-pvp", CombatType.PvP, GameVersion = "6.58", Description = "pvp skills")]
public class DNCPvP : DancerRotation
{

    protected override bool EmergencyAbility(IAction nextGCD, out IAction? act)
    {
        if (CuringWaltzPvP.CanUse(out act)) return true;
        return base.EmergencyAbility(nextGCD, out act);
    }

    protected override bool AttackAbility(IAction nextGCD, out IAction? act)
    {
        if (FanDancePvP.CanUse(out act, skipAoeCheck: true)) return true;
        return base.AttackAbility(nextGCD, out act);
    }

    protected override bool GeneralGCD(out IAction? act)
    {
        if (StarfallDancePvP.CanUse(out act, skipAoeCheck:true)) return true;
        if (FountainPvP.CanUse(out act)) return true;
        if (CascadePvP.CanUse(out act)) return true;
        return base.GeneralGCD(out act);
    }
}