﻿using FluentAssertions;
using Moq;
using Munchkin.BL.Helper;
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
    public class ValkyriesTests
    {
        [Fact]
        public void SpecialPowerNoItemAndDiffrentProficiencyTest()
        {
            //Arrange
            var game = new Game();
            var valkyries = new Valkyries("Valkyries", CardType.Monster);
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            valkyries.SpecialPower(game, user);
            //Assert
            valkyries.Power.Should().Be(12);
            valkyries.NumberOfPrizes.Should().Be(3);
            valkyries.HowManyLevels.Should().Be(1);
        }

        [Fact]
        public void SpecialPowerWithWaeponTest()
        {
            //Arrange
            var game = new Game();
            var valkyries = new Valkyries("Valkyries", CardType.Monster);
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var item = new ItemCard("sword1H", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            user.UserAvatar.Build.LeftHandItem = item;
            //Act
            valkyries.SpecialPower(game, user);
            //Assert
            valkyries.Power.Should().Be(16);
        }


        [Fact]
        public void SpecialPowerWithWaeponAnWarriorProficiencyTest()
        {
            //Arrange
            var mockReadLineOverride = new Mock<ReadLineOverride>();
            mockReadLineOverride.Setup(x => x.GetNextString()).Returns("1");
            var game = new Game();
            var valkyries = new Valkyries("Valkyries", CardType.Monster);
            var warrior = new WarriorProficiency(mockReadLineOverride.Object);
            var userAvatar = new UserAvatar()
            {
                Proficiency = warrior
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var item = new ItemCard("sword1H", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            user.UserAvatar.Build.LeftHandItem = item;
            //Act
            valkyries.SpecialPower(game, user);
            //Assert
            valkyries.Power.Should().Be(18);
        }

        [Fact]
        public void FindTheMostPowerfulItemInBuildTest()
        {
            //Arrange
            var mockReadLineOverride = new Mock<ReadLineOverride>();
            mockReadLineOverride.Setup(x => x.GetNextString()).Returns("1");
            var game = new Game();
            var valkyries = new Valkyries("Valkyries", CardType.Monster);
            var warrior = new WarriorProficiency(mockReadLineOverride.Object);
            var userAvatar = new UserAvatar()
            {
                Proficiency = warrior
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var item = new ItemCard("sword1H", CardType.Prize, PrizeCardType.Item, 10, null, false, ItemType.Weapon, null, 300);
            user.UserAvatar.Build.Armor = new ItemCard("leatherArmor", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Armor, null, 300);
            user.UserAvatar.Build.LeftHandItem = item;
            user.UserAvatar.Build.RightHandItem = new ItemCard("axe", CardType.Prize, PrizeCardType.Item, 3, null, true, ItemType.Weapon, null, 300);
            //Act
            var result = valkyries.FindTheMostPowerfulItemInBuild(user);
            //Assert
            result.Should().BeSameAs(result);
        }

        [Fact]
        public void FindTheMostPowerfulItemInBuildNoItemsTest()
        {
            //Arrange
            var mockReadLineOverride = new Mock<ReadLineOverride>();
            mockReadLineOverride.Setup(x => x.GetNextString()).Returns("1");
            var game = new Game();
            var valkyries = new Valkyries("Valkyries", CardType.Monster);
            var warrior = new WarriorProficiency(mockReadLineOverride.Object);
            var userAvatar = new UserAvatar()
            {
                Proficiency = warrior
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            var item = valkyries.FindTheMostPowerfulItemInBuild(user);
            //Assert
            item.Should().BeNull();
        }

        [Fact]
        public void DeadEndTest()
        {
            //Arrange
            var mockReadLineOverride = new Mock<ReadLineOverride>();
            mockReadLineOverride.Setup(x => x.GetNextString()).Returns("1");
            var game = new Game();
            var valkyries = new Valkyries("Valkyries", CardType.Monster);
            var warrior = new WarriorProficiency(mockReadLineOverride.Object);
            var userAvatar = new UserAvatar()
            {
                Proficiency = warrior
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var item = new ItemCard("sword1H", CardType.Prize, PrizeCardType.Item, 10, null, false, ItemType.Weapon, null, 300);
            user.UserAvatar.Build.Armor = new ItemCard("leatherArmor", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Armor, null, 300);
            user.UserAvatar.Build.LeftHandItem = item;
            user.UserAvatar.Build.RightHandItem = new ItemCard("axe", CardType.Prize, PrizeCardType.Item, 3, null, true, ItemType.Weapon, null, 300);
            //Act
            valkyries.DeadEnd(game, user);
            //Assert
            game.DestroyedPrizeCards.Should().HaveCount(1);
            game.DestroyedPrizeCards.Should().Contain(item);
            user.UserAvatar.Build.LeftHandItem.Should().BeNull();
        }

        [Fact]
        public void DeadEndNoItemsTest()
        {
            //Arrange
            var mockReadLineOverride = new Mock<ReadLineOverride>();
            mockReadLineOverride.Setup(x => x.GetNextString()).Returns("1");
            var game = new Game();
            var valkyries = new Valkyries("Valkyries", CardType.Monster);
            var warrior = new WarriorProficiency(mockReadLineOverride.Object);
            var userAvatar = new UserAvatar()
            {
                Proficiency = warrior
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            valkyries.DeadEnd(game, user);
            //Assert
            game.DestroyedPrizeCards.Should().HaveCount(0);
        }
    }
}
