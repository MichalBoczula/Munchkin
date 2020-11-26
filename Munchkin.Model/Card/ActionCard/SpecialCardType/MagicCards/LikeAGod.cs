using Munchkin.Model;
using Munchkin.Model.Card.ActionCard;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard.SpecialCardType.MagicCards
{
    public class LikeAGod : ActionCardBase
    {
        public LikeAGod(string name, CardType cardType) : base(name, cardType)
        {
            MagicCardType = MagicCardType.Monster;
        }

        public override void CastSpecialSpell(UserClass user, MonsterCardBase monster, Game game)
        {
            monster.Power += 10;
            monster.NumberOfPrizes += 2;
        }

        public override string Description()
        {
            return "Card can be used only one monster. Monster get additional 10 point power and 2 prizes.";
        }
    }
}
