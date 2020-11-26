using Munchkin.Model.Character;
using Munchkin.Model.Character.Hero.Proficiency;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.PrizeCard.SituationalItems
{
    public class FireBall : SituationalItem
    {
        public FireBall(string name, CardType cardType, PrizeCardType prizeCardType, int power, Dictionary<bool, RaceBase> raceRestriction, bool isTwoHanded, ItemType itemType, Dictionary<bool, ProficiencyBase> proficiencyRestriction, int price) : base(name, cardType, prizeCardType, power, raceRestriction, isTwoHanded, itemType, proficiencyRestriction, price)
        {
        }

        public override void SpecialEffect(Fight fight)
        {
            var boost = 3;
            foreach(var hero in fight.Heros)
            {
                if(hero.UserAvatar.Proficiency is MageProficiency)
                {
                    boost = 6;
                }
            }
            fight.Heros[0].UserAvatar.Power += boost;
            System.Console.WriteLine("Heroes get 3 power boots or if you mage get 6");
        }

        public override void Description()
        {
            System.Console.WriteLine("FireBall give user 3 points of power, but if player proficiency is mage you get 6 points." +
                "\n Player Power += 3 || Player Power += 6 if proficiency equal to Mage");
        }
    }
}
