namespace DefaultRotations.Healer;
[Rotation("ast-pvp", CombatType.PvP, GameVersion = "6.58", Description = "pvp skills")]
public class ASTPvP : AstrologianRotation
{
    protected override bool EmergencyAbility(IAction nextGCD, out IAction? act)
    {

        if (AspectedBeneficPvP_29247.CanUse(out act)) return true;

        return base.EmergencyAbility(nextGCD, out act);

    }

    protected override bool AttackAbility(IAction nextGCD, out IAction? act)
    {

        //if (GravityIiPvP_29248.CanUse(out act, skipAoeCheck: true)) return true;
        //if (DoubleCastPvP.CanUse(out act)) return true;

        return base.AttackAbility(nextGCD, out act);

    }
    protected override bool GeneralAbility(IAction nextGCD, out IAction? act)
    {

        //if (TheArrowPvP.CanUse(out act)) return true;
        //if (TheBalancePvP.CanUse(out act)) return true;
        //if (TheBolePvP.CanUse(out act)) return true;
        if (DrawPvP.CanUse(out act)) return true;

        if (MacrocosmosPvP.CanUse(out act)) return true;
        if (MicrocosmosPvP.CanUse(out act)) return true;

        return base.GeneralAbility(nextGCD, out act);

    }

    protected override bool GeneralGCD(out IAction? act)
    {

        if (GravityIiPvP.CanUse(out act)) return true;

        if (FallMaleficPvP.CanUse(out act)) return true;

        if (AspectedBeneficPvP.CanUse(out act)) return true;

        return base.GeneralGCD(out act);

    }
}