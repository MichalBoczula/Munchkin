using Munchkin.Model.Card.PrizeCard;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ItemCard
{
    public class AdditionalItem : PrizeCardBase
    {
        public int Power { get; set; }

        public AdditionalItem(string name, CardType cardType) : base(name, cardType)
        {

        }
    }
}
