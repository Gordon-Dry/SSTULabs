﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSTUTools
{
    public class SSTUGameSettings : GameParameters.CustomParameterNode
    {

        [GameParameters.CustomParameterUI("Boiloff Enabled?", toolTip = "Boiloff for Cryogenic fuels.  If enabled, cryogenic fuels will slowly evaporate if cooling is not provided.")]
        public bool boiloffEnabled = true;

        [GameParameters.CustomFloatParameterUI("Boiloff Multiplier", asPercentage = true, minValue = 0, maxValue = 2, toolTip = "How fast do cryogenic fuels evaporate? 0 = none, 1 = standard rate, 2 = 2x standard rate.")]
        public float boiloffModifier = 1f;

        [GameParameters.CustomParameterUI("Override stock sandbox upgrade", toolTip = "Force-sets the stock 'apply upgrades in sandbox' to true.")]
        public bool upgradesInSandboxOverride = true;

        [GameParameters.CustomParameterUI("Persistent Recolor Selections", toolTip = "If true, custom recolor selections will persist across texture set changes.")]
        public bool persistRecolorSelections = false;

        public override string Section { get { return "SSTU"; } }

        public override int SectionOrder { get { return 1; } }

        public override string Title { get { return "SSTU Options"; } }

        public override GameParameters.GameMode GameMode { get { return GameParameters.GameMode.ANY; } }

        public override bool HasPresets { get { return true; } }

        public override string DisplaySection
        {
            get
            {
                return "SSTU";
            }
        }

        public override void SetDifficultyPreset(GameParameters.Preset preset)
        {
            switch (preset)
            {
                case GameParameters.Preset.Easy:
                    boiloffModifier = 0f;
                    boiloffEnabled = false;
                    break;
                case GameParameters.Preset.Normal:
                    boiloffModifier = 0.5f;
                    boiloffEnabled = true;
                    break;
                case GameParameters.Preset.Moderate:
                    boiloffModifier = 1f;
                    boiloffEnabled = true;
                    break;
                case GameParameters.Preset.Hard:
                    boiloffModifier = 1f;
                    boiloffEnabled = true;
                    break;
                case GameParameters.Preset.Custom:
                    boiloffModifier = 1f;
                    boiloffEnabled = true;
                    break;
                default:
                    boiloffModifier = 1f;
                    boiloffEnabled = true;
                    break;
            }
        }

        public static bool persistRecolor()
        {
            if (HighLogic.CurrentGame != null)
            {
                return HighLogic.CurrentGame.Parameters.CustomParams<SSTUGameSettings>().persistRecolorSelections;
            }
            return false;
        }

    }
}
