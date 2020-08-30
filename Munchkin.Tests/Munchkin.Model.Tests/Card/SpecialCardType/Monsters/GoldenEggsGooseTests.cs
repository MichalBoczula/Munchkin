using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Moq;
using Munchkin.BL.Helper;
using Munchkin.Model;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret;
using Munchkin.Model.Card.PrizeCard;
using Munchkin.Model.Character;
using Munchkin.Model.User;
using Munchkin.Tests.Munchkin.Model.Tests.Helper;
using Xunit;

namespace Munchkin.Tests.Munchkin.Model.Tests.Card.SpecialCardType.Monsters
{
    public class GoldenEggsGooseTests
    {
        [Fact]
        public void FindTheMostExpensiveItemTest()
        {
            //Arrange
            var mockTestReadLine = new Mock<TestReadLine>();
            var goose = new GoldenEggsGoose("Goose", CardType.Action, mockTestReadLine.Object);
            var userAvatar = new UserAvatar()
            {
                Build = new Build()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var mostExpensive = new ItemCard("normalBoot", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Boots, null, 500);
            user.UserAvatar.Build.Armor = new ItemCard("leatherArmor", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Armor, null, 100);
            user.UserAvatar.Build.Helmet = new ItemCard("leatherHelmet", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Helmet, null, 200);
            user.UserAvatar.Build.Boots = mostExpensive;
            user.UserAvatar.Build.LeftHandItem = new ItemCard("sword1H", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            user.UserAvatar.Build.RightHandItem = new ItemCard("axe", CardType.Prize, PrizeCardType.Item, 3, null, true, ItemType.Weapon, null, 400);
            //Act
            var item = goose.FindTheMostExpensiveItem(user);
            //Arrange
            item.Should().BeSameAs(mostExpensive);
        }

        [Fact]
        public void FindTheMostExpensiveItemThereAreNoItemsTest()
        {
            //Arrange
            var mockTestReadLine = new Mock<TestReadLine>();
            var goose = new GoldenEggsGoose("Goose", CardType.Action, mockTestReadLine.Object);
            var userAvatar = new UserAvatar()
            {
                Build = new Build()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            var item = goose.FindTheMostExpensiveItem(user);
            //Arrange
            item.Should().BeNull();
        }

        [Fact]
        public void SpecialPowerChooseOne()
        {
            //Arrange
            var game = new Game();
            var mockTestReadLine = new Mock<TestReadLine>();
            mockTestReadLine.Setup(x => x.GetNextString()).Returns("1");
            var goose = new GoldenEggsGoose("Goose", CardType.Action, mockTestReadLine.Object);
            var userAvatar = new UserAvatar()
            {
                Build = new Build()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            goose.SpecialPower(game, user);
            //Assert
            goose.HowManyLevels = 1;
            goose.NumberOfPrizes = 0;
        }


        [Fact]
        public void SpecialPowerChooseTwo()
        {
            //Arrange
            var game = new Game();
            var mockTestReadLine = new Mock<TestReadLine>();
            mockTestReadLine.Setup(x => x.GetNextString()).Returns("2");
            var goose = new GoldenEggsGoose("Goose", CardType.Action, mockTestReadLine.Object);
            var userAvatar = new UserAvatar()
            {
                Build = new Build()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            goose.SpecialPower(game, user);
            //Assert
            goose.HowManyLevels = 0;
            goose.NumberOfPrizes = 3;
        }

        [Fact]
        public void DeadEndTest()
        {
            //Arrange
            var game = new Game();
            var mockTestReadLine = new Mock<TestReadLine>();
            mockTestReadLine.Setup(x => x.GetNextString()).Returns("2");
            var goose = new GoldenEggsGoose("Goose", CardType.Action, mockTestReadLine.Object);
            var userAvatar = new UserAvatar()
            {
                Build = new Build()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var mostExpensive = new ItemCard("normalBoot", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Boots, null, 500);
            user.UserAvatar.Build.Armor = new ItemCard("leatherArmor", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Armor, null, 100);
            user.UserAvatar.Build.Helmet = new ItemCard("leatherHelmet", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Helmet, null, 200);
            user.UserAvatar.Build.Boots = mostExpensive;
            user.UserAvatar.Build.LeftHandItem = new ItemCard("sword1H", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            user.UserAvatar.Build.RightHandItem = new ItemCard("axe", CardType.Prize, PrizeCardType.Item, 3, null, true, ItemType.Weapon, null, 400);
            //Act
            goose.DeadEnd(game, user);
            //Assert
            user.UserAvatar.Build.Boots.Should().BeNull();
            game.DestroyedPrizeCards.Should().HaveCount(1);
            game.DestroyedPrizeCards.Should().Contain(mostExpensive);
        }

        [Fact]
        public void DeadEndNoItemsTest()
        {
            //Arrange
            var game = new Game();
            var mockTestReadLine = new Mock<TestReadLine>();
            mockTestReadLine.Setup(x => x.GetNextString()).Returns("2");
            var goose = new GoldenEggsGoose("Goose", CardType.Action, mockTestReadLine.Object);
            var userAvatar = new UserAvatar()
            {
                Build = new Build()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            goose.DeadEnd(game, user);
            //Assert
            game.DestroyedPrizeCards.Should().HaveCount(0);
        }
    }
}
