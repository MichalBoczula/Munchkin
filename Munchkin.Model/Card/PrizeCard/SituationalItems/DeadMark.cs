using Munchkin.Model.Character;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.PrizeCard.SituationalItems
{
    public class DeadMark : SituationalItem
    {
        public DeadMark(string name, CardType cardType, PrizeCardType prizeCardType, int power, Dictionary<bool, RaceBase> raceRestriction, bool isTwoHanded, ItemType itemType, Dictionary<bool, ProficiencyBase> proficiencyRestriction, int price) : base(name, cardType, prizeCardType, power, raceRestriction, isTwoHanded, itemType, proficiencyRestriction, price)
        {
        }

        public override void SpecialEffect(Fight fight)
        {
            foreach(var hero in fight.Heros)
            {
                hero.UserAvatar.Nerfs.Wounded.Add(true);
            }
            System.Console.WriteLine("Heroes gain wound nerf.");
        }

        public override void Description()
        {
            System.Console.WriteLine("Dead Mark used by ocultist. Use on user and look give him wound nerf. Player Wounded += 1");
        }
    }
}
