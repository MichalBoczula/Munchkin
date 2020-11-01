using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard.SpecialCardType.MagicCards
{
    public class ToTheArea : ActionCardBase
    {
        public ToTheArea(string name, CardType cardType) : base(name, cardType)
        {
            MagicCardType = MagicCardType.Hero;
        }

#nullable enable
        public override void CastSpecialSpell(UserClass? user, MonsterCardBase? monster, Game? game)
        {
            if (user != null)
            {
                user.UserAvatar.Curses.NoDefence = true;
            }
        }
#nullable disable
    }
}
