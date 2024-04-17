namespace DefaultRotations.Melee;
[Rotation("Drg-PvP", CombatType.PvP, GameVersion = "6.58", Description = "PvP")]
[Api(1)]

public class DRGPvP : DragoonRotation
{
    protected override bool EmergencyAbility(IAction nextGCD, out IAction? act)
    {

        if (HasHostilesInRange && HorridRoarPvP.CanUse(out act, skipAoeCheck: true)) return true;

        return base.EmergencyAbility(nextGCD, out act);
    }

    protected override bool AttackAbility(IAction nextGCD, out IAction? act)
    {

        if (HighJumpPvP.CanUse(out act)) return true;

        if (GeirskogulPvP.CanUse(out act, skipAoeCheck: true)) return true;
        if (NastrondPvP.CanUse(out act, skipAoeCheck: true)) return true;

        return base.AttackAbility(nextGCD, out act);
    }
    protected override bool GeneralAbility(IAction nextGCD, out IAction? act)
    {

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