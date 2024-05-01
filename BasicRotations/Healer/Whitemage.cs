namespace PvPRotations.Healer;
[Rotation("Whm-PvP", CombatType.PvP, GameVersion = "6.58", Description = "PvP")]
[Api(1)]

public class WHM : WhiteMageRotation
{
    #region Settings
    [RotationConfig(CombatType.PvP, Name = "Use Sprint out of combat?")]
    public bool UseSprint { get; set; } = true;
    #endregion

    protected override bool EmergencyAbility(IAction nextGCD, out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;

        if (AquaveilPvP.CanUse(out act) && AquaveilPvP.Target.Target?.GetHealthRatio() < 0.75) return true;

        return base.EmergencyAbility(nextGCD, out act);
    }

    protected override bool AttackAbility(IAction nextGCD, out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;

        return base.AttackAbility(nextGCD, out act);
    }

    protected override bool GeneralAbility(IAction nextGCD, out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;

        if (UseSprint)
        {
            if (!InCombat && SprintPvP.CanUse(out act)) return true;
        }

        return base.GeneralAbility(nextGCD, out act);
    }
    protected override bool GeneralGCD(out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;

        if (AfflatusMiseryPvP.CanUse(out act, skipAoeCheck:true)) return true;

        if (GlareIiiPvP.CanUse(out act)) return true;

        if (Player.HasStatus(true, StatusID.CureIiiReady))
        {
            if (Player.CurrentHp < Player.MaxHp && CureIiiPvP.CanUse(out act, skipAoeCheck: true)) return true;
            if (Player.WillStatusEnd(3, true, StatusID.CureIiiReady) && CureIiPvP.CanUse(out act, skipAoeCheck: true)) return true;
        }

        if (CureIiPvP.CanUse(out act) && CureIiPvP.Target.Target?.GetHealthRatio() < 0.75) return true;

        return base.GeneralGCD(out act);
    }
}