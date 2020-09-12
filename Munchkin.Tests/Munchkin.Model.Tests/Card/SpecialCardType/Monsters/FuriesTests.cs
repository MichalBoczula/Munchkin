using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret;
using Munchkin.Model;
using Munchkin.Model.User;
using Munchkin.Model.Character;
using Munchkin.Model.Character.Hero.Proficiency;
using Munchkin.BL.Helper;
using Moq;

namespace Munchkin.Tests.Munchkin.Model.Tests.Card.SpecialCardType.Monsters
{
    public class FuriesTests
    {
        [Fact]
        public void SpecialPowerThiefTest()
        {
            //Arrange
            var mockReadLine = new Mock<ReadLineOverride>();
            mockReadLine.Setup(x => x.GetNextString()).Returns("");
            var thief = new ThiefProficiency(mockReadLine.Object);
            var game = new Game();
            var furies = new Furies("Furies", CardType.Monster);
            var userAvatar = new UserAvatar()
            {
                Proficiency = thief
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            furies.SpecialPower(game, user);
            //Assert
            furies.Power.Should().Be(10);
            furies.NumberOfPrizes.Should().Be(2);
            furies.HowManyLevels.Should().Be(1);
        }

        [Fact]
        public void SpecialPowerDiffrentProficiencyTest()
        {
            //Arrange
            var game = new Game();
            var furies = new Furies("Furies", CardType.Monster);
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
            furies.SpecialPower(game, user);
            //Assert
            furies.Power.Should().Be(6);
            furies.NumberOfPrizes.Should().Be(2);
            furies.HowManyLevels.Should().Be(1);
        }

        [Fact]
        public void DeadEndTest()
        {
            //Arrange
            var game = new Game();
            var furies = new Furies("Furies", CardType.Monster);
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            furies.DeadEnd(game, user);
            user.UserAvatar.EndTurn();
            //Assert
            user.UserAvatar.Nerfs.Power.Should().Contain(2);
            user.UserAvatar.Nerfs.FleeChances.Should().Contain(1);
            user.UserAvatar.FleeChances.Should().Be(2);
            user.UserAvatar.Level.Should().Be(0);
            user.UserAvatar.Power.Should().Be(-2);

        }

    }
}
