namespace DefaultRotations.Healer;
[Rotation("sch-pvp", CombatType.PvP, GameVersion = "6.58", Description = "pvp skills")]
public class SCHPvP : ScholarRotation
{
    protected override bool EmergencyAbility(IAction nextGCD, out IAction? act)
    {

        if (AdloquiumPvP.CanUse(out act)) return true;
        if (DeploymentTacticsPvP.CanUse(out act)) return true;

        return base.EmergencyAbility(nextGCD, out act);
    }

    protected override bool AttackAbility(IAction nextGCD, out IAction? act)
    {
        if (MummificationPvP.CanUse(out act, skipAoeCheck: true)) return true;

        return base.AttackAbility(nextGCD,out act);
    }
    protected override bool GeneralAbility(IAction nextGCD, out IAction? act)
    {

        if (ExpedientPvP.CanUse(out act)) return true;

        return base.GeneralAbility(nextGCD, out act);
    }
    protected override bool GeneralGCD(out IAction? act)
    {

        if (BiolysisPvP.CanUse(out act)) return true;

        if (BroilIvPvP.CanUse(out act)) return true;

        return base.GeneralGCD(out act);
    }
}