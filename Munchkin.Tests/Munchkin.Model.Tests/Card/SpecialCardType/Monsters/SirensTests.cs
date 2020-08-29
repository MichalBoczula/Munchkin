using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Munchkin.Model;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret;
using Munchkin.Model.Card.PrizeCard;
using Munchkin.Model.Character;
using Munchkin.Model.Character.Hero.Proficiency;
using Munchkin.Model.User;
using Xunit;

namespace Munchkin.Tests.Munchkin.Model.Tests.Card.SpecialCardType.Monsters
{
    public class SirensTests
    {
        [Fact]
        public void SpecialPowerWarriorProficiencyTests()
        {
            //Arrange
            var game = new Game();
            var sirens = new Sirens("Sirens", CardType.Action);
            var warrior = new WarriorProficiency();
            var userAvatar = new UserAvatar()
            {
                Build = new Build(),
                Proficiency = warrior
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            sirens.SpecialPower(game, user);
            //Assert
            sirens.Power.Should().Be(6);
        }

        [Fact]
        public void SpecialPowerDiffrentProficiencyTests()
        {
            //Arrange
            var game = new Game();
            var sirens = new Sirens("Sirens", CardType.Action);
            var mage = new MageProficiency();
            var userAvatar = new UserAvatar()
            {
                Build = new Build(),
                Proficiency = mage
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            sirens.SpecialPower(game, user);
            //Assert
            sirens.Power.Should().Be(1);
        }

        [Fact]
        public void DeadEndTests()
        {
            //Arrange
            var game = new Game();
            var sirens = new Sirens("Sirens", CardType.Action);
            var userAvatar = new UserAvatar()
            {
                Build = new Build()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var helmet = new ItemCard("leatherArmor", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Armor, null);
            user.UserAvatar.Build.Helmet = helmet; 
            //Act
            sirens.DeadEnd(game, user);
            user.UserAvatar.EndTurn();
            //Assert
            user.UserAvatar.Build.Helmet.Should().BeNull();
            user.UserAvatar.Power.Should().Be(1);
            game.DestroyedPrizeCards.Should().Contain(helmet);
            game.DestroyedPrizeCards.Should().HaveCount(1);
        }

        [Fact]
        public void DeadEndNoHelmetTests()
        {
            //Arrange
            var game = new Game();
            var sirens = new Sirens("Sirens", CardType.Action);
            var userAvatar = new UserAvatar()
            {
                Build = new Build()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var boots = new ItemCard("normalBoot", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Boots, null);
            user.UserAvatar.Build.Boots = boots;
            //Act
            sirens.DeadEnd(game, user);
            user.UserAvatar.EndTurn();
            //Assert
            user.UserAvatar.Build.Helmet.Should().BeNull();
            user.UserAvatar.Power.Should().Be(4);
            game.DestroyedPrizeCards.Should().HaveCount(0);
        }
    }
}
