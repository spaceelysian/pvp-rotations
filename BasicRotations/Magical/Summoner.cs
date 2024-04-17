namespace DefaultRotations.Magical;
[Rotation("Smn-PvP", CombatType.PvP, GameVersion = "6.58", Description = "PvP")]
[Api(1)]

public class SMNPvP : SummonerRotation
{
    protected override bool EmergencyAbility(IAction nextGCD, out IAction? act)
    {

        if (Player.CurrentHp < Player.MaxHp && RadiantAegisPvP.CanUse(out act)) return true;

        return base.EmergencyAbility(nextGCD, out act);
    }

    protected override bool AttackAbility(IAction nextGCD, out IAction? act)
    {

        if (FesterPvP.CanUse(out act) && FesterPvP.Target.Target?.GetHealthRatio() < 0.5) return true;

        if (MountainBusterPvP.CanUse(out act, skipAoeCheck: true)) return true;

        if (EnkindleBahamutPvP.CanUse(out act)) return true;

        if (EnkindlePhoenixPvP.CanUse(out act)) return true;

        return base.AttackAbility(nextGCD, out act);
    }
    protected override bool GeneralAbility(IAction nextGCD, out IAction? act)
    {

        if (RadiantAegisPvP.CanUse(out act) && RadiantAegisPvP.Target.Target?.GetHealthRatio() < 0.9) return true;

        return base.GeneralAbility(nextGCD, out act);
    }
    protected override bool GeneralGCD(out IAction? act)
    {

        if (SlipstreamPvP.CanUse(out act, skipAoeCheck: true)) return true;

        if (CrimsonCyclonePvP.IsInCooldown && CrimsonStrikePvP.IsInCooldown && RuinIiiPvP.CanUse(out act)) return true;

        if (CrimsonCyclonePvP.CanUse(out act, skipCastingCheck: true, skipClippingCheck: true, skipAoeCheck: true)) return true;
        if (CrimsonStrikePvP.CanUse(out act, skipCastingCheck: true, skipClippingCheck: true, skipAoeCheck: true)) return true;

        if (RuinIiiPvP.CanUse(out act)) return true;

        return base.GeneralGCD(out act);
    }
}