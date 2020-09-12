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
using Munchkin.Model.Character.Hero.Race;

namespace Munchkin.Tests.Munchkin.Model.Tests.Card.SpecialCardType.Monsters
{
    public class TomTumbTests
    {
        [Fact]
        public void DeadEndTest()
        {
            //Arrange
            var game = new Game();
            var tombTumb = new TomTumb("Tom Tumb", CardType.Monster);
            var race = new Elf("elf");
            var userAvatar = new UserAvatar()
            {
                Build = new Build(),
                Race = race
                
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var lhand = new ItemCard("sword1H", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var rhand = new ItemCard("axe", CardType.Prize, PrizeCardType.Item, 3, null, true, ItemType.Weapon, null, 300);
            user.UserAvatar.Build.LeftHandItem = lhand;
            user.UserAvatar.Build.RightHandItem = rhand;
            //Act
            tombTumb.SpecialPower(game, user);
            tombTumb.DeadEnd(game, user);
            //Assert
            tombTumb.NumberOfPrizes.Should().Be(1);
            tombTumb.Power.Should().Be(2);
            user.UserAvatar.Build.LeftHandItem.Should().BeNull();
            user.UserAvatar.Build.RightHandItem.Should().BeNull();
            game.DestroyedPrizeCards.Should().HaveCount(2);
            game.DestroyedPrizeCards.Should().Contain(lhand);
            game.DestroyedPrizeCards.Should().Contain(rhand);
        }

        [Fact]
        public void DeadEndNoWeaponsTest()
        {
            //Arrange
            var game = new Game();
            var tombTumb = new TomTumb("Tom Tumb", CardType.Monster);
            var userAvatar = new UserAvatar()
            {
                Build = new Build()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            tombTumb.SpecialPower(game, user);
            tombTumb.DeadEnd(game, user);
            //Assert
            tombTumb.Power.Should().Be(2);
            user.UserAvatar.Build.LeftHandItem.Should().BeNull();
            user.UserAvatar.Build.RightHandItem.Should().BeNull();
            game.DestroyedPrizeCards.Should().HaveCount(0);
        }

        [Fact]
        public void DeadEndFightWithHalfingTest()
        {
            //Arrange
            var game = new Game();
            var tombTumb = new TomTumb("Tom Tumb", CardType.Monster);
            var race = new Halfling("elf");
            var userAvatar = new UserAvatar()
            {
                Build = new Build(),
                Race = race
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            tombTumb.SpecialPower(game, user);
            tombTumb.DeadEnd(game, user);
            //Assert
            tombTumb.Power.Should().Be(5);
        }
    }
}
