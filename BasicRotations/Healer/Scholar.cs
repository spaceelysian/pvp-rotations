using Newtonsoft.Json.Linq;

namespace DefaultRotations.Healer;

[Rotation("sch-pvp", CombatType.PvP, GameVersion = "6.58", Description = "pvp skills")]
public class SCHPvP : ScholarRotation
{
    protected override bool EmergencyAbility(IAction nextGCD, out IAction? act)
    {

        return base.EmergencyAbility(nextGCD, out act);
    }

    protected override bool AttackAbility(out IAction? act)
    {

        return base.AttackAbility(out act);
    }

    protected override bool GeneralGCD(out IAction? act)
    {

        return base.GeneralGCD(out act);
    }
}