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
    }
}
