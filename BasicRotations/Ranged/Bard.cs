namespace DefaultRotations.Ranged;
[Rotation("Brd-pvp", CombatType.PvP, GameVersion = "6.58", Description = "PvP")]
[Api(1)]

public sealed class BRDPvP : BardRotation
{
    protected override bool EmergencyAbility(IAction nextGCD, out IAction? act)
    {

        if (Player.HasStatus(true, StatusID.Stun))
        {
            if (TheWardensPaeanPvP.CanUse(out act)) return true;
        }

        return base.EmergencyAbility(nextGCD, out act);
    }
    protected override bool AttackAbility(IAction nextGCD, out IAction? act)
    {

        if (Player.HasStatus(true, StatusID.FrontlineForte))
        {
            if (EmpyrealArrowPvP.Cooldown.CurrentCharges == 3 && EmpyrealArrowPvP.CanUse(out act)) return true;
        }

        if (SilentNocturnePvP.CanUse(out act)) return true;

        return base.AttackAbility(nextGCD, out act);
    }
    protected override bool GeneralAbility(IAction nextGCD, out IAction? act)
    {

        return base.GeneralAbility(nextGCD, out act);
    }
    protected override bool GeneralGCD(out IAction? act)
    {

        if (PitchPerfectPvP.CanUse(out act)) return true;

        if (BlastArrowPvP.CanUse(out act)) return true;
        if (ApexArrowPvP.CanUse(out act)) return true;

        if (PowerfulShotPvP.CanUse(out act)) return true;

        return base.GeneralGCD(out act);

    }
}
