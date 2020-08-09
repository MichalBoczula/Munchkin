using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard.SpecialCardType
{
    public abstract class SpecialCard : ActionCardBase
    {
        public SpecialCard(string name, CardType cardType) : base(name, cardType)
        {

        }

        public abstract void SpecialEffect(UserClass user);
    }
}
