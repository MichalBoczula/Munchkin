using FluentAssertions;
using Munchkin.Model;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret;
using Munchkin.Model.Character;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Munchkin.Tests.Munchkin.Model.Tests.Card.SpecialCardType.Monsters
{
    public class BloodyMaryTests
    {
        [Fact]
        public void SpecialPowerTest()
        {
            //Arrange
            var game = new Game();
            var bloodyMary = new BloodyMary("Bloody Mary", CardType.Monster);
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            bloodyMary.SpecialPower(game, user);
            //Assert
            bloodyMary.Power.Should().Be(8);
            bloodyMary.NumberOfPrizes.Should().Be(2);
            bloodyMary.HowManyLevels.Should().Be(1);
            user.UserAvatar.Nerfs.Power.Should().Contain(2);
            user.UserAvatar.Nerfs.Power.Should().HaveCount(1);
            user.UserAvatar.Nerfs.FleeChances.Should().Contain(1);
            user.UserAvatar.Nerfs.FleeChances.Should().HaveCount(1);
            user.UserAvatar.Level.Should().Be(0);
        }

        [Fact]
        public void DeadEndTest()
        {
            //Arrange
            var game = new Game();
            var bloodyMary = new BloodyMary("Bloody Mary", CardType.Monster);
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            bloodyMary.DeadEnd(game, user);
            //Assert
            user.UserAvatar.Nerfs.DamagedHead.Should().BeTrue();
        }
    }
}
