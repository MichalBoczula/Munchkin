using Munchkin.Model.Character;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.PrizeCard.SituationalItems
{
    public class GoldenApple : SituationalItem
    {
        public GoldenApple(string name, CardType cardType, PrizeCardType prizeCardType, int power, Dictionary<bool, RaceBase> raceRestriction, bool isTwoHanded, ItemType itemType, Dictionary<bool, ProficiencyBase> proficiencyRestriction, int price) : base(name, cardType, prizeCardType, power, raceRestriction, isTwoHanded, itemType, proficiencyRestriction, price)
        {
        }

        public override void SpecialEffect(Fight fight)
        {
            foreach(var hero in fight.Heros)
            {
                hero.Power += 5;
                hero.Nerfs.Poisoned.Add(true);
            }
        }
    }
}
