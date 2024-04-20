﻿namespace DefaultRotations.Melee;
[Rotation("Sam-PvP", CombatType.PvP, GameVersion = "6.58", Description = "PvP")]
[Api(1)]

public class SAMPvP : SamuraiRotation
{
    protected override bool EmergencyAbility(IAction nextGCD, out IAction? act)
    {

        if (MeikyoShisuiPvP.CanUse(out act) && HasHostilesInRange) return true;

        return base.EmergencyAbility(nextGCD, out act);
    }

    protected override bool AttackAbility(IAction nextGCD, out IAction? act)
    {

        if (MineuchiPvP.CanUse(out act)) return true;

        return base.AttackAbility(nextGCD, out act);
    }

    protected override bool GeneralAbility(IAction nextGCD, out IAction? act)
    {

        if (!InCombat && SprintPvP.CanUse(out act)) return true;

        if (TimeSinceLastAction.TotalSeconds > 4.5)
        {
            if (SprintPvP.CanUse(out act)) return true;
        }

        if (HissatsuChitenPvP.CanUse(out act) && (Player.CurrentHp < Player.MaxHp) && HasHostilesInMaxRange) return true;

        return base.GeneralAbility(nextGCD, out act);
    }

    protected override bool GeneralGCD(out IAction? act)
    {

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