namespace DefaultRotations.Melee;

[Rotation("nin-pvp", CombatType.PvP, GameVersion = "6.58", Description = "pvp skills")]
public class NINPvP : NinjaRotation
{
    protected override bool EmergencyAbility(IAction nextGCD, out IAction? act)
    {

        return base.EmergencyAbility(nextGCD, out act);
    }

    protected override bool AttackAbility(IAction nextGCD, out IAction? act)
    {

        return base.AttackAbility(nextGCD, out act);
    }

    protected override bool GeneralGCD(out IAction? act)
    {
        if (AeolianEdgePvP.CanUse(out act)) return true;
        if (GustSlashPvP.CanUse(out act)) return true;
        if (SpinningEdgePvP.CanUse(out act)) return true;
        if (FumaShurikenPvP.CanUse(out act)) return true;
        return base.GeneralGCD(out act);
    }
}