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
    public class MagicFlowersTests
    {
        [Fact]
        public void SpecialEffectHeroTest()
        {
            //Arrange
            var userClass = new UserClass();
            var userAvatar = new UserAvatar()
            {
                Power = 5
            };
            userClass.UserAvatar = userAvatar;
            var fight = new Fight();
            var monster = new AntArmy("Ant Army", CardType.Monster);
            fight.Heros.Add(userClass.UserAvatar);
            fight.Monsters.Add(monster);
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var magicFlower = new MagicFlowers("MagicFlowers", CardType.Special, PrizeCardType.Sitiuational, 0, null, false, ItemType.Sitiuational, null, 100, mock.Object);
            //Act
            magicFlower.SpecialEffect(fight);
            //Assert
            userClass.UserAvatar.Power.Should().Be(7);
        }

        [Fact]
        public void SpecialEffectMonsterTest()
        {
            //Arrange
            var userClass = new UserClass();
            var userAvatar = new UserAvatar()
            {
                Power = 5
            };
            userClass.UserAvatar = userAvatar;
            var fight = new Fight();
            var monster = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 5
            };
            fight.Heros.Add(userClass.UserAvatar);
            fight.Monsters.Add(monster);
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("2");
            var magicFlower = new MagicFlowers("MagicFlowers", CardType.Special, PrizeCardType.Sitiuational, 0, null, false, ItemType.Sitiuational, null, 100, mock.Object);
            //Act
            magicFlower.SpecialEffect(fight);
            //Assert
            monster.Power.Should().Be(7);
        }

        [Fact]
        public void SpecialEffectHeroTwoTest()
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
                Power = 3
            };
            userClass.UserAvatar = userAvatar;
            userClass2.UserAvatar = userAvatar2;
            var fight = new Fight();
            var monster = new AntArmy("Ant Army", CardType.Monster);
            fight.Heros.Add(userClass.UserAvatar);
            fight.Heros.Add(userClass2.UserAvatar);
            fight.Monsters.Add(monster);
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var magicFlower = new MagicFlowers("MagicFlowers", CardType.Special, PrizeCardType.Sitiuational, 0, null, false, ItemType.Sitiuational, null, 100, mock.Object);
            //Act
            magicFlower.SpecialEffect(fight);
            //Assert
            userClass.UserAvatar.Power.Should().Be(7);
            userClass2.UserAvatar.Power.Should().Be(3);
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
            userClass.UserAvatar = userAvatar;
            var fight = new Fight();
            var monster = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 5
            };
            var monster2 = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 5
            };
            fight.Heros.Add(userClass.UserAvatar);
            fight.Monsters.Add(monster);
            fight.Monsters.Add(monster2);
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("2");
            var magicFlower = new MagicFlowers("MagicFlowers", CardType.Special, PrizeCardType.Sitiuational, 0, null, false, ItemType.Sitiuational, null, 100, mock.Object);
            //Act
            magicFlower.SpecialEffect(fight);
            //Assert
            monster.Power.Should().Be(5);
            monster2.Power.Should().Be(7);
        }
    }
}
