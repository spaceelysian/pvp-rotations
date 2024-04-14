namespace DefaultRotations.Tank;
[Rotation("war-pvp", CombatType.PvP, GameVersion = "6.58", Description = "pvp skills")]
public sealed class WARPvP : WarriorRotation
{
    protected override bool EmergencyAbility(IAction nextGCD, out IAction? act)
    {

        return base.EmergencyAbility(nextGCD, out act);

    }

    protected override bool AttackAbility(IAction nextGCD, out IAction? act)
    {
        // if (BlotaPvP.CanUse(out act)) return true;

        if (OrogenyPvP.CanUse(out act)) return true;
        if (OnslaughtPvP.CanUse(out act)) return true;

        return base.AttackAbility(nextGCD, out act);

    }
    protected override bool GeneralAbility(IAction nextGCD, out IAction? act)
    {

        if (BloodwhettingPvP.CanUse(out act)) return true;

        return base.GeneralAbility(nextGCD, out act);

    }
    protected override bool GeneralGCD(out IAction? act)
    {

        if (PrimalRendPvP.CanUse(out act)) return true;

        if (ChaoticCyclonePvP.CanUse(out act)) return true;

        // if (FellCleavePvP.CanUse(out act)) return true;

        if (StormsPathPvP.CanUse(out act)) return true;
        if (MaimPvP.CanUse(out act)) return true;
        if (HeavySwingPvP.CanUse(out act)) return true;

        return base.GeneralGCD(out act);

    }

}