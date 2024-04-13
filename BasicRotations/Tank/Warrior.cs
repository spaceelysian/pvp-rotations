namespace DefaultRotations.Tank;
[Rotation("gnb-pvp", CombatType.PvP, GameVersion = "6.58", Description = "pvp skills")]
public sealed class WARPvP : WarriorRotation
{
    protected override bool EmergencyAbility(IAction nextGCD, out IAction? act)
    {

        return base.EmergencyAbility(nextGCD, out act);
    }

    protected override bool AttackAbility(out IAction? act)
    {

        if (BloodwhettingPvP.CanUse(out act)) return true;
        if (OrogenyPvP.CanUse(out act, skipAoeCheck: true)) return true;
        if (OnslaughtPvP.CanUse(out act)) return true;
        return base.AttackAbility(out act);
    }

    protected override bool GeneralGCD(out IAction? act)
    {
        if (ChaoticCyclonePvP.CanUse(out act)) return true;

        if (PrimalRendPvP.CanUse(out act)) return true;

        if (StormsPathPvP.CanUse(out act)) return true;
        if (MaimPvP.CanUse(out act)) return true;
        if (HeavySwingPvP.CanUse(out act)) return true;

        return base.GeneralGCD(out act);
    }
}