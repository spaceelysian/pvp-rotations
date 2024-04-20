namespace DefaultRotations.Healer;
[Rotation("Sge-PvP", CombatType.PvP, GameVersion = "6.58", Description = "PvP")]
[Api(1)]

public class SGEPvP : SageRotation
{
    protected override bool EmergencyAbility(IAction nextGCD, out IAction? act)
    {

        return base.EmergencyAbility(nextGCD, out act);
    }

    protected override bool AttackAbility(IAction nextGCD, out IAction? act)
    {

        if (!HostileTarget.HasStatus(true, StatusID.Toxikon) && ToxikonPvP.CanUse(out act, skipAoeCheck: true, usedUp: true)) return true;

        return base.AttackAbility(nextGCD, out act);
    }

    protected override bool GeneralAbility(IAction nextGCD, out IAction? act)
    {

        if (!InCombat && SprintPvP.CanUse(out act)) return true;

        if (EukrasiaPvP.Cooldown.CurrentCharges == 2 && EukrasiaPvP.CanUse(out act)) return true;

        return base.GeneralAbility(nextGCD, out act);
    }

    protected override bool GeneralGCD(out IAction? act)
    {

        if (PneumaPvP.CanUse(out act, skipAoeCheck: true)) return true;

        if (PhlegmaIiiPvP.CanUse(out act, skipAoeCheck: true, usedUp: true)) return true;

        if (DosisIiiPvP.CanUse(out act)) return true;

        return base.GeneralGCD(out act);
    }
}