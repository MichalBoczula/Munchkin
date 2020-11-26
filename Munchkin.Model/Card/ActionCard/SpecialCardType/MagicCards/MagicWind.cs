using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard.SpecialCardType.MagicCards
{
    public class MagicWind : ActionCardBase
    {
        public MagicWind(string name, CardType cardType) : base(name, cardType)
        {
            MagicCardType = MagicCardType.Monster;
        }

        public override void CastSpecialSpell(UserClass user, MonsterCardBase monster, Game game)
        {
            user.Deck.Monsters.Add(monster);
        }

        public override string Description()
        {
            return "Magic wind make monster more friendly and now you have pet. Monster card is currently in your deck.";
        }
    }
}
