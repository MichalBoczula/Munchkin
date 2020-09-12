using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard.SpecialCardType.MagicCards
{
    public class DamagedBoots : ActionCardBase
    {
        public DamagedBoots(string name, CardType cardType) : base(name, cardType)
        {
        }

#nullable enable
        public override void CastSpecialSpell(UserClass? user, MonsterCardBase? monster, Game? game)
        {
            if (user != null && game != null)
            {
                if (user.UserAvatar.Build.Boots != null)
                {
                    var boots = user.UserAvatar.Build.Boots;
                    user.UserAvatar.Build.Boots = null;
                    game.DestroyedPrizeCards.Add(boots);
                }
            }
        }
#nullable disable
    }
}
