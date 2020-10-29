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
        }
    }
}
