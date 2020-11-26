using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard.SpecialCardType.MagicCards
{
    public class YouHaveAccident : ActionCardBase
    {
        public YouHaveAccident(string name, CardType cardType) : base(name, cardType)
        {
            MagicCardType = MagicCardType.Hero;
        }

        public override void CastSpecialSpell(UserClass user, MonsterCardBase monster, Game game)
        {
            user.UserAvatar.Nerfs.Wounded.Add(true);
        }

        public override void Description()
        {
            System.Console.WriteLine("What a tradegy you have a accident and now you are wounded.");
        }
    }
}
