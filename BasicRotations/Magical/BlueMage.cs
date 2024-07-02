namespace PvPRotations.Magical;
[Rotation("Bloops", CombatType.PvE, GameVersion = "6.58", Description = "Bluest mage")]
[Api(2)]

public class BlueMage : BlueMageRotation
{
    protected override bool EmergencyAbility(IAction nextGCD, out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Diamondback)) return false;

        return base.EmergencyAbility(nextGCD, out act);
    }

    protected override bool AttackAbility(IAction nextGCD, out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Diamondback)) return false;

        if (QuasarPvE.CanUse(out act)) return true;
        if (ShockStrikePvE.CanUse(out act)) return true;

        if (GlassDancePvE.CanUse(out act)) return true;

        if (BeingMortalPvE.CanUse(out act)) return true;
        if (SeaShantyPvE.CanUse(out act)) return true;
        if (NightbloomPvE.CanUse(out act)) return true;

        return base.AttackAbility(nextGCD, out act);
    }

    protected override bool GeneralAbility(IAction nextGCD, out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Diamondback)) return false;

        return base.GeneralAbility(nextGCD, out act);
    }

    protected override bool MoveForwardAbility(IAction nextGCD, out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Diamondback)) return false;

        if (FeatherRainPvE.CanUse(out act)) return true;

        return base.MoveForwardAbility(nextGCD, out act);
    }

    protected override bool HealSingleGCD(out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Diamondback)) return false;

        return base.HealSingleGCD(out act);
    }

    protected override bool HealAreaGCD(out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Diamondback)) return false;

        return base.HealAreaGCD(out act);
    }

    protected override bool DefenseSingleGCD(out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Diamondback)) return false;

        if (!Player.HasStatus(true, StatusID.ToadOil) && ToadOilPvE.CanUse(out act)) return true;

        return base.HealAreaGCD(out act);
    }

    protected override bool DefenseAreaGCD(out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Diamondback)) return false;

        if (!Player.HasStatus(true, StatusID.Gobskin) && GobskinPvE.CanUse(out act)) return true;

        return base.HealAreaGCD(out act);
    }

    protected override bool MoveForwardGCD(out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Diamondback)) return false;

        return base.MoveForwardGCD(out act);
    }

    protected override bool GeneralGCD(out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Diamondback)) return false;

        if (SonicBoomPvE.CanUse(out act)) return true;

        return base.GeneralGCD(out act);
    }
}