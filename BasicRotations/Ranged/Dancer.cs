namespace DefaultRotations.Ranged;
[Rotation("Dnc-PvP", CombatType.PvP, GameVersion = "6.58", Description = "PvP")]
[Api(1)]

public class DNCPvP : DancerRotation
{

    protected override bool EmergencyAbility(IAction nextGCD, out IAction? act)
    {

        if (CuringWaltzPvP.CanUse(out act, skipAoeCheck: true) && (Player.CurrentHp < Player.MaxHp)) return true;

        return base.EmergencyAbility(nextGCD, out act);
    }

    protected override bool AttackAbility(IAction nextGCD, out IAction? act)
    {

        if (Player.HasStatus(true, StatusID.SaberDance) && FanDancePvP.CanUse(out act, skipAoeCheck: true)) return true;

        return base.AttackAbility(nextGCD, out act);
    }

    protected override bool GeneralAbility(IAction nextGCD, out IAction? act)
    {

        if (!InCombat && SprintPvP.CanUse(out act)) return true;

        if (TimeSinceLastAction.TotalSeconds > 4.5)
        {
            if (SprintPvP.CanUse(out act)) return true;
        }

        return base.GeneralAbility(nextGCD, out act);
    }

    protected override bool GeneralGCD(out IAction? act)
    {

        if (Player.HasStatus(true, StatusID.SaberDance) && StarfallDancePvP.CanUse(out act, skipAoeCheck: true)) return true;

        if (FountainPvP.CanUse(out act)) return true;
        if (CascadePvP.CanUse(out act)) return true;

        return base.GeneralGCD(out act);
    }
}