namespace DefaultRotations.Melee;
[Rotation("drg-pvp", CombatType.PvP, GameVersion = "6.58", Description = "pvp skills")]
public class DRGPvP : DragoonRotation
{
    protected override bool EmergencyAbility(IAction nextGCD, out IAction? act)
    {

        if (HorridRoarPvP.CanUse(out act)) return true;

        return base.EmergencyAbility(nextGCD, out act);
    }

    protected override bool AttackAbility(IAction nextGCD, out IAction? act)
    {

        if (GeirskogulPvP.CanUse(out act, skipAoeCheck: true)) return true;
        if (NastrondPvP.CanUse(out act, skipAoeCheck: true)) return true;

        //if (HighJumpPvP.CanUse(out act)) return true;

        return base.AttackAbility(nextGCD, out act);
    }
    protected override bool GeneralAbility(IAction nextGCD, out IAction? act)
    {

        //if (ElusiveJumpPvP.CanUse(out act)) return true;

        return base.GeneralAbility(nextGCD, out act);
    }
    protected override bool GeneralGCD(out IAction? act)
    {

        if (Player.HasStatus(true, StatusID.FirstmindsFocus) && WyrmwindThrustPvP.CanUse(out act, skipAoeCheck:true)) return true;

        if ((Player.CurrentHp < Player.MaxHp) && ChaoticSpringPvP.CanUse(out act)) return true;

        if (WheelingThrustPvP.CanUse(out act)) return true;
        if (FangAndClawPvP.CanUse(out act)) return true;
        if (RaidenThrustPvP.CanUse(out act)) return true;

        return base.GeneralGCD(out act);
    }
}