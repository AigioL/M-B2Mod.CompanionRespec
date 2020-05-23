#region 程序集 TaleWorlds.CampaignSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// C:\Program Files (x86)\Steam\steamapps\common\Mount & Blade II Bannerlord\bin\Win64_Shipping_Client\TaleWorlds.CampaignSystem.dll
#endregion

using System;
using System.Collections.Generic;

namespace TaleWorlds.CampaignSystem
{
    public class DefaultPerks
    {
        public PerkObject PolearmExtraHp;
        public PerkObject BowMerryMen;
        public PerkObject BowInstructor;
        public PerkObject BowInstinctiveShot;
        public PerkObject BowBattleEquipped;
        public PerkObject BowHowlingBolt;
        public PerkObject BowPickTargets;
        public PerkObject BowRanger;
        public PerkObject BowArcheryRenown;
        public PerkObject BowIntimidateInfantry;
        public PerkObject CrossbowHastyReload;
        public PerkObject CrossbowPlainHunter;
        public PerkObject CrossbowImprovedAim;
        public PerkObject CrossbowMaintenance;
        public PerkObject CrossbowRecruiter;
        public PerkObject CrossbowRenownedMarksman;
        public PerkObject CrossbowVolleyCommander;
        public PerkObject CrossbowWithoutHonor;
        public PerkObject CrossbowBoneBolts;
        public PerkObject CrossbowCrossbowCavalry;
        public PerkObject BowIntimidateArchers;
        public PerkObject CrossbowFastReload;
        public PerkObject BowMountedArcher;
        public PerkObject PolearmHorseKiller;
        public PerkObject PolearmFootwork;
        public PerkObject PolearmLancer;
        public PerkObject PolearmPushback;
        public PerkObject PolearmPowerfulThrust;
        public PerkObject PolearmHowlingSwing;
        public PerkObject PolearmExpertInfantry;
        public PerkObject PolearmExpertCavalry;
        public PerkObject PolearmStandardBearer;
        public PerkObject PoleArmRapidLancer;
        public PerkObject PoleArmKeepAtBay;
        public PerkObject PoleArmTightGrip;
        public PerkObject PoleArmSlaughter;
        public PerkObject BowMarksman;
        public PerkObject BowStrongPull;
        public PerkObject BowFasterAim;
        public PerkObject BowMarshesHunter;
        public PerkObject BowForestHunter;
        public PerkObject BowLargeQuiver;

        public static IEnumerable<PerkObject> GetAllPerks() => Array.Empty<PerkObject>();

        public static class OneHanded
        {
            public static PerkObject Deflect { get; }
            public static PerkObject DeadlyPurpose { get; }
            public static PerkObject FleetOfFoot { get; }
            public static PerkObject SteelCoreShields { get; }
            public static PerkObject LeadByExample { get; }
            public static PerkObject StandUnited { get; }
            public static PerkObject FullBarracks { get; }
            public static PerkObject StrengthInNumbers { get; }
            public static PerkObject UnwaveringDefense { get; }
            public static PerkObject ArrowCatcher { get; }
            public static PerkObject Duelist { get; }
            public static PerkObject OneHandedTrainer { get; }
            public static PerkObject ShieldBearer { get; }
            public static PerkObject Cavalry { get; }
            public static PerkObject StrongArms { get; }
            public static PerkObject ToBeBlunt { get; }
            public static PerkObject Basher { get; }
            public static PerkObject ShieldWall { get; }
            public static PerkObject WayOfTheSword { get; }
        }
        public static class Strategy
        {
        }
        public static class Trade
        {
            public static PerkObject Appraiser { get; }
            public static PerkObject EverythingHasAPrice { get; }
            public static PerkObject TradeyardForeman { get; }
            public static PerkObject GranaryAccountant { get; }
            public static PerkObject RapidDevelopment { get; }
            public static PerkObject InsurancePlans { get; }
            public static PerkObject ContentTrades { get; }
            public static PerkObject VillagerConnections { get; }
            public static PerkObject Extra1 { get; }
            public static PerkObject GreatInvestor { get; }
            public static PerkObject Tollgates { get; }
            public static PerkObject DistributedGoods { get; }
            public static PerkObject LocalConnection { get; }
            public static PerkObject TravelingRumors { get; }
            public static PerkObject TownMerchant { get; }
            public static PerkObject CaravanMaster { get; }
            public static PerkObject WholeSeller { get; }
            public static PerkObject ArtisanCommunity { get; }
            public static PerkObject Extra2 { get; }
        }
        public static class Charm
        {
            public static PerkObject Diplomacy { get; }
            public static PerkObject Parade { get; }
            public static PerkObject Courtship { get; }
            public static PerkObject NaturalLeader { get; }
            public static PerkObject MoralLeader { get; }
            public static PerkObject ProFamilia { get; }
            public static PerkObject OurGloriousLeader { get; }
            public static PerkObject Promoter { get; }
            public static PerkObject EffortForThePeople { get; }
            public static PerkObject RespectfulOpposition { get; }
            public static PerkObject Champion { get; }
            public static PerkObject YoungAndRespectful { get; }
            public static PerkObject InBloom { get; }
            public static PerkObject MeaningfulFavors { get; }
            public static PerkObject ForgivableGrievances { get; }
            public static PerkObject ShowYourScars { get; }
            public static PerkObject AdventureStories { get; }
            public static PerkObject IceBreaker { get; }
            public static PerkObject Extra1 { get; }
            public static PerkObject ImmortalCharm { get; }
        }
        public static class Steward
        {
            public static PerkObject TaxCollector { get; }
            public static PerkObject SwordsAsTribute { get; }
            public static PerkObject WarRations { get; }
            public static PerkObject LogisticsExpert { get; }
            public static PerkObject Warmonger { get; }
            public static PerkObject Prominence { get; }
            public static PerkObject SupremeAuthority { get; }
            public static PerkObject Ruler { get; }
            public static PerkObject FoodRationing { get; }
            public static PerkObject Reeve { get; }
            public static PerkObject ManAtArms { get; }
            public static PerkObject EnhancedMines { get; }
            public static PerkObject ProsperousReign { get; }
            public static PerkObject Bannerlord { get; }
            public static PerkObject NourishSettlement { get; }
            public static PerkObject Agriculture { get; }
            public static PerkObject MountExpert { get; }
            public static PerkObject StandUnited { get; }
        }
        public static class Leadership
        {
            public static PerkObject CombatTips { get; }
            public static PerkObject Companions { get; }
            public static PerkObject SwordsAsTribute { get; }
            public static PerkObject InspringWarrior { get; }
            public static PerkObject PublicTalker { get; }
            public static PerkObject AssuringPresence { get; }
            public static PerkObject InspringLeader { get; }
            public static PerkObject CitizenMilitia { get; }
            public static PerkObject DrillMaster { get; }
            public static PerkObject LeaderOfMasses { get; }
            public static PerkObject DispenserOfJustice { get; }
            public static PerkObject VeteransRespect { get; }
            public static PerkObject LevySergeant { get; }
            public static PerkObject Gratitude { get; }
            public static PerkObject StiffUpperLip { get; }
            public static PerkObject StaurDefender { get; }
            public static PerkObject InspiringAttacker { get; }
            public static PerkObject RaiseTheMeek { get; }
            public static PerkObject UltimateLeader { get; }
            public static PerkObject Extra1 { get; }
        }
        public static class Roguery
        {
            public static PerkObject RaidingParty { get; }
            public static PerkObject EyeForLoot { get; }
            public static PerkObject CommandingPresence { get; }
            public static PerkObject RaidForTheThrill { get; }
            public static PerkObject Scavenger { get; }
            public static PerkObject ConcealedBlade { get; }
            public static PerkObject SlipIntoShadows { get; }
            public static PerkObject BribeMaster { get; }
            public static PerkObject Negotiator { get; }
            public static PerkObject Camouflage { get; }
        }
        public static class Scouting
        {
            public static PerkObject Pathfinder { get; }
            public static PerkObject TorchCarriers { get; }
            public static PerkObject Navigator { get; }
            public static PerkObject Investigator { get; }
            public static PerkObject Farsighted { get; }
            public static PerkObject Ambusher { get; }
            public static PerkObject ForestLore { get; }
            public static PerkObject DesertLore { get; }
            public static PerkObject HillsLore { get; }
            public static PerkObject MarshesLore { get; }
        }
        public static class Medicine
        {
            public static PerkObject SelfMedication { get; }
            public static PerkObject FortitudeTonic { get; }
            public static PerkObject CheatDeath { get; }
            public static PerkObject CleanInfrastructure { get; }
            public static PerkObject PhysicianOfPeople { get; }
            public static PerkObject HealthAdvise { get; }
            public static PerkObject PerfectHealth { get; }
            public static PerkObject BushDoctor { get; }
            public static PerkObject Extra1 { get; }
            public static PerkObject PristineStreets { get; }
            public static PerkObject GoodLodging { get; }
            public static PerkObject BestMedicine { get; }
            public static PerkObject DoctorsOath { get; }
            public static PerkObject MobileAid { get; }
            public static PerkObject WalkItOff { get; }
            public static PerkObject TriageTent { get; }
            public static PerkObject PreventiveMedicine { get; }
            public static PerkObject SiegeMedic { get; }
            public static PerkObject MinisterOfHealth { get; }
        }
        public static class Tactics
        {
            public static PerkObject CompanionCavalry { get; }
            public static PerkObject TacticalSuperiority { get; }
            public static PerkObject OneStepAhead { get; }
            public static PerkObject Logistics { get; }
            public static PerkObject AmbushSpecialist { get; }
            public static PerkObject Phalanx { get; }
            public static PerkObject HammerAndAnvil { get; }
            public static PerkObject Elusive { get; }
        }
        public static class Athletics
        {
            public static PerkObject ExtraArrows { get; }
            public static PerkObject ExtraThrowingWeapons { get; }
            public static PerkObject CloseQuartersTraining { get; }
            public static PerkObject RangedTraining { get; }
            public static PerkObject Endurance { get; }
            public static PerkObject Dexterous { get; }
            public static PerkObject Powerkick { get; }
        }
        public static class Riding
        {
            public static PerkObject Vigorous { get; }
            public static PerkObject SpareArrows { get; }
            public static PerkObject SpareThrowingWeapon { get; }
            public static PerkObject Sharpshooter { get; }
            public static PerkObject Squires { get; }
            public static PerkObject MountedArcher { get; }
            public static PerkObject Cavalry { get; }
            public static PerkObject BowExpert { get; }
            public static PerkObject CrossbowExpert { get; }
            public static PerkObject HorseGrooming { get; }
            public static PerkObject Conroi { get; }
            public static PerkObject Trampler { get; }
            public static PerkObject IronSteed { get; }
            public static PerkObject FilledToBrim { get; }
            public static PerkObject NomadicTraditions { get; }
        }
        public static class Throwing
        {
            public static PerkObject SteadyHand { get; }
            public static PerkObject SkullCrasher { get; }
            public static PerkObject FullyArmed { get; }
            public static PerkObject Skirmishers { get; }
            public static PerkObject ConcealedCarry { get; }
            public static PerkObject BattleReady { get; }
            public static PerkObject MasterThrower { get; }
            public static PerkObject PerfectAccuracy { get; }
            public static PerkObject WellPrepared { get; }
            public static PerkObject Extra1 { get; }
            public static PerkObject Extra2 { get; }
        }
        public static class Crossbow
        {
            public static PerkObject FastReload { get; }
            public static PerkObject HastyReload { get; }
            public static PerkObject CrossbowCavalry { get; }
            public static PerkObject PlainHunter { get; }
            public static PerkObject ImprovedAim { get; }
            public static PerkObject Maintenance { get; }
            public static PerkObject Recruiter { get; }
            public static PerkObject RenownedMarksman { get; }
            public static PerkObject VolleyCommander { get; }
            public static PerkObject WithoutHonor { get; }
            public static PerkObject BoneBolts { get; }
        }
        public static class Bow
        {
            public static PerkObject Marksman { get; }
            public static PerkObject PickTargets { get; }
            public static PerkObject HowlingBolt { get; }
            public static PerkObject BattleEquipped { get; }
            public static PerkObject InstinctiveShot { get; }
            public static PerkObject Instructor { get; }
            public static PerkObject MerryMen { get; }
            public static PerkObject Ranger { get; }
            public static PerkObject IntimidateInfantry { get; }
            public static PerkObject LargeQuiver { get; }
            public static PerkObject MountedArcher { get; }
            public static PerkObject ForestHunter { get; }
            public static PerkObject MarshesHunter { get; }
            public static PerkObject FasterAim { get; }
            public static PerkObject StrongPull { get; }
            public static PerkObject IntimidateArchers { get; }
            public static PerkObject ArcheryRenown { get; }
        }
        public static class Polearm
        {
            public static PerkObject ExtraHp { get; }
            public static PerkObject StandardBearer { get; }
            public static PerkObject HorseKiller { get; }
            public static PerkObject Footwork { get; }
            public static PerkObject Lancer { get; }
            public static PerkObject PushBack { get; }
            public static PerkObject PowerfulThrust { get; }
            public static PerkObject HowlingSwing { get; }
            public static PerkObject ExpertInfantry { get; }
            public static PerkObject ExpertCavalry { get; }
            public static PerkObject RapidLancer { get; }
            public static PerkObject KeepAtBay { get; }
            public static PerkObject Slaughter { get; }
            public static PerkObject TightGrip { get; }
        }
        public static class TwoHanded
        {
            public static PerkObject ExtraHp { get; }
            public static PerkObject KnockDown { get; }
            public static PerkObject Dominator { get; }
            public static PerkObject Vandal { get; }
            public static PerkObject HorseSlaughter { get; }
            public static PerkObject InspiringLeader { get; }
            public static PerkObject LegendaryTwoHanded { get; }
            public static PerkObject Berserker { get; }
            public static PerkObject MountedTwoHanded { get; }
            public static PerkObject Eviscerator { get; }
            public static PerkObject ShieldBreaker { get; }
            public static PerkObject EdgePlacement { get; }
            public static PerkObject MultiHit { get; }
            public static PerkObject QuickPlunder { get; }
            public static PerkObject Notorious { get; }
            public static PerkObject SpeedBasher { get; }
            public static PerkObject PowerBasher { get; }
            public static PerkObject ReducedWage { get; }
            public static PerkObject GarrisonCapacity { get; }
            public static PerkObject ExtraDamage { get; }
            public static PerkObject TwoHandedMastery { get; }
            public static PerkObject DeflectArrows { get; }
        }
        public static class Crafting
        {
            public static PerkObject IronMaker { get; }
            public static PerkObject SiegeExpert { get; }
            public static PerkObject WeaponMasterSmith { get; }
            public static PerkObject EnduringSmith { get; }
            public static PerkObject StrongSmith { get; }
            public static PerkObject VigorousSmith { get; }
            public static PerkObject LegendarySmith { get; }
            public static PerkObject MasterSmith { get; }
            public static PerkObject ExperiencedSmith { get; }
            public static PerkObject SharpenedEdge { get; }
            public static PerkObject ArtisanSmith { get; }
            public static PerkObject PracticalSmelter { get; }
            public static PerkObject PracticalRefiner { get; }
            public static PerkObject CuriousSmith { get; }
            public static PerkObject CuriousSmelter { get; }
            public static PerkObject SteelMaker3 { get; }
            public static PerkObject SteelMaker2 { get; }
            public static PerkObject SteelMaker { get; }
            public static PerkObject CharcoalMaker { get; }
            public static PerkObject PracticalSmith { get; }
            public static PerkObject SharpenedTip { get; }
        }
        public static class Engineering
        {
            public static PerkObject ConstructionExpert { get; }
            public static PerkObject Ballistics { get; }
        }
    }

    public struct PerkObject
    {
        public static IEnumerable<PerkObject> All { get; } = DefaultPerks.GetAllPerks();
    }
}