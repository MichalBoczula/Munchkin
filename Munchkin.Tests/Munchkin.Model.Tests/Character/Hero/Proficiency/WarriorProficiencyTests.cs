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
using Xunit;

namespace Munchkin.Tests.Munchkin.Model.Tests.Character.Hero.Proficiency
{
    public class WarriorProficiencyTests
    {
        [Fact]
        public void BeStrongerSuccessTest()
        {
            //Arrange
            var mockReadLineOverride = new Mock<ReadLineOverride>();
            mockReadLineOverride.Setup(x => x.GetNextString()).Returns(new Queue<string>(new[] { "4", "1", "2", "1", "1", "1" }).Dequeue);
            var random = new Random();
            var drawCard = new DrawCardService(random);
            var stackCardGeneratorService = new StackCardGeneratorService();
            var prizeStackGenerator = new PrizeStackController(drawCard, stackCardGeneratorService);
            var warrior = new WarriorProficiency(mockReadLineOverride.Object);
            var userAvatar = new UserAvatar()
            {
                Proficiency = warrior
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            user = prizeStackGenerator.DrawCardsForStartDeck(user);
            //Act
            var result1 = user.UserAvatar.Proficiency.BeStronger(user);
            var result2 = user.UserAvatar.Proficiency.BeStronger(user);
            var result3 = user.UserAvatar.Proficiency.BeStronger(user);
            //Assert
            user.UserAvatar.TempPower.Should().Be(4);
            user.Deck.Count().Should().Be(2);
            result1.DestroyedPrizeCards.Count.Should().Be(1);
            result2.DestroyedPrizeCards.Count.Should().Be(1);
            result3.DestroyedPrizeCards.Count.Should().Be(1);
        }

        [Fact]
        public void BeStrongerFailNotEnoughCardsTest()
        {
            //Arrange
            var mockReadLineOverride = new Mock<ReadLineOverride>();
            mockReadLineOverride.Setup(x => x.GetNextString()).Returns("1");
            var random = new Random();
            var drawCard = new DrawCardService(random);
            var stackCardGeneratorService = new StackCardGeneratorService();
            var prizeStackGenerator = new PrizeStackController(drawCard, stackCardGeneratorService);
            var warrior = new WarriorProficiency(mockReadLineOverride.Object);
            var userAvatar = new UserAvatar()
            {
                Proficiency = warrior
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            user = prizeStackGenerator.DrawCardsForStartDeck(user);
            user.Deck.Clear();
            //Act
            user.UserAvatar.Proficiency.BeStronger(user);
            //Assert
            user.UserAvatar.TempPower.Should().Be(1);
            user.Deck.Count().Should().Be(0);
        }

        [Fact]
        public void BeStrongerDeckIsNullTest()
        {
            //Arrange
            var mockReadLineOverride = new Mock<ReadLineOverride>();
            mockReadLineOverride.Setup(x => x.GetNextString()).Returns("1");
            var random = new Random();
            var drawCard = new DrawCardService(random);
            var stackCardGeneratorService = new StackCardGeneratorService();
            var prizeStackGenerator = new PrizeStackController(drawCard, stackCardGeneratorService);
            var warrior = new WarriorProficiency(mockReadLineOverride.Object);
            var userAvatar = new UserAvatar()
            {
                Proficiency = warrior
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            user.UserAvatar.Proficiency.BeStronger(user);
            //Assert
            user.UserAvatar.TempPower.Should().Be(1);
            user.Deck.Count().Should().Be(0);
        }

        [Fact]
        public void BeStrongerCastFourTimesTest()
        {
            //Arrange
            var mockReadLineOverride = new Mock<ReadLineOverride>();
            mockReadLineOverride.Setup(x => x.GetNextString()).Returns(new Queue<string>(new[] { "5", "1", "2", "1", "1", "1", "1" }).Dequeue);
            var random = new Random();
            var drawCard = new DrawCardService(random);
            var stackCardGeneratorService = new StackCardGeneratorService();
            var prizeStackGenerator = new PrizeStackController(drawCard, stackCardGeneratorService);
            var warrior = new WarriorProficiency(mockReadLineOverride.Object);
            var userAvatar = new UserAvatar()
            {
                Proficiency = warrior
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            user = prizeStackGenerator.DrawCardsForStartDeck(user);
            //Act
            var result1 = user.UserAvatar.Proficiency.BeStronger(user);
            var result2 = user.UserAvatar.Proficiency.BeStronger(user);
            var result3 = user.UserAvatar.Proficiency.BeStronger(user);
            var result4 = user.UserAvatar.Proficiency.BeStronger(user);
            //Assert
            user.UserAvatar.TempPower.Should().Be(4);
            user.Deck.Count().Should().Be(2);
            result1.DestroyedPrizeCards.Should().HaveCount(1);
            result2.DestroyedPrizeCards.Should().HaveCount(1);
            result3.DestroyedPrizeCards.Should().HaveCount(1);
            result4.DestroyedPrizeCards.Should().BeEmpty();
        }

        [Fact]
        public void BeStrongerSuccessDiffrentCArds()
        {
            //Arrange
            var mockReadLineOverride = new Mock<ReadLineOverride>();
            mockReadLineOverride.Setup(x => x.GetNextString()).Returns(new Queue<string>(new[] { "1", "1", "1", "1", "1", "1", "1" }).Dequeue);
            var random = new Random();
            var drawCard = new DrawCardService(random);
            var stackCardGeneratorService = new StackCardGeneratorService();
            var prizeStackGenerator = new PrizeStackController(drawCard, stackCardGeneratorService);
            var warrior = new WarriorProficiency(mockReadLineOverride.Object);
            var userAvatar = new UserAvatar()
            {
                Proficiency = warrior
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
            var result = user.UserAvatar.Proficiency.BeStronger(user);
            var result2 = user.UserAvatar.Proficiency.BeStronger(user);
            var result3 = user.UserAvatar.Proficiency.BeStronger(user);
            //Assert
            user.UserAvatar.TempPower.Should().Be(4);
            user.Deck.Count().Should().Be(0);
            result.DestroyedPrizeCards.Should().HaveCount(1);
            result2.DestroyedActionCards.Should().HaveCount(1);
            result3.DestroyedActionCards.Should().HaveCount(1);
        }
    }
}
