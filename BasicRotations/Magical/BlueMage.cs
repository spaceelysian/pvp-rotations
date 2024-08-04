namespace PvPRotations.Magical;
[Rotation("Bloops", CombatType.PvE, GameVersion = "7", Description = "Bluest mage")]
[Api(3)]

public class BlueMage : BlueMageRotation
{
    protected override bool EmergencyAbility(IAction nextGCD, out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Diamondback)) return false;

        if (VeilOfTheWhorlPvE.CanUse(out act)) return true; // 49

        return base.EmergencyAbility(nextGCD, out act);
    }

    protected override bool AttackAbility(IAction nextGCD, out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Diamondback)) return false;
        //if (Player.HasStatus(true, StatusID.SurpanakhasFury) && SurpanakhaPvE.CanUse(out act, usedUp: true)) return true; // 78B


        if (BeingMortalPvE.CanUse(out act)) return true; // 124
        if (ApokalypsisPvE.CanUse(out act)) return true; // 123
        if (SeaShantyPvE.CanUse(out act)) return true; // 122

        if (NightbloomPvE.CanUse(out act)) return true; // 104
        if (PhantomFlurryPvE_23289.CanUse(out act)) return true; // 103B
        if (PhantomFlurryPvE.CanUse(out act)) return true; // 103A
        if (BothEndsPvE.CanUse(out act)) return true; // 102

        if (QuasarPvE.CanUse(out act)) return true; // 79
        if (SurpanakhaPvE.CanUse(out act, usedUp: true)) return true; // 78

        if (GlassDancePvE.CanUse(out act)) return true; // 48
        if (ShockStrikePvE.CanUse(out act)) return true; // 47
        if (MountainBusterPvE.CanUse(out act)) return true; // 46
        if (EruptionPvE.CanUse(out act)) return true; // 45
        if (FeatherRainPvE.CanUse(out act)) return true; // 44

        return base.AttackAbility(nextGCD, out act);
    }

    protected override bool GeneralAbility(IAction nextGCD, out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Diamondback)) return false;

        return base.GeneralAbility(nextGCD, out act);
    }

    protected override bool MoveForwardAbility(IAction nextGCD, out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Diamondback)) return false;

        if (JKickPvE.CanUse(out act)) return true; // 80

        return base.MoveForwardAbility(nextGCD, out act);
    }

    protected override bool HealSingleGCD(out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Diamondback)) return false;

        return base.HealSingleGCD(out act);
    }

    protected override bool HealAreaGCD(out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Diamondback)) return false;

        return base.HealAreaGCD(out act);
    }

    protected override bool DefenseSingleGCD(out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Diamondback)) return false;

        if (!Player.HasStatus(true, StatusID.ToadOil) && ToadOilPvE.CanUse(out act)) return true; // 32

        return base.HealAreaGCD(out act);
    }

    protected override bool DefenseAreaGCD(out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Diamondback)) return false;

        if (!Player.HasStatus(true, StatusID.Gobskin) && GobskinPvE.CanUse(out act)) return true; // 59

        return base.HealAreaGCD(out act);
    }

    protected override bool MoveForwardGCD(out IAction? act)
    {
        act = null;
        if (Player.HasStatus(true, StatusID.Diamondback)) return false;

        return base.MoveForwardGCD(out act);
    }

    protected override bool GeneralGCD(out IAction? act)
    {
        var NoMF = CurrentTarget != null && !CurrentTarget.HasStatus(true, StatusID.MortalFlame_3643);
        var NoBB = CurrentTarget != null && !CurrentTarget.HasStatus(true, StatusID.DamageDown);
        var NoBoM = CurrentTarget != null && !CurrentTarget.HasStatus(true, StatusID.BreathOfMagic);
        var NoD = CurrentTarget != null && !CurrentTarget.HasStatus(true, StatusID.Dropsy_1736);

        act = null;
        if (Player.HasStatus(true, StatusID.Diamondback)) return false;

        if (!Player.HasStatus(true, StatusID.BasicInstinct) && BasicInstinctPvE.CanUse(out act)) return true; // 91
        if (!Player.HasStatus(true, StatusID.MightyGuard) && MightyGuardPvE.CanUse(out act)) return true; // 30

        if (Player.HasStatus(true, StatusID.AethericMimicryTank))
        {
            act = null;

            if (DivineCataractPvE.CanUse(out act)) return true; // 89B
            if (ChelonianGatePvE.CanUse(out act)) return true; // 89A
            if (DevourPvE.CanUse(out act)) return true; // 75
            if (CactguardPvE.CanUse(out act)) return true; // 70

            return true;
        }

        if (Player.HasStatus(true, StatusID.AethericMimicryHealer))
        {
            act = null;

            if (ExuviationPvE.CanUse(out act)) return true; // 73
            if (PomCurePvE.CanUse(out act)) return true; // 58

            return true;
        }

        if (Player.HasStatus(true, StatusID.AethericMimicryDps))
        {
            act = null;

            if (MatraMagicPvE.CanUse(out act)) return true; // 100

            return true;
        }

        if  (NoMF && MortalFlamePvE.CanUse(out act)) return true; // 121
        
        if (CandyCanePvE.CanUse(out act)) return true; // 120
        if (LaserEyePvE.CanUse(out act)) return true; // 119
        if (WingedReprobationPvE.CanUse(out act)) return true; // 118
        if (ForceFieldPvE.CanUse(out act)) return true; // 117
        if (ConvictionMarcatoPvE.CanUse(out act)) return true; // 116
        if (DimensionalShiftPvE.CanUse(out act)) return true; // 115
        if (DivinationRunePvE.CanUse(out act)) return true; // 114
        if (RubyDynamicsPvE.CanUse(out act)) return true; // 113
        if (DeepCleanPvE.CanUse(out act)) return true; // 112
        if (PeatPeltPvE.CanUse(out act)) return true; // 111

        if (WildRagePvE.CanUse(out act)) return true; // 110
        if (NoBoM && BreathOfMagicPvE.CanUse(out act)) return true; // 109
        if (SchiltronPvE.CanUse(out act)) return true; // 107
        if (RightRoundPvE.CanUse(out act)) return true; // 106
        if (GoblinPunchPvE.CanUse(out act)) return true; // 105

        if (!IsLastGCD((ActionID)PeripheralSynthesisPvE.ID) && PeripheralSynthesisPvE.CanUse(out act)) return true; // 101

        if (ChocoMeteorPvE.CanUse(out act)) return true; // 99
        if (MaledictionOfWaterPvE.CanUse(out act)) return true; // 98
        if (HydroPullPvE.CanUse(out act)) return true; // 97
        if (AetherialSparkPvE.CanUse(out act)) return true; // 96
        if (DragonForcePvE.CanUse(out act)) return true; // 95
        if (IsLastGCD((ActionID)PeripheralSynthesisPvE.ID) && MustardBombPvE.CanUse(out act)) return true; // 94
        if (BlazePvE.CanUse(out act)) return true; // 93
        if (UltravibrationPvE.CanUse(out act)) return true; // 92

        if (TheRoseOfDestructionPvE.CanUse(out act)) return true; // 90
        if (AngelsSnackPvE.CanUse(out act)) return true; // 88
        if (FeculentFloodPvE.CanUse(out act)) return true; // 87
        if (SaintlyBeamPvE.CanUse(out act)) return true; // 86
        if (StotramPvE_23416.CanUse(out act)) return true; // 85B
        if (StotramPvE.CanUse(out act)) return true; // 85A
        if (ColdFogPvE.CanUse(out act)) return true; // 84
        if (TatamigaeshiPvE.CanUse(out act)) return true; // 83
        if (TinglePvE.CanUse(out act)) return true; // 82
        if (TripleTridentPvE.CanUse(out act)) return true; // 81

        if (AethericMimicryPvE.CanUse(out act)) return true; // 77
        if (CondensedLibraPvE.CanUse(out act)) return true; // 76
        if (RefluxPvE.CanUse(out act)) return true; // 74
        if (AngelWhisperPvE.CanUse(out act)) return true; // 72
        if (RevengeBlastPvE.CanUse(out act)) return true; // 71

        if (PerpetualRayPvE.CanUse(out act)) return true; // 69
        if (LauncherPvE.CanUse(out act)) return true; // 68
        if (Level5DeathPvE.CanUse(out act)) return true; // 67
        if (BlackKnightsTourPvE.CanUse(out act)) return true; // 66
        if (WhiteKnightsTourPvE.CanUse(out act)) return true; // 65
        if (WhistlePvE.CanUse(out act)) return true; // 64
        if (SonicBoomPvE.CanUse(out act)) return true; // 63
        if (FrogLegsPvE.CanUse(out act)) return true; // 62
        if (AvailPvE.CanUse(out act)) return true; // 61

        if (MagicHammerPvE.CanUse(out act)) return true; // 60
        if (EerieSoundwavePvE.CanUse(out act)) return true; // 57
        if (ChirpPvE.CanUse(out act)) return true; // 56
        if (AbyssalTransfixionPvE.CanUse(out act)) return true; // 55
        if (KaltstrahlPvE.CanUse(out act)) return true; // 54
        if (ElectrogenesisPvE.CanUse(out act)) return true; // 53
        if (NortherliesPvE.CanUse(out act)) return true; // 52
        if (ProteanWavePvE.CanUse(out act)) return true; // 51

        if (AlpineDraftPvE.CanUse(out act)) return true; // 50
        if (PeculiarLightPvE.CanUse(out act)) return true; // 43
        if (DoomPvE.CanUse(out act)) return true; // 42
        if (MindBlastPvE.CanUse(out act)) return true; // 41

        if (TailScrewPvE.CanUse(out act)) return true; // 40
        if (MoonFlutePvE.CanUse(out act)) return true; // 39
        if (FireAngonPvE.CanUse(out act)) return true; // 38
        if (InkJetPvE.CanUse(out act)) return true; // 37
        if (_1000NeedlesPvE.CanUse(out act)) return true; // 36
        if (MissilePvE.CanUse(out act)) return true; // 35
        if (TheDragonsVoicePvE.CanUse(out act)) return true; // 34
        if (TheRamsVoicePvE.CanUse(out act)) return true; // 33
        if (StickyTonguePvE.CanUse(out act)) return true; // 31

        if (DiamondbackPvE.CanUse(out act)) return true; // 29
        if (NoBB && BadBreathPvE.CanUse(out act)) return true; // 28
        if (TheLookPvE.CanUse(out act)) return true; // 27
        if (_4TonzeWeightPvE.CanUse(out act)) return true; // 26
        if (SnortPvE.CanUse(out act)) return true; // 25
        if (FlyingSardinePvE.CanUse(out act)) return true; // 24
        if (FazePvE.CanUse(out act)) return true; // 23
        if (TransfusionPvE.CanUse(out act)) return true; // 22
        if (SelfdestructPvE.CanUse(out act)) return true; // 21

        if (OffguardPvE.CanUse(out act)) return true; // 20
        if (BombTossPvE.CanUse(out act)) return true; // 19
        if (AcornBombPvE.CanUse(out act)) return true; // 18
        if (BloodDrainPvE.CanUse(out act)) return true; // 17
        if (IceSpikesPvE.CanUse(out act)) return true; // 16
        if (SharpenedKnifePvE.CanUse(out act)) return true; // 15
        if (Level5PetrifyPvE.CanUse(out act)) return true; // 14
        if (WhiteWindPvE.CanUse(out act)) return true; // 13
        if (BristlePvE.CanUse(out act)) return true; // 12
        if (PlaincrackerPvE.CanUse(out act)) return true; // 11

        if (GlowerPvE.CanUse(out act)) return true; // 10
        if (SongOfTormentPvE.CanUse(out act)) return true; // 9
        if (FinalStingPvE.CanUse(out act)) return true; // 8
        if (LoomPvE.CanUse(out act)) return true; // 7
        if (HighVoltagePvE.CanUse(out act)) return true; // 6
        if (DrillCannonsPvE.CanUse(out act)) return true; // 5
        if (FlyingSardinePvE.CanUse(out act)) return true; // 4
        if (NoD && AquaBreathPvE.CanUse(out act)) return true; // 3
        if (FlameThrowerPvE.CanUse(out act)) return true; // 2
        if (WaterCannonPvE.CanUse(out act)) return true; // 1

        return base.GeneralGCD(out act);
    }
}