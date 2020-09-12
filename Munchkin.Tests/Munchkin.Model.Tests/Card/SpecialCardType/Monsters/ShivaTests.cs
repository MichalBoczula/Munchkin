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
    public class ShivaTests
    {
        [Fact]
        public void SpecialPowerNoWeaponsTest()
        {
            //Arrange
            var game = new Game();
            var shiva = new Shiva("Shiva", CardType.Monster);
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            shiva.SpecialPower(game, user);
            //Assert
            shiva.Power.Should().Be(20);
            shiva.NumberOfPrizes.Should().Be(5);
            shiva.HowManyLevels.Should().Be(3);
        }

        [Fact]
        public void SpecialPowerWeaponsTest()
        {
            //Arrange
            var game = new Game();
            var shiva = new Shiva("Shiva", CardType.Monster);
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var lHand = new ItemCard("sword1H", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var rHand = new ItemCard("axe", CardType.Prize, PrizeCardType.Item, 3, null, true, ItemType.Weapon, null, 300);
            user.UserAvatar.Build.LeftHandItem = lHand;
            user.UserAvatar.Build.RightHandItem = rHand;
            //Act
            shiva.SpecialPower(game, user);
            //Assert
            shiva.Power.Should().Be(26);
            shiva.NumberOfPrizes.Should().Be(5);
            shiva.HowManyLevels.Should().Be(3);
        }

        [Fact]
        public void SpecialPowerOnlyOneWeapomTest()
        {
            //Arrange
            var game = new Game();
            var shiva = new Shiva("Shiva", CardType.Monster);
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var lHand = new ItemCard("sword1H", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            user.UserAvatar.Build.LeftHandItem = lHand;
            //Act
            shiva.SpecialPower(game, user);
            //Assert
            shiva.Power.Should().Be(23);
            shiva.NumberOfPrizes.Should().Be(5);
            shiva.HowManyLevels.Should().Be(3);
        }


        [Fact]
        public void DeadEndTest()
        {
            //Arrange
            var game = new Game();
            var shiva = new Shiva("Shiva", CardType.Monster);
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            shiva.DeadEnd(game, user);
            //Assert
            user.UserAvatar.IsDied.Should().BeTrue();
        }
    }
}
