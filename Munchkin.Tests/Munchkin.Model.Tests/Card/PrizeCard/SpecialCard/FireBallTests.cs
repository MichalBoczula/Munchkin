 using FluentAssertions;
using Moq;
using Munchkin.BL.Helper;
using Munchkin.Model;
using Munchkin.Model.Card.PrizeCard;
using Munchkin.Model.Card.PrizeCard.SituationalItems;
using Munchkin.Model.Character;
using Munchkin.Model.Character.Hero.Proficiency;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Munchkin.Tests.Munchkin.Model.Tests.Card.PrizeCard.SpecialCard
{
    public class FireBallTests
    {
        [Fact]
        public void SpecialEffectHeroMageProficiencyTest()
        {
            //Arrange
            var userClass = new UserClass();
            var userAvatar = new UserAvatar()
            {
                Power = 5,
                Proficiency = new MageProficiency()
            };
            userClass.UserAvatar = userAvatar;
            var fight = new Fight();
            fight.Heros.Add(userClass.UserAvatar);
            var fireBall = new FireBall("FireBall", CardType.Special, PrizeCardType.Sitiuational, 0, null, false, ItemType.Sitiuational, null, 400);
            //Act
            fireBall.SpecialEffect(fight);
            //Assert
            userClass.UserAvatar.Power.Should().Be(11);
        }

        [Fact]
        public void SpecialEffectHeroDiffrentProficiencyTest()
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
            var fireBall = new FireBall("FireBall", CardType.Special, PrizeCardType.Sitiuational, 0, null, false, ItemType.Sitiuational, null, 400);
            //Act
            fireBall.SpecialEffect(fight);
            //Assert
            userClass.UserAvatar.Power.Should().Be(8);
        }

        [Fact]
        public void SpecialEffectHeroTwoWithoutMageTest()
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
            fight.Heros.Add(userClass.UserAvatar);
            fight.Heros.Add(userClass2.UserAvatar);
            var fireBall = new FireBall("FireBall", CardType.Special, PrizeCardType.Sitiuational, 0, null, false, ItemType.Sitiuational, null, 400);
            //Act
            fireBall.SpecialEffect(fight);
            //Assert
            userClass.UserAvatar.Power.Should().Be(8);
            userClass2.UserAvatar.Power.Should().Be(4);
        }

        [Fact]
        public void SpecialEffectHeroTwoWithMageTest()
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
                Power = 4,
                Proficiency = new MageProficiency()
            };
            userClass.UserAvatar = userAvatar;
            userClass2.UserAvatar = userAvatar2;
            var fight = new Fight();
            fight.Heros.Add(userClass.UserAvatar);
            fight.Heros.Add(userClass2.UserAvatar);
            var fireBall = new FireBall("FireBall", CardType.Special, PrizeCardType.Sitiuational, 0, null, false, ItemType.Sitiuational, null, 400);
            //Act
            fireBall.SpecialEffect(fight);
            //Assert
            userClass.UserAvatar.Power.Should().Be(11);
            userClass2.UserAvatar.Power.Should().Be(4);
        }
    }
}
