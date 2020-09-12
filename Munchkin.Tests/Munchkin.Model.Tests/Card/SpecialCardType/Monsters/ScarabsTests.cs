using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Munchkin.Model;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret;
using Munchkin.Model.Card.PrizeCard;
using Munchkin.Model.Character;
using Munchkin.Model.User;
using Xunit;

namespace Munchkin.Tests.Munchkin.Model.Tests.Card.SpecialCardType.Monsters
{
    public class ScarabsTests
    {
        [Fact]
        public void DeadEnd()
        {
            //Arrange
            var game = new Game();
            var scarabs = new Scarabs("Scarabs", CardType.Monster);
            var userAvatar = new UserAvatar()
            {
                Build = new Build()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            user.UserAvatar.Level = 1;
            user.UserAvatar.CountPower();
            //Act
            scarabs.DeadEnd(game, user);
            user.UserAvatar.EndTurn();
            //Assert
            user.UserAvatar.Power.Should().Be(-1);
            user.UserAvatar.FleeChances.Should().Be(2);
            scarabs.Power.Should().Be(1);
            scarabs.NumberOfPrizes.Should().Be(1);
        }

        [Fact]
        public void SpecialPower()
        {
            //Arrange
            var game = new Game();
            var scarabs = new Scarabs("Scarabs", CardType.Monster);
            var userAvatar = new UserAvatar()
            {
                Build = new Build()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var boots = new ItemCard("normalBoot", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Boots, null, 300);
            user.UserAvatar.Build.Boots = boots;
            //Act
            scarabs.SpecialPower(game, user);
            //Assert
            scarabs.Power.Should().Be(4);
            scarabs.NumberOfPrizes.Should().Be(1);
        }

        [Fact]
        public void SpecialNoBootsPower()
        {
            //Arrange
            var game = new Game();
            var scarabs = new Scarabs("Scarabs", CardType.Monster);
            var userAvatar = new UserAvatar()
            {
                Build = new Build()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            scarabs.DeadEnd(game, user);
            //Assert
            scarabs.Power.Should().Be(1);
            scarabs.NumberOfPrizes.Should().Be(1);
        }
    }

}
