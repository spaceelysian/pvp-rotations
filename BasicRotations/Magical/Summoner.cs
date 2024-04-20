namespace DefaultRotations.Magical;
[Rotation("Smn-PvP", CombatType.PvP, GameVersion = "6.58", Description = "PvP")]
[Api(1)]

public class SMNPvP : SummonerRotation
{
    protected override bool EmergencyAbility(IAction nextGCD, out IAction? act)
    {

        if ((Player.CurrentHp < Player.MaxHp) && RadiantAegisPvP.CanUse(out act)) return true;

        return base.EmergencyAbility(nextGCD, out act);
    }

    protected override bool AttackAbility(IAction nextGCD, out IAction? act)
    {

        if (FesterPvP.CanUse(out act, usedUp: true) && FesterPvP.Target.Target?.GetHealthRatio() < 0.5) return true;

        if (FesterPvP.Cooldown.CurrentCharges == 2 && FesterPvP.CanUse(out act)) return true;

        if (MountainBusterPvP.CanUse(out act, skipAoeCheck: true)) return true;

        if (Player.HasStatus(true,StatusID.DreadwyrmTrance_3228))
        {
            if (EnkindleBahamutPvP.CanUse(out act)) return true;
        }

        if (Player.HasStatus(true, StatusID.FirebirdTrance))
        {
            if (EnkindlePhoenixPvP.CanUse(out act)) return true;
        }

        return base.AttackAbility(nextGCD, out act);
    }
    protected override bool GeneralAbility(IAction nextGCD, out IAction? act)
    {

        if (!InCombat && SprintPvP.CanUse(out act)) return true;

        if (TimeSinceLastAction.TotalSeconds > 4.5)
        {
            if (SprintPvP.CanUse(out act)) return true;
        }

        if (RadiantAegisPvP.CanUse(out act) && RadiantAegisPvP.Target.Target?.GetHealthRatio() < 0.9) return true;

        return base.GeneralAbility(nextGCD, out act);
    }

    protected override bool GeneralGCD(out IAction? act)
    {

        if (IsLastGCD((ActionID)CrimsonCyclonePvP.ID) && CrimsonStrikePvP.CanUse(out act, skipAoeCheck: true)) return true;

        if (SlipstreamPvP.CanUse(out act, skipAoeCheck: true)) return true;

        if (RuinIiiPvP.CanUse(out act)) return true;

        return base.GeneralGCD(out act);
    }
}