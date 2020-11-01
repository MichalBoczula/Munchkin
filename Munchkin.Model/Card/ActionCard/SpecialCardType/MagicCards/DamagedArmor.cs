using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard.SpecialCardType.MagicCards
{
    public class DamagedArmor : ActionCardBase
    {
        public DamagedArmor(string name, CardType cardType) : base(name, cardType)
        {
            MagicCardType = MagicCardType.Hero;
        }

        public override void CastSpecialSpell(UserClass user, MonsterCardBase monster, Game game)
        {
            if (user != null && game != null)
            {
                if (user.UserAvatar.Build.Armor != null)
                {
                    var armor = user.UserAvatar.Build.Armor;
                    user.UserAvatar.Build.Armor = null;
                    game.DestroyedPrizeCards.Add(armor);
                }
            }
        }
    }
}
