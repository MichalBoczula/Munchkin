using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret;
using Munchkin.Model;
using Munchkin.Model.Character;
using Munchkin.Model.User;
using Munchkin.Model.Card.PrizeCard;

namespace Munchkin.Tests.Munchkin.Model.Tests.Card.SpecialCardType.Monsters
{
    public class GryphonTests
    {
        [Fact]
        public void SpecialPowerLevelBelowOneTest()
        {
            //Arrange
            var game = new Game();
            var gryphon = new Gryphon("Gryphon", CardType.Action);
            var userAvatar = new UserAvatar()
            {
                Build = new Build()
            };
            var user = new UserClass
            {
                UserAvatar = userAvatar
            };
            //Act
            gryphon.SpecialPower(game, user);
            //Assert
            gryphon.Power.Should().Be(4);
            gryphon.HowManyLevels.Should().Be(2);
            gryphon.NumberOfPrizes.Should().Be(2);
        }

        [Fact]
        public void SpecialPowerLevelAboceOneTest()
        {
            //Arrange
            var game = new Game();
            var gryphon = new Gryphon("Gryphon", CardType.Action);
            var userAvatar = new UserAvatar()
            {
                Build = new Build()
            };
            var user = new UserClass
            {
                UserAvatar = userAvatar
            };
            user.UserAvatar.Level = 2;
            //Act
            gryphon.SpecialPower(game, user);
            //Assert
            gryphon.Power.Should().Be(5);
            gryphon.HowManyLevels.Should().Be(1);
            gryphon.NumberOfPrizes.Should().Be(2);
        }


        [Fact]
        public void DeadEndWeaponTest()
        {
            //Arrange
            var game = new Game();
            var gryphon = new Gryphon("Gryphon", CardType.Action);
            var userAvatar = new UserAvatar()
            {
                Build = new Build()
            };
            var user = new UserClass
            {
                UserAvatar = userAvatar
            };
            var lHand= new ItemCard("sword1H", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            user.UserAvatar.Build.LeftHandItem = lHand;
            //Act
            gryphon.DeadEnd(game, user);
            //Assert
            user.UserAvatar.Build.LeftHandItem.Should().BeNull();
            game.DestroyedPrizeCards.Should().HaveCount(1);
            game.DestroyedPrizeCards.Should().Contain(lHand);
        }

        [Fact]
        public void DeadEndNoWeaponTest()
        {
            //Arrange
            var game = new Game();
            var gryphon = new Gryphon("Gryphon", CardType.Action);
            var userAvatar = new UserAvatar()
            {
                Build = new Build()
            };
            var user = new UserClass
            {
                UserAvatar = userAvatar
            };
            //Act
            gryphon.DeadEnd(game, user);
            //Assert
            user.UserAvatar.Build.LeftHandItem.Should().BeNull();
            game.DestroyedPrizeCards.Should().HaveCount(0);
        }
    }
}
