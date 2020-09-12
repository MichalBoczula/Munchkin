using FluentAssertions;
using Munchkin.Model;
using Munchkin.Model.Card.ActionCard.SpecialCardType.MagicCards;
using Munchkin.Model.Card.PrizeCard;
using Munchkin.Model.Character;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Munchkin.Tests.Munchkin.Model.Tests.Card.SpecialCardType.MagicCard
{
    public class ItIsTooMuchTests
    {
        [Fact]
        public void FindTheMostPowerfulTwoEqualsPriceItemTest()
        {
            //Arrange
            var game = new Game();
            var curse = new ItIsTooMuch("It Is Too Much", CardType.Curse);
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var mostPowerful = new ItemCard("leatherArmor", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Armor, null, 300);
            user.UserAvatar.Build.Armor = mostPowerful;
            user.UserAvatar.Build.Helmet = new ItemCard("leatherHelmet", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Helmet, null, 300);
            user.UserAvatar.Build.Boots = new ItemCard("normalBoot", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Boots, null, 500);
            user.UserAvatar.Build.LeftHandItem = new ItemCard("sword1H", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            //Act
            var result = curse.FindTheMostPowerfulItem(user);
            //Assert
            result.Should().BeSameAs(mostPowerful);
        }

        [Fact]
        public void FindTheMostPowerfuleDiffrentPriceItemTest()
        {
            //Arrange
            var game = new Game();
            var curse = new ItIsTooMuch("It Is Too Much", CardType.Curse);
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var mostPowerful = new ItemCard("leatherArmor", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Armor, null, 500);
            user.UserAvatar.Build.Armor = mostPowerful;
            user.UserAvatar.Build.Helmet = new ItemCard("leatherHelmet", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Helmet, null, 700);
            user.UserAvatar.Build.Boots = new ItemCard("normalBoot", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Boots, null, 500);
            user.UserAvatar.Build.LeftHandItem = new ItemCard("sword1H", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 900);
            //Act
            var result = curse.FindTheMostPowerfulItem(user);
            //Assert
            result.Should().BeSameAs(mostPowerful);
        }

        [Fact]
        public void DeleteTheMostPowerfulItemTest()
        {
            //Arrange
            var game = new Game();
            var curse = new ItIsTooMuch("It Is Too Much", CardType.Curse);
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var mostPowerful = new ItemCard("sword1H", CardType.Prize, PrizeCardType.Item, 6, null, false, ItemType.Weapon, null, 900);
            user.UserAvatar.Build.Armor = new ItemCard("leatherArmor", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Armor, null, 500);
            user.UserAvatar.Build.Helmet = new ItemCard("leatherHelmet", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Helmet, null, 700);
            user.UserAvatar.Build.Boots = new ItemCard("normalBoot", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Boots, null, 500);
            user.UserAvatar.Build.LeftHandItem = mostPowerful;
            //Act
            curse.DeleteMostPowerfulItem(game, user, mostPowerful);
            //Assert
            game.DestroyedPrizeCards.Should().HaveCount(1);
            user.UserAvatar.Build.LeftHandItem.Should().BeNull();
        }

        [Fact]
        public void CastSpecialSpellWithBuildTest()
        {
            //Arrange
            var game = new Game();
            var curse = new ItIsTooMuch("It Is Too Much", CardType.Curse);
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var mostPowerful = new ItemCard("sword1H", CardType.Prize, PrizeCardType.Item, 6, null, false, ItemType.Weapon, null, 900);
            user.UserAvatar.Build.Armor = new ItemCard("leatherArmor", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Armor, null, 500);
            user.UserAvatar.Build.Helmet = new ItemCard("leatherHelmet", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Helmet, null, 700);
            user.UserAvatar.Build.Boots = new ItemCard("normalBoot", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Boots, null, 500);
            user.UserAvatar.Build.LeftHandItem = mostPowerful;
            //Act
            curse.CastSpecialSpell(user, null, game);
            //Assert
            game.DestroyedPrizeCards.Should().HaveCount(1);
            game.DestroyedPrizeCards[0].Should().BeSameAs(mostPowerful);
            user.UserAvatar.Build.LeftHandItem.Should().BeNull();
        }

        [Fact]
        public void CastSpecialSpellNoItemsTest()
        {
            //Arrange
            var game = new Game();
            var curse = new ItIsTooMuch("It Is Too Much", CardType.Curse);
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            curse.CastSpecialSpell(user, null, game);
            //Assert
            game.DestroyedPrizeCards.Should().HaveCount(0);
        }
    }
}
