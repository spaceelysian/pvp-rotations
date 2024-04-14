namespace DefaultRotations.Healer;
[Rotation("sge-pvp", CombatType.PvP, GameVersion = "6.58", Description = "pvp skills")]
public class SGEPvP : SageRotation
{
    protected override bool EmergencyAbility(IAction nextGCD, out IAction? act)
    {

        return base.EmergencyAbility(nextGCD, out act);

    }

    protected override bool AttackAbility(IAction nextGCD, out IAction? act)
    {

        if (ToxikonPvP.CanUse(out act)) return true;

        return base.AttackAbility(nextGCD, out act);

    }
    protected override bool GeneralAbility(IAction nextGCD, out IAction? act)
    {

        return base.GeneralAbility(nextGCD, out act);

    }
    protected override bool GeneralGCD(out IAction? act)
    {

        if (PneumaPvP.CanUse(out act)) return true;

        if (PhlegmaIiiPvP.CanUse(out act)) return true;

        if (DosisIiiPvP.CanUse(out act)) return true;

        return base.GeneralGCD(out act);

    }
}