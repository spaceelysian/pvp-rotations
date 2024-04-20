namespace DefaultRotations.Healer;
[Rotation("Sch-PvP", CombatType.PvP, GameVersion = "6.58", Description = "PvP")]
[Api(1)]

public class SCHPvP : ScholarRotation
{
    protected override bool EmergencyAbility(IAction nextGCD, out IAction? act)
    {

        return base.EmergencyAbility(nextGCD, out act);
    }

    protected override bool AttackAbility(IAction nextGCD, out IAction? act)
    {

        if (MummificationPvP.CanUse(out act, skipAoeCheck: true)) return true;

        return base.AttackAbility(nextGCD,out act);
    }

    protected override bool GeneralAbility(IAction nextGCD, out IAction? act)
    {

        if (!InCombat && SprintPvP.CanUse(out act)) return true;

        if (ExpedientPvP.CanUse(out act)) return true;

        if (AdloquiumPvP.CanUse(out act) && AdloquiumPvP.Target.Target?.GetHealthRatio() < 0.9) return true;
 
        return base.GeneralAbility(nextGCD, out act);
    }

    protected override bool GeneralGCD(out IAction? act)
    {

        if (BiolysisPvP.CanUse(out act)) return true;

        if (BroilIvPvP.CanUse(out act)) return true;

        return base.GeneralGCD(out act);
    }
}