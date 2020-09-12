using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard
{
    public abstract class ActionCardBase : CardGameBase
    {
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
#nullable disable
    }
}
