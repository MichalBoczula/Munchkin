using FluentAssertions;
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
    public class GoldenAppleTests
    {
        [Fact]
        public void SpecialEffectOnlyOneHeroTest()
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
            var goldenApple = new GoldenApple("GoldenApple", CardType.Special, PrizeCardType.Sitiuational, 0, null, false, ItemType.Sitiuational, null, 500);
            //Act
            goldenApple.SpecialEffect(fight);
            //Assert
            userClass.UserAvatar.Power.Should().Be(10);
            userClass.UserAvatar.Nerfs.Poisoned.Should().HaveCount(1);
            userClass.UserAvatar.Nerfs.Poisoned[0].Should().Be(true);
        }

        [Fact]
        public void SpecialEffectFewHerosTest()
        {
            //Arrange
            var userClass = new UserClass();
            var userAvatar = new UserAvatar()
            {
                Power = 5
            };
            var userClass2 = new UserClass();
            var userAvatar2 = new UserAvatar()
            {
                Power = 3
            };
            userClass.UserAvatar = userAvatar;
            userClass2.UserAvatar = userAvatar2;
            var fight = new Fight();
            fight.Heros.Add(userClass.UserAvatar);
            fight.Heros.Add(userClass2.UserAvatar);
            var goldenApple = new GoldenApple("GoldenApple", CardType.Special, PrizeCardType.Sitiuational, 0, null, false, ItemType.Sitiuational, null, 500);
            //Act
            goldenApple.SpecialEffect(fight);
            //Assert
            userClass.UserAvatar.Power.Should().Be(10);
            userClass.UserAvatar.Nerfs.Poisoned.Should().HaveCount(1);
            userClass.UserAvatar.Nerfs.Poisoned[0].Should().Be(true);
            userClass2.UserAvatar.Power.Should().Be(8);
            userClass2.UserAvatar.Nerfs.Poisoned.Should().HaveCount(1);
            userClass2.UserAvatar.Nerfs.Poisoned[0].Should().Be(true);
        }
    }
}
