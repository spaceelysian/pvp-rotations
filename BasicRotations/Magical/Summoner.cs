namespace PvPRotations.Magical;
[Rotation("Smn-PvP", CombatType.PvP, GameVersion = "7.1", Description = "PvP")]
[Api(4)]

public class SMNPvP : SummonerRotation
{
    #region Settings
    [RotationConfig(CombatType.PvP, Name = "Use Sprint out of combat?")]
    public bool UseSprint { get; set; } = false;
    #endregion

    protected override bool EmergencyAbility(IAction nextGCD, out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;
        if (Player.GetHealthRatio() < 0.7 && RecuperatePvP.CanUse(out act)) return true;

        if ((Player.CurrentHp < Player.MaxHp) && RadiantAegisPvP.CanUse(out act)) return true;

        return base.EmergencyAbility(nextGCD, out act);
    }

    protected override bool AttackAbility(IAction nextGCD, out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;
        if (!Player.HasStatus(true, StatusID.DreadwyrmTrance_3228, StatusID.FirebirdTrance))
        {
            if (!Player.HasStatus(true, StatusID.FurtherRuin_4399) && NecrotizePvP.CanUse(out act)) return true;
            if (IsMoving && !Player.HasStatus(true, StatusID.FurtherRuin_4399) && NecrotizePvP.CanUse(out act, usedUp: true)) return true;
        }


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

        if (!Player.HasStatus(true, StatusID.DreadwyrmTrance_3228, StatusID.FirebirdTrance))
        {
            if (Player.HasStatus(true, StatusID.CrimsonStrikeReady) && CrimsonStrikePvP.CanUse(out act, skipAoeCheck: true)) return true;

            if (NoResilience && MountainBusterPvP.CanUse(out act, skipAoeCheck: true)) return true;

            if (SlipstreamPvP.CanUse(out act, skipAoeCheck: true)) return true;
        }

        if (Player.HasStatus(true, StatusID.FurtherRuin_4399) && RuinIvPvP.CanUse(out act, skipAoeCheck: true)) return true;
        if (RuinIiiPvP.CanUse(out act)) return true;

        return base.GeneralGCD(out act);
    }
}