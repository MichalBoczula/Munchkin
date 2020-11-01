using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard.SpecialCardType.MagicCards
{
    public class DamagedHelmet : ActionCardBase
    {
        public DamagedHelmet(string name, CardType cardType) : base(name, cardType)
        {
            MagicCardType = MagicCardType.Hero;
        }

#nullable enable
        public override void CastSpecialSpell(UserClass? user, MonsterCardBase? monster, Game? game)
        {
            if (user != null && game != null)
            {
                if (user.UserAvatar.Build.Helmet != null)
                {
                    var helmet = user.UserAvatar.Build.Helmet;
                    user.UserAvatar.Build.Helmet = null;
                    game.DestroyedPrizeCards.Add(helmet);
                }
            }
        }
#nullable disable
    }
}
