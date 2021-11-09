﻿using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using TabletopTweaks.Config;
using TabletopTweaks.Extensions;
using TabletopTweaks.Utilities;

namespace TabletopTweaks.NewContent.Feats {
    class ExtraKi {
        public static void AddExtraKi() {
            var KiPowerResource = Resources.GetBlueprint<BlueprintAbilityResource>("9d9c90a9a1f52d04799294bf91c80a82");
            var KiPowerFeature = Resources.GetBlueprint<BlueprintFeature>("e9590244effb4be4f830b1e3fffced13");

            var ExtraKi = FeatTools.CreateExtraResourceFeat("ExtraKi", KiPowerResource, 2, bp => {
                bp.SetName("b0094dc7aec540d5b535a42af6c9aa17", "Extra Ki");
                bp.SetDescription("aea3b9bba6594e88a4fb28ed535cb37a", "Your ki pool increases by 2." +
                    "\nYou can take this feat multiple times. Its effects stack.");
                bp.AddPrerequisiteFeature(KiPowerFeature);
            });
            if (ModSettings.AddedContent.Feats.IsDisabled("ExtraKi")) { return; }
            FeatTools.AddAsFeat(ExtraKi);
        }
    }
}
