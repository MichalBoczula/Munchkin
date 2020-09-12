using FluentAssertions;
using Munchkin.Model;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret;
using Munchkin.Model.Character;
using Munchkin.Model.Character.Hero.Race;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Munchkin.Tests.Munchkin.Model.Tests.Card.SpecialCardType.Monsters
{
    public class KrakenTests
    {
        [Fact]
        public void SpecialPowerDiffrentClassTest()
        {
            //Arrange
            var game = new Game();
            var kraken = new Kraken("Kraken", CardType.Monster);
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            kraken.SpecialPower(game, user);
            //Assert
            kraken.Power.Should().Be(21);
            kraken.NumberOfPrizes.Should().Be(4);
            kraken.HowManyLevels.Should().Be(2);
        }


        [Fact]
        public void SpecialPowerHalfingTest()
        {
            //Arrange
            var game = new Game();
            var kraken = new Kraken("Kraken", CardType.Monster);
            var userAvatar = new UserAvatar()
            {
                Race = new Halfling("Halfing")
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            kraken.SpecialPower(game, user);
            //Assert
            kraken.Power.Should().Be(13);
            kraken.NumberOfPrizes.Should().Be(4);
            kraken.HowManyLevels.Should().Be(2);
        }

        [Fact]
        public void DeadEndTest()
        {
            //Arrange
            var game = new Game();
            var kraken = new Kraken("Kraken", CardType.Monster);
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            kraken.DeadEnd(game, user);
            //Assert
            user.UserAvatar.Nerfs.BrokenRibs.Should().BeTrue();
        }
    }
}
