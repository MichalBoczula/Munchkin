using FluentAssertions;
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
    public class RuneMarkTests
    {
        [Fact]
        public void SpecialEffectTest()
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
            var runeMark = new RuneMark("Poison", CardType.Special, PrizeCardType.Sitiuational, 0, null, false, ItemType.Sitiuational, null, 400);
            //Act
            runeMark.SpecialEffect(fight);
            //Assert
            userClass.UserAvatar.Power.Should().Be(5);
            monster.Power.Should().Be(2);
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
            AntArmy monster2 = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 5
            };
            fight.Heros.Add(userClass.UserAvatar);
            fight.Monsters.Add(monster);
            fight.Monsters.Add(monster2);
            var runeMark = new RuneMark("Poison", CardType.Special, PrizeCardType.Sitiuational, 0, null, false, ItemType.Sitiuational, null, 400);
            //Act
            runeMark.SpecialEffect(fight);
            //Assert
            userClass.UserAvatar.Power.Should().Be(5);
            monster.Power.Should().Be(2);
            monster2.Power.Should().Be(2);
        }
    }
}
