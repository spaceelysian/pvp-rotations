namespace DefaultRotations.Healer;
[Rotation("Whm-PvP", CombatType.PvP, GameVersion = "6.58", Description = "PvP")]
public class WHM : WhiteMageRotation
{
    protected override bool EmergencyAbility(IAction nextGCD, out IAction? act)
    {

        if (AquaveilPvP.CanUse(out act) && AquaveilPvP.Target.Target?.GetHealthRatio() < 0.8) return true;

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

        if (AfflatusMiseryPvP.CanUse(out act, skipAoeCheck:true)) return true;

        if (GlareIiiPvP.CanUse(out act)) return true;

        if (Player.CurrentHp < Player.MaxHp && CureIiiPvP.CanUse(out act)) return true;

        if (CureIiPvP.CanUse(out act)) return true;

        return base.GeneralGCD(out act);
    }
}