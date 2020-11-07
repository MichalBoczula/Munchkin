using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Moq;
using Munchkin.BL.CardGenerator;
using Munchkin.BL.CharacterCreator;
using Munchkin.BL.GameController;
using Munchkin.BL.Helper;
using Munchkin.Model;
using Munchkin.Model.Card.ActionCard.SpecialCardType.MagicCards;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret;
using Munchkin.Model.Character;
using Munchkin.Model.Character.Hero.Proficiency;
using Munchkin.Model.User;
using Xunit;

namespace Munchkin.Tests.Munchkin.Model.Tests.Character.Hero.Proficiency
{
    public class MageProficiencyTests
    {
        [Fact]
        public void FleeSpellSuccessTest()
        {
            //Arrange
            var game = new Game();
            var mockReadLineOverride = new Mock<ReadLineOverride>();
            mockReadLineOverride.Setup(x => x.GetNextString()).Returns(new Queue<string>(new[] { "4", "1", "2", "1", "1", "1" }).Dequeue);
            var random = new Random();
            var drawCard = new DrawCardService(random);
            var stackCardGeneratorService = new StackCardGeneratorService();
            var prizeStackGenerator = new PrizeStackController(drawCard, stackCardGeneratorService);
            var mage = new MageProficiency(mockReadLineOverride.Object);
            var userAvatar = new UserAvatar()
            {
                Proficiency = mage
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            user = prizeStackGenerator.DrawCardsForStartDeck(user);
            //Act
            var result1 = user.UserAvatar.Proficiency.FleeSpell(user);
            var result2 = user.UserAvatar.Proficiency.FleeSpell(user);
            var result3 = user.UserAvatar.Proficiency.FleeSpell(user);
            //Assert
            user.UserAvatar.FleeChances.Should().Be(6);
            user.Deck.Count().Should().Be(2);
            result1.DestroyedPrizeCards.Count.Should().Be(1);
            result2.DestroyedPrizeCards.Count.Should().Be(1);
            result3.DestroyedPrizeCards.Count.Should().Be(1);
        }

        [Fact]
        public void FleeSpellFailNotEnoughCardsTest()
        {
            //Arrange
            var game = new Game();
            var mockReadLineOverride = new Mock<ReadLineOverride>();
            mockReadLineOverride.Setup(x => x.GetNextString()).Returns("1");
            var random = new Random();
            var drawCard = new DrawCardService(random);
            var stackCardGeneratorService = new StackCardGeneratorService();
            var prizeStackGenerator = new PrizeStackController(drawCard, stackCardGeneratorService);
            var mage = new MageProficiency(mockReadLineOverride.Object);
            var userAvatar = new UserAvatar()
            {
                Proficiency = mage
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            user = prizeStackGenerator.DrawCardsForStartDeck(user);
            user.Deck.Clear();
            //Act
            var result1 = user.UserAvatar.Proficiency.FleeSpell(user);
            //Assert
            user.UserAvatar.FleeChances.Should().Be(3);
            user.Deck.Count().Should().Be(0);
            result1.DestroyedPrizeCards.Count.Should().Be(0);
        }

        [Fact]
        public void FleeSpellDeckIsNullTest()
        {
            //Arrange
            var mockReadLineOverride = new Mock<ReadLineOverride>();
            mockReadLineOverride.Setup(x => x.GetNextString()).Returns("1");
            var random = new Random();
            var drawCard = new DrawCardService(random);
            var stackCardGeneratorService = new StackCardGeneratorService();
            var prizeStackGenerator = new PrizeStackController(drawCard, stackCardGeneratorService);
            var mage = new MageProficiency(mockReadLineOverride.Object);
            var userAvatar = new UserAvatar()
            {
                Proficiency = mage
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            var result1 = user.UserAvatar.Proficiency.FleeSpell(user);
            //Assert
            user.UserAvatar.FleeChances.Should().Be(3);
            user.Deck.Count().Should().Be(0);
            result1.DestroyedPrizeCards.Count.Should().Be(0);
        }

        [Fact]
        public void FleeSpellCastFourTimesTest()
        {
            //Arrange
            var mockReadLineOverride = new Mock<ReadLineOverride>();
            mockReadLineOverride.Setup(x => x.GetNextString()).Returns(new Queue<string>(new[] { "5", "1", "2", "1", "1", "1", "1" }).Dequeue);
            var random = new Random();
            var drawCard = new DrawCardService(random);
            var stackCardGeneratorService = new StackCardGeneratorService();
            var prizeStackGenerator = new PrizeStackController(drawCard, stackCardGeneratorService);
            var mage = new MageProficiency(mockReadLineOverride.Object);
            var userAvatar = new UserAvatar()
            {
                Proficiency = mage
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            user = prizeStackGenerator.DrawCardsForStartDeck(user);
            //Act
            var result1 = user.UserAvatar.Proficiency.FleeSpell(user);
            var result2 = user.UserAvatar.Proficiency.FleeSpell(user);
            var result3 = user.UserAvatar.Proficiency.FleeSpell(user);
            var result4 = user.UserAvatar.Proficiency.FleeSpell(user);
            //Assert
            user.UserAvatar.FleeChances.Should().Be(6);
            user.Deck.Count().Should().Be(2);
            result1.DestroyedPrizeCards.Should().HaveCount(1);
            result2.DestroyedPrizeCards.Should().HaveCount(1);
            result3.DestroyedPrizeCards.Should().HaveCount(1);
            result4.DestroyedPrizeCards.Should().BeEmpty();
        }

        [Fact]
        public void FleeSpellSuccessDiffrentCArds()
        {
            //Arrange
            var mockReadLineOverride = new Mock<ReadLineOverride>();
            mockReadLineOverride.Setup(x => x.GetNextString()).Returns(new Queue<string>(new[] { "1", "1", "1", "1", "1", "1", "1" }).Dequeue);
            var random = new Random();
            var drawCard = new DrawCardService(random);
            var stackCardGeneratorService = new StackCardGeneratorService();
            var prizeStackGenerator = new PrizeStackController(drawCard, stackCardGeneratorService);
            var mage = new MageProficiency(mockReadLineOverride.Object);
            var userAvatar = new UserAvatar()
            {
                Proficiency = mage
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var monster = new AntArmy("Ant Army", CardType.Monster);
            var magic = new BackToSchool("BackToSchool", CardType.Curse);
            user = prizeStackGenerator.DrawCardsForStartDeck(user);
            user.Deck.Items.RemoveAt(0);
            user.Deck.Items.RemoveAt(0);
            user.Deck.Items.RemoveAt(0);
            user.Deck.Items.RemoveAt(0);
            user.Deck.Monsters.Add(monster);
            user.Deck.MagicCards.Add(magic);
            //Act
            var result = user.UserAvatar.Proficiency.FleeSpell(user);
            var result2 = user.UserAvatar.Proficiency.FleeSpell(user);
            var result3 = user.UserAvatar.Proficiency.FleeSpell(user);
            //Assert
            user.UserAvatar.FleeChances.Should().Be(6);
            user.Deck.Count().Should().Be(0);
            result.DestroyedPrizeCards.Should().HaveCount(1);
            result2.DestroyedActionCards.Should().HaveCount(1);
            result3.DestroyedActionCards.Should().HaveCount(1);
        }

        [Fact]
        public void InstantKillSuccessTest()
        {
            //Arrange
            var stackCardGenedratorService = new StackCardGeneratorService();
            var random = new Random();
            var drawCardService = new DrawCardService(random);
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGenedratorService);
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var mage1 = new MageProficiency(mock.Object);
            var avatar = new UserAvatar()
            {
                Proficiency = mage1
            };
            var user = new UserClass()
            {
                UserAvatar = avatar
            };
            user = prizeStackController.DrawCardsForStartDeck(user);
            //Act
            var result = user.UserAvatar.Proficiency.InstantKill(user);
            //Assert
            Assert.True(result.DestroyedActionCards.Count + result.DestroyedPrizeCards.Count > 3);
            user.Deck.Count().Should().Be(0);
        }

        [Fact]
        public void InstantKillFailTest()
        {
            //Arrange
            var stackCardGenedratorService = new StackCardGeneratorService();
            var random = new Random();
            var drawCardService = new DrawCardService(random);
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGenedratorService);
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var mage1 = new MageProficiency(mock.Object);
            var avatar = new UserAvatar()
            {
                Proficiency = mage1
            };
            var user = new UserClass()
            {
                UserAvatar = avatar
            };
            user = prizeStackController.DrawCardsForStartDeck(user);
            user.Deck.Clear();
            //Act
            var result = user.UserAvatar.Proficiency.InstantKill(user);
            //Assert
            Assert.False(result.DestroyedActionCards.Count + result.DestroyedPrizeCards.Count > 3);
            user.Deck.Count().Should().Be(0);
        }
    }
}
