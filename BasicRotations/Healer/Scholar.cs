using Dalamud.Game.ClientState.Objects.Enums;
using Dalamud.Utility;
using FFXIVClientStructs.FFXIV.Client.Game.Group;

namespace PvPRotations.Healer;
[Rotation("Sch-PvP", CombatType.PvP, GameVersion = "7", Description = "PvP")]
[Api(2)]

public class SCHPvP : ScholarRotation
{
    #region Settings
    [RotationConfig(CombatType.PvP, Name = "Use Sprint out of combat?")]
    public bool UseSprint { get; set; } = true;
    #endregion

    #region Deployment Tactics
    public IBaseAction DeploymentTactics => Deploy.Value;

    private readonly Lazy<IBaseAction> Deploy = new(delegate
    {
        IBaseAction action = new BaseAction(ActionID.DeploymentTacticsPvP);
        ActionSetting setting = action.Setting;
        ModifyDeployThis(ref setting);
        action.Setting = setting;
        return action;
    });

    public static void ModifyDeployThis(ref ActionSetting setting)
    {
        setting.TargetStatusNeed = [StatusID.Biolysis_3089];
    }
    #endregion


    protected override bool EmergencyAbility(IAction nextGCD, out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;
        if (Player.GetHealthRatio() < 0.7 && RecuperatePvP.CanUse(out act)) return true;

        return base.EmergencyAbility(nextGCD, out act);
    }

    protected override bool AttackAbility(IAction nextGCD, out IAction? act)
    {
        var NoResilience = CurrentTarget != null && !CurrentTarget.HasStatus(true, StatusID.Resilience);
        act = null;
        if (Player.HasStatus(true, StatusID.Guard)) return false;

        if (NoResilience && MummificationPvP.CanUse(out act, skipAoeCheck: true)) return true;

        return base.AttackAbility(nextGCD,out act);
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

        if (DeploymentTacticsPvP.Cooldown.HasOneCharge && (Player.HasStatus(true, StatusID.Recitation_3094) || ExpedientPvP.Cooldown.RecastTimeRemainOneCharge > 15))
        {
            if (BiolysisPvP.CanUse(out act)) return true;
        }

        if (BroilIvPvP.CanUse(out act)) return true;

        return base.GeneralGCD(out act);
    }
}