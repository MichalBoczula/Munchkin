using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Munchkin.Model;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret;
using Munchkin.Model.Character;
using Munchkin.Model.Character.Hero.Proficiency;
using Munchkin.Model.User;
using Xunit;

namespace Munchkin.Tests.Munchkin.Model.Tests.Card.SpecialCardType.Monsters
{
    public class CreepsTests
    {
        [Fact]
        public void DeadEndTests()
        {
            //Arrange
            var game = new Game();
            var creeps = new Creeps("Creeps", CardType.Monster);
            var mage = new MageProficiency();
            var userAvatar = new UserAvatar()
            {
                Proficiency = mage
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            user.UserAvatar.CountPower();
            //Act
            creeps.DeadEnd(game, user);
            user.UserAvatar.EndTurn();
            //Assert
            user.UserAvatar.Power.Should().Be(-1);
            user.UserAvatar.Level.Should().Be(-1);
            creeps.NumberOfPrizes.Should().Be(1);
        }

        [Fact]
        public void SpecialPowerMageProficiencyTests()
        {
            //Arrange
            var game = new Game();
            var creeps = new Creeps("Creeps", CardType.Monster);
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
            creeps.SpecialPower(game, user);
            //Assert
            creeps.Power.Should().Be(4);
            creeps.NumberOfPrizes.Should().Be(1);
        }

        [Fact]
        public void SpecialPowerDiffrentProficiencyTests()
        {
            //Arrange
            var game = new Game();
            var creeps = new Creeps("Creeps", CardType.Monster);
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
            creeps.SpecialPower(game, user);
            //Assert
            creeps.Power.Should().Be(1);
            creeps.NumberOfPrizes.Should().Be(1);
        }
    }
}
