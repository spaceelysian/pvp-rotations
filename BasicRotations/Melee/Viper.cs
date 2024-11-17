namespace PvPRotations.Melee;
[Rotation("Vpr-PvP", CombatType.PvP, GameVersion = "7.1", Description = "PvP")]
[Api(4)]

public class VPRPvP : ViperRotation
{
    #region Settings
    [RotationConfig(CombatType.PvP, Name = "Use Sprint out of combat?")]
    public bool UseSprint { get; set; } = false;
    #endregion

    protected override bool EmergencyAbility(IAction nextGCD, out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;
        if (Player.HasStatus(true, StatusID.HardenedScales)) return false;

        if (Player.GetHealthRatio() < 0.7 && RecuperatePvP.CanUse(out act)) return true;

        if (SnakeScalesPvP.Cooldown.IsCoolingDown && UncoiledFuryPvP.Cooldown.IsCoolingDown && RattlingCoilPvP.CanUse(out act)) return true;

        return base.EmergencyAbility(nextGCD, out act);
    }

    protected override bool AttackAbility(IAction nextGCD, out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;
        if (Player.HasStatus(true, StatusID.HardenedScales)) return false;
        if (IsLastGCD((ActionID)UncoiledFuryPvP.ID) && UncoiledTwinfangPvP.CanUse(out act, skipAoeCheck: true)) return true;
        if (IsLastGCD((ActionID)BarbarousBitePvP.ID, (ActionID)RavenousBitePvP.ID) && DeathRattlePvP.CanUse(out act)) return true;
        if (IsLastGCD((ActionID)BloodcoilPvP.ID) && TwinfangBitePvP.CanUse(out act, skipAoeCheck: true)) return true;
        if (IsLastGCD((ActionID)SanguineFeastPvP.ID) && TwinbloodBitePvP.CanUse(out act, skipAoeCheck: true)) return true;

        return base.AttackAbility(nextGCD, out act);
    }

    protected override bool GeneralAbility(IAction nextGCD, out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;
        if (Player.HasStatus(true, StatusID.HardenedScales)) return false;

        if (UseSprint) { if (!InCombat && SprintPvP.CanUse(out act)) return true; }

        return base.GeneralAbility(nextGCD, out act);
    }

    protected override bool GeneralGCD(out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;
        if (Player.HasStatus(true, StatusID.HardenedScales)) return false;

        if (SanguineFeastPvP.CanUse(out act, skipAoeCheck: true)) return true;
        if (BloodcoilPvP.CanUse(out act, skipAoeCheck: true)) return true;

        if (UncoiledFuryPvP.CanUse(out act, skipAoeCheck: true)) return true;

        if (RavenousBitePvP.CanUse(out act)) return true;
        if (SwiftskinsStingPvP.CanUse(out act)) return true;
        if (PiercingFangsPvP.CanUse(out act)) return true;
        if (BarbarousBitePvP.CanUse(out act)) return true;
        if (HuntersStingPvP.CanUse(out act)) return true;
        if (SteelFangsPvP.CanUse(out act)) return true;

        return base.GeneralGCD(out act);
    }
}