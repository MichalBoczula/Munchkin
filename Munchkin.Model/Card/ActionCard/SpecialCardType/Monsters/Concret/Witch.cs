using Munchkin.Model;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Tests.Munchkin.Model.Tests.Card.SpecialCardType.Monsters
{
    public class Witch : MonsterCardBase
    {
        public Witch(string name, CardType cardType) : base(name, cardType)
        {
            Power = 12;
            NumberOfPrizes = 3;
            HowManyLevels = 1;
        }

        public override void DeadEnd(Game game, UserClass user)
        {
            user.UserAvatar.Nerfs.Poisoned.Add(true);
        }

        public override void SpecialPower(Game game, UserClass user)
        {
            user.UserAvatar.Level -= 1;
        }
    }
}
