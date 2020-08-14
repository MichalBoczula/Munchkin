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
            var thorsHammerRestrictions = new Dictionary<ProficiencyBase, bool>
            {
                { new WarriorProficiency(), true }
            };
            var khazaDumRestrictions = new Dictionary<RaceBase, bool>
            {
                { new Dwarf("dwarf"), true }
            };
            var result = name switch
            {
                "sword2H" => new ItemCard("sword2H", CardType.Prize, PrizeCardType.Item, 5, null, true, ItemType.Weapon, null),
                "sword1H" => new ItemCard("sword1H", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null),
                "khazaDumHammer" => new ItemCard("khazaDumHammer", CardType.Prize, PrizeCardType.Item, 3, khazaDumRestrictions, true, ItemType.Weapon, null),
                "axe" => new ItemCard("axe", CardType.Prize, PrizeCardType.Item, 3, null, true, ItemType.Weapon, null),
                "thorsHammer" => new ItemCard("thorsHammer", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, thorsHammerRestrictions),
                _ => null
            };
            return result;
        }

        public ItemCard CreateArmorCard(string name)
        {
            var godsArmorRestrictions = new Dictionary<ProficiencyBase, bool>
            {
                { new WarriorProficiency(), true }
            };
            var moiraRestrictions = new Dictionary<RaceBase, bool>
            {
                { new Dwarf("dwarf"), true }
            };
            var result = name switch
            {
                "leatherArmor" => new ItemCard("leatherArmor", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Armor, null),
                "robe" => new ItemCard("robe", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Armor, null),
                "moiraArmor" => new ItemCard("moiraArmor", CardType.Prize, PrizeCardType.Item, 3, moiraRestrictions, false, ItemType.Armor, null),
                "plateArmor" => new ItemCard("plateArmor", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Armor, null),
                "godsArmor" => new ItemCard("godsArmor", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Armor, godsArmorRestrictions),
                _ => null
            };
            return result;
        }

        public ItemCard CreateBootsCard(string name)
        {
            var magicBootsRestrictions = new Dictionary<ProficiencyBase, bool>
            {
                { new MageProficiency(), true }
            };
            var result = name switch
            {
                "bootsOfHaste" => new ItemCard("bootsOfHaste", CardType.Prize, PrizeCardType.Item, 5, null, true, ItemType.Boots, null),
                "plateBoots" => new ItemCard("plateBoots", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Boots, null),
                "dragonSkinsSandal" => new ItemCard("dragonSkinsSandal", CardType.Prize, PrizeCardType.Item, 3, null, true, ItemType.Boots, null),
                "magicBoots" => new ItemCard("magicBoots", CardType.Prize, PrizeCardType.Item, 3, null, true, ItemType.Boots, magicBootsRestrictions),
                "normalBoot" => new ItemCard("normalBoot", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Boots, null),
                _ => null
            };
            return result;
        }

        public ItemCard CreateHelmetCard(string name)
        {
            var thiefHoodieRestrictions = new Dictionary<ProficiencyBase, bool>
            {
                { new ThiefProficiency(), true }
            };
            var wizardHat = new Dictionary<ProficiencyBase, bool>
            {
                { new MageProficiency(), true }
            };
            var elfGoldHelmet = new Dictionary<RaceBase, bool>
            {
                { new Elf("elf"), true }
            };
            var result = name switch
            {
                "thiefHoodie" => new ItemCard("thiefHoodie", CardType.Prize, PrizeCardType.Item, 5, null, true, ItemType.Helmet, thiefHoodieRestrictions),
                "wizardHat" => new ItemCard("wizardHat", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Helmet, wizardHat),
                "elfGoldHelmet" => new ItemCard("elfGoldHelmet", CardType.Prize, PrizeCardType.Item, 3, elfGoldHelmet, true, ItemType.Helmet, null),
                "plateHelmet" => new ItemCard("plateHelmet", CardType.Prize, PrizeCardType.Item, 3, null, true, ItemType.Helmet, null),
                "leatherHelmet" => new ItemCard("leatherHelmet", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Helmet, null),
                _ => null
            };
            return result;
        }
    }
}
