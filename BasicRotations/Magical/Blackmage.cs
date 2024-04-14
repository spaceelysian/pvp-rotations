namespace DefaultRotations.Magical;
[Rotation("blm-pvp", CombatType.PvP, GameVersion = "6.58", Description = "pvp skills")]
public class BLMPvP : BlackMageRotation
{

    protected override bool EmergencyAbility(IAction nextGCD, out IAction? act)
    {



        return base.EmergencyAbility(nextGCD, out act);
    }

    protected override bool AttackAbility(IAction nextGCD, out IAction? act)
    {

        if (NightWingPvP.CanUse(out act)) return true;

        if (SuperflarePvP.CanUse(out act)) return true;

        return base.AttackAbility(nextGCD, out act);
    }

    protected override bool GeneralAbility(IAction nextGCD, out IAction? act)
    {

        if (AetherialManipulationPvP.CanUse(out act)) return true;

        return base.GeneralAbility(nextGCD, out act);
    }
    protected override bool GeneralGCD(out IAction? act)
    {

        if (BurstPvP.CanUse(out act)) return true;

        if (ParadoxPvP.CanUse(out act)) return true;

        if (FirePvP.CanUse(out act)) return true;
        if (BlizzardPvP.CanUse(out act)) return true;

        return base.GeneralGCD(out act);
    }
}