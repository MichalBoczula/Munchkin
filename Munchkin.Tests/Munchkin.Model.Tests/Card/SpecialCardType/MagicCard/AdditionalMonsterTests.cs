using FluentAssertions;
using Moq;
using Munchkin.BL.Helper;
using Munchkin.Model;
using Munchkin.Model.Card.ActionCard.SpecialCardType.MagicCards;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret;
using Munchkin.Model.Character;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Munchkin.Tests.Munchkin.Model.Tests.Card.SpecialCardType.MagicCard
{
    public class AdditionalMonsterTests
    {
        [Fact]
        public void CastSpecialSpell()
        {
            //Arrange
            var game = new Game();
            var fight = new Fight();
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("0");
            var curse = new AdditionalMonster("AdditionalMonster", CardType.Special, mock.Object);
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            fight.Heros.Add(user);
            var monster = new AntArmy("Ant Army", CardType.Monster);
            user.Deck.Monsters.Add(monster);
            //Act
            curse.CastSpecialSpell(user: user, game: game, fight: fight);
            //Assert
            fight.Monsters.Should().HaveCount(1);
            fight.Monsters[0].Should().BeSameAs(monster);
            user.Deck.Monsters.Count.Should().Be(0);
        }

        [Fact]
        public void CastSpecialSpellMoreMonsterThan1()
        {
            //Arrange
            var game = new Game();
            var fight = new Fight();
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var curse = new AdditionalMonster("AdditionalMonster", CardType.Special, mock.Object);
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            fight.Heros.Add(user);
            var monster = new AntArmy("Ant Army", CardType.Monster);
            var babaYaga = new BabaYaga("Baba Yaga", CardType.Monster);
            user.Deck.Monsters.Add(monster);
            user.Deck.Monsters.Add(babaYaga);
            //Act
            curse.CastSpecialSpell(user: user, game: game, fight: fight);
            //Assert
            fight.Monsters.Should().HaveCount(1);
            fight.Monsters[0].Should().BeSameAs(babaYaga);
            user.Deck.Monsters.Count.Should().Be(1);
        }
    }
}
