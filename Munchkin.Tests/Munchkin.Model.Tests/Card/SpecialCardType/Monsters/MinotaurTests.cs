using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret;
using Munchkin.Model;
using Munchkin.Model.Character;
using Munchkin.Model.Card.PrizeCard;
using Munchkin.Model.User;

namespace Munchkin.Tests.Munchkin.Model.Tests.Card.SpecialCardType.Monsters
{
    public class MinotaurTests
    {
        [Fact]
        public void SpecialPowerWithHelmetTest()
        {
            //Arrange
            var game = new Game();
            var minotaur = new Minotaur("Minotaur", CardType.Action);
            var userAvatar = new UserAvatar()
            {
                Build = new Build()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var helmet = new ItemCard("leatherHelmet", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Helmet, null, 300);
            user.UserAvatar.Build.Helmet = helmet;
            //Act
            minotaur.SpecialPower(game, user);
            //Assert
            minotaur.Power.Should().Be(6);
            minotaur.NumberOfPrizes.Should().Be(2);
            minotaur.HowManyLevels.Should().Be(1);
        }

        [Fact]
        public void SpecialPowerNoHelmetTest()
        {
            //Arrange
            var game = new Game();
            var minotaur = new Minotaur("Minotaur", CardType.Action);
            var userAvatar = new UserAvatar()
            {
                Build = new Build()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            minotaur.SpecialPower(game, user);
            //Assert
            minotaur.Power.Should().Be(4);
        }

        [Fact]
        public void DeadEndWithHelmetTest()
        {
            //Arrange
            var game = new Game();
            var minotaur = new Minotaur("Minotaur", CardType.Action);
            var userAvatar = new UserAvatar()
            {
                Build = new Build()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var helmet = new ItemCard("leatherHelmet", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Helmet, null, 300);
            user.UserAvatar.Build.Helmet = helmet;
            //Act
            minotaur.DeadEnd(game, user);
            //Assert
            game.DestroyedPrizeCards.Should().HaveCount(1);
            game.DestroyedPrizeCards.Should().Contain(helmet);
            user.UserAvatar.Build.Helmet.Should().BeNull();
            user.UserAvatar.Nerfs.DamagedHead.Should().BeTrue();
        }

        [Fact]
        public void DeadEndNoHelmetTest()
        {
            //Arrange
            var game = new Game();
            var minotaur = new Minotaur("Minotaur", CardType.Action);
            var userAvatar = new UserAvatar()
            {
                Build = new Build()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            minotaur.DeadEnd(game, user);
            //Assert
            game.DestroyedPrizeCards.Should().HaveCount(0);
            user.UserAvatar.Nerfs.DamagedHead.Should().BeTrue();
        }
    }
}
