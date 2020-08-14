using Munchkin.Model.Card.PrizeCard;
using Munchkin.Model.Character;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.PrizeCard
{
    public class ItemCard : PrizeCardBase
    {
        public int Power { get; set; }
        public Dictionary<RaceBase, bool> RaceRestriction { get; set; }
        public Dictionary<ProficiencyBase, bool> ProficiencyRestriction { get; set; }
        public bool IsTwoHanded { get; set; }
        public ItemType ItemType { get; set; }

        public ItemCard(string name,
            CardType cardType,
            PrizeCardType prizeCardType,
            int power,
            Dictionary<RaceBase, bool> raceRestriction,
            bool isTwoHanded,
            ItemType itemType,
            Dictionary<ProficiencyBase, bool> proficiencyRestriction) : base(name, cardType, prizeCardType)
        {
            Power = power;
            RaceRestriction = raceRestriction;
            IsTwoHanded = isTwoHanded;
            ItemType = itemType;
            ProficiencyRestriction = proficiencyRestriction;
        }
    }

    public enum ItemType
    {
        Helmet,
        Armor,
        Boots,
        Weapon
    }
}
