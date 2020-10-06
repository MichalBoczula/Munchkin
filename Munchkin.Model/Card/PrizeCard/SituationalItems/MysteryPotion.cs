using Munchkin.Model.Character;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.PrizeCard.SituationalItems
{
    public class MysteryPotion : SituationalItem
    {
        private Random random;

        public MysteryPotion(string name, CardType cardType, PrizeCardType prizeCardType, int power, Dictionary<bool, RaceBase> raceRestriction, bool isTwoHanded, ItemType itemType, Dictionary<bool, ProficiencyBase> proficiencyRestriction, int price, Random random) : base(name, cardType, prizeCardType, power, raceRestriction, isTwoHanded, itemType, proficiencyRestriction, price)
        {
            this.random = random;
        }

        public override void SpecialEffect(Fight fight)
        {
            var choice = random.Next(2);
            if(choice == 0)
            {
                foreach(var hero in fight.Heros)
                {
                    hero.Power -= 2;
                }
            }
            else
            {
                foreach (var hero in fight.Heros)
                {
                    hero.Power += 3;
                }
            }
        }
    }
}
