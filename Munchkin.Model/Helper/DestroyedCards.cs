﻿using Munchkin.Model.Card.ActionCard;
using Munchkin.Model.Card.PrizeCard;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Helper
{
    public class DestroyedCards
    {
        public List<ItemCard> DestroyedPrizeCards { get; set; }
        public List<ActionCardBase> ActionCards { get; set; }
        public List<ActionCardBase> DestroyedActionCards { get; set; }

        public DestroyedCards()
        {
            DestroyedPrizeCards = new List<ItemCard>();
            ActionCards = new List<ActionCardBase>();
            DestroyedActionCards = new List<ActionCardBase>();
        }
    }
}
