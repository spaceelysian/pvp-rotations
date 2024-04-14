namespace DefaultRotations.Tank;
[Rotation("drk-pvp", CombatType.PvP, GameVersion = "6.58", Description = "pvp skills")]
public sealed class DRKPvP : DarkKnightRotation
{
    protected override bool EmergencyAbility(IAction nextGCD, out IAction? act)
    {
        if (TheBlackestNightPvP.CanUse(out act)) return true;

        return base.EmergencyAbility(nextGCD, out act);
    }

    protected override bool AttackAbility(IAction nextGCD, out IAction? act)
    {

        if (SaltAndDarknessPvP.CanUse(out act)) return true;
        if (SaltedEarthPvP.CanUse(out act)) return true;

        return base.AttackAbility(nextGCD, out act);
    }
    protected override bool GeneralAbility(IAction nextGCD, out IAction? act)
    {

        return base.GeneralAbility(nextGCD, out act);
    }
    protected override bool GeneralGCD(out IAction? act)
    {

        if (QuietusPvP.CanUse(out act)) return true;

        if (SouleaterPvP.CanUse(out act)) return true;
        if (SyphonStrikePvP.CanUse(out act)) return true;
        if (HardSlashPvP.CanUse(out act)) return true;

        return base.GeneralGCD(out act);
    }
}
