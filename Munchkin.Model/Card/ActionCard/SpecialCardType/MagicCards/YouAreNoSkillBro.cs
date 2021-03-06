﻿using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.Character.Hero.Proficiency;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard.SpecialCardType.MagicCards
{
    public class YouAreNoSkillBro : ActionCardBase
    {
        public YouAreNoSkillBro(string name, CardType cardType) : base(name, cardType)
        {
            MagicCardType = MagicCardType.Hero;
        }

        public override void CastSpecialSpell(UserClass user, MonsterCardBase monster, Game game)
        {
            user.UserAvatar.Proficiency = new NoOneProficiency();
        }

        public override string Description()
        {
            return "You stop develop your proficiency skill and lose it. Now you are a No One.";
        }
    }
}
