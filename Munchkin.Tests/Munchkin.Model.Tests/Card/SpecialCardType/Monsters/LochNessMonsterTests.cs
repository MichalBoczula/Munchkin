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
    public class LochNessMonsterTests
    {
        [Fact]
        public void SpecialPowerTest()
        {
            //Arrange
            var game = new Game();
            var lochNessMonster = new LochNessMonster("Loch Ness Monster", CardType.Monster);
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            lochNessMonster.SpecialPower(game, user);
            //Assert
            lochNessMonster.Power.Should().Be(14);
            lochNessMonster.NumberOfPrizes.Should().Be(4);
            lochNessMonster.HowManyLevels.Should().Be(1);
            user.UserAvatar.Level.Should().Be(-1);
        }

        [Fact]
        public void DeadEndTest()
        {
            //Arrange
            var game = new Game();
            var lochNessMonster = new LochNessMonster("Loch Ness Monster", CardType.Monster);
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            lochNessMonster.DeadEnd(game, user);
            //Assert
            user.UserAvatar.Nerfs.Poisoned.Should().HaveCount(1);
            user.UserAvatar.Nerfs.Poisoned.Should().Contain(true);
        }
    }
}
