namespace PvPRotations.Magical;
[Rotation("Pct-PvP", CombatType.PvP, GameVersion = "7", Description = "PvP")]
[Api(2)]

public class PCTPvP : PictomancerRotation
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

        if ((Player.CurrentHp < Player.MaxHp) && TemperaCoatPvP.CanUse(out act)) return true;
        if (Player.HasStatus(true, StatusID.TemperaCoat_4114))
        {
            if (Player.WillStatusEnd(5, true, StatusID.TemperaCoat_4114) && TemperaGrassaPvP.CanUse(out act, skipAoeCheck: true)) return true;
        }


        return base.EmergencyAbility(nextGCD, out act);
    }

    protected override bool AttackAbility(IAction nextGCD, out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;

        if (Player.HasStatus(true, StatusID.MawMotif) && FangedMusePvP.CanUse(out act, skipAoeCheck: true, usedUp: true)) return true;
        if (Player.HasStatus(true, StatusID.PomMotif) && PomMusePvP.CanUse(out act, skipAoeCheck: true, usedUp: true)) return true;
        if (Player.HasStatus(true, StatusID.WingMotif) && WingedMusePvP.CanUse(out act, skipAoeCheck: true, usedUp: true)) return true;
        if (Player.HasStatus(true, StatusID.ClawMotif) && ClawedMusePvP.CanUse(out act, skipAoeCheck: true, usedUp: true)) return true;

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
        var NoResilience = CurrentTarget != null && !CurrentTarget.HasStatus(false, StatusID.Resilience);
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;

        if (Player.HasStatus(true, StatusID.MooglePortrait) && MogOfTheAgesPvP.CanUse(out act, skipAoeCheck: true)) return true;
        if (Player.HasStatus(true, StatusID.MadeenPortrait) && RetributionOfTheMadeenPvP.CanUse(out act, skipAoeCheck: true)) return true;
        if (Player.HasStatus(true, StatusID.MawSketch) && MawMotifPvP.CanUse(out act)) return true;
        if (Player.HasStatus(true, StatusID.WingSketch) && WingMotifPvP.CanUse(out act)) return true;
        if (Player.HasStatus(true, StatusID.ClawSketch) && ClawMotifPvP.CanUse(out act)) return true;
        if (Player.HasStatus(true, StatusID.PomSketch) && PomMotifPvP.CanUse(out act)) return true;


        if (Player.HasStatus(true, StatusID.SubtractivePalette_4102))
        {
            act = null;
            if (Player.HasStatus(true, StatusID.Guard)) return false;
            if (CometInBlackPvP.CanUse(out act, skipAoeCheck: true, usedUp: true)) return true;
            if (Player.HasStatus(true, StatusID.AetherhuesIi_4101) && ThunderInMagentaPvP.CanUse(out act)) return true;
            if (Player.HasStatus(true, StatusID.Aetherhues_4100) && StoneInYellowPvP.CanUse(out act)) return true;
        }

        if (HolyInWhitePvP.CanUse(out act, skipAoeCheck: true, usedUp: true)) return true;

        if (Player.HasStatus(true, StatusID.AetherhuesIi_4101) && WaterInBluePvP.CanUse(out act)) return true;
        if (Player.HasStatus(true, StatusID.Aetherhues_4100) && AeroInGreenPvP.CanUse(out act)) return true;
        if (FireInRedPvP.CanUse(out act)) return true;

        return base.GeneralGCD(out act);
    }
}