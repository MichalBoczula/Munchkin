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
using Munchkin.Model.User;

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
            prizeStackController.PrizeStack.Deck.Should().HaveCount(48);
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
            userAfterDeckInicialize.Deck.Count().Should().Be(0);
        }

    }
}
