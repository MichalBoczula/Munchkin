using FluentAssertions;
using Munchkin.Model;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret;
using Munchkin.Model.Character;
using Munchkin.Model.Character.Hero.Proficiency;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Munchkin.Tests.Munchkin.Model.Tests.Card.SpecialCardType.Monsters
{
    public class ShamanTests
    {
        [Fact]
        public void SpecialPowerMageTest()
        {
            //Arrange
            var game = new Game();
            var shaman = new Shaman("Shaman", CardType.Action);
            var mage = new MageProficiency();
            var userAvatar = new UserAvatar()
            {
                Proficiency = mage
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            shaman.SpecialPower(game, user);
            //Assert
            shaman.Power.Should().Be(15);
            shaman.NumberOfPrizes.Should().Be(3);
            shaman.HowManyLevels.Should().Be(1);
        }

        [Fact]
        public void SpecialPowerPriestTest()
        {
            //Arrange
            var game = new Game();
            var shaman = new Shaman("Shaman", CardType.Action);
            var priest = new PriestProficiency();
            var userAvatar = new UserAvatar()
            {
                Proficiency = priest
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            shaman.SpecialPower(game, user);
            //Assert
            shaman.Power.Should().Be(15);
            shaman.NumberOfPrizes.Should().Be(3);
            shaman.HowManyLevels.Should().Be(1);
        }

        [Fact]
        public void SpecialPowerDiffrenProficiencyTest()
        {
            //Arrange
            var game = new Game();
            var shaman = new Shaman("Shaman", CardType.Action);
            var warrior = new WarriorProficiency();
            var userAvatar = new UserAvatar()
            {
                Proficiency = warrior
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            shaman.SpecialPower(game, user);
            //Assert
            shaman.Power.Should().Be(10);
            shaman.NumberOfPrizes.Should().Be(3);
            shaman.HowManyLevels.Should().Be(1);
        }

        [Fact]
        public void DeadEndTest()
        {
            //Arrange
            var game = new Game();
            var shaman = new Shaman("Shaman", CardType.Action);
            var warrior = new WarriorProficiency();
            var userAvatar = new UserAvatar()
            {
                Proficiency = warrior
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            shaman.DeadEnd(game, user);
            user.UserAvatar.EndTurn();
            //Assert
            user.UserAvatar.Nerfs.Poisoned.Should().HaveCount(1);
            user.UserAvatar.Nerfs.Poisoned.Should().Contain(true);
            user.UserAvatar.Level.Should().Be(0);
            user.UserAvatar.Power.Should().Be(-1);
        }
    }
}
