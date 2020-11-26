using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard.SpecialCardType.MagicCards
{
    public class DrunkCurse : ActionCardBase
    {
        private readonly Random random;

        public DrunkCurse(string name, CardType cardType, Random random) : base(name, cardType)
        {
            MagicCardType = MagicCardType.Hero;
            this.random = random;
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

        public override string Description()
        {
            return "You was on party. Currently you struggle with huge amount of alcohol, and you lost one of your cards.";
        }
    }
}
