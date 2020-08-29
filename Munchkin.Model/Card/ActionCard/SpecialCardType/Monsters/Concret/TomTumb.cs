﻿using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.Character.Hero.Race;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret
{
    public class TomTumb : MonsterCardBase
    {
        public TomTumb(string name, CardType cardType) : base(name, cardType)
        {
            Power = 2;
        }

        public override void DeadEnd(Game game, UserClass user)
        {
            if (user.UserAvatar.Build.LeftHandItem != null)
            {
                var item = user.UserAvatar.Build.LeftHandItem;
                user.UserAvatar.Build.LeftHandItem = null;
                game.DestroyedPrizeCards.Add(item);

            }
            if (user.UserAvatar.Build.RightHandItem != null)
            {
                var item = user.UserAvatar.Build.RightHandItem;
                user.UserAvatar.Build.RightHandItem = null;
                game.DestroyedPrizeCards.Add(item);
            }
        }

        public override void SpecialPower(Game game, UserClass user)
        {
            if (user.UserAvatar.Race == null) return;
            if (user.UserAvatar.Race is Halfling)
            {
                Power += 3;
            }
        }

        public override int GetNumberOfPrizes()
        {
            return 1;
        }
    }
}
