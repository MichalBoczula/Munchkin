using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard
{
    public abstract class ActionCardBase : CardGameBase
    {
        public ActionCardType ActionCardType { get; set; }

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
    }
}
