using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Munchkin.BL.GameController;
using Munchkin.BL.CardGenerator;
using Munchkin.BL.CharacterCreator;
using Munchkin.Model;
using Munchkin.Model.Card.PrizeCard;

namespace Munchkin.Tests.Munchkin.BL.Tests.GameController
{
    public class PrizeStackControllerTests
    {
        [Fact]
        public void DrawCardTest()
        {
            //Arrange
            var stackCardGenedratorService = new StackCardGeneratorService();
            var random = new Random();
            var drawCardService = new DrawCardService(random);
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGenedratorService);
            //Act
            var firstItem = prizeStackController.DrawCard();
            var secondItem = prizeStackController.DrawCard();
            //Assert
            Assert.NotNull(firstItem);
            Assert.NotNull(secondItem);
            Assert.IsType<ItemCard>(firstItem);
            Assert.IsType<ItemCard>(secondItem);
            Assert.Equal(18, prizeStackController.PrizeStack.Deck.Count);
        }

        [Fact]
        public void DrawCardsForStartDeckTests()
        {
            //Arrange
            var userBeforeDeckInicialize = new UserClass();
            var userAfterDeckInicialize = new UserClass() { IsDeckInicialize = true};
            var stackCardGenedratorService = new StackCardGeneratorService();
            var random = new Random();
            var drawCardService = new DrawCardService(random);
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGenedratorService);
            //Act
            userBeforeDeckInicialize = prizeStackController.DrawCardsForStartDeck(userBeforeDeckInicialize);
            userAfterDeckInicialize = prizeStackController.DrawCardsForStartDeck(userAfterDeckInicialize);
            //Assert
            Assert.NotNull(userBeforeDeckInicialize.Deck);
            Assert.True(userBeforeDeckInicialize.IsDeckInicialize);
            Assert.Null(userAfterDeckInicialize.Deck);
        }

        [Fact]
        public void DrawCardPrizeCardsTests()
        {
            //Arrange
            var user = new UserClass();
            var howMany2 = 2;
            var stackCardGenedratorService = new StackCardGeneratorService();
            var random = new Random();
            var drawCardService = new DrawCardService(random);
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGenedratorService);
            user = prizeStackController.DrawCardsForStartDeck(user);
            //Act
            user = prizeStackController.DrawCardPrizeCards(user, howMany2);
            //Assert
            Assert.Equal(7, user.Deck.Count);
            Assert.Equal(13, prizeStackController.PrizeStack.Deck.Count);
        }
    }
}
