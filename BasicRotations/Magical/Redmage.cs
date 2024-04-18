namespace DefaultRotations.Magical;
[Rotation("Rdm-PvP", CombatType.PvP, GameVersion = "6.58", Description = "PvP")]
[Api(1)]

public class RDMPvP : RedMageRotation
{
    protected override bool EmergencyAbility(IAction nextGCD, out IAction? act)
    {

        return base.EmergencyAbility(nextGCD, out act);
    }

    protected override bool AttackAbility(IAction nextGCD, out IAction? act)
    {
        if (Player.HasStatus(true, StatusID.BlackShift))
        {
            if (FrazzlePvP.CanUse(out act)) return true;
        }

        return base.AttackAbility(nextGCD, out act);
    }

    protected override bool GeneralAbility(IAction nextGCD, out IAction? act)
    {
        if (Player.HasStatus(true, StatusID.WhiteShift))
        {
            if (MagickBarrierPvP.CanUse(out act)) return true;
        }

            return base.GeneralAbility(nextGCD, out act);
    }

    protected override bool GeneralGCD(out IAction? act)
    {

        if (Player.HasStatus(true, StatusID.BlackShift))
        {
            if (EnchantedRedoublementPvP_29694.CanUse(out act)) return true;
            if (EnchantedZwerchhauPvP_29693.CanUse(out act)) return true;
            if (EnchantedRipostePvP_29692.CanUse(out act)) return true;
            if (Player.HasStatus(true, StatusID.VermilionRadiance))
            {
                if (VerflarePvP.CanUse(out act, skipAoeCheck: true)) return true;
            }

            if (Player.HasStatus(true, StatusID.Dualcast_1393))
            {
                if (VerthunderIiiPvP.CanUse(out act, skipComboCheck: true)) return true;
            }
            if (VerfirePvP.CanUse(out act)) return true;
        }

        if (Player.HasStatus(true, StatusID.WhiteShift))
        {

            if (EnchantedRedoublementPvP.CanUse(out act)) return true;
            if (EnchantedZwerchhauPvP.CanUse(out act)) return true;
            if (EnchantedRipostePvP.CanUse(out act)) return true;
            if (Player.HasStatus(true, StatusID.VermilionRadiance))
            {
                if (VerholyPvP.CanUse(out act, skipAoeCheck: true)) return true;
            }

            if (Player.HasStatus(true, StatusID.Dualcast_1393))
            {
                if (VeraeroIiiPvP.CanUse(out act, skipComboCheck: true)) return true;
            }

            if (VerstonePvP.CanUse(out act)) return true;
        }

        return base.GeneralGCD(out act);
    }
}