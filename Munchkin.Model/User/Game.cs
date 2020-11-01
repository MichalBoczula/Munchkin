using Munchkin.Model.Card.ActionCard;
using Munchkin.Model.Card.ActionCard.SpecialCardType.MagicCards;
using Munchkin.Model.Card.PrizeCard;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.User
{
    public class Game
    {
        public int Id { get; set; }
        public List<UserClass> Users{ get; set; }
        public List<ItemCard> DestroyedPrizeCards { get; set; }
        public List<ActionCardBase> ActionCards { get; set; }
        public List<ActionCardBase> DestroyedActionCards { get; set; }

        public Game()
        {
            Users = new List<UserClass>();
            DestroyedPrizeCards = new List<ItemCard>();
            ActionCards = new List<ActionCardBase>();
            DestroyedActionCards = new List<ActionCardBase>();
        }
    }
}
