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
    public class PayToHaronTests
    {
        [Fact]
        public void FindTheMostExpensiveTwoEqualsPriceItemTest()
        {

            //Arrange
            var game = new Game();
            var curse = new PayToHaron("PayToHaron", CardType.Curse);
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
            var result = curse.FindTheMostExpensiveItem(user);
            //Assert
            result.Should().BeSameAs(mostExp);
        }

        [Fact]
        public void FindTheMostExpensiveDiffrentPriceItemTest()
        {
            //Arrange
            var game = new Game();
            var curse = new PayToHaron("PayToHaron", CardType.Curse);
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
            var result = curse.FindTheMostExpensiveItem(user);
            //Assert
            result.Should().BeSameAs(mostExp);
        }

        [Fact]
        public void DeleteTheMostExpensiveItemTest()
        {
            //Arrange
            var game = new Game();
            var curse = new PayToHaron("PayToHaron", CardType.Curse);
            var userAvatar = new UserAvatar();
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
            curse.DeleteMostExpensiveItem(game, user, mostExp);
            //Assert
            game.DestroyedPrizeCards.Should().HaveCount(1);
            user.UserAvatar.Build.LeftHandItem.Should().BeNull();
        }

        [Fact]
        public void CastSpecialSpellWithBuildTest()
        {
            //Arrange
            var game = new Game();
            var curse = new PayToHaron("PayToHaron", CardType.Curse);
            var userAvatar = new UserAvatar();
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
            curse.CastSpecialSpell(user, null, game);
            //Assert
            game.DestroyedPrizeCards.Should().HaveCount(1);
            user.UserAvatar.Build.LeftHandItem.Should().BeNull();
        }

        [Fact]
        public void CastSpecialSpellNoItemsTest()
        {
            //Arrange
            var game = new Game();
            var curse = new PayToHaron("PayToHaron", CardType.Curse);
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
