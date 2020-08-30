using FluentAssertions;
using Munchkin.Model;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret;
using Munchkin.Model.Card.PrizeCard;
using Munchkin.Model.Character;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Munchkin.Tests.Munchkin.Model.Tests.Card.SpecialCardType.Monsters
{
    public class BoogieManDanceFloorKingTests
    {
        [Fact]
        public void SpecialPowerTest()
        {
            //Arrange
            var game = new Game();
            var boogieManDanceFloorKing = new BoogieManDanceFloorKing("Boogie Man Dance Floor King", CardType.Action);
            var userAvatar = new UserAvatar()
            {
                Build = new Build()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var boots = new ItemCard("normalBoot", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Boots, null, 300); ;
            user.UserAvatar.Build.Boots = boots;
            //Act
            boogieManDanceFloorKing.SpecialPower(game, user);
            //Assert
            boogieManDanceFloorKing.Power.Should().Be(13);
            boogieManDanceFloorKing.NumberOfPrizes.Should().Be(3);
            boogieManDanceFloorKing.HowManyLevels.Should().Be(1);
        }

        [Fact]
        public void SpecialPowerNoBootsTest()
        {
            //Arrange
            var game = new Game();
            var boogieManDanceFloorKing = new BoogieManDanceFloorKing("Boogie Man Dance Floor King", CardType.Action);
            var userAvatar = new UserAvatar()
            {
                Build = new Build()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            boogieManDanceFloorKing.SpecialPower(game, user);
            //Assert
            boogieManDanceFloorKing.Power.Should().Be(10);
            boogieManDanceFloorKing.NumberOfPrizes.Should().Be(3);
            boogieManDanceFloorKing.HowManyLevels.Should().Be(1);
        }

        [Fact]
        public void DeadEndTest()
        {
            //Arrange
            var game = new Game();
            var boogieManDanceFloorKing = new BoogieManDanceFloorKing("Boogie Man Dance Floor King", CardType.Action);
            var userAvatar = new UserAvatar()
            {
                Build = new Build()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var boots = new ItemCard("normalBoot", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Boots, null, 300); ;
            user.UserAvatar.Build.Boots = boots;
            //Act
            boogieManDanceFloorKing.DeadEnd(game, user);
            //Assert
            game.DestroyedPrizeCards.Should().HaveCount(1);
            game.DestroyedPrizeCards.Should().Contain(boots);
            user.UserAvatar.Nerfs.BrokenLegs.Should().BeTrue();
            user.UserAvatar.Build.Boots.Should().BeNull();
        }

        [Fact]
        public void DeadEndNoBootsTest()
        {
            //Arrange
            var game = new Game();
            var boogieManDanceFloorKing = new BoogieManDanceFloorKing("Boogie Man Dance Floor King", CardType.Action);
            var userAvatar = new UserAvatar()
            {
                Build = new Build()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            boogieManDanceFloorKing.DeadEnd(game, user);
            //Assert
            game.DestroyedPrizeCards.Should().HaveCount(0);
            user.UserAvatar.Nerfs.BrokenLegs.Should().BeTrue();
        }
    }
}
