using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard.SpecialCardType.MagicCards
{
    public interface IMagicCard
    {
        int Id { get; set; }
        string Name { get; set; }
        CardType CardType { get; set; }
        MagicCardType MagicCardType { get; set; }
        void CastSpecialSpell(UserClass user, MonsterCardBase monster, Game game);
    }
}
