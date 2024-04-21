namespace DefaultRotations.Tank;
[Rotation("Drk-PvP", CombatType.PvP, GameVersion = "6.58", Description = "PvP")]
[Api(1)]

public sealed class DRKPvP : DarkKnightRotation
{
    #region Settings
    [RotationConfig(CombatType.PvP, Name = "Use Sprint?")]
    public bool UseSprint { get; set; } = true;
    #endregion

    protected override bool EmergencyAbility(IAction nextGCD, out IAction? act)
    {

        if ((Player.CurrentHp < Player.MaxHp) && TheBlackestNightPvP.CanUse(out act)) return true;

        return base.EmergencyAbility(nextGCD, out act);
    }
    protected override bool AttackAbility(IAction nextGCD, out IAction? act)
    {

        if (IsLastAbility((ActionID)PlungePvP.ID) && SaltedEarthPvP.CanUse(out act) && HasHostilesInRange) return true;

        if (IsLastAbility((ActionID)SaltedEarthPvP.ID) && SaltAndDarknessPvP.CanUse(out act)) return true;

        if (Player.HasStatus(true, StatusID.DarkArts_3034) && ShadowbringerPvP_29738.CanUse(out act, skipAoeCheck: true)) return true;

        return base.AttackAbility(nextGCD, out act);
    }

    protected override bool GeneralAbility(IAction nextGCD, out IAction? act)
    {

        if (UseSprint)
        {
            if (!InCombat && SprintPvP.CanUse(out act)) return true;

            if (TimeSinceLastAction.TotalSeconds > 5)
            {
                if (SprintPvP.CanUse(out act)) return true;
            }
        }

        if (TheBlackestNightPvP.Target.Target?.GetHealthRatio() < 0.9 && TheBlackestNightPvP.CanUse(out act)) return true;

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
