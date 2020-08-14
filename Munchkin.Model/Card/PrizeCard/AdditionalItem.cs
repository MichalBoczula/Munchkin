using Munchkin.Model.Card.PrizeCard;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.PrizeCard
{
    public class AdditionalItem : PrizeCardBase
    {
        public int Power { get; set; }

        public AdditionalItem(string name, CardType cardType, PrizeCardType prizeCardType) : base(name, cardType, prizeCardType)
        {

        }
    }
}
