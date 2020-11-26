using Munchkin.BL.Helper;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard.SpecialCardType.MagicCards
{
    public class WhatAMess : ActionCardBase
    {
        private readonly Random random;

        public WhatAMess(string name, CardType cardType, Random random) : base(name, cardType)
        {
            this.random = random;
            MagicCardType = MagicCardType.Hero;
        }

        public override void CastSpecialSpell(UserClass user, MonsterCardBase monster, Game game)
        {
            var list = new List<CardGameBase>();
            list.AddRange(user.Deck.Items);
            list.AddRange(user.Deck.MagicCards);
            list.AddRange(user.Deck.Monsters);
            var num = random.Next(list.Count);

            if (list.Count > 0)
            {
                if (user.Deck.Items.Count - 1 >= num)
                {
                    var cardToRemove = user.Deck.Items[num];
                    game.DestroyedPrizeCards.Add(cardToRemove);
                    user.Deck.Items.RemoveAt(num);
                    return;
                }

                num = num - user.Deck.Items.Count;

                if (user.Deck.MagicCards.Count - 1 >= num)
                {
                    var cardToRemove = user.Deck.MagicCards[num];
                    game.DestroyedActionCards.Add(cardToRemove);
                    user.Deck.MagicCards.RemoveAt(num);
                    return;
                }

                num = num - user.Deck.MagicCards.Count;

                if (user.Deck.Monsters.Count - 1 >= num)
                {
                    var cardToRemove = user.Deck.Monsters[num];
                    game.DestroyedActionCards.Add(cardToRemove);
                    user.Deck.Monsters.RemoveAt(num);
                    return;
                }
            }
        }

        public override void Description()
        {
            System.Console.WriteLine("You have a big mess in your eqipment and lose an item from build.");
        }
    }
}
