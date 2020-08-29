using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Munchkin.Model;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret;
using Munchkin.Model.Card.PrizeCard;
using Munchkin.Model.Character;
using Munchkin.Model.User;
using Xunit;

namespace Munchkin.Tests.Munchkin.Model.Tests.Card.SpecialCardType.Monsters
{
    public class GremlinTests
    {
        [Fact]
        public void FindTheMostPowerfulItem()
        {
            //Arrange
            var gremlin = new Gremlin("Gremlin", CardType.Action);
            var userAvatar = new UserAvatar()
            {
                Build = new Build()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var theMostPowerfulItem = new ItemCard("sword1H", CardType.Prize, PrizeCardType.Item, 4, null, false, ItemType.Weapon, null);
            user.UserAvatar.Build.LeftHandItem = theMostPowerfulItem;
            user.UserAvatar.Build.RightHandItem = new ItemCard("axe", CardType.Prize, PrizeCardType.Item, 3, null, true, ItemType.Weapon, null);
            user.UserAvatar.CountPower();
            //Act
            var result = gremlin.FindTheMostPowerfulItem(user);
            //Assert
            gremlin.Power.Should().Be(1);
            user.UserAvatar.TempPower.Should().Be(8);
            result.Should().BeSameAs(theMostPowerfulItem);
        }

        [Fact]
        public void SpecialPowerTest()
        {
            //Arrange
            var game = new Game();
            var gremlin = new Gremlin("Gremlin", CardType.Action);
            var userAvatar = new UserAvatar()
            {
                Build = new Build()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var theMostPowerfulItem = new ItemCard("sword1H", CardType.Prize, PrizeCardType.Item, 4, null, false, ItemType.Weapon, null);
            user.UserAvatar.Build.LeftHandItem = theMostPowerfulItem;
            user.UserAvatar.Build.RightHandItem = new ItemCard("axe", CardType.Prize, PrizeCardType.Item, 3, null, true, ItemType.Weapon, null);
            user.UserAvatar.CountPower();
            //Act
            gremlin.SpecialPower(game, user);
            //Assert
            user.UserAvatar.TempPower.Should().Be(4);
        }

        [Fact]
        public void SpecialPowerNoItemsTest()
        {
            //Arrange
            var game = new Game();
            var gremlin = new Gremlin("Gremlin", CardType.Action);
            var userAvatar = new UserAvatar()
            {
                Build = new Build()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            user.UserAvatar.Level = 8;
            user.UserAvatar.CountPower();
            //Act
            gremlin.SpecialPower(game, user);
            //Assert
            user.UserAvatar.TempPower.Should().Be(8);
        }

        [Fact]
        public void DeadEndTest()
        {
            //Arrange
            var game = new Game();
            var gremlin = new Gremlin("Gremlin", CardType.Action);
            var userAvatar = new UserAvatar()
            {
                Build = new Build()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var theMostPowerfulItem = new ItemCard("sword1H", CardType.Prize, PrizeCardType.Item, 4, null, false, ItemType.Weapon, null);
            user.UserAvatar.Build.LeftHandItem = theMostPowerfulItem;
            user.UserAvatar.Build.RightHandItem = new ItemCard("axe", CardType.Prize, PrizeCardType.Item, 3, null, true, ItemType.Weapon, null);
            //Act
            gremlin.DeadEnd(game, user);
            user.UserAvatar.EndTurn();
            //Assert
            user.UserAvatar.TempPower.Should().Be(4);
        }

        [Fact]
        public void DeadEndNoItemsTest()
        {
            //Arrange
            var game = new Game();
            var gremlin = new Gremlin("Gremlin", CardType.Action);
            var userAvatar = new UserAvatar()
            {
                Build = new Build()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            user.UserAvatar.Level = 5;
            //Act
            gremlin.DeadEnd(game, user);
            user.UserAvatar.EndTurn();
            //Assert
            user.UserAvatar.TempPower.Should().Be(5);
            game.DestroyedPrizeCards.Should().HaveCount(0);
        }
    }
}
