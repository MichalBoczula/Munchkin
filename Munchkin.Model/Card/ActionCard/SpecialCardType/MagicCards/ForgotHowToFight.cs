﻿using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard.SpecialCardType.MagicCards
{
    public class ForgotHowToFight : ActionCardBase
    {
        public ForgotHowToFight(string name, CardType cardType) : base(name, cardType)
        {
        }

        public override void CastSpecialSpell(UserClass user, MonsterCardBase monster, Game game)
        {
            user.UserAvatar.Nerfs.Power.Add(3);
        }
    }
}