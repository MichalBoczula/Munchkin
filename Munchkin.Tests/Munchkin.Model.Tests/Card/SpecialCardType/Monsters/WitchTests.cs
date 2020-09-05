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
    public class WitchTests
    {
        [Fact]
        public void SpecialPowerTest()
        {
            //Arrange
            var game = new Game();
            var witch = new Witch("Witch", CardType.Action);
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            witch.SpecialPower(game, user);
            //Assert
            witch.Power.Should().Be(12);
            witch.NumberOfPrizes.Should().Be(3);
            witch.HowManyLevels.Should().Be(1);
            user.UserAvatar.Level.Should().Be(0);
        }

        [Fact]
        public void DeadEndTest()
        {
            //Arrange
            var game = new Game();
            var witch = new Witch("Witch", CardType.Action);
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            witch.DeadEnd(game, user);
            //Assert
            user.UserAvatar.Nerfs.Poisoned.Should().HaveCount(1);
            user.UserAvatar.Nerfs.Poisoned.Should().Contain(true);
        }
    }
}
