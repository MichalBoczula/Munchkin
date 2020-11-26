using Munchkin.Model.Character;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.PrizeCard.SituationalItems
{
    public class ValhallasHorn : SituationalItem
    {
        public ValhallasHorn(string name, CardType cardType, PrizeCardType prizeCardType, int power, Dictionary<bool, RaceBase> raceRestriction, bool isTwoHanded, ItemType itemType, Dictionary<bool, ProficiencyBase> proficiencyRestriction, int price) : base(name, cardType, prizeCardType, power, raceRestriction, isTwoHanded, itemType, proficiencyRestriction, price)
        {
        }

        public override void SpecialEffect(Fight fight)
        {
            foreach(var hero in fight.Heros)
            {
                hero.UserAvatar.Power += 2;
            }
            foreach (var monster in fight.Monsters)
            {
                monster.Power -= 2;
            }
            System.Console.WriteLine("All users get 2 points of power and all monsters lose 2 points of power.");
        }


        public override void Description()
        {
            System.Console.WriteLine("Sound of Valhallas Horn increase user power by 2 and decrese monster power by 2 :" +
                "\nUser get 2 points of power. Player Power += 2 " +
                "\nMonster lose 2 points of power. Monster Power -= 2");
        }
    }
}
