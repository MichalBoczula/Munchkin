using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard.SpecialCardType.MagicCards
{
    public class FridayNightCurse : ActionCardBase
    {
        public FridayNightCurse(string name, CardType cardType) : base(name, cardType)
        {
            MagicCardType = MagicCardType.Hero;
        }

        public override void CastSpecialSpell(UserClass user, MonsterCardBase monster, Game game)
        {
            user.UserAvatar.Nerfs.Poisoned.Add(true);
        }

        public override string Description()
        {
            return "You have a hangover. Poison nerf is increased by one.";
        }
    }
}
