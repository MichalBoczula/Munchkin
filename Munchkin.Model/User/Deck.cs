using Munchkin.Model.Card.ActionCard;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.Card.PrizeCard;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.User
{
    public class Deck
    {
        public List<ItemCard> Items { get; set; }
        public List<MonsterCardBase> Monsters { get; set; }
        public List<MagicCard> MagicCards { get; set; }

        public Deck()
        {
            Items = new List<ItemCard>();
            Monsters = new List<MonsterCardBase>();
            MagicCards = new List<MagicCard>();
        }

        public  void Clear()
        {
            Items.Clear();
            Monsters.Clear();
        }

        public int Count()
        {
            return Items.Count + Monsters.Count + MagicCards.Count;
        }

    }
}
