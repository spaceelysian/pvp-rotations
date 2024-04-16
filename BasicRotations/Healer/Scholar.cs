namespace DefaultRotations.Healer;
[Rotation("Sch-PvP", CombatType.PvP, GameVersion = "6.58", Description = "PvP")]
public class SCHPvP : ScholarRotation
{
    protected override bool EmergencyAbility(IAction nextGCD, out IAction? act)
    {

        //if (AdloquiumPvP.CanUse(out act) && Player.CurrentHp < Player.MaxHp) return true;

        return base.EmergencyAbility(nextGCD, out act);
    }

    protected override bool AttackAbility(IAction nextGCD, out IAction? act)
    {

        // if (HostileTarget.HasStatus(true, StatusID.Biolysis_3089) && DeploymentTacticsPvP.CanUse(out act)) return true;

        if (MummificationPvP.CanUse(out act, skipAoeCheck: true)) return true;

        return base.AttackAbility(nextGCD,out act);
    }
    protected override bool GeneralAbility(IAction nextGCD, out IAction? act)
    {

        //if (ExpedientPvP.CanUse(out act)) return true;

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