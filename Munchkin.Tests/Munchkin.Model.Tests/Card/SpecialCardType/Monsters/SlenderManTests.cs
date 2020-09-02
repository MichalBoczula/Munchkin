using FluentAssertions;
using Munchkin.Model;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret;
using Munchkin.Model.Card.PrizeCard;
using Munchkin.Model.Character;
using Munchkin.Model.Character.Hero.Proficiency;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Munchkin.Tests.Munchkin.Model.Tests.Card.SpecialCardType.Monsters
{
    public class SlenderManTests
    {
        [Fact]
        public void SpecialPowerTest()
        {
            //Arrange
            var game = new Game();
            var slenderMan = new SlenderMan("Slender Man", CardType.Action);
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            slenderMan.SpecialPower(game, user);
            //Assert
            slenderMan.Power.Should().Be(12);
            slenderMan.NumberOfPrizes.Should().Be(3);
            slenderMan.HowManyLevels.Should().Be(1);
            user.UserAvatar.Proficiency.Should().BeOfType<NoOneProficiency>();
        }

        [Fact]
        public void DeadEndTest()
        {
            //Arrange
            var game = new Game();
            var slenderMan = new SlenderMan("Slender Man", CardType.Action);
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            slenderMan.DeadEnd(game, user);
            //Assert
            user.UserAvatar.Nerfs.Wounded.Should().HaveCount(1);
            user.UserAvatar.Nerfs.Wounded.Should().Contain(true);
        }
    }
}
