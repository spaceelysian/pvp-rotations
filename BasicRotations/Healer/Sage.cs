namespace PvPRotations.Healer;
[Rotation("Sge-PvP", CombatType.PvP, GameVersion = "6.58", Description = "PvP")]
[Api(1)]

public class SGEPvP : SageRotation
{
    #region Settings
    [RotationConfig(CombatType.PvP, Name = "Use Sprint out of combat?")]
    public bool UseSprint { get; set; } = true;
    #endregion

    protected override bool EmergencyAbility(IAction nextGCD, out IAction? act)
    {
        var Toxikon = CurrentTarget != null && !CurrentTarget.HasStatus(true, StatusID.Toxikon);
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;
        if (Player.GetHealthRatio() < 0.75 && RecuperatePvP.CanUse(out act)) return true;

        if (ToxikonPvP.CanUse(out act, skipAoeCheck: true, usedUp: true) && Toxikon) return true;

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

        if (!Player.HasStatus(true, StatusID.Eukrasia) && EukrasiaPvP.CanUse(out act)) return true;

        return base.GeneralAbility(nextGCD, out act);
    }

    protected override bool GeneralGCD(out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;

        if (PneumaPvP.CanUse(out act)) return true;

        if (PhlegmaIiiPvP.CanUse(out act, skipAoeCheck: true, usedUp: true)) return true;

        if (DosisIiiPvP.CanUse(out act)) return true;

        return base.GeneralGCD(out act);
    }
}