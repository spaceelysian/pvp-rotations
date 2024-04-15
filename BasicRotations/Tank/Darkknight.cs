namespace DefaultRotations.Tank;
[Rotation("drk-pvp", CombatType.PvP, GameVersion = "6.58", Description = "pvp skills")]
public sealed class DRKPvP : DarkKnightRotation
{
    protected override bool EmergencyAbility(IAction nextGCD, out IAction? act)
    {

        if (Player.CurrentHp < Player.MaxHp && TheBlackestNightPvP.CanUse(out act)) return true;

        return base.EmergencyAbility(nextGCD, out act);
    }
    protected override bool AttackAbility(IAction nextGCD, out IAction? act)
    {

        if (PlungePvP.CanUse(out act)) return true;

        if (IsLastAbility((ActionID)PlungePvP.ID) && SaltedEarthPvP.CanUse(out act) && HasHostilesInMaxRange) return true;

        if (IsLastAbility((ActionID)SaltedEarthPvP.ID) && SaltAndDarknessPvP.CanUse(out act)) return true;

        if (Player.HasStatus(true, StatusID.DarkArts_3034) && ShadowbringerPvP_29738.CanUse(out act)) return true;



        return base.AttackAbility(nextGCD, out act);
    }
    protected override bool GeneralAbility(IAction nextGCD, out IAction? act)
    {

        if (TheBlackestNightPvP.Target.Target?.GetHealthRatio() < 0.9 && TheBlackestNightPvP.CanUse(out act)) return true;

        return base.GeneralAbility(nextGCD, out act);
    }
    protected override bool GeneralGCD(out IAction? act)
    {

        if (QuietusPvP.CanUse(out act)) return true;

        if (SouleaterPvP.CanUse(out act)) return true;
        if (SyphonStrikePvP.CanUse(out act)) return true;
        if (HardSlashPvP.CanUse(out act)) return true;

        return base.GeneralGCD(out act);
    }
}
