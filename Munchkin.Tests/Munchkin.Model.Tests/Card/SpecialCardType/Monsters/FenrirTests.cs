using FluentAssertions;
using Moq;
using Munchkin.BL.Helper;
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
    public class FenrirTests
    {
        [Fact]
        public void SpecialPowerPriestProficiencyTest()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var game = new Game();
            var fenrir = new Fenrir("Fenrir", CardType.Monster);
            var userAvatar = new UserAvatar()
            {
                Proficiency = new PriestProficiency(mock.Object)
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            fenrir.SpecialPower(game, user);
            //Assert
            fenrir.Power.Should().Be(13);
            fenrir.NumberOfPrizes.Should().Be(4);
            fenrir.HowManyLevels.Should().Be(2);
        }

        [Fact]
        public void SpecialPowerDiffrentProficiencyTest()
        {
            //Arrange
            var game = new Game();
            var fenrir = new Fenrir("Fenrir", CardType.Monster);
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            fenrir.SpecialPower(game, user);
            //Assert
            fenrir.Power.Should().Be(21);
            fenrir.NumberOfPrizes.Should().Be(4);
            fenrir.HowManyLevels.Should().Be(2);
        }

        [Fact]
        public void DeadEndTest()
        {
            //Arrange
            var game = new Game();
            var fenrir = new Fenrir("Fenrir", CardType.Monster);
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            fenrir.DeadEnd(game, user);
            //Assert
            user.UserAvatar.Nerfs.TornOffArms.Should().HaveCount(1);
            user.UserAvatar.Nerfs.TornOffArms.Should().Contain(true);
        }
    }
}
