using FluentAssertions;
using Moq;
using Munchkin.BL.Helper;
using Munchkin.Model;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret;
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
    public class IcePotionTests
    {
        [Fact]
        public void SpecialEffectUsedOnHeroesTest()
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
                Power = 5
            };
            userClass.UserAvatar = userAvatar;
            userClass2.UserAvatar = userAvatar2;
            var fight = new Fight();
            var monster = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 5
            };
            fight.Heros.Add(userClass);
            fight.Heros.Add(userClass2);
            fight.Monsters.Add(monster);
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var icePotion = new IcePotion("IcePotion", CardType.Special, PrizeCardType.Sitiuational, 0, null, false, ItemType.Sitiuational, null, 300, mock.Object);
            //Act
            icePotion.SpecialEffect(fight);
            //Assert
            userClass.UserAvatar.FleeChances.Should().Be(0);
            userClass2.UserAvatar.FleeChances.Should().Be(0);
        }

        [Fact]
        public void SpecialEffectTwoMonstersTest()
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
                Power = 5
            };
            userClass.UserAvatar = userAvatar;
            userClass2.UserAvatar = userAvatar2;
            var fight = new Fight();
            var monster = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 5
            };
            fight.Heros.Add(userClass);
            fight.Heros.Add(userClass2);
            fight.Monsters.Add(monster);
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("2");
            var icePotion = new IcePotion("IcePotion", CardType.Special, PrizeCardType.Sitiuational, 0, null, false, ItemType.Sitiuational, null, 300, mock.Object);
            //Act
            icePotion.SpecialEffect(fight);
            //Assert
            userClass.UserAvatar.FleeChances.Should().Be(6);
            userClass2.UserAvatar.FleeChances.Should().Be(6);
        }
    }
}
