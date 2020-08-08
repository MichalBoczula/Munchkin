using Munchkin.Model.Card.PrizeCard;
using Munchkin.Model.Character;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ItemCard
{
    public class ItemCard : PrizeCardBase
    {
        public int Power { get; set; }
        public Dictionary<RaceBase, bool> Restriction { get; set; }
        public PrizeCardType Type;

        public  ItemCard(string name, CardType cardType) : base(name, cardType)
        {
        }
    }
}
