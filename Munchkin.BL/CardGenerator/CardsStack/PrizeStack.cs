using Munchkin.Model;
using Munchkin.Model.Card.PrizeCard;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.BL.CardGenerator.CardsStack
{
    public class PrizeStack
    {
        public List<ItemCard> Weapons;
        public List<ItemCard> Armors;
        public List<ItemCard> Boots;
        public List<ItemCard> Helmets;
        public List<ItemCard> Deck;

        public PrizeStack(List<ItemCard> weapons, List<ItemCard> armors, List<ItemCard> boots, List<ItemCard> helmets)
        {
            Weapons = weapons;
            Armors = armors;
            Boots = boots;
            Helmets = helmets;

            Deck = new List<ItemCard>();
            Deck.AddRange(Armors);
            Deck.AddRange(Boots);
            Deck.AddRange(Weapons);
            Deck.AddRange(Helmets);
        }
    }
}
