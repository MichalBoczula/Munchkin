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
    public class CerberTests
    {
        [Fact]
        public void SpecialPowerPriestTest()
        {
            //Arrange
            var game = new Game();
            var cerber = new Cerber("Cerber", CardType.Monster);
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
            cerber.SpecialPower(game, user);
            //Assert
            cerber.Power.Should().Be(9);
            cerber.NumberOfPrizes.Should().Be(2);
            cerber.HowManyLevels.Should().Be(1);
        }

        [Fact]
        public void SpecialPowerDiffrentProficiencyest()
        {
            //Arrange
            var game = new Game();
            var cerber = new Cerber("Cerber", CardType.Monster);
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
            cerber.SpecialPower(game, user);
            //Assert
            cerber.Power.Should().Be(6);
            cerber.NumberOfPrizes.Should().Be(2);
            cerber.HowManyLevels.Should().Be(1);
        }

        [Fact]
        public void DeadEndSuccesTest()
        {
            //Arrange
            var game = new Game();
            var cerber = new Cerber("Cerber", CardType.Monster);
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
            cerber.DeadEnd(game, user);
            //Assert
            user.UserAvatar.Nerfs.TornOffArms.Should().Contain(true);
        }
    }
}
