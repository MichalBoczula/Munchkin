using FluentAssertions;
using Munchkin.Model;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret;
using Munchkin.Model.Card.PrizeCard;
using Munchkin.Model.Character;
using Munchkin.Model.Character.Hero.Proficiency;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Munchkin.Tests.Munchkin.Model.Tests.Card.SpecialCardType.Monsters
{
    public class LokiTests
    {
        [Fact]
        public void SpecialPowerTest()
        {
            //Arrange
            var game = new Game();
            var loki = new Loki("Loki", CardType.Monster);
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            loki.SpecialPower(game, user);
            //Assert
            loki.Power.Should().Be(14);
            loki.NumberOfPrizes.Should().Be(4);
            loki.HowManyLevels.Should().Be(1);
            user.UserAvatar.Proficiency.Should().BeOfType<NoOneProficiency>();
        }

        [Fact]
        public void DeadEndNoItemsTest()
        {
            //Arrange
            var game = new Game();
            var loki = new Loki("Loki", CardType.Monster);
            var userAvatar = new UserAvatar()
            {
                Build = new Build()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            loki.DeadEnd(game, user);
            //Assert
            user.UserAvatar.Level.Should().Be(-1);
            game.DestroyedPrizeCards.Should().HaveCount(0);
        }

        [Fact]
        public void DeadEndWithItemTest()
        {
            //Arrange
            var game = new Game();
            var loki = new Loki("Loki", CardType.Monster);
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
            loki.DeadEnd(game, user);
            //Assert
            game.DestroyedPrizeCards.Should().HaveCount(1);
            game.DestroyedPrizeCards.Should().Contain(mostExp);
            user.UserAvatar.Build.LeftHandItem.Should().BeNull();
            user.UserAvatar.Level.Should().Be(-1);
        }

        [Fact]
        public void FindTheMostExpensiveTwoEqualsPriceItemTest()
        {
           
            //Arrange
            var game = new Game();
            var loki = new Loki("Loki", CardType.Monster);
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
            var result = loki.FindTheMostExpensiveItem(user);
            //Assert
            result.Should().BeSameAs(mostExp);
        }

        [Fact]
        public void FindTheMostExpensiveDiffrentPriceItemTest()
        {         
            //Arrange
            var game = new Game();
            var loki = new Loki("Loki", CardType.Monster);
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
            var result = loki.FindTheMostExpensiveItem(user);
            //Assert
            result.Should().BeSameAs(mostExp);
        }

        [Fact]
        public void DeleteTheMostExpensiveItemTest()
        {
            //Arrange
            var game = new Game();
            var loki = new Loki("Loki", CardType.Monster);
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
            var result = loki.FindTheMostExpensiveItem(user);
            loki.DeleteMostExpensiveItem(game, user, result);
            //Assert
            game.DestroyedPrizeCards.Should().HaveCount(1);
            game.DestroyedPrizeCards.Should().Contain(result);
            user.UserAvatar.Build.LeftHandItem.Should().BeNull();
        }
    }
}
