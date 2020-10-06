using FluentAssertions;
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
    public class DeadMarkTests
    {
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
            fight.Heros.Add(userClass.UserAvatar);
            fight.Monsters.Add(monster);
            var deadMark = new DeadMark("DeadMark", CardType.Special, PrizeCardType.Sitiuational, 0, null, false, ItemType.Sitiuational, null, 700);
            //Act
            deadMark.SpecialEffect(fight);
            //Assert
            userClass.UserAvatar.Nerfs.Wounded.Should().HaveCount(1);
            userClass.UserAvatar.Nerfs.Wounded[0].Should().Be(true);
            userClass.UserAvatar.Power.Should().Be(5);
            monster.Power.Should().Be(5);
        }

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
            fight.Heros.Add(userClass.UserAvatar);
            fight.Heros.Add(userClass2.UserAvatar);
            fight.Monsters.Add(monster);
            var deadMark = new DeadMark("DeadMark", CardType.Special, PrizeCardType.Sitiuational, 0, null, false, ItemType.Sitiuational, null, 700);
            //Act
            deadMark.SpecialEffect(fight);
            //Assert
            userClass.UserAvatar.Nerfs.Wounded.Should().HaveCount(1);
            userClass.UserAvatar.Nerfs.Wounded[0].Should().Be(true);
            userClass.UserAvatar.Power.Should().Be(5);
            userClass2.UserAvatar.Nerfs.Wounded.Should().HaveCount(1);
            userClass2.UserAvatar.Nerfs.Wounded[0].Should().Be(true);
            userClass2.UserAvatar.Power.Should().Be(5);
            monster.Power.Should().Be(5);
        }
    }
}
