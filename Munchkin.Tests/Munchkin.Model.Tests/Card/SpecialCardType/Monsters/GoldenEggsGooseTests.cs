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
        public void SpecialPowerChooseOne()
        {
            //Arrange
            var game = new Game();
            var mockTestReadLine = new Mock<TestReadLine>();
            mockTestReadLine.Setup(x => x.GetNextString()).Returns("1");
            var goose = new GoldenEggsGoose("Goose", CardType.Monster, mockTestReadLine.Object);
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
            goose.HowManyLevels.Should().Be(1);
            goose.NumberOfPrizes.Should().Be(0);
        }


        [Fact]
        public void SpecialPowerChooseTwo()
        {
            //Arrange
            var game = new Game();
            var mockTestReadLine = new Mock<TestReadLine>();
            mockTestReadLine.Setup(x => x.GetNextString()).Returns("2");
            var goose = new GoldenEggsGoose("Goose", CardType.Monster, mockTestReadLine.Object);
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
            goose.HowManyLevels.Should().Be(0);
            goose.NumberOfPrizes.Should().Be(3);
        }

        [Fact]
        public void DeadEndNoItemsTest()
        {
            //Arrange
            var game = new Game();
            var mockTestReadLine = new Mock<TestReadLine>();
            var goldenEggsGoose = new GoldenEggsGoose("Golden Eggs Goose", CardType.Monster, mockTestReadLine.Object);
            var userAvatar = new UserAvatar()
            {
                Build = new Build()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            goldenEggsGoose.DeadEnd(game, user);
            //Assert
            game.DestroyedPrizeCards.Should().HaveCount(0);
        }

        [Fact]
        public void DeadEndWithItemTest()
        {
            //Arrange
            var game = new Game();
            var mockTestReadLine = new Mock<TestReadLine>();
            var goldenEggsGoose = new GoldenEggsGoose("Golden Eggs Goose", CardType.Monster, mockTestReadLine.Object);
            var userAvatar = new UserAvatar()
            {
                Build = new Build()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var mostExp = new ItemCard("sword1H", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 900);
            user.UserAvatar.Build.Armor = new ItemCard("leatherArmor", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Armor, null, 500);
            user.UserAvatar.Build.Helmet = new ItemCard("leatherHelmet", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Helmet, null, 700);
            user.UserAvatar.Build.Boots = new ItemCard("normalBoot", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Boots, null, 500);
            user.UserAvatar.Build.LeftHandItem = mostExp;
            //Act
            goldenEggsGoose.DeadEnd(game, user);
            //Assert
            game.DestroyedPrizeCards.Should().HaveCount(1);
            game.DestroyedPrizeCards.Should().Contain(mostExp);
            user.UserAvatar.Build.LeftHandItem.Should().BeNull();
        }

        [Fact]
        public void FindTheMostExpensiveTwoEqualsPriceItemTest()
        {

            //Arrange
            var game = new Game();
            var mockTestReadLine = new Mock<TestReadLine>();
            var goldenEggsGoose = new GoldenEggsGoose("Golden Eggs Goose", CardType.Monster, mockTestReadLine.Object);
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var mostExp = new ItemCard("leatherArmor", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Armor, null, 500);
            user.UserAvatar.Build.Armor = mostExp;
            user.UserAvatar.Build.Helmet = new ItemCard("leatherHelmet", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Helmet, null, 300);
            user.UserAvatar.Build.Boots = new ItemCard("normalBoot", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Boots, null, 500);
            user.UserAvatar.Build.LeftHandItem = new ItemCard("sword1H", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            //Act
            var result = goldenEggsGoose.FindTheMostExpensiveItem(user);
            //Assert
            result.Should().BeSameAs(mostExp);
        }

        [Fact]
        public void FindTheMostExpensiveDiffrentPriceItemTest()
        {
            //Arrange
            var game = new Game();
            var mockTestReadLine = new Mock<TestReadLine>();
            var goldenEggsGoose = new GoldenEggsGoose("Golden Eggs Goose", CardType.Monster, mockTestReadLine.Object);
            var userAvatar = new UserAvatar()
            {
                Build = new Build()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var mostExp = new ItemCard("sword1H", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 900);
            user.UserAvatar.Build.Armor = new ItemCard("leatherArmor", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Armor, null, 500);
            user.UserAvatar.Build.Helmet = new ItemCard("leatherHelmet", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Helmet, null, 700);
            user.UserAvatar.Build.Boots = new ItemCard("normalBoot", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Boots, null, 500);
            user.UserAvatar.Build.LeftHandItem = mostExp;
            //Act
            var result = goldenEggsGoose.FindTheMostExpensiveItem(user);
            //Assert
            result.Should().BeSameAs(mostExp);
        }

        [Fact]
        public void DeleteTheMostExpensiveItemTest()
        {
            //Arrange
            var game = new Game();
            var mockTestReadLine = new Mock<TestReadLine>();
            var goldenEggsGoose = new GoldenEggsGoose("Golden Eggs Goose", CardType.Monster, mockTestReadLine.Object);
            var userAvatar = new UserAvatar()
            {
                Build = new Build()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var mostExp = new ItemCard("sword1H", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 900);
            user.UserAvatar.Build.Armor = new ItemCard("leatherArmor", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Armor, null, 500);
            user.UserAvatar.Build.Helmet = new ItemCard("leatherHelmet", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Helmet, null, 700);
            user.UserAvatar.Build.Boots = new ItemCard("normalBoot", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Boots, null, 500);
            user.UserAvatar.Build.LeftHandItem = mostExp;
            //Act
            var result = goldenEggsGoose.FindTheMostExpensiveItem(user);
            goldenEggsGoose.DeleteMostExpensiveItem(game, user, result);
            //Assert
            game.DestroyedPrizeCards.Should().HaveCount(1);
            game.DestroyedPrizeCards.Should().Contain(result);
            user.UserAvatar.Build.LeftHandItem.Should().BeNull();
        }

    }
}
