using FluentAssertions;
using Moq;
using Munchkin.BL.CardGenerator;
using Munchkin.BL.CharacterCreator;
using Munchkin.BL.GameController;
using Munchkin.BL.Helper;
using Munchkin.Model;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret;
using Munchkin.Model.Character;
using Munchkin.Model.Character.Hero.Proficiency;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Munchkin.Tests.Munchkin.Model.Tests.Character.Hero.Proficiency
{
    public class PriestProficiencyTests
    {
        [Fact]
        public void MakeMonsterAPetThereIsNoFight()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            var random = new Random();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var priest = new PriestProficiency(mock.Object);
            var userAvatar = new UserAvatar()
            {
                Proficiency = priest
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var drawCardService = new DrawCardService(random);
            var stackCardGeneratorService = new StackCardGeneratorService();
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGeneratorService);
            var fight = new Fight();
            var antArmy = new AntArmy("Ant Army", CardType.Monster);
            prizeStackController.DrawCardsForStartDeck(user);
            fight.Heros.Add(user);
            fight.Monsters.Add(antArmy);
            //Act
            var result = user.UserAvatar.Proficiency.MakeMonsterAPet(user, null);
            //Assert
            user.Deck.Count().Should().Be(5);
            result.DestroyedPrizeCards.Should().BeEmpty();
        }

        [Fact]
        public void MakeMonsterAPetThereIsFightCastSpell()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            var random = new Random();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var priest = new PriestProficiency(mock.Object);
            var userAvatar = new UserAvatar()
            {
                Proficiency = priest
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var drawCardService = new DrawCardService(random);
            var stackCardGeneratorService = new StackCardGeneratorService();
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGeneratorService);
            var fight = new Fight();
            var antArmy = new AntArmy("Ant Army", CardType.Monster);
            prizeStackController.DrawCardsForStartDeck(user);
            fight.Heros.Add(user);
            fight.Monsters.Add(antArmy);
            //Act
            var result = user.UserAvatar.Proficiency.MakeMonsterAPet(user, fight);
            //Assert
            user.Deck.Count().Should().Be(1);
            user.Deck.Monsters[0].Should().BeSameAs(antArmy);
            result.DestroyedPrizeCards.Should().HaveCount(5);
        }

        [Fact]
        public void MakeMonsterAPetThereIsFightDoesntCastSpell()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            var random = new Random();
            mock.Setup(x => x.GetNextString()).Returns("2");
            var priest = new PriestProficiency(mock.Object);
            var userAvatar = new UserAvatar()
            {
                Proficiency = priest
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var drawCardService = new DrawCardService(random);
            var stackCardGeneratorService = new StackCardGeneratorService();
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGeneratorService);
            var fight = new Fight();
            var antArmy = new AntArmy("Ant Army", CardType.Monster);
            prizeStackController.DrawCardsForStartDeck(user);
            fight.Heros.Add(user);
            fight.Monsters.Add(antArmy);
            //Act
            var result = user.UserAvatar.Proficiency.MakeMonsterAPet(user, fight);
            //Assert
            user.Deck.Count().Should().Be(5);
            user.Deck.Monsters.Should().BeEmpty();
            result.DestroyedPrizeCards.Should().HaveCount(0);
        }

        [Fact]
        public void MakeMonsterAPetThereIsFightWithFewMonsters()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            var random = new Random();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var priest = new PriestProficiency(mock.Object);
            var userAvatar = new UserAvatar()
            {
                Proficiency = priest
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var drawCardService = new DrawCardService(random);
            var stackCardGeneratorService = new StackCardGeneratorService();
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGeneratorService);
            var fight = new Fight();
            var antArmyNormal1 = new AntArmy("Ant Army", CardType.Monster);
            var antArmyNormal2 = new AntArmy("Ant Army", CardType.Monster);
            var antArmyStrongest = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 11
            };
            prizeStackController.DrawCardsForStartDeck(user);
            fight.Heros.Add(user);
            fight.Monsters.Add(antArmyNormal1);
            fight.Monsters.Add(antArmyStrongest);
            fight.Monsters.Add(antArmyNormal2);
            //Act
            var result = user.UserAvatar.Proficiency.MakeMonsterAPet(user, fight);
            //Assert
            user.Deck.Count().Should().Be(1);
            result.DestroyedPrizeCards.Should().HaveCount(5);
            user.Deck.Monsters.Should().HaveCount(1);
            user.Deck.Monsters[0].Should().BeSameAs(antArmyStrongest);
        }

        [Fact]
        public void MakeMonsterAPetTooLessCardsNoCast()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            var random = new Random();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var priest = new PriestProficiency(mock.Object);
            var userAvatar = new UserAvatar()
            {
                Proficiency = priest
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var drawCardService = new DrawCardService(random);
            var stackCardGeneratorService = new StackCardGeneratorService();
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGeneratorService);
            var fight = new Fight();
            var antArmyStrongest = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 11
            };
            prizeStackController.DrawCardsForStartDeck(user);
            user.Deck.Items.RemoveAt(0);
            user.Deck.Items.RemoveAt(0);
            user.Deck.Items.RemoveAt(0);
            fight.Heros.Add(user);
            fight.Monsters.Add(antArmyStrongest);
            //Act
            var result = user.UserAvatar.Proficiency.MakeMonsterAPet(user, fight);
            //Assert
            user.Deck.Count().Should().Be(2);
            result.DestroyedPrizeCards.Should().HaveCount(0);
            user.Deck.Monsters.Should().BeEmpty();
        }
    }
}
