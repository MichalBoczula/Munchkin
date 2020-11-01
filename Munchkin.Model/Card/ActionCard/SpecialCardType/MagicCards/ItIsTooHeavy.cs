using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard.SpecialCardType.MagicCards
{
    public class ItIsTooHeavy : ActionCardBase
    {
        public ItIsTooHeavy(string name, CardType cardType) : base(name, cardType)
        {
            MagicCardType = MagicCardType.Hero;
        }

        public override void CastSpecialSpell(UserClass user, MonsterCardBase monster, Game game)
        {
            if (user != null && game != null)
            {
                if (user.UserAvatar.Build.LeftHandItem != null)
                {
                    var weapon = user.UserAvatar.Build.LeftHandItem;
                    user.UserAvatar.Build.LeftHandItem = null;
                    game.DestroyedPrizeCards.Add(weapon);
                }

                if (user.UserAvatar.Build.RightHandItem != null)
                {
                    var weapon = user.UserAvatar.Build.RightHandItem;
                    user.UserAvatar.Build.RightHandItem = null;
                    game.DestroyedPrizeCards.Add(weapon);
                }
            }
        }
    }
}
