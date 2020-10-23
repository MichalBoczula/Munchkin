using Munchkin.BL.Helper;
using Munchkin.Model.Card.PrizeCard;
using Munchkin.Model.Card.PrizeCard.SituationalItems;
using Munchkin.Model.Character;
using Munchkin.Model.Character.Hero.Proficiency;
using Munchkin.Model.Character.Hero.Race;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.CardFactory
{
    public class ItemFactory
    {
        public ItemCard CreateHandsCard(string name)
        {
            var lambas = new Dictionary<bool, RaceBase>
            {
                { true, new Halfling("halfling") }
            };
            var excalibur = new Dictionary<bool, ProficiencyBase>
            {
                { false, new MageProficiency() }
            };
            var lighting = new Dictionary<bool, ProficiencyBase>
            {
                { true, new MageProficiency() }
            };
            var thorsHammer = new Dictionary<bool, ProficiencyBase>
            {
                { true, new WarriorProficiency() }
            };
            var trident = new Dictionary<bool, RaceBase>
            {
                { false, new Halfling("halfling") }
            };
            var sooLongBow = new Dictionary<bool, RaceBase>
            {
                { false, new Dwarf("dwarf") }
            };
            var result = name switch
            {
                "MirrorShield" => new ItemCard("MirrorShield", CardType.Prize, PrizeCardType.Item, 2, null, false, ItemType.Weapon, null, 400),
                "Lambas" => new ItemCard("Lambas", CardType.Prize, PrizeCardType.Item, 5, lambas, true, ItemType.Weapon, null, 300),
                "Excalibur" => new ItemCard("Excalibur", CardType.Prize, PrizeCardType.Item, 4, null, false, ItemType.Weapon, excalibur, 600),
                "Graal" => new ItemCard("Graal", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300),
                "Egida" => new ItemCard("Egida", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 500),
                "OrpheusHarp" => new ItemCard("OrpheusHarp", CardType.Prize, PrizeCardType.Item, 3, null, true, ItemType.Weapon, null, 300),
                "PowerAxe" => new ItemCard("PowerAxe", CardType.Prize, PrizeCardType.Item, 4, null, true, ItemType.Weapon, null, 600),
                "Lighting" => new ItemCard("Lighting", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, lighting, 100),
                "Trident" => new ItemCard("Trident", CardType.Prize, PrizeCardType.Item, 3, trident, false, ItemType.Weapon, null, 300),
                "MaceOfDestraction" => new ItemCard("MaceOfDestraction", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Weapon, null, 600),
                "HerculesBow" => new ItemCard("HerculesBow", CardType.Prize, PrizeCardType.Item, 4, null, true, ItemType.Weapon, null, 700),
                "SooLongBow" => new ItemCard("SooLongBow", CardType.Prize, PrizeCardType.Item, 3, sooLongBow, true, ItemType.Weapon, null, 400),
                "MagicFagot" => new ItemCard("MagicFagot", CardType.Prize, PrizeCardType.Item, 4, null, true, ItemType.Weapon, null, 600),
                "EsculapsStaff" => new ItemCard("EsculapsStaff", CardType.Prize, PrizeCardType.Item, 2, null, false, ItemType.Weapon, null, 500),
                "ThorsHammer" => new ItemCard("ThorsHammer", CardType.Prize, PrizeCardType.Item, 6, null, false, ItemType.Weapon, thorsHammer, 700),
                _ => null
            };
            return result;
        }

        public ItemCard CreateAdditionalItemCard(string name)
        {
            var cyberCoat = new Dictionary<bool, RaceBase>
            {
                { false, new Elf("elf") }
            };
            var betterDefenceSpray = new Dictionary<bool, ProficiencyBase>
            {
                { false, new WarriorProficiency() }
            };
            var result = name switch
            {
                "CyberCoat" => new ItemCard("CyberCoat", CardType.Prize, PrizeCardType.Item, 2, cyberCoat, false, ItemType.Additional, null, 300),
                "GodsHelp" => new ItemCard("GodsHelp", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Additional, null, 0),
                "BetterDefenceSpray" => new ItemCard("BetterDefenceSpray", CardType.Prize, PrizeCardType.Item, 4, null, false, ItemType.Additional, betterDefenceSpray, 400),
                "RepairKit" => new ItemCard("RepairKit", CardType.Prize, PrizeCardType.Item, 1, null, false, ItemType.Additional, null, 200),
                "Dog" => new ItemCard("Dog", CardType.Prize, PrizeCardType.Item, 1, null, false, ItemType.Additional, null, 100),
                "Henchman" => new ItemCard("Henchman", CardType.Prize, PrizeCardType.Item, 2, null, false, ItemType.Additional, null, 500),
                _ => null
            };
            return result;
        }

        public ItemCard CreateArmorCard(string name)
        {
            var godsArmorRestrictions = new Dictionary<bool, ProficiencyBase>
            {
                { true, new WarriorProficiency()}
            };
            var moiraRestrictions = new Dictionary<bool, RaceBase>
            {
                { true, new Dwarf("Dwarf") }
            };
            var elfGoldenArmor = new Dictionary<bool, RaceBase>
            {
                { true, new Elf("Elf") }
            };
            var result = name switch
            {
                "ElfGoldenArmor" => new ItemCard("ElfGoldenArmor", CardType.Prize, PrizeCardType.Item, 5, elfGoldenArmor, false, ItemType.Armor, null, 600),
                "Robe" => new ItemCard("Robe", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Armor, null, 300),
                "PlateArmor" => new ItemCard("PlateArmor", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Armor, null, 300),
                "MoiraArmor" => new ItemCard("MoiraArmor", CardType.Prize, PrizeCardType.Item, 4, moiraRestrictions, false, ItemType.Armor, null, 400),
                "GodsArmor" => new ItemCard("GodsArmor", CardType.Prize, PrizeCardType.Item, 6, null, false, ItemType.Armor, godsArmorRestrictions, 600),
                _ => null
            };
            return result;
        }

        public ItemCard CreateBootsCard(string name)
        {
            var result = name switch
            {
                "BootsOfHaste" => new ItemCard("BootsOfHaste", CardType.Prize, PrizeCardType.Item, 2, null, true, ItemType.Boots, null, 200),
                "GlassBoots" => new ItemCard("GlassBoots", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Boots, null, 300),
                "DragonSkinsSandal" => new ItemCard("DragonSkinsSandal", CardType.Prize, PrizeCardType.Item, 4, null, true, ItemType.Boots, null, 600),
                "MagicBoots" => new ItemCard("MagicBoots", CardType.Prize, PrizeCardType.Item, 4, null, true, ItemType.Boots, null, 500),
                "NormalBoot" => new ItemCard("NormalBoot", CardType.Prize, PrizeCardType.Item, 1, null, false, ItemType.Boots, null, 100),
                _ => null
            };
            return result;
        }

        public ItemCard CreateHelmetCard(string name)
        {
            var ritualHelmetRestrictions = new Dictionary<bool, ProficiencyBase>
            {
                { true, new PriestProficiency() }
            };
            var maskOfDeadRestrictions = new Dictionary<bool, ProficiencyBase>
            {
                { false, new PriestProficiency() }
            };
            var result = name switch
            {
                "RitualHelmet" => new ItemCard("RitualHelmet", CardType.Prize, PrizeCardType.Item, 4, null, false, ItemType.Helmet, ritualHelmetRestrictions, 500),
                "WarHelmet" => new ItemCard("WarHelmet", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Helmet, null, 400),
                "MaskOfDead" => new ItemCard("MaskOfDead", CardType.Prize, PrizeCardType.Item, 4, null, false, ItemType.Helmet, maskOfDeadRestrictions, 600),
                "LaurelWreath" => new ItemCard("LaurelWreath", CardType.Prize, PrizeCardType.Item, 1, null, false, ItemType.Helmet, null, 100),
                "LeatherHelmet" => new ItemCard("LeatherHelmet", CardType.Prize, PrizeCardType.Item, 2, null, false, ItemType.Helmet, null, 300),
                _ => null
            };
            return result;
        }

        public ItemCard CreateSituationalCard(string name)
        {
            ReadLineOverride readLineOverride = new ReadLineOverride();
            Random random = new Random();
            SituationalItem result = name switch
            {
                "DeadlyBerries" => new DeadlyBerries("DeadlyBerries", CardType.Special, PrizeCardType.Sitiuational, 0, null, false, ItemType.Sitiuational, null, 500, readLineOverride),
                "DeadMark" => new DeadMark("DeadMark", CardType.Special, PrizeCardType.Sitiuational, 0, null, false, ItemType.Sitiuational, null, 700),
                "DionisiosWine" => new DionisiosWine("DionisiosWine", CardType.Special, PrizeCardType.Sitiuational, 0, null, false, ItemType.Sitiuational, null, 400, readLineOverride),
                "FireBall" => new FireBall("FireBall", CardType.Special, PrizeCardType.Sitiuational, 0, null, false, ItemType.Sitiuational, null, 400),
                "GoldenApple" => new GoldenApple("GoldenApple", CardType.Special, PrizeCardType.Sitiuational, 0, null, false, ItemType.Sitiuational, null, 500),
                "IcePotion" => new IcePotion("IcePotion", CardType.Special, PrizeCardType.Sitiuational, 0, null, false, ItemType.Sitiuational, null, 300, readLineOverride),
                "LightingStrike" => new LightingStrike("LightingStrike", CardType.Special, PrizeCardType.Sitiuational, 0, null, false, ItemType.Sitiuational, null, 500, readLineOverride),
                "MagicFlowers" => new MagicFlowers("MagicFlowers", CardType.Special, PrizeCardType.Sitiuational, 0, null, false, ItemType.Sitiuational, null, 100, readLineOverride),
                "MysteryPotion" => new MysteryPotion("MysteryPotion", CardType.Special, PrizeCardType.Sitiuational, 0, null, false, ItemType.Sitiuational, null, 500, random),
                "Poison" => new Poison("Poison", CardType.Special, PrizeCardType.Sitiuational, 0, null, false, ItemType.Sitiuational, null, 100, readLineOverride),
                "RedBullDrink" => new RedBullDrink("RedBullDrink", CardType.Special, PrizeCardType.Sitiuational, 0, null, false, ItemType.Sitiuational, null, 500, readLineOverride),
                "RuneMark" => new RuneMark("RuneMark", CardType.Special, PrizeCardType.Sitiuational, 0, null, false, ItemType.Sitiuational, null, 400),
                "SnowBall" => new SnowBall("SnowBall", CardType.Special, PrizeCardType.Sitiuational, 0, null, false, ItemType.Sitiuational, null, 100, readLineOverride),
                "ValhallasHorn" => new ValhallasHorn("ValhallasHorn", CardType.Special, PrizeCardType.Sitiuational, 0, null, false, ItemType.Sitiuational, null, 700),
                _ => null
            };
            return result;
        }
    }
}
