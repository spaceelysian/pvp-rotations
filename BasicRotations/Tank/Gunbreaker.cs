namespace DefaultRotations.Tank;
[Rotation("gnb-pvp", CombatType.PvP, GameVersion = "6.58", Description = "pvp skills")]
public sealed class GNBPvP : GunbreakerRotation
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
