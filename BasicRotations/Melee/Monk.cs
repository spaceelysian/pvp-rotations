namespace DefaultRotations.Melee;
[Rotation("Mnk-PvP", CombatType.PvP, GameVersion = "6.58", Description = "PvP")]
[Api(1)]

public sealed class MNKPvP : MonkRotation
{
    #region Settings
    [RotationConfig(CombatType.PvP, Name = "Use Sprint?")]
    public bool UseSprint { get; set; } = true;
    #endregion

    protected override bool EmergencyAbility(IAction nextGCD, out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;

        if (IsLastGCD((ActionID)DemolishPvP.ID) && RisingPhoenixPvP.CanUse(out act, skipAoeCheck: true)) return true;

        if (RiddleOfEarthPvP.CanUse(out act, skipAoeCheck: true) && HasHostilesInRange) return true;

        if (IsLastGCD((ActionID)EnlightenmentPvP.ID) && ThunderclapPvP.CanUse(out act)) return true;

        return base.EmergencyAbility(nextGCD, out act);
    }

    protected override bool AttackAbility(IAction nextGCD, out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;

        if (SixsidedStarPvP.CanUse(out act)) return true;

        if (Player.WillStatusEnd(4, true, StatusID.EarthResonance) && EarthsReplyPvP.CanUse(out act, skipAoeCheck: true)) return true;
        if ((Player.CurrentHp < 20000) && EarthsReplyPvP.CanUse(out act, skipAoeCheck: true)) return true;

        return base.AttackAbility(nextGCD, out act);
    }

    protected override bool GeneralAbility(IAction nextGCD, out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;

        if (UseSprint)
        {
            if (!InCombat && SprintPvP.CanUse(out act)) return true;

            if (TimeSinceLastAction.TotalSeconds > 5)
            {
                if (SprintPvP.CanUse(out act)) return true;
            }
        }

        return base.GeneralAbility(nextGCD, out act);
    }

    protected override bool GeneralGCD(out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;

        if (EnlightenmentPvP.CanUse(out act,skipAoeCheck:true)) return true;

        if (PhantomRushPvP.CanUse(out act, skipAoeCheck: true)) return true;
        if (DemolishPvP.CanUse(out act)) return true;
        if (TwinSnakesPvP.CanUse(out act)) return true;
        if (DragonKickPvP.CanUse(out act)) return true;
        if (SnapPunchPvP.CanUse(out act)) return true;
        if (TrueStrikePvP.CanUse(out act)) return true;
        if (BootshinePvP.CanUse(out act)) return true;

        return base.GeneralGCD(out act);
    }
}