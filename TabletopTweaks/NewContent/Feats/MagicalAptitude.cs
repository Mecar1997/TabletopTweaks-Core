﻿using Kingmaker.EntitySystem.Stats;
using TabletopTweaks.Config;
using TabletopTweaks.Extensions;
using TabletopTweaks.Utilities;

namespace TabletopTweaks.NewContent.Feats {
    static class MagicalAptitude {
        public static void AddMagicalAptitude() {
            var MagicalAptitude = FeatTools.CreateSkillFeat("MagicalAptitude", StatType.SkillKnowledgeArcana, StatType.SkillUseMagicDevice, bp => {
                bp.SetName("048f9664c7014c1b8c6fe5f450e749e3", "Magical Aptitude");
                bp.SetDescription("ca89a2430e1b4f33b4bdda48d02f6ea4", "You are skilled at spellcasting and using magic items." +
                    "\nYou get a +2 bonus on Knowledge (Arcana) and " +
                    "Use Magic Device skill checks. If you have 10 or more ranks in one of these skills," +
                    " the bonus increases to +4 for that skill.");
            });
            if (ModSettings.AddedContent.Feats.IsDisabled("MagicalAptitude")) { return; }
            FeatTools.AddAsFeat(MagicalAptitude);
        }
    }
}
