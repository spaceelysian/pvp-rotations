namespace DefaultRotations.Melee;
[Rotation("Mnk-PvP", CombatType.PvP, GameVersion = "6.58", Description = "PvP")]
public sealed class MNKPvP : MonkRotation
{
    protected override bool EmergencyAbility(IAction nextGCD, out IAction? act)
    {

        return base.EmergencyAbility(nextGCD, out act);
    }

    protected override bool AttackAbility(IAction nextGCD, out IAction? act)
    {

        return base.AttackAbility(nextGCD, out act);
    }
    protected override bool GeneralAbility(IAction nextGCD, out IAction? act)
    {

        return base.GeneralAbility(nextGCD, out act);
    }
    protected override bool GeneralGCD(out IAction? act)
    {

        return base.GeneralGCD(out act);
    }
}