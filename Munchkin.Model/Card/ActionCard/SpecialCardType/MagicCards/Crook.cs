using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard.SpecialCardType.MagicCards
{
    public class Crook : ActionCardBase
    {
        public Crook(string name, CardType cardType) : base(name, cardType)
        {
            MagicCardType = MagicCardType.Crook;
        }

        public override void CastSpecialSpell(UserClass user, MonsterCardBase monster, Game game)
        {
            user.UserAvatar.Build.IsItACrook = true;
        }

        public override void Description()
        {
            System.Console.WriteLine("Card allow you use additional item. This card eliminate all restriction.");
        }
    }
}
