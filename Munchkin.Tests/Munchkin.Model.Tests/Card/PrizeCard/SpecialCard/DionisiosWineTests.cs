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
    public class DionisiosWineTests
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
            fight.Heros.Add(userClass);
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var dionisiosWine = new DionisiosWine("DionisiosWine", CardType.Special, PrizeCardType.Sitiuational, 0, null, false, ItemType.Sitiuational, null, 400, mock.Object);
            //Act
            dionisiosWine.SpecialEffect(fight);
            //Assert
            userClass.UserAvatar.Power.Should().Be(8);
            userClass.UserAvatar.FleeChances.Should().Be(1);
        }

        [Fact]
        public void SpecialEffectHeroAndMonsterTest()
        {
            //Arrange
            var userClass = new UserClass();
            var userAvatar = new UserAvatar()
            {
                Power = 5
            };
            var antArmy = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 5
            };
            userClass.UserAvatar = userAvatar;
            var fight = new Fight();
            fight.Heros.Add(userClass);
            fight.Monsters.Add(antArmy);
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("2");
            var dionisiosWine = new DionisiosWine("DionisiosWine", CardType.Special, PrizeCardType.Sitiuational, 0, null, false, ItemType.Sitiuational, null, 400, mock.Object);
            //Act
            dionisiosWine.SpecialEffect(fight);
            //Assert
            antArmy.Power.Should().Be(8);
            userClass.UserAvatar.Power.Should().Be(5);
            userClass.UserAvatar.FleeChances.Should().Be(5);
        }

        [Fact]
        public void SpecialEffectFewHerosAndMonstersUsedOnHeroesTest()
        {
            //Arrange
            var userClass = new UserClass();
            var userAvatar = new UserAvatar()
            {
                Power = 5
            };
            var antArmy = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 5
            };
            var userClass2 = new UserClass();
            var userAvatar2 = new UserAvatar()
            {
                Power = 3
            };
            var antArmy2 = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 4
            };
            userClass.UserAvatar = userAvatar;
            userClass2.UserAvatar = userAvatar2;
            var fight = new Fight();
            fight.Heros.Add(userClass);
            fight.Heros.Add(userClass2);
            fight.Monsters.Add(antArmy);
            fight.Monsters.Add(antArmy2);
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var dionisiosWine = new DionisiosWine("DionisiosWine", CardType.Special, PrizeCardType.Sitiuational, 0, null, false, ItemType.Sitiuational, null, 400, mock.Object);
            //Act
            dionisiosWine.SpecialEffect(fight);
            //Assert
            userClass.UserAvatar.Power.Should().Be(8);
            userClass.UserAvatar.FleeChances.Should().Be(1);
            userClass2.UserAvatar.Power.Should().Be(6);
            userClass2.UserAvatar.FleeChances.Should().Be(1);
            antArmy.Power.Should().Be(5);
            antArmy2.Power.Should().Be(4);
        }

        [Fact]
        public void SpecialEffectFewHerosAndMonstersUsedOnMonstersTest()
        {
            //Arrange
            var userClass = new UserClass();
            var userAvatar = new UserAvatar()
            {
                Power = 5
            };
            var antArmy = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 5
            };
            var userClass2 = new UserClass();
            var userAvatar2 = new UserAvatar()
            {
                Power = 3
            };
            var antArmy2 = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 4
            };
            userClass.UserAvatar = userAvatar;
            userClass2.UserAvatar = userAvatar2;
            var fight = new Fight();
            fight.Heros.Add(userClass);
            fight.Heros.Add(userClass2);
            fight.Monsters.Add(antArmy);
            fight.Monsters.Add(antArmy2);
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("2");
            var dionisiosWine = new DionisiosWine("DionisiosWine", CardType.Special, PrizeCardType.Sitiuational, 0, null, false, ItemType.Sitiuational, null, 400, mock.Object);
            //Act
            dionisiosWine.SpecialEffect(fight);
            //Assert
            userClass.UserAvatar.Power.Should().Be(5);
            userClass.UserAvatar.FleeChances.Should().Be(5);
            userClass2.UserAvatar.Power.Should().Be(3);
            userClass2.UserAvatar.FleeChances.Should().Be(5);
            antArmy.Power.Should().Be(8);
            antArmy2.Power.Should().Be(7);
        }
    }
}
