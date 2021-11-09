﻿using Kingmaker.EntitySystem.Stats;
using TabletopTweaks.Config;
using TabletopTweaks.Extensions;
using TabletopTweaks.Utilities;

namespace TabletopTweaks.NewContent.Feats {
    static class Scholar {
        public static void AddScholar() {
            // Icon: Spell Focus? Alertness?
            var Scholar = FeatTools.CreateSkillFeat("Scholar", StatType.SkillKnowledgeArcana, StatType.SkillKnowledgeWorld, bp => {
                bp.SetName("1cac2cda30e843178f562df23acdf513", "Scholar");
                bp.SetDescription("3262b6277a8e4e3b9d54150bb513b2e3", "You have graduated from one of the many colleges, universities, and specialized schools of higher learning scattered throughout the Inner Sea region." +
                    "\nYou get a +2 bonus on Knowledge (Arcana) and " +
                    "Knowledge (World) skill checks. If you have 10 or more ranks in one of these skills," +
                    " the bonus increases to +4 for that skill.");
            });
            if (ModSettings.AddedContent.Feats.IsDisabled("Scholar")) { return; }
            FeatTools.AddAsFeat(Scholar);
        }
    }
}
