namespace DefaultRotations.Magical;
[Rotation("smn-pvp", CombatType.PvP, GameVersion = "6.58", Description = "pvp skills")]
public class SMNPvP : SummonerRotation
{
    protected override bool EmergencyAbility(IAction nextGCD, out IAction? act)
    {

        if (RadiantAegisPvP.CanUse(out act)) return true;

        return base.EmergencyAbility(nextGCD, out act);
    }

    protected override bool AttackAbility(IAction nextGCD, out IAction? act)
    {

        if (FesterPvP.CanUse(out act)) return true;
        if (MountainBusterPvP.CanUse(out act)) return true;
        if (EnkindleBahamutPvP.CanUse(out act)) return true;
        if (EnkindlePhoenixPvP.CanUse(out act)) return true;

        return base.AttackAbility(nextGCD, out act);
    }
    protected override bool GeneralAbility(IAction nextGCD, out IAction? act)
    {

        return base.GeneralAbility(nextGCD, out act);
    }
    protected override bool GeneralGCD(out IAction? act)
    {

        if (SlipstreamPvP.CanUse(out act)) return true;

        if (RuinIiiPvP.CanUse(out act)) return true;

        if (CrimsonStrikePvP.CanUse(out act)) return true;
        if (CrimsonCyclonePvP.CanUse(out act)) return true;

        return base.GeneralGCD(out act);
    }
}