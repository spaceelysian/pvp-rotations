﻿namespace PvPRotations.Melee;
[Rotation("Rpr-PvP", CombatType.PvP, GameVersion = "6.58", Description = "PvP")]
[Api(1)]

public sealed class RPRPvP : ReaperRotation
{
    #region Settings
    [RotationConfig(CombatType.PvP, Name = "Use Sprint out of combat?")]
    public bool UseSprint { get; set; } = true;
    #endregion

    protected override bool EmergencyAbility(IAction nextGCD, out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;
        if ((Player.CurrentHp < (Player.MaxHp - 22222)) && RecuperatePvP.CanUse(out act)) return true;

        if (HostileTarget.DistanceToPlayer() <= 6 && DeathWarrantPvP.CanUse(out act)) return true;

        if ((Player.CurrentHp < Player.MaxHp) & ArcaneCrestPvP.CanUse(out act) && HasHostilesInRange) return true;

        return base.EmergencyAbility(nextGCD, out act);
    }

    protected override bool AttackAbility(IAction nextGCD, out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;

        if (GrimSwathePvP.CanUse(out act)) return true;

        if (HarvestMoonPvP.CanUse(out act, skipAoeCheck: true) && HarvestMoonPvP.Target.Target?.GetHealthRatio() < 0.5) return true;

        if (Player.HasStatus(true, StatusID.Soulsow_2750))
        {
            if (Player.WillStatusEnd(5, true, StatusID.Soulsow_2750) && HarvestMoonPvP.CanUse(out act, skipAoeCheck: true)) return true;
        }

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

        if (SoulSlicePvP.CanUse(out act, usedUp: true)) return true;

        if (PlentifulHarvestPvP.CanUse(out act)) return true;

        if (InfernalSlicePvP.CanUse(out act)) return true;
        if (WaxingSlicePvP.CanUse(out act)) return true;
        if (SlicePvP.CanUse(out act)) return true;

        return base.GeneralGCD(out act);
    }
}