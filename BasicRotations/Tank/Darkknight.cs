namespace PvPRotations.Tank;
[Rotation("Drk-PvP", CombatType.PvP, GameVersion = "6.58", Description = "PvP")]
[Api(2)]

public sealed class DRKPvP : DarkKnightRotation
{
    #region Settings
    [RotationConfig(CombatType.PvP, Name = "Use Sprint out of combat?")]
    public bool UseSprint { get; set; } = true;
    #endregion

    protected override bool EmergencyAbility(IAction nextGCD, out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;
        if (Player.GetHealthRatio() < 0.7 && RecuperatePvP.CanUse(out act)) return true;

        if (Player.CurrentHp < Player.MaxHp && TheBlackestNightPvP.CanUse(out act)) return true;

        return base.EmergencyAbility(nextGCD, out act);
    }
    protected override bool AttackAbility(IAction nextGCD, out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;

        if (SaltedEarthPvP.CanUse(out act)) return true;

        if (SaltAndDarknessPvP.CanUse(out act, skipAoeCheck: true)) return true;

        if (Player.HasStatus(true, StatusID.DarkArts_3034) && ShadowbringerPvP_29738.CanUse(out act, skipAoeCheck: true)) return true;

        return base.AttackAbility(nextGCD, out act);
    }

    protected override bool GeneralAbility(IAction nextGCD, out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;
        if (UseSprint) { if (!InCombat && SprintPvP.CanUse(out act)) return true; }

        return base.GeneralAbility(nextGCD, out act);
    }

    protected override bool GeneralGCD(out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;

        if ((Player.CurrentHp < Player.MaxHp) && QuietusPvP.CanUse(out act)) return true;

        if (SouleaterPvP.CanUse(out act)) return true;
        if (SyphonStrikePvP.CanUse(out act)) return true;
        if (HardSlashPvP.CanUse(out act)) return true;

        return base.GeneralGCD(out act);
    }
}
