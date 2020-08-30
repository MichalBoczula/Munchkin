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
    public class AntArmyTests
    {
        [Fact]
        public void SpecialPowerTest()
        {
            //Arrange
            var game = new Game();
            var antArmy = new AntArmy("Ant Army", CardType.Action);
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            antArmy.SpecialPower(game, user);
            //Assert
            antArmy.Power.Should().Be(8);
            antArmy.NumberOfPrizes.Should().Be(2);
            antArmy.HowManyLevels.Should().Be(1);
            user.UserAvatar.FleeChances.Should().Be(-999);
        }

        [Fact]
        public void DeadEndTest()
        {
            //Arrange
            var game = new Game();
            var antArmy = new AntArmy("Ant Army", CardType.Action);
            var userAvatar = new UserAvatar()
            {
                Build =  new Build()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var boots = new ItemCard("normalBoot", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Boots, null, 300); ;
            user.UserAvatar.Build.Boots = boots;
            //Act
            antArmy.DeadEnd(game, user);
            user.UserAvatar.EndTurn();
            //Assert
            user.UserAvatar.Nerfs.FleeChances.Should().Contain(1);
            user.UserAvatar.Nerfs.FleeChances.Should().HaveCount(1);
            user.UserAvatar.FleeChances.Should().Be(2);
            game.DestroyedPrizeCards.Should().HaveCount(1);
            game.DestroyedPrizeCards.Should().Contain(boots);
        }

        [Fact]
        public void DeadEndNoBootsTest()
        {
            //Arrange
            var game = new Game();
            var antArmy = new AntArmy("Ant Army", CardType.Action);
            var userAvatar = new UserAvatar()
            {
                Build = new Build()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            antArmy.DeadEnd(game, user);
            user.UserAvatar.EndTurn();
            //Assert
            user.UserAvatar.Nerfs.FleeChances.Should().Contain(1);
            user.UserAvatar.Nerfs.FleeChances.Should().HaveCount(1);
            user.UserAvatar.FleeChances.Should().Be(2);
            game.DestroyedPrizeCards.Should().HaveCount(0);
        }
    }
}
