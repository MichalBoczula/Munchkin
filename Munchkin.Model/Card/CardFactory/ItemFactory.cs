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
                { true, new Dwarf("dwarf") }
            };
            var result = name switch
            {
                "leatherArmor" => new ItemCard("leatherArmor", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Armor, null, 300),
                "robe" => new ItemCard("robe", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Armor, null, 300), 
                "moiraArmor" => new ItemCard("moiraArmor", CardType.Prize, PrizeCardType.Item, 3, moiraRestrictions, false, ItemType.Armor, null, 300),
                "plateArmor" => new ItemCard("plateArmor", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Armor, null, 300),
                "godsArmor" => new ItemCard("godsArmor", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Armor, godsArmorRestrictions, 300),
                _ => null
            };
            return result;
        }

        public ItemCard CreateBootsCard(string name)
        {
            var magicBootsRestrictions = new Dictionary<bool, ProficiencyBase>
            {
                { true, new MageProficiency() }
            };
            var result = name switch
            {
                "bootsOfHaste" => new ItemCard("bootsOfHaste", CardType.Prize, PrizeCardType.Item, 5, null, true, ItemType.Boots, null, 300),
                "plateBoots" => new ItemCard("plateBoots", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Boots, null, 300),
                "dragonSkinsSandal" => new ItemCard("dragonSkinsSandal", CardType.Prize, PrizeCardType.Item, 3, null, true, ItemType.Boots, null, 300),
                "magicBoots" => new ItemCard("magicBoots", CardType.Prize, PrizeCardType.Item, 3, null, true, ItemType.Boots, magicBootsRestrictions, 300),
                "normalBoot" => new ItemCard("normalBoot", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Boots, null, 300),
                _ => null
            };
            return result;
        }

        public ItemCard CreateHelmetCard(string name)
        {
            var thiefHoodieRestrictions = new Dictionary<bool, ProficiencyBase>
            {
                { true, new ThiefProficiency() }
            };
            var wizardHat = new Dictionary<bool, ProficiencyBase>
            {
                { true, new MageProficiency() }
            };
            var elfGoldHelmet = new Dictionary<bool, RaceBase>
            {
                {  true, new Elf("elf")}
            };
            var result = name switch
            {
                "thiefHoodie" => new ItemCard("thiefHoodie", CardType.Prize, PrizeCardType.Item, 5, null, true, ItemType.Helmet, thiefHoodieRestrictions, 300),
                "wizardHat" => new ItemCard("wizardHat", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Helmet, wizardHat, 300),
                "elfGoldHelmet" => new ItemCard("elfGoldHelmet", CardType.Prize, PrizeCardType.Item, 3, elfGoldHelmet, true, ItemType.Helmet, null, 300),
                "plateHelmet" => new ItemCard("plateHelmet", CardType.Prize, PrizeCardType.Item, 3, null, true, ItemType.Helmet, null, 300),
                "leatherHelmet" => new ItemCard("leatherHelmet", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Helmet, null, 300),
                _ => null
            };
            return result;
        }
    }
}
