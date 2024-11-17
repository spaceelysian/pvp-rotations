namespace PvPRotations.Magical;
[Rotation("Blm-PvP", CombatType.PvP, GameVersion = "7.1", Description = "PvP")]
[Api(4)]

public class BLMPvP : BlackMageRotation
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

        return base.EmergencyAbility(nextGCD, out act);
    }

    protected override bool AttackAbility(IAction nextGCD, out IAction? act)
    {
        return base.AttackAbility(nextGCD, out act);
    }

    protected override bool GeneralAbility(IAction nextGCD, out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;
        if (UseSprint) { if (!InCombat && SprintPvP.CanUse(out act)) return true; }

        if (Player.HasStatus(true, StatusID.AstralFire_3212, StatusID.AstralFireIi_3213, StatusID.AstralFireIii_3381) && WreathOfFirePvP.CanUse(out act)) return true;
        if (Player.GetHealthRatio() < .99 && Player.HasStatus(true, StatusID.UmbralIce_3214, StatusID.UmbralIceIi_3215, StatusID.UmbralIceIii_3382) && WreathOfIcePvP.CanUse(out act)) return true;


        return base.GeneralAbility(nextGCD, out act);
    }

    protected override bool GeneralGCD(out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;


        if (Player.HasStatus(true, StatusID.Paradox) && ParadoxPvP.CanUse(out act, skipAoeCheck: true)) return true;

        if (BurstPvP.CanUse(out act, skipAoeCheck: true) && HostileTarget.DistanceToPlayer() <= 4) return true;

        if (XenoglossyPvP.CanUse(out act)) return true;
        if (Player.GetHealthRatio() < 0.5 && XenoglossyPvP.CanUse(out act, usedUp:true)) return true;
        if (IsMoving && XenoglossyPvP.CanUse(out act, usedUp: true)) return true;

        if (Player.HasStatus(true, StatusID.AstralFire_3212) && FireIiiPvP.CanUse(out act, skipAoeCheck: true)) return true;
        if (Player.HasStatus(true, StatusID.AstralFireIi_3213) && FireIvPvP.CanUse(out act, skipAoeCheck: true)) return true;
        if (Player.HasStatus(true, StatusID.AstralFireIii_3381) && HighFireIiPvP.CanUse(out act, skipAoeCheck: true)) return true;

        if (Player.HasStatus(true, StatusID.UmbralIce_3214) && BlizzardIiiPvP.CanUse(out act, skipAoeCheck: true)) return true;
        if (Player.HasStatus(true, StatusID.UmbralIceIi_3215) && BlizzardIvPvP.CanUse(out act, skipAoeCheck: true)) return true;
        if (Player.HasStatus(true, StatusID.UmbralIceIii_3382) && HighBlizzardIiPvP.CanUse(out act, skipAoeCheck: true)) return true;

        return base.GeneralGCD(out act);
    }
}