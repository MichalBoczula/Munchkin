using Munchkin.Model.Card.ActionCard.SpecialCardType;
using Munchkin.Model.Card.ActionCard.SpecialCardType.MagicCards;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard
{
    public abstract class ActionCardBase : CardGameBase
    {
        public MagicCardType MagicCardType;

        protected ActionCardBase(string name, CardType cardType) : base(name, cardType)
        {
        }

        public virtual void DeadEnd(Game game, UserClass user)
        {

        }

        public virtual void SpecialPower(Game game, UserClass user)
        {

        }

        public virtual void DoSomething()
        {

        }

#nullable enable
        public virtual void CastSpecialSpell(UserClass? user, MonsterCardBase? monster, Game? game)
        {

        }

        public virtual void CastSpecialSpell(UserClass? user, Game? game, Fight? fight)
        {

        }
#nullable disable
    }
}
