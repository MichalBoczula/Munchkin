using Munchkin.Model;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.Character.Hero.Race;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret
{
    public class FrozenGiant : MonsterCardBase
    {
        public FrozenGiant(string name, CardType cardType) : base(name, cardType)
        {
            Power = 4;
            HowManyLevels = 1;
            NumberOfPrizes = 2;
        }

        public override void DeadEnd(Game game, UserClass user)
        {
            if (user.UserAvatar.Build.Boots != null)
            {
                var item = user.UserAvatar.Build.Boots;
                user.UserAvatar.Build.Boots = null;
                game.DestroyedPrizeCards.Add(item);
            }
            user.UserAvatar.Nerfs.BrokenLegs = true;
        }

        public override void SpecialPower(Game game, UserClass user)
        {
            if (user.UserAvatar.Race == null) return;
            if (user.UserAvatar.Race is Halfling)
            {
                Power += 4;
                HowManyLevels += 1;
            }
        }

        public override string Description()
        {
            return "Monster: FrozenGiant\n" +
                $"Power: {Power}, Prizes: {NumberOfPrizes}, Levels: {HowManyLevels}" +
                "SpecialPower: Monster gain 4 when player race is Halfing but halfing get two levels when win fight\n" +
                "Dead End: Player has permanent broke legs and can't use a boots and lose actual equipped boots";
        }
    }
}
