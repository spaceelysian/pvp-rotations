namespace DefaultRotations.Melee;
[Rotation("Nin-PvP", CombatType.PvP, GameVersion = "6.58", Description = "PvP")]
[Api(1)]

public class NINPvP : NinjaRotation
{
    protected override bool EmergencyAbility(IAction nextGCD, out IAction? act)
    {

        return base.EmergencyAbility(nextGCD, out act);
    }

    protected override bool AttackAbility(IAction nextGCD, out IAction? act)
    {

        if (!Player.HasStatus(true, StatusID.ThreeMudra) && FumaShurikenPvP.Cooldown.CurrentCharges <= 1 && MugPvP.CanUse(out act)) return true;

        return base.AttackAbility(nextGCD, out act);
    }
    protected override bool GeneralAbility(IAction nextGCD, out IAction? act)
    {


        return base.GeneralAbility(nextGCD, out act);
    }
    protected override bool GeneralGCD(out IAction? act)
    {

        if (Player.HasStatus(true, StatusID.Hidden_1705))
        {
            act = null;
            if (AssassinatePvP.CanUse(out act)) return true;
            return false;
        }

        if (Player.HasStatus(true, StatusID.ThreeMudra))
        {
            act = null;
            return false;
        }

        if (FumaShurikenPvP.Cooldown.CurrentCharges == 3 && FumaShurikenPvP.CanUse(out act)) return true;

        if (AeolianEdgePvP.CanUse(out act)) return true;
        if (GustSlashPvP.CanUse(out act)) return true;
        if (SpinningEdgePvP.CanUse(out act)) return true;

        if (FumaShurikenPvP.Cooldown.CurrentCharges > 1 && FumaShurikenPvP.CanUse(out act, usedUp: true)) return true;
        if (FumaShurikenPvP.Target.Target?.GetHealthRatio() < 0.5 && FumaShurikenPvP.CanUse(out act, usedUp: true)) return true;

        return base.GeneralGCD(out act);
    }
}