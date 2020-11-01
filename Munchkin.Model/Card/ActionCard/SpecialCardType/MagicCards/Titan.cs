using Munchkin.Model;
using Munchkin.Model.Card.ActionCard;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard.SpecialCardType.MagicCards
{
    public class Titan : ActionCardBase
    {
        public Titan(string name, CardType cardType) : base(name, cardType)
        {
            MagicCardType = MagicCardType.Monster;
        }

        public override void CastSpecialSpell(UserClass user, MonsterCardBase monster, Game game)
        {
            monster.Power += 10;
            monster.NumberOfPrizes += 2;
        }
    }
}
