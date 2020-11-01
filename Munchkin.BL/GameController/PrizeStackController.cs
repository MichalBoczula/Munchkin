using Munchkin.BL.CardGenerator;
using Munchkin.BL.CardGenerator.CardsStack;
using Munchkin.BL.CardGenerator.PrizeCard.ItemCards;
using Munchkin.BL.CharacterCreator;
using Munchkin.Model;
using Munchkin.Model.Card.PrizeCard;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Munchkin.BL.GameController
{
    public class PrizeStackController
    {
        private readonly StackCardGeneratorService _stackCardGeneratorService;
        private readonly DrawCardService _drawCardService;
        public PrizeStack PrizeStack;
        public Game Game;

        public PrizeStackController(DrawCardService drawCardService, StackCardGeneratorService stackCardGeneratorService)
        {
            _drawCardService = drawCardService;
            _stackCardGeneratorService = stackCardGeneratorService;
            PrizeStack = _stackCardGeneratorService.GeneratePrizeStack();
            _drawCardService.Shuffle(PrizeStack.Deck);
        }

        public PrizeStackController(DrawCardService drawCardService, StackCardGeneratorService stackCardGeneratorService, Game game)
        {
            _drawCardService = drawCardService;
            _stackCardGeneratorService = stackCardGeneratorService;
            PrizeStack = _stackCardGeneratorService.GeneratePrizeStack();
            _drawCardService.Shuffle(PrizeStack.Deck);
            Game = game;
        }

        public UserClass DrawCardsForStartDeck(UserClass user)
        {
            if (!user.IsDeckInicialize)
            {
                var startedHand = new List<ItemCard>
                {
                    DrawCard(),
                    DrawCard(),
                    DrawCard(),
                    DrawCard(),
                    DrawCard()
                };
                user.Deck.Items.AddRange(startedHand);
                user.IsDeckInicialize = true;
            }
            else
            {
                Console.WriteLine("Deck has been inicialized!!!");
            }
            return user;
        }

        public ItemCard DrawCard()
        {
            CheckHowManyPrizesAre(Game);
            var num = _drawCardService.RandomPrizeCard(PrizeStack.Deck.Count);
            var item = PrizeStack.Deck[num];
            PrizeStack.Deck.Remove(item);
            return item;
        }

        private void CheckHowManyPrizesAre(Game game)
        {
            if (PrizeStack.Deck.Count == 0)
            {
                PrizeStack.Deck.AddRange(Game.DestroyedPrizeCards);
                Game.DestroyedPrizeCards.RemoveRange(0, Game.DestroyedPrizeCards.Count);
                _drawCardService.Shuffle(PrizeStack.Deck);
            }
        }
    }
}
