using Munchkin.Model.Card.ActionCard;
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
        public List<PrizeCardBase> Prizes{ get; set; }
        public List<PrizeCardBase> DestroyedPrizeCards { get; set; }
        public List<ActionCardBase> ActionCards { get; set; }
        public List<ActionCardBase> DestroyedActionCards { get; set; }

        public Game()
        {
            Users = new List<UserClass>();
            Prizes = new List<PrizeCardBase>();
            DestroyedPrizeCards = new List<PrizeCardBase>();
            ActionCards = new List<ActionCardBase>();
            DestroyedActionCards = new List<ActionCardBase>();
        }
    }
}
