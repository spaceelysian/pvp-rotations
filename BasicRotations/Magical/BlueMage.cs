namespace PvPRotations.Magical;
[Rotation("Blue", CombatType.PvE, GameVersion = "6.58", Description = "Bluest mage")]
[Api(1)]

public class BlueMage : BlueMageRotation
{
    #region Settings
    [RotationConfig(CombatType.PvE, Name = "Zzz?")]
    public bool UseSprint { get; set; } = true;
    #endregion

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

        return base.MoveForwardAbility(nextGCD, out act);
    }

    protected override bool GeneralGCD(out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Diamondback)) return false;

        return base.GeneralGCD(out act);
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

    protected override bool MoveForwardGCD(out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Diamondback)) return false;

        return base.MoveForwardGCD(out act);
    }
}