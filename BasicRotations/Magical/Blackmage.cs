namespace PvPRotations.Magical;
[Rotation("Blm-PvP", CombatType.PvP, GameVersion = "6.58", Description = "PvP")]
[Api(1)]

public class BLMPvP : BlackMageRotation
{
    #region Settings
    [RotationConfig(CombatType.PvP, Name = "Use Sprint out of combat?")]
    public bool UseSprint { get; set; } = true;
    #endregion

    protected override bool EmergencyAbility(IAction nextGCD, out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;

        return base.EmergencyAbility(nextGCD, out act);
    }

    protected override bool AttackAbility(IAction nextGCD, out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;

        if (HostileTarget.StatusStack(true, StatusID.AstralWarmth) == 3)
        {
            if (SuperflarePvP.CanUse(out act, skipAoeCheck: true, usedUp: true)) return true;
        }

        if (HostileTarget.StatusStack(true, StatusID.UmbralFreeze) == 3)
        {
            if (SuperflarePvP.CanUse(out act, skipAoeCheck: true, usedUp: true)) return true;
        }

        if (NightWingPvP.CanUse(out act)) return true;

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

        if (IsLastAbility((ActionID)AetherialManipulationPvP.ID) && BurstPvP.CanUse(out act, skipAoeCheck: true) && HostileTarget.DistanceToPlayer() <= 5) return true;

        /*if (HostileTarget.StatusStack(true, StatusID.UmbralFreeze) == 1)
        {
            if (ParadoxPvP.CanUse(out act)) return true;
        }

        if (Player.HasStatus(true, StatusID.UmbralIceIii_3382) && FreezePvP.CanUse(out act, skipAoeCheck: true)) return true;
        if (Player.HasStatus(true, StatusID.UmbralIceIi_3215) && BlizzardIvPvP.CanUse(out act)) return true;
      
        if (Player.HasStatus(true, StatusID.AstralFireIii_3381) && FlarePvP.CanUse(out act, skipAoeCheck: true)) return true;
        if (Player.HasStatus(true, StatusID.AstralFireIi_3213) &&  FireIvPvP.CanUse(out act)) return true;
        */
        return base.GeneralGCD(out act);
    }
}