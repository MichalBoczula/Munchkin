using Munchkin.Model.Card.PrizeCard;
using Munchkin.Model.Character;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.PrizeCard
{
    public abstract class SituationalItem : ItemCard
    {
        public SituationalItem(string name,
                               CardType cardType,
                               PrizeCardType prizeCardType,
                               int power,
                               Dictionary<bool, RaceBase> raceRestriction,
                               bool isTwoHanded,
                               ItemType itemType,
                               Dictionary<bool, ProficiencyBase> proficiencyRestriction,
                               int price) : base(name, cardType, prizeCardType, power, raceRestriction, isTwoHanded, itemType, proficiencyRestriction, price)
        {

        }

        public override abstract void SpecialEffect(Fight fight);
    }
}
