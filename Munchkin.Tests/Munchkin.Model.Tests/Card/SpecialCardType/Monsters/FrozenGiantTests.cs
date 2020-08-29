using FluentAssertions;
using Munchkin.Model;
using Munchkin.Model.Character;
using Munchkin.Model.Character.Hero.Race;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Munchkin.Tests.Munchkin.Model.Tests.Card.SpecialCardType.Monsters
{
    public class FrozenGiantTests
    {
        [Fact]
        public void DeadEnd()
        {
            //Arrange
            var game = new Game();
            var frozenGiant = new FrozenGiant("Frozen Giant", CardType.Prize);
            var userAvatar = new UserAvatar()
            {
                Build = new Build()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            frozenGiant.DeadEnd(game, user);
            //Assert
            frozenGiant.Power.Should().Be(4);
            frozenGiant.NumberOfPrizes.Should().Be(2);
            frozenGiant.HowManyLevels.Should().Be(1);
            user.UserAvatar.Nerfs.BrokenLegs.Should().BeTrue();

        }

        [Fact]
        public void SpecialPowerHalfingTest()
        {
            var game = new Game();
            var frozenGiant = new FrozenGiant("Frozen Giant", CardType.Prize);
            var halfing = new Halfling("Halfling");
            var userAvatar = new UserAvatar()
            {
                Race = halfing,
                Build = new Build()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            frozenGiant.SpecialPower(game, user);
            //Assert
            frozenGiant.Power.Should().Be(8);
            frozenGiant.NumberOfPrizes.Should().Be(2);
            frozenGiant.HowManyLevels.Should().Be(2);
        }

        [Fact]
        public void SpecialPowerDiffrentRaceTest()
        {
            var game = new Game();
            var frozenGiant = new FrozenGiant("Frozen Giant", CardType.Prize);
            var userAvatar = new UserAvatar()
            {
                Build = new Build()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            frozenGiant.SpecialPower(game, user);
            //Assert
            frozenGiant.Power.Should().Be(4);
            frozenGiant.NumberOfPrizes.Should().Be(2);
            frozenGiant.HowManyLevels.Should().Be(1);
        }
    }
}
