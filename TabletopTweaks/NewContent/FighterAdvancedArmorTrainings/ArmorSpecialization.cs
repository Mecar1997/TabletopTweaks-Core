﻿using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components;
using TabletopTweaks.Config;
using TabletopTweaks.Extensions;
using TabletopTweaks.NewComponents;
using TabletopTweaks.Utilities;

namespace TabletopTweaks.NewContent.FighterAdvancedArmorTrainings {
    class ArmorSpecialization {
        public static void AddArmorSpecialization() {
            var FighterClass = Resources.GetBlueprint<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var ArmorFocusLight = Resources.GetBlueprint<BlueprintFeature>("3bc6e1d2b44b5bb4d92e6ba59577cf62");

            var ArmorSpecializationSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>("ArmorSpecializationSelection", bp => {
                bp.SetName("42b3df4853f040caa9eab9c73f35b1ce", "Armor Specialization");
                bp.SetDescription("dc4ffe1bfb854d0fa0759e085ea61d80", "The fighter selects one specific type of armor with which he is proficient, such as light or heavy. " +
                    "While wearing the selected type of armor, the fighter adds one-quarter of his fighter level to the armor’s " +
                    "{g|Encyclopedia:Armor_Class}armor{/g} {g|Encyclopedia:Bonus}bonus{/g}, up to a " +
                    "maximum bonus of +3 for light armor, +4 for medium armor, or +5 for heavy armor. This increase to the {g|Encyclopedia:Armor_Class}armor{/g} " +
                    "{g|Encyclopedia:Bonus}bonus{/g} doesn’t increase " +
                    "the benefit that the fighter gains from feats, class abilities, or other effects that are determined by his armor’s base " +
                    "{g|Encyclopedia:Armor_Class}armor{/g} {g|Encyclopedia:Bonus}bonus{/g}, " +
                    "including other advanced armor training options. A fighter can choose this option multiple times. Each time he chooses it, he applies " +
                    "its benefit to a different type of armor.");
                bp.m_AllFeatures = new BlueprintFeatureReference[0];
                bp.m_Features = new BlueprintFeatureReference[0];
                bp.IsClassFeature = true;
            });
            var ArmorSpecializationLightEffect = Helpers.CreateBlueprint<BlueprintFeature>("ArmorSpecializationLightEffect", bp => {
                bp.SetName("60543feebf344acfb098df7ea0758760", "Light Armor Specialization");
                bp.SetDescription("5d9b48d9cc74449c9d4e3c40f0212967", "Light Armor Specialization");
                bp.IsClassFeature = true;
                bp.HideInCharacterSheetAndLevelUp = true;
                bp.Ranks = 1;
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.ArmorFocus;
                    c.Stat = StatType.AC;
                    c.Value = new ContextValue {
                        ValueType = ContextValueType.Rank,
                        ValueRank = AbilityRankType.StatBonus
                    };
                });
                bp.AddContextRankConfig(c => {
                    c.m_Type = AbilityRankType.StatBonus;
                    c.m_BaseValueType = ContextRankBaseValueType.ClassLevel;
                    c.m_Progression = ContextRankProgression.DivStep;
                    c.m_StartLevel = 1;
                    c.m_StepLevel = 4;
                    c.m_Max = 3;
                    c.m_Min = 1;
                    c.m_UseMin = true;
                    c.m_UseMax = true;
                    c.m_Class = new BlueprintCharacterClassReference[] { FighterClass.ToReference<BlueprintCharacterClassReference>() };
                });
            });
            var ArmorSpecializationLightFeature = Helpers.CreateBlueprint<BlueprintFeature>("ArmorSpecializationLightFeature", bp => {
                bp.m_Icon = ArmorFocusLight.Icon;
                bp.SetName("fd7f1034174b44f280b711af89eba411", "Light Armor Specialization");
                bp.SetDescription("e2064aab13b142b2b5c01d9d264d8d4a", "The {g|Encyclopedia:Armor_Class}AC{/g} {g|Encyclopedia:Bonus}bonus{/g} granted by any light armor you equip increases by 1 for every 4 fighter levels you possess up to a maximum of 3.");
                bp.IsClassFeature = true;
                bp.Ranks = 1;
                bp.AddComponent<ArmorFeatureUnlock>(c => {
                    c.NewFact = ArmorSpecializationLightEffect.ToReference<BlueprintUnitFactReference>();
                    c.RequiredArmor = new ArmorProficiencyGroup[] { ArmorProficiencyGroup.Light };
                });
            });
            var ArmorSpecializationMediumEffect = Helpers.CreateBlueprint<BlueprintFeature>("ArmorSpecializationMediumEffect", bp => {
                bp.SetName("bf4ac0d99518478bb8294a35078ad50e", "Medium Armor Specialization");
                bp.SetDescription("171fde0219b54587a0a1ac03fd06c172", "Medium Armor Specialization");
                bp.IsClassFeature = true;
                bp.HideInCharacterSheetAndLevelUp = true;
                bp.Ranks = 1;
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.ArmorFocus;
                    c.Stat = StatType.AC;
                    c.Value = new ContextValue {
                        ValueType = ContextValueType.Rank,
                        ValueRank = AbilityRankType.StatBonus
                    };
                });
                bp.AddContextRankConfig(c => {
                    c.m_Type = AbilityRankType.StatBonus;
                    c.m_BaseValueType = ContextRankBaseValueType.ClassLevel;
                    c.m_Progression = ContextRankProgression.DivStep;
                    c.m_StartLevel = 1;
                    c.m_StepLevel = 4;
                    c.m_Max = 4;
                    c.m_Min = 1;
                    c.m_UseMin = true;
                    c.m_UseMax = true;
                    c.m_Class = new BlueprintCharacterClassReference[] { FighterClass.ToReference<BlueprintCharacterClassReference>() };
                });
            });
            var ArmorSpecializationMediumFeature = Helpers.CreateBlueprint<BlueprintFeature>("ArmorSpecializationMediumFeature", bp => {
                bp.m_Icon = ArmorFocusLight.Icon;
                bp.SetName("de27eed10e5242c9b7ce5c46f0ffd662", "Medium Armor Specialization");
                bp.SetDescription("8ae8fad66ab94ae1bf098ef422bb5697", "The {g|Encyclopedia:Armor_Class}AC{/g} {g|Encyclopedia:Bonus}bonus{/g} granted by any medium armor " +
                    "you equip increases by 1 for every 4 fighter levels you possess up to a maximum of 4.");
                bp.IsClassFeature = true;
                bp.Ranks = 1;
                bp.AddComponent<ArmorFeatureUnlock>(c => {
                    c.NewFact = ArmorSpecializationMediumEffect.ToReference<BlueprintUnitFactReference>();
                    c.RequiredArmor = new ArmorProficiencyGroup[] { ArmorProficiencyGroup.Medium };
                });
            });
            var ArmorSpecializationHeavyEffect = Helpers.CreateBlueprint<BlueprintFeature>("ArmorSpecializationHeavyEffect", bp => {
                bp.SetName("87d1b2e4de414009a229547a0491eacd", "Heavy Armor Specialization");
                bp.SetDescription("cd6c4abe8a3f473fbb5fe0ca7114612a", "Heavy Armor Specialization");
                bp.IsClassFeature = true;
                bp.HideInCharacterSheetAndLevelUp = true;
                bp.Ranks = 1;
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.ArmorFocus;
                    c.Stat = StatType.AC;
                    c.Value = new ContextValue {
                        ValueType = ContextValueType.Rank,
                        ValueRank = AbilityRankType.StatBonus
                    };
                });
                bp.AddContextRankConfig(c => {
                    c.m_Type = AbilityRankType.StatBonus;
                    c.m_BaseValueType = ContextRankBaseValueType.ClassLevel;
                    c.m_Progression = ContextRankProgression.DivStep;
                    c.m_StartLevel = 1;
                    c.m_StepLevel = 4;
                    c.m_Max = 5;
                    c.m_Min = 1;
                    c.m_UseMin = true;
                    c.m_UseMax = true;
                    c.m_Class = new BlueprintCharacterClassReference[] { FighterClass.ToReference<BlueprintCharacterClassReference>() };
                });
            });
            var ArmorSpecializationHeavyFeature = Helpers.CreateBlueprint<BlueprintFeature>("ArmorSpecializationHeavyFeature", bp => {
                bp.m_Icon = ArmorFocusLight.Icon;
                bp.SetName("8e5f1de1852d456b8f3539f20eae338b", "Heavy Armor Specialization");
                bp.SetDescription("aa53a09cb7504a358f84a67ca86bd2f9", "The {g|Encyclopedia:Armor_Class}AC{/g} {g|Encyclopedia:Bonus}bonus{/g} " +
                    "granted by any heavy armor you equip increases by 1 for every 4 fighter levels you possess up to a maximum of 5.");
                bp.IsClassFeature = true;
                bp.Ranks = 1;
                bp.AddComponent<ArmorFeatureUnlock>(c => {
                    c.NewFact = ArmorSpecializationHeavyEffect.ToReference<BlueprintUnitFactReference>();
                    c.RequiredArmor = new ArmorProficiencyGroup[] { ArmorProficiencyGroup.Heavy };
                });
            });

            ArmorSpecializationSelection.AddFeatures(ArmorSpecializationLightFeature, ArmorSpecializationMediumFeature, ArmorSpecializationHeavyFeature);
            if (ModSettings.AddedContent.FighterAdvancedArmorTraining.IsDisabled("ArmorSpecialization")) { return; }
            AdvancedArmorTraining.AddToAdvancedArmorTrainingSelection(ArmorSpecializationSelection);
        }
    }
}
