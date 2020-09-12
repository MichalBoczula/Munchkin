using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard.SpecialCardType.MagicCards
{
    public class Friday13th : ActionCardBase
    {
        public Friday13th(string name, CardType cardType) : base(name, cardType)
        {
        }

        public override void CastSpecialSpell(UserClass user, MonsterCardBase monster, Game game)
        {
            user.UserAvatar.Nerfs.Power.Add(1);
            user.UserAvatar.Nerfs.FleeChances.Add(1);
            user.UserAvatar.Level -= 1;
        }
    }
}
