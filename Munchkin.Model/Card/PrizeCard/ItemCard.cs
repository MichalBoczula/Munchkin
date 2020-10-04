using Munchkin.Model.Card.PrizeCard;
using Munchkin.Model.Character;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.PrizeCard
{
    public class ItemCard : PrizeCardBase
    {
        public int Power { get; set; }
        public Dictionary<bool, RaceBase> RaceRestriction { get; set; }
        public Dictionary<bool, ProficiencyBase> ProficiencyRestriction { get; set; }
        public bool IsTwoHanded { get; set; }
        public ItemType ItemType { get; set; }
        public int Price { get; set; }

        public ItemCard(string name,
                        CardType cardType,
                        PrizeCardType prizeCardType,
                        int power,
                        Dictionary<bool, RaceBase> raceRestriction,
                        bool isTwoHanded,
                        ItemType itemType,
                        Dictionary<bool, ProficiencyBase> proficiencyRestriction,
                        int price) : base(name, cardType, prizeCardType)
        {
            Power = power;
            RaceRestriction = raceRestriction;
            IsTwoHanded = isTwoHanded;
            ItemType = itemType;
            ProficiencyRestriction = proficiencyRestriction;
            Price = price;
        }

        public virtual void SpecialEffect(Fight fight)
        {

        }
    }


    public enum ItemType
    {
        Helmet,
        Armor,
        Boots,
        Weapon,
        Additional
    }
}
