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
    public class ValhallasHornTests
    {
        [Fact]
        public void SpecialEffectHeroAnMonsterTest()
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
            fight.Heros.Add(userClass);
            fight.Monsters.Add(monster);
            var valhallasHorn = new ValhallasHorn(" ValhallasHorn", CardType.Special, PrizeCardType.Sitiuational, 0, null, false, ItemType.Sitiuational, null, 700);
            //Act
            valhallasHorn.SpecialEffect(fight);
            //Assert
            userClass.UserAvatar.Power.Should().Be(7);
            monster.Power.Should().Be(3);
        }

        [Fact]
        public void SpecialEffectHerosAndMonstersTest()
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
            var monster = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 5
            };
            var monster2 = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 6
            };
            fight.Heros.Add(userClass);
            fight.Heros.Add(userClass2);
            fight.Monsters.Add(monster);
            fight.Monsters.Add(monster2);
            var valhallasHorn = new ValhallasHorn(" ValhallasHorn", CardType.Special, PrizeCardType.Sitiuational, 0, null, false, ItemType.Sitiuational, null, 700);
            //Act
            valhallasHorn.SpecialEffect(fight);
            //Assert
            userClass.UserAvatar.Power.Should().Be(7);
            userClass2.UserAvatar.Power.Should().Be(5);
            monster.Power.Should().Be(3);
            monster2.Power.Should().Be(4);
        }
    }
}
