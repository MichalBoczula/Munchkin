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
    }
}
