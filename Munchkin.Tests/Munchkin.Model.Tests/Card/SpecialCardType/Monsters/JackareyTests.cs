using FluentAssertions;
using Munchkin.Model;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret;
using Munchkin.Model.Card.PrizeCard;
using Munchkin.Model.Character;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Munchkin.Tests.Munchkin.Model.Tests.Card.SpecialCardType.Monsters
{
    public class JackareyTests
    {
        [Fact]
        public void DeadEndTest()
        {
            //Arrange
            var game = new Game();
            var jackarey = new Jackarey("Jackarey", CardType.Action);
            var userAvatar = new UserAvatar()
            {
                Build = new Build()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            jackarey.DeadEnd(game, user);
            user.UserAvatar.EndTurn();
            //Assert
            user.UserAvatar.Nerfs.Poisoned.Should().HaveCount(1);
            user.UserAvatar.Nerfs.Poisoned.Should().Contain(true);
            user.UserAvatar.Level.Should().Be(0);
            user.UserAvatar.Power.Should().Be(-1);
        }

        [Fact]
        public void SpecialPowerFullTest()
        {
            //Arrange
            var game = new Game();
            var jackarey = new Jackarey("Jackarey", CardType.Action);
            var userAvatar = new UserAvatar()
            {
                Build = new Build()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var helmet = new ItemCard("leatherHelmet", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Helmet, null, 300);
            var armor = new ItemCard("leatherArmor", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Armor, null, 300);
            var boots = new ItemCard("normalBoot", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Boots, null, 300);
            user.UserAvatar.Build.Helmet = helmet;
            user.UserAvatar.Build.Armor = armor;
            user.UserAvatar.Build.Boots = boots;
            //Act
            jackarey.SpecialPower(game, user);
            //Assert
            user.UserAvatar.Level.Should().Be(1);
            user.UserAvatar.Nerfs.FleeChances.Should().HaveCount(0);
            user.UserAvatar.Nerfs.Power.Should().HaveCount(0);
        }

        [Fact]
        public void SpecialPowerNoItemsTest()
        {
            //Arrange
            var game = new Game();
            var jackarey = new Jackarey("Jackarey", CardType.Action);
            var userAvatar = new UserAvatar()
            {
                Build = new Build()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            jackarey.SpecialPower(game, user);
            user.UserAvatar.EndTurn();
            //Assert
            user.UserAvatar.Level.Should().Be(0);
            user.UserAvatar.Power.Should().Be(-2);
            user.UserAvatar.FleeChances.Should().Be(2);
            user.UserAvatar.Nerfs.Power.Should().Contain(2);
            user.UserAvatar.Nerfs.Power.Should().HaveCount(1);
            user.UserAvatar.Nerfs.FleeChances.Should().Contain(1);
            user.UserAvatar.Nerfs.FleeChances.Should().HaveCount(1);
        }

        [Fact]
        public void SpecialPowerFewItemsTest()
        {
            //Arrange
            var game = new Game();
            var jackarey = new Jackarey("Jackarey", CardType.Action);
            var userAvatar = new UserAvatar()
            {
                Build = new Build()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var helmet = new ItemCard("leatherHelmet", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Helmet, null, 300);
            var boots = new ItemCard("normalBoot", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Boots, null, 300);
            user.UserAvatar.Build.Helmet = helmet;
            user.UserAvatar.Build.Boots = boots;
            //Act
            jackarey.SpecialPower(game, user);
            user.UserAvatar.EndTurn();
            //Assert
            user.UserAvatar.Nerfs.Power.Should().HaveCount(1);
            user.UserAvatar.Nerfs.Power.Should().Contain(2);
            user.UserAvatar.Level.Should().Be(1);
            user.UserAvatar.Nerfs.FleeChances.Should().HaveCount(0);
        }

        [Fact]
        public void SpecialPowerOnlyArmorTest()
        {
            //Arrange
            var game = new Game();
            var jackarey = new Jackarey("Jackarey", CardType.Action);
            var userAvatar = new UserAvatar()
            {
                Build = new Build()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var armor = new ItemCard("leatherArmor", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Armor, null, 300);
            user.UserAvatar.Build.Armor = armor;
            //Act
            jackarey.SpecialPower(game, user);
            //Assert
            user.UserAvatar.Level.Should().Be(0);
            user.UserAvatar.Nerfs.Power.Should().HaveCount(0);
            user.UserAvatar.Nerfs.FleeChances.Should().HaveCount(1);
            user.UserAvatar.Nerfs.FleeChances.Should().Contain(1);
        }
    }
}
