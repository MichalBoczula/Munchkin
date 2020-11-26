using Munchkin.Model.Character;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.PrizeCard.SituationalItems
{
    public class RuneMark : SituationalItem
    {
        public RuneMark(string name, CardType cardType, PrizeCardType prizeCardType, int power, Dictionary<bool, RaceBase> raceRestriction, bool isTwoHanded, ItemType itemType, Dictionary<bool, ProficiencyBase> proficiencyRestriction, int price) : base(name, cardType, prizeCardType, power, raceRestriction, isTwoHanded, itemType, proficiencyRestriction, price)
        {
        }

        public override void SpecialEffect(Fight fight)
        {
            foreach(var monster in fight.Monsters)
            {
                monster.Power -= 3;
            }
            System.Console.WriteLine("All monsters lose 3 point of power.");
        }

        public override string Description()
        {
            return "Monster lose 3 point of power:" +
                "\nMonster lose 3 points of power. Monster Power -= 3";
        }
    }
}
