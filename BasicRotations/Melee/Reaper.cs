namespace DefaultRotations.Melee;
[Rotation("rpr-pvp", CombatType.PvP, GameVersion = "6.58", Description = "pvp skills")]
public sealed class RPRPvP : ReaperRotation
{
    protected override bool EmergencyAbility(IAction nextGCD, out IAction? act)
    {

        if (ArcaneCrestPvP.CanUse(out act)) return true;

        return base.EmergencyAbility(nextGCD, out act);
    }

    protected override bool AttackAbility(IAction nextGCD, out IAction? act)
    {

        if (GrimSwathePvP.CanUse(out act)) return true;

        if (LemuresSlicePvP.CanUse(out act)) return true;

        if (HarvestMoonPvP.CanUse(out act)) return true;

        return base.AttackAbility(nextGCD, out act);
    }
    protected override bool GeneralAbility(IAction nextGCD, out IAction? act)
    {

        return base.GeneralAbility(nextGCD, out act);
    }
    protected override bool GeneralGCD(out IAction? act)
    {

        //if (VoidReapingPvP.CanUse(out act, usedUp: true)) return true;
        //if (CrossReapingPvP.CanUse(out act, usedUp: true)) return true;
        //if (CommunioPvP.CanUse(out act, usedUp: true)) return true;

        if (SoulSlicePvP.CanUse(out act, usedUp: true)) return true;

        if (PlentifulHarvestPvP.CanUse(out act)) return true;

        if (InfernalSlicePvP.CanUse(out act)) return true;
        if (WaxingSlicePvP.CanUse(out act)) return true;
        if (SlicePvP.CanUse(out act)) return true;

        return base.GeneralGCD(out act);
    }
}