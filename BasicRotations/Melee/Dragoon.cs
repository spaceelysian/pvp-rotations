namespace PvPRotations.Melee;
[Rotation("Drg-PvP", CombatType.PvP, GameVersion = "7", Description = "PvP")]
[Api(2)]

public class DRGPvP : DragoonRotation
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

        if (Player.HasStatus(true, StatusID.LifeOfTheDragon) && HasHostilesInRange && HorridRoarPvP.CanUse(out act, skipAoeCheck: true)) return true;

        return base.EmergencyAbility(nextGCD, out act);
    }

    protected override bool AttackAbility(IAction nextGCD, out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;

        if (!HorridRoarPvP.Cooldown.IsCoolingDown)
        {
            if (GeirskogulPvP.CanUse(out act, skipAoeCheck: true)) return true;
        }

        if (Player.WillStatusEnd(2, true, StatusID.LifeOfTheDragon))
        {
            if (NastrondPvP.CanUse(out act, skipAoeCheck: true)) return true;
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
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;

        if (Player.HasStatus(true, StatusID.FirstmindsFocus) && WyrmwindThrustPvP.CanUse(out act, skipAoeCheck:true)) return true;

        if (Player.HasStatus(true, StatusID.LifeOfTheDragon))
        {
            if ((Player.CurrentHp < Player.MaxHp) && ChaoticSpringPvP.CanUse(out act)) return true;
        }

        if (Player.GetHealthRatio() < 0.2 && ChaoticSpringPvP.CanUse(out act)) return true;

        if (WheelingThrustPvP.CanUse(out act)) return true;
        if (FangAndClawPvP.CanUse(out act)) return true;
        if (RaidenThrustPvP.CanUse(out act)) return true;

        return base.GeneralGCD(out act);
    }
}