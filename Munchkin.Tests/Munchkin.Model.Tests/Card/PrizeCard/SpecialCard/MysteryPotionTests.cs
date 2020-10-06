using FluentAssertions;
using Moq;
using Munchkin.Model;
using Munchkin.Model.Card.PrizeCard;
using Munchkin.Model.Card.PrizeCard.SituationalItems;
using Munchkin.Model.Character;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Munchkin.Tests.Munchkin.Model.Tests.Card.PrizeCard.SpecialCard
{
    public class MysteryPotionTests
    {
        [Fact]
        public void SpecialEffectHeroNegativeEffectTest()
        {
            //Arrange
            var userClass = new UserClass();
            var userAvatar = new UserAvatar()
            {
                Power = 5
            };
            userClass.UserAvatar = userAvatar;
            var fight = new Fight();
            fight.Heros.Add(userClass.UserAvatar);
            var mock = new Mock<Random>();
            mock.Setup(x => x.Next(It.IsAny<int>())).Returns(0);
            var mysteryPotion = new MysteryPotion("MysteryPotion", CardType.Special, PrizeCardType.Sitiuational, 0, null, false, ItemType.Sitiuational, null, 500, mock.Object);
            //Act
            mysteryPotion.SpecialEffect(fight);
            //Assert
            userClass.UserAvatar.Power.Should().Be(3);
        }

        [Fact]
        public void SpecialEffectHeroPositiveEffectTest()
        {
            //Arrange
            var userClass = new UserClass();
            var userAvatar = new UserAvatar()
            {
                Power = 5
            };
            userClass.UserAvatar = userAvatar;
            var fight = new Fight();
            fight.Heros.Add(userClass.UserAvatar);
            var mock = new Mock<Random>();
            mock.Setup(x => x.Next(It.IsAny<int>())).Returns(1);
            var mysteryPotion = new MysteryPotion("MysteryPotion", CardType.Special, PrizeCardType.Sitiuational, 0, null, false, ItemType.Sitiuational, null, 500, mock.Object);
            //Act
            mysteryPotion.SpecialEffect(fight);
            //Assert
            userClass.UserAvatar.Power.Should().Be(8);
        }

        [Fact]
        public void SpecialEffectTwoHeroNegativeEffectTest()
        {
            //Arrange
            var userClass = new UserClass();
            var userClass2 = new UserClass();
            var userAvatar = new UserAvatar()
            {
                Power = 5
            };
            var userAvatar2 = new UserAvatar()
            {
                Power = 4
            };
            userClass.UserAvatar = userAvatar;
            userClass2.UserAvatar = userAvatar2;
            var fight = new Fight();
            var mock = new Mock<Random>();
            mock.Setup(x => x.Next(It.IsAny<int>())).Returns(0);
            var mysteryPotion = new MysteryPotion("MysteryPotion", CardType.Special, PrizeCardType.Sitiuational, 0, null, false, ItemType.Sitiuational, null, 500, mock.Object);
            fight.Heros.Add(userClass.UserAvatar);
            fight.Heros.Add(userClass2.UserAvatar);
            //Act
            mysteryPotion.SpecialEffect(fight);
            //Assert
            userClass.UserAvatar.Power.Should().Be(3);
            userClass2.UserAvatar.Power.Should().Be(2);
        }

        [Fact]
        public void SpecialEffectTwoHeroPositiveEffectTest()
        {
            //Arrange
            var userClass = new UserClass();
            var userClass2 = new UserClass();
            var userAvatar = new UserAvatar()
            {
                Power = 5
            };
            var userAvatar2 = new UserAvatar()
            {
                Power = 4
            };
            userClass.UserAvatar = userAvatar;
            userClass2.UserAvatar = userAvatar2;
            var fight = new Fight();
            var mock = new Mock<Random>();
            mock.Setup(x => x.Next(It.IsAny<int>())).Returns(1);
            var mysteryPotion = new MysteryPotion("MysteryPotion", CardType.Special, PrizeCardType.Sitiuational, 0, null, false, ItemType.Sitiuational, null, 500, mock.Object);
            fight.Heros.Add(userClass.UserAvatar);
            fight.Heros.Add(userClass2.UserAvatar);
            //Act
            mysteryPotion.SpecialEffect(fight);
            //Assert
            userClass.UserAvatar.Power.Should().Be(8);
            userClass2.UserAvatar.Power.Should().Be(7);
        }
    }
}
