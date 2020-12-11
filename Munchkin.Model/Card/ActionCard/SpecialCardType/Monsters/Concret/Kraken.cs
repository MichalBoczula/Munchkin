using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.Character.Hero.Race;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret
{
    public class Kraken : MonsterCardBase
    {
        public Kraken(string name, CardType cardType) : base(name, cardType)
        {
            Power = 16;
            NumberOfPrizes = 4;
            HowManyLevels = 2;
        }

        public override void DeadEnd(Game game, UserClass user)
        {
            if (user.UserAvatar.Build.Armor != null)
            {
                var item = user.UserAvatar.Build.Armor;
                user.UserAvatar.Build.Armor = null;
                game.DestroyedPrizeCards.Add(item);
            }
            user.UserAvatar.Nerfs.BrokenRibs = true;
        }

        public override void SpecialPower(Game game, UserClass user)
        {
            if(user.UserAvatar.Race is Halfling || user.UserAvatar.Race is Dwarf)
            {
                Power -= 3;
            }
            else
            {
                Power += 5;
            }
        }

        public override string Description()
        {
            return "Monster: Kraken\n" +
                $"Power: {Power}, Prizes: {NumberOfPrizes}, Levels: {HowManyLevels}" +
                "SpecialPower: Monster gain 3 power when player race is dwarf or halfing, otherwise monsters power increased by 5\n" +
                "Dead End: Player has broken ribs and can't use armor and lose actual equiped armor";
        }
    }
}
