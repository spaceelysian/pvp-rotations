namespace DefaultRotations.Melee;
[Rotation("Rpr-PvP", CombatType.PvP, GameVersion = "6.58", Description = "PvP")]
[Api(1)]

public sealed class RPRPvP : ReaperRotation
{
    protected override bool EmergencyAbility(IAction nextGCD, out IAction? act)
    {

        if (ArcaneCrestPvP.CanUse(out act) && HasHostilesInRange) return true;

        return base.EmergencyAbility(nextGCD, out act);
    }

    protected override bool AttackAbility(IAction nextGCD, out IAction? act)
    {

        if (Player.HasStatus(true, StatusID.Soulsow_2750) && HarvestMoonPvP.CanUse(out act)) return true;

        if (GrimSwathePvP.CanUse(out act, skipAoeCheck: true)) return true;


        return base.AttackAbility(nextGCD, out act);
    }

    protected override bool GeneralAbility(IAction nextGCD, out IAction? act)
    {

        return base.GeneralAbility(nextGCD, out act);
    }

    protected override bool GeneralGCD(out IAction? act)
    {

        if (Player.HasStatus(true, StatusID.Enshrouded_2863))
        {
            if (LemuresSlicePvP.CanUse(out act, skipAoeCheck: true)) return true;
        }

        if (SoulSlicePvP.CanUse(out act, usedUp: true)) return true;

        if (PlentifulHarvestPvP.CanUse(out act)) return true;


        if (InfernalSlicePvP.CanUse(out act)) return true;
        if (WaxingSlicePvP.CanUse(out act)) return true;
        if (SlicePvP.CanUse(out act)) return true;

        return base.GeneralGCD(out act);
    }
}