namespace PvPRotations.Melee;
[Rotation("Sam-PvP", CombatType.PvP, GameVersion = "6.58", Description = "PvP")]
[Api(1)]

public class SAMPvP : SamuraiRotation
{
    #region Settings
    [RotationConfig(CombatType.PvP, Name = "Use Sprint out of combat?")]
    public bool UseSprint { get; set; } = true;
    #endregion

    protected override bool EmergencyAbility(IAction nextGCD, out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;

        if (MeikyoShisuiPvP.CanUse(out act) && HasHostilesInRange) return true;

        return base.EmergencyAbility(nextGCD, out act);
    }

    protected override bool AttackAbility(IAction nextGCD, out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;

        if (!HostileTarget.HasStatus(true, StatusID.Resilience) && MineuchiPvP.CanUse(out act)) return true;

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

        if (HissatsuChitenPvP.CanUse(out act) && (Player.CurrentHp < Player.MaxHp) && HasHostilesInMaxRange) return true;

        return base.GeneralAbility(nextGCD, out act);
    }

    protected override bool GeneralGCD(out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;

        if (IsLastGCD((ActionID)OgiNamikiriPvP.ID) && KaeshiNamikiriPvP.CanUse(out act)) return true;

        if (Player.HasStatus(true, StatusID.Midare) && MidareSetsugekkaPvP.CanUse(out act)) return true;

        if (OgiNamikiriPvP.CanUse(out act)) return true;

        if (Player.HasStatus(true, StatusID.Kaiten_3201))
        {
            if (OkaPvP.CanUse(out act, skipAoeCheck: true)) return true;
            if (MangetsuPvP.CanUse(out act, skipAoeCheck: true)) return true;
            if (HyosetsuPvP.CanUse(out act, skipAoeCheck: true)) return true;
        }

        if (KashaPvP.CanUse(out act)) return true;
        if (GekkoPvP.CanUse(out act)) return true;
        if (YukikazePvP.CanUse(out act)) return true;

        return base.GeneralGCD(out act);
    }
}