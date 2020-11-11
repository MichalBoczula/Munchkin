using FluentAssertions;
using Moq;
using Munchkin.BL.GameController;
using Munchkin.BL.Helper;
using Munchkin.Model;
using Munchkin.Model.Card.PrizeCard;
using Munchkin.Model.Character;
using Munchkin.Model.Character.Hero.Race;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Munchkin.Tests.Munchkin.BL.Tests.GameController
{
    public class SellItemControllerTests
    {
        [Fact]
        public void SellItemSuccessTest()
        {
            //Arange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var userAvatar = new UserAvatar
            {
                Level = 1
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var deckController = new DeckController(mock.Object);
            var sellItemController = new SellItemController(deckController, mock.Object);
            var helmet = new ItemCard("Helmet", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Helmet, null, 300);
            user.Deck.Items.Add(helmet);
            //Act
            var result = sellItemController.SellItem(user);
            //Assert
            user.Deck.Items.Should().HaveCount(0);
            user.UserAvatar.Wallet.Should().Be(300);
            result.Should().BeTrue();
        }

        [Fact]
        public void SellItemSuccessHalfingRaceTest()
        {
            //Arange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var userAvatar = new UserAvatar
            {
                Level = 1,
                Race = new Halfling("Halfing")
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var deckController = new DeckController(mock.Object);
            var sellItemController = new SellItemController(deckController, mock.Object);
            var helmet = new ItemCard("Helmet", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Helmet, null, 300);
            user.Deck.Items.Add(helmet);
            //Act
            var result = sellItemController.SellItem(user);
            //Assert
            user.Deck.Items.Should().HaveCount(0);
            user.UserAvatar.Wallet.Should().Be(600);
            result.Should().BeTrue();
        }

        [Fact]
        public void SellItemFailureNoCardsinDeckTest()
        {
            //Arange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var userAvatar = new UserAvatar
            {
                Level = 1
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var deckController = new DeckController(mock.Object);
            var sellItemController = new SellItemController(deckController, mock.Object);
            //Act
            var result = sellItemController.SellItem(user);
            //Assert
            user.Deck.Items.Should().HaveCount(0);
            user.UserAvatar.Wallet.Should().Be(0);
            result.Should().BeFalse();
        }

        [Fact]
        public void SellItemFailureDEcideToNotSellTest()
        {
            //Arange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("0");
            var userAvatar = new UserAvatar
            {
                Level = 1
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var deckController = new DeckController(mock.Object);
            var sellItemController = new SellItemController(deckController, mock.Object);
            //Act
            var result = sellItemController.SellItem(user);
            //Assert
            user.Deck.Items.Should().HaveCount(0);
            user.UserAvatar.Wallet.Should().Be(0);
            result.Should().BeFalse();
        }

        [Fact]
        public void CheckMoneyAndAddLevelSuccessTest()
        {
            //Arange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("0");
            var userAvatar = new UserAvatar
            {
                Level = 1,
                Wallet = 1001
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var deckController = new DeckController(mock.Object);
            var sellItemController = new SellItemController(deckController, mock.Object);
            //Act
            sellItemController.CheckMoneyAndAddLevel(user);
            //Assert
            user.UserAvatar.Wallet.Should().Be(1);
            user.UserAvatar.Level.Should().Be(2);
        }

        [Fact]
        public void CheckMoneyAndAddLevelNotEnoughMoneyTest()
        {
            //Arange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("0");
            var userAvatar = new UserAvatar
            {
                Level = 1,
                Wallet = 999
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var deckController = new DeckController(mock.Object);
            var sellItemController = new SellItemController(deckController, mock.Object);
            //Act
            sellItemController.CheckMoneyAndAddLevel(user);
            //Assert
            user.UserAvatar.Wallet.Should().Be(999);
            user.UserAvatar.Level.Should().Be(1);
        }

        [Fact]
        public void CheckMoneyAndAddLevelSuccesMoneyEqualToThousandTest()
        {
            //Arange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("0");
            var userAvatar = new UserAvatar
            {
                Level = 1,
                Wallet = 1000
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var deckController = new DeckController(mock.Object);
            var sellItemController = new SellItemController(deckController, mock.Object);
            //Act
            sellItemController.CheckMoneyAndAddLevel(user);
            //Assert
            user.UserAvatar.Wallet.Should().Be(0);
            user.UserAvatar.Level.Should().Be(2);
        }
    }
}
