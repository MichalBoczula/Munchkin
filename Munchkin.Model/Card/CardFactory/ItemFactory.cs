using Munchkin.BL.Helper;
using Munchkin.Model.Card.PrizeCard;
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
        public ItemCard CreateWeaponCard(string name)
        {
            var thorsHammerRestrictions = new Dictionary<bool, ProficiencyBase>
            {
                { true, new WarriorProficiency() }
            };
            var khazaDumRestrictions = new Dictionary<bool, RaceBase>
            {
                { true, new Dwarf("dwarf") }
            };
            var result = name switch
            {
                "sword2H" => new ItemCard("sword2H", CardType.Prize, PrizeCardType.Item, 5, null, true, ItemType.Weapon, null, 300),
                "sword1H" => new ItemCard("sword1H", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300),
                "khazaDumHammer" => new ItemCard("khazaDumHammer", CardType.Prize, PrizeCardType.Item, 3, khazaDumRestrictions, true, ItemType.Weapon, null, 300),
                "axe" => new ItemCard("axe", CardType.Prize, PrizeCardType.Item, 3, null, true, ItemType.Weapon, null, 300),
                "thorsHammer" => new ItemCard("thorsHammer", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, thorsHammerRestrictions, 300),
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
    }
}
