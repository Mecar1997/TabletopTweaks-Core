﻿using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using TabletopTweaks.Config;
using TabletopTweaks.Extensions;
using TabletopTweaks.NewComponents;
using TabletopTweaks.Utilities;

namespace TabletopTweaks.NewContent.Races {
    static class Elf {

        private static readonly BlueprintRace ElfRace = Resources.GetBlueprint<BlueprintRace>("25a5878d125338244896ebd3238226c8");
        private static readonly BlueprintFeatureSelection ElvenHeritageSelection = Resources.GetBlueprint<BlueprintFeatureSelection>("5482f879dcfd40f9a3168fdb48bc938c");
        private static readonly BlueprintFeature ElvenWeaponFamiliarity = Resources.GetBlueprint<BlueprintFeature>("03fd1e043fc678a4baf73fe67c3780ce");
        private static readonly BlueprintFeature ElvenImmunities = Resources.GetBlueprint<BlueprintFeature>("2483a523984f44944a7cf157b21bf79c");
        private static readonly BlueprintFeature ElvenMagic = Resources.GetBlueprint<BlueprintFeature>("55edf82380a1c8540af6c6037d34f322");
        private static readonly BlueprintFeature KeenSenses = Resources.GetBlueprint<BlueprintFeature>("9c747d24f6321f744aa1bb4bd343880d");

        private static readonly BlueprintFeature BlightbornElf = Resources.GetBlueprint<BlueprintFeature>("2a300f4e0c13495bbde59160809fce7f");
        private static readonly BlueprintFeature LoremasterElf = Resources.GetBlueprint<BlueprintFeature>("fb69a451e7064015b5dbe512c9122ef8");

        private static readonly BlueprintFeature DestinyBeyondBirthMythicFeat = Resources.GetBlueprint<BlueprintFeature>("325f078c584318849bfe3da9ea245b9d");

        public static void AddElfHeritage() {

            var ElfAbilityModifiers = Helpers.CreateBlueprint<BlueprintFeature>("ElfAbilityModifiers", bp => {
                bp.IsClassFeature = true;
                bp.HideInUI = true;
                bp.Ranks = 1;
                bp.HideInCharacterSheetAndLevelUp = true;
                bp.Groups = new FeatureGroup[] { FeatureGroup.Racial };
                bp.SetName("3bc5959c5153418da2357db2f77bdd96", "Elf Ability Modifiers");
                bp.SetDescription("fd735240e5ea4c77a3c0aee7ecdd83b9", "Elves are nimble, both in body and mind, but their form is frail. They gain +2 Dexterity, +2 Intelligence, and –2 Constitution.");
                bp.AddComponent(Helpers.Create<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Racial;
                    c.Stat = StatType.Intelligence;
                    c.Value = 2;
                }));
                bp.AddComponent(Helpers.Create<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Racial;
                    c.Stat = StatType.Dexterity;
                    c.Value = 2;
                }));
                bp.AddComponent(Helpers.Create<AddStatBonusIfHasFact>(c => {
                    c.Descriptor = ModifierDescriptor.Racial;
                    c.Stat = StatType.Constitution;
                    c.Value = -2;
                    c.InvertCondition = true;
                    c.m_CheckedFacts = new BlueprintUnitFactReference[] { DestinyBeyondBirthMythicFeat.ToReference<BlueprintUnitFactReference>() };
                }));
                bp.AddComponent(Helpers.Create<RecalculateOnFactsChange>(c => {
                    c.m_CheckedFacts = new BlueprintUnitFactReference[] { DestinyBeyondBirthMythicFeat.ToReference<BlueprintUnitFactReference>() };
                }));
            });
            var ElfNoAlternateTrait = Helpers.CreateBlueprint<BlueprintFeature>("ElfNoAlternateTrait", bp => {
                bp.IsClassFeature = true;
                bp.Ranks = 1;
                bp.Groups = new FeatureGroup[] { FeatureGroup.Racial };
                bp.HideInUI = true;
                bp.HideInCharacterSheetAndLevelUp = true;
                bp.SetName("11d4a7cf92234d0cafda39842561dff3", "None");
                bp.SetDescription("14a803e74b8b4129a9bad42f62ce843b", "No Alternate Trait");
            });
            var ElfFieraniFeature = Helpers.CreateBlueprint<BlueprintFeature>("ElfFieraniFeature", bp => {
                bp.IsClassFeature = true;
                bp.Ranks = 1;
                bp.Groups = new FeatureGroup[] { FeatureGroup.Racial };
                bp.SetName("779d633a26fb4bcaa29bb549b16a8617", "Fierani Elf");
                bp.SetDescription("751645ae268046a3b2805975a1ec10fc", "Having returned to Golarion to reclaim their ancestral homeland, some elves of the Fierani Forest have a closer bond "
                    + "to nature than most of their kin. Elves with this racial trait gain +2 Dexterity, +2 Wisdom, and -2 Constitution."
                    + "\nThis racial trait alters the elves’ ability score modifiers.");
                bp.AddComponent(Helpers.Create<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Racial;
                    c.Stat = StatType.Wisdom;
                    c.Value = 2;
                }));
                bp.AddComponent(Helpers.Create<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Racial;
                    c.Stat = StatType.Dexterity;
                    c.Value = 2;
                }));
                bp.AddComponent(Helpers.Create<AddStatBonusIfHasFact>(c => {
                    c.Descriptor = ModifierDescriptor.Racial;
                    c.Stat = StatType.Constitution;
                    c.Value = -2;
                    c.InvertCondition = true;
                    c.m_CheckedFacts = new BlueprintUnitFactReference[] { DestinyBeyondBirthMythicFeat.ToReference<BlueprintUnitFactReference>() };
                }));
                bp.AddComponent(Helpers.Create<RecalculateOnFactsChange>(c => {
                    c.m_CheckedFacts = new BlueprintUnitFactReference[] { DestinyBeyondBirthMythicFeat.ToReference<BlueprintUnitFactReference>() };
                }));
                bp.AddTraitReplacment(ElfAbilityModifiers);
                bp.AddSelectionCallback(ElvenHeritageSelection);
            });
            var ElfArcaneFocusFeature = Helpers.CreateBlueprint<BlueprintFeature>("ElfArcaneFocusFeature", bp => {
                bp.IsClassFeature = true;
                bp.Ranks = 1;
                bp.Groups = new FeatureGroup[] { FeatureGroup.Racial };
                bp.SetName("8e14d9e9a3c64007a35b704ebcf6f91f", "Arcane Focus");
                bp.SetDescription("66d782ae1b694e19aa19c21169837fcf", "Some elven families have such long traditions of producing wizards (and other arcane spellcasters) that they raise their children " +
                    "with the assumption each is destined to be a powerful magic-user, with little need for mundane concerns such as skill with weapons. " +
                    "Elves with this racial trait gain a +2 racial bonus on concentration checks.\nThis racial trait replaces weapon familiarity.");
                bp.AddComponent(Helpers.Create<ConcentrationBonus>(c => {
                    c.Value = 2;
                }));
                bp.AddTraitReplacment(ElvenWeaponFamiliarity);
                bp.AddSelectionCallback(ElvenHeritageSelection);
            });
            var ElfLongLimbedFeature = Helpers.CreateBlueprint<BlueprintFeature>("ElfLongLimbedFeature", bp => {
                bp.IsClassFeature = true;
                bp.Ranks = 1;
                bp.Groups = new FeatureGroup[] { FeatureGroup.Racial };
                bp.SetName("ab5bd7f92e004db797bc989190b75116", "Long Limbed");
                bp.SetDescription("e66cf06441334f4d8f1dd31c9aeb3272", "Elves with this racial trait have a base move speed of 35 feet.\nThis racial trait replaces weapon familiarity.");
                bp.AddComponent(Helpers.Create<BuffMovementSpeed>(c => {
                    c.Descriptor = ModifierDescriptor.Racial;
                    c.Value = 5;
                    c.ContextBonus = new ContextValue();
                }));
                bp.AddTraitReplacment(ElvenWeaponFamiliarity);
                bp.AddSelectionCallback(ElvenHeritageSelection);
            });
            var ElfMoonkissedFeature = Helpers.CreateBlueprint<BlueprintFeature>("ElfMoonkissedFeature", bp => {
                bp.IsClassFeature = true;
                bp.Ranks = 1;
                bp.Groups = new FeatureGroup[] { FeatureGroup.Racial };
                bp.SetName("bcb70c72672a4aaabdcf43bb23c5ba7f", "Moonkissed");
                bp.SetDescription("6fe09389867d4866a160ef8942243928", "Elves with this alternate racial trait gain a +1 racial bonus on saving throws.\nThis replaces elven immunities and keen senses.");
                bp.AddComponent(Helpers.Create<BuffAllSavesBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Racial;
                    c.Value = 1;
                }));
                bp.AddTraitReplacment(KeenSenses);
                bp.AddTraitReplacment(ElvenImmunities);
                bp.AddSelectionCallback(ElvenHeritageSelection);
            });
            var ElfVigilanceFeature = Helpers.CreateBlueprint<BlueprintFeature>("ElfVigilanceFeature", bp => {
                bp.IsClassFeature = true;
                bp.Ranks = 1;
                bp.Groups = new FeatureGroup[] { FeatureGroup.Racial };
                bp.SetName("9b2669b7f84c475e92bc51fb5db1f6b9", "Vigilance");
                bp.SetDescription("014a083b14654fcbb9e05b4b23b82f14", "You gain a +2 dodge bonus to AC against attacks by chaotic creatures.\nThis trait replaces elven magic.");
                bp.AddComponent(Helpers.Create<ArmorClassBonusAgainstAlignment>(c => {
                    c.alignment = AlignmentComponent.Chaotic;
                    c.Descriptor = ModifierDescriptor.Dodge;
                    c.Value = 2;
                    c.Bonus = new ContextValue();
                }));
                bp.AddTraitReplacment(ElvenMagic);
                bp.AddSelectionCallback(ElvenHeritageSelection);
            });

            BlightbornElf.RemoveComponents<RemoveFeatureOnApply>();
            BlightbornElf.AddTraitReplacment(ElvenImmunities);
            BlightbornElf.AddTraitReplacment(ElvenMagic);
            BlightbornElf.AddSelectionCallback(ElvenHeritageSelection);

            LoremasterElf.RemoveComponents<RemoveFeatureOnApply>();
            LoremasterElf.AddTraitReplacment(KeenSenses);
            LoremasterElf.AddTraitReplacment(ElvenMagic);
            LoremasterElf.AddSelectionCallback(ElvenHeritageSelection);

            if (ModSettings.AddedContent.Races.IsDisabled("ElfAlternateTraits")) { return; }
            ElfRace.SetComponents(Helpers.Create<AddFeatureOnApply>(c => {
                c.m_Feature = ElfAbilityModifiers.ToReference<BlueprintFeatureReference>();
            }));
            ElvenHeritageSelection.SetName("facb28e2e1b84c0f97f41fa02e0458ba", "Alternate Traits");
            ElvenHeritageSelection.SetDescription("91b8cdbe23cb49f596eaf0d0b21cbce5", "The following alternate traits are available.");
            ElvenHeritageSelection.Group = FeatureGroup.KitsuneHeritage;
            ElvenHeritageSelection.SetFeatures(
                ElfNoAlternateTrait,
                ElfFieraniFeature,
                ElfArcaneFocusFeature,
                ElfLongLimbedFeature,
                ElfMoonkissedFeature,
                ElfVigilanceFeature,
                BlightbornElf,
                LoremasterElf
            );
        }

        private static void AddTraitReplacment(this BlueprintFeature feature, BlueprintFeature replacement) {
            feature.AddComponent(Helpers.Create<RemoveFeatureOnApply>(c => {
                c.m_Feature = replacement.ToReference<BlueprintUnitFactReference>();
            }));
            feature.AddPrerequisiteFeature(replacement);
        }

        private static void AddSelectionCallback(this BlueprintFeature feature, BlueprintFeatureSelection selection) {
            feature.AddComponent(Helpers.Create<AddAdditionalRacialFeatures>(c => {
                c.Features = new BlueprintFeatureBaseReference[] { selection.ToReference<BlueprintFeatureBaseReference>() };
            }));
        }
    }
}
