namespace DefaultRotations.Healer;

[Rotation("whm-pvp", CombatType.PvP, GameVersion = "6.58", Description = "pvp skills")]
public class WHM : WhiteMageRotation
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