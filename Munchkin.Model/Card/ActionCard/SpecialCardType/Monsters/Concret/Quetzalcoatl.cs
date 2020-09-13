﻿using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.Character.Hero.Proficiency;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret
{
    public class Quetzalcoatl : MonsterCardBase
    {
        public Quetzalcoatl(string name, CardType cardType) : base(name, cardType)
        {
            Power = 16;
            NumberOfPrizes = 4;
            HowManyLevels = 2;
        }

        public override void DeadEnd(Game game, UserClass user)
        {
            if (user.UserAvatar.Proficiency is PriestProficiency)
            {
                user.Deck.Clear();
            }
            else
            {
                user.UserAvatar.IsDied = true;
            }
        }

        public override void SpecialPower(Game game, UserClass user)
        {
            if (!(user.UserAvatar.Proficiency is PriestProficiency))
            {
                Power += 5;
            }
        }
    }
}