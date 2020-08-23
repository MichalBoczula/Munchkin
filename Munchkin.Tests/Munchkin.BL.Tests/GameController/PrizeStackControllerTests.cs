using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Munchkin.BL.GameController;
using Munchkin.BL.CardGenerator;
using Munchkin.BL.CharacterCreator;
using Munchkin.Model;
using Munchkin.Model.Card.PrizeCard;
using FluentAssertions;

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
            firstItem.Should().NotBeNull();
            secondItem.Should().NotBeNull();
            firstItem.Should().BeOfType<ItemCard>();
            secondItem.Should().BeOfType<ItemCard>();
            prizeStackController.PrizeStack.Deck.Should().HaveCount(18);
        }

        [Fact]
        public void DrawCardsForStartDeckTests()
        {
            //Arrange
            var userBeforeDeckInicialize = new UserClass();
            var userAfterDeckInicialize = new UserClass() { IsDeckInicialize = true };
            var stackCardGenedratorService = new StackCardGeneratorService();
            var random = new Random();
            var drawCardService = new DrawCardService(random);
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGenedratorService);
            //Act
            userBeforeDeckInicialize = prizeStackController.DrawCardsForStartDeck(userBeforeDeckInicialize);
            userAfterDeckInicialize = prizeStackController.DrawCardsForStartDeck(userAfterDeckInicialize);
            //Assert
            userBeforeDeckInicialize.Deck.Should().NotBeNull();
            userBeforeDeckInicialize.IsDeckInicialize.Should().BeTrue();
            userAfterDeckInicialize.Deck.Should().BeNull();
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
            user.Deck.Should().HaveCount(7);
            prizeStackController.PrizeStack.Deck.Should().HaveCount(13);
        }
    }
}
