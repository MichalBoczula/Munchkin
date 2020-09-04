﻿using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret
{
    public class Hades : MonsterCardBase
    {
        public Hades(string name, CardType cardType) : base(name, cardType)
        {
            Power = 18;
            NumberOfPrizes = 5;
            HowManyLevels = 2;
        }

        public override void DeadEnd(Game game, UserClass user)
        {
            user.UserAvatar.IsDied = true;
        }

        public override void SpecialPower(Game game, UserClass user)
        {
            user.UserAvatar.Nerfs.Wounded.Add(true);
        }
    }
}
