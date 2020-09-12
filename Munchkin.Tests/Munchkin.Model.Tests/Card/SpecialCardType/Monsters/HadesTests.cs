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
    public class HadesTests
    {
        [Fact]
        public void SpecialPowerDiffrentClassTest()
        {
            //Arrange
            var game = new Game();
            var hades = new Hades("Hades", CardType.Monster);
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            hades.SpecialPower(game, user);
            //Assert
            hades.Power.Should().Be(18);
            hades.NumberOfPrizes.Should().Be(5);
            hades.HowManyLevels.Should().Be(2);
            user.UserAvatar.Nerfs.Wounded.Should().HaveCount(1);
            user.UserAvatar.Nerfs.Wounded.Should().Contain(true);
        }


        [Fact]
        public void SpecialPowerHalfingTest()
        {
            //Arrange
            var game = new Game();
            var hades = new Hades("Hades", CardType.Monster);
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            hades.DeadEnd(game, user);
            //Assert
            user.UserAvatar.IsDied.Should().BeTrue();
        }
    }
}
