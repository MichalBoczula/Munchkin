﻿using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret
{
    public class Minotaur : MonsterCardBase
    {
        public Minotaur(string name, CardType cardType) : base(name, cardType)
        {
            Power = 4;
            HowManyLevels = 1;
            NumberOfPrizes = 2;
        }

        public override void DeadEnd(Game game, UserClass user)
        {
            if(user.UserAvatar.Build.Helmet != null)
            {
                var item = user.UserAvatar.Build.Helmet;
                user.UserAvatar.Build.Helmet = null;
                game.DestroyedPrizeCards.Add(item);
            }
        }

        public override void SpecialPower(Game game, UserClass user)
        {
            if (user.UserAvatar.Build.Helmet != null)
            {
                Power += 2;
            }
        }
    }
}