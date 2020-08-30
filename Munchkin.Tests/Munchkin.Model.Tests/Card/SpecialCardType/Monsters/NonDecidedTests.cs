using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Moq;
using Munchkin.Model;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret;
using Munchkin.Model.Character;
using Munchkin.Model.User;
using Munchkin.Tests.Munchkin.Model.Tests.Helper;
using Xunit;

namespace Munchkin.Tests.Munchkin.Model.Tests.Card.SpecialCardType.Monsters
{
    public class NonDecidedTests
    {
        [Fact]
        public void SpecialPowerFightTests()
        {
            //Arrange
            var game = new Game();
            var mockTestReadLine = new Mock<TestReadLine>();
            mockTestReadLine.Setup(x => x.GetNextString()).Returns("1");
            var nonDecided = new NonDecided("non Decided", CardType.Action, mockTestReadLine.Object);
            var userAvatar = new UserAvatar()
            {
                Build = new Build()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            nonDecided.SpecialPower(game, user);
            //Arrange
            nonDecided.HowManyLevels.Should().Be(1);
        }

        [Fact]
        public void SpecialPowerNoFightTests()
        {
            //Arrange
            var game = new Game();
            var mockTestReadLine = new Mock<TestReadLine>();
            mockTestReadLine.Setup(x => x.GetNextString()).Returns("2");
            var nonDecided = new NonDecided("non Decided", CardType.Action, mockTestReadLine.Object);
            var userAvatar = new UserAvatar()
            {
                Build = new Build()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            nonDecided.SpecialPower(game, user);
            //Arrange
            nonDecided.HowManyLevels.Should().Be(0);
        }

        [Fact]
        public void DeadEndTests()
        {
            //Arrange
            var game = new Game();
            var mockTestReadLine = new Mock<TestReadLine>();
            var nonDecided = new NonDecided("non Decided", CardType.Action, mockTestReadLine.Object);
            var userAvatar = new UserAvatar()
            {
                Build = new Build()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            nonDecided.DeadEnd(game, user);
            user.UserAvatar.EndTurn();
            //Arrange
            user.UserAvatar.Level.Should().Be(0);
            user.UserAvatar.Power.Should().Be(-1);
            user.UserAvatar.FleeChances.Should().Be(2);
        }
    }
}
