using Munchkin.Model.Card.ItemCard;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.PrizeCard
{
    public abstract class PrizeCardBase : CardGameBase
    {
        public PrizeCardType PrizeCardType{ get; set; }

        protected PrizeCardBase(string name, CardType cardType) : base(name, cardType)
        {
        }
    }
}
