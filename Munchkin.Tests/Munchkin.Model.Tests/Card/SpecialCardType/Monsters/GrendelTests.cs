using FluentAssertions;
using Munchkin.Model.Character;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret
{
    public class GrendelTests
    {
        [Fact]
        public void SpecialPowerTest()
        {
            //Arrange
            var game = new Game();
            var grendel = new Grendel("Grendel", CardType.Action);
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            grendel.SpecialPower(game, user);
            //Assert
            grendel.Power.Should().Be(19);
            grendel.NumberOfPrizes.Should().Be(4);
            grendel.HowManyLevels.Should().Be(1);
        }

        [Fact]
        public void DeadEndTest()
        {
            //Arrange
            var game = new Game();
            var grendel = new Grendel("Grendel", CardType.Action);
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            grendel.DeadEnd(game, user);
            //Assert
            user.UserAvatar.Nerfs.BrokenRibs.Should().BeTrue();
        }
    }
}
