namespace DefaultRotations.Melee;
[Rotation("Mnk-PvP", CombatType.PvP, GameVersion = "6.58", Description = "PvP")]
public sealed class MNKPvP : MonkRotation
{
    protected override bool EmergencyAbility(IAction nextGCD, out IAction? act)
    {

        if (IsLastGCD((ActionID)EnlightenmentPvP.ID) && ThunderclapPvP.CanUse(out act)) return true;

        return base.EmergencyAbility(nextGCD, out act);
    }

    protected override bool AttackAbility(IAction nextGCD, out IAction? act)
    {

        if (IsLastGCD((ActionID)DemolishPvP.ID) && RisingPhoenixPvP.CanUse(out act, skipAoeCheck: true)) return true;

        if (SixsidedStarPvP.CanUse(out act)) return true;

        if (Player.WillStatusEnd(2, true, StatusID.EarthResonance) && EarthsReplyPvP.CanUse(out act, skipAoeCheck: true)) return true;
        if ((Player.CurrentHp < 20000) && EarthsReplyPvP.CanUse(out act, skipAoeCheck: true)) return true;


        return base.AttackAbility(nextGCD, out act);
    }
    protected override bool GeneralAbility(IAction nextGCD, out IAction? act)
    {

        if (RiddleOfEarthPvP.CanUse(out act) && HasHostilesInRange) return true;

        return base.GeneralAbility(nextGCD, out act);
    }
    protected override bool GeneralGCD(out IAction? act)
    {

        if (EnlightenmentPvP.CanUse(out act,skipAoeCheck:true)) return true;

        if (PhantomRushPvP.CanUse(out act, skipAoeCheck: true)) return true;
        if (DemolishPvP.CanUse(out act)) return true;
        if (TwinSnakesPvP.CanUse(out act)) return true;
        if (DragonKickPvP.CanUse(out act)) return true;
        if (SnapPunchPvP.CanUse(out act)) return true;
        if (TrueStrikePvP.CanUse(out act)) return true;
        if (BootshinePvP.CanUse(out act)) return true;

        return base.GeneralGCD(out act);
    }
}