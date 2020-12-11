using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.Character.Hero.Race;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret
{
    public class Grendel : MonsterCardBase
    {
        public Grendel(string name, CardType cardType) : base(name, cardType)
        {
            Power = 14;
            HowManyLevels = 1;
            NumberOfPrizes = 4;
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
            if (user.UserAvatar.Race is null || user.UserAvatar.Race is Dwarf)
            {
                Power += 5;
            }
        }

        public override string Description()
        {
            return "Monster: Grendel\n" +
                $"Power: {Power}, Prizes: {NumberOfPrizes}, Levels: {HowManyLevels}\n" +
                "SpecialPower: Monster gain 5 power when Player race is Dwarf\n" +
                "Dead End: Player has broken ribs and can't use armor and lose actual equiped armor";
        }
    }
}
