﻿namespace DefaultRotations.Melee;

[Rotation("sam-pvp", CombatType.PvP, GameVersion = "6.58", Description = "pvp skills")]
public class SAMPvP : SamuraiRotation
{
   protected override bool EmergencyAbility(IAction nextGCD, out IAction? act)
    {

        return base.EmergencyAbility(nextGCD, out act);
    }

    protected override bool AttackAbility(IAction nextGCD, out IAction? act)
    {

        return base.AttackAbility(nextGCD, out act);
    }

    protected override bool GeneralGCD(out IAction? act)
    {

        return base.GeneralGCD(out act);
    }
}