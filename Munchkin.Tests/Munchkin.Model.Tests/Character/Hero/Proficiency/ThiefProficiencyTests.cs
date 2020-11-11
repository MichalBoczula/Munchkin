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
using Munchkin.Model.Card.PrizeCard;
using Munchkin.Model.Card.PrizeCard.SituationalItems;
using Munchkin.Model.Character;
using Munchkin.Model.Character.Hero.Proficiency;
using Munchkin.Tests.Munchkin.Model.Tests.Card.SpecialCardType.Monsters;
using Munchkin.Tests.Munchkin.Model.Tests.Helper;
using Xunit;

namespace Munchkin.Tests.Munchkin.Model.Tests.Character.Hero.Proficiency
{
    public class ThiefProficiencyTests
    {
        [Fact]
        public void StealSuccessTest()
        {
            //Arrange
            var mockReadLine = new Mock<ReadLineOverride>();
            mockReadLine.Setup(x => x.GetNextString()).Returns("1");
            var random = new Random();
            var mockRandom = new Mock<Random>();
            var thief = new ThiefProficiency(mockReadLine.Object, mockRandom.Object);
            var stackCardGenedratorService = new StackCardGeneratorService();
            mockRandom.Setup(x => x.Next(6)).Returns(4);
            var mockTestReadLine = new Mock<TestReadLine>();
            mockTestReadLine.Setup(x => x.GetNextString()).Returns("1");
            var drawCardService = new DrawCardService(random);
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGenedratorService);
            var userAvatar = new UserAvatar()
            {
                Proficiency = thief
            };
            var thiefChar = new UserClass()
            {
                UserAvatar = userAvatar
            };

            var readLineOverride = new ReadLineOverride();
            var mage = new MageProficiency(readLineOverride);
            var userAvatarVictim = new UserAvatar()
            {
                Proficiency = mage,
                Build = new Build()
            };
            var victim = new UserClass()
            {
                UserAvatar = userAvatarVictim
            };
            var item = new ItemCard("g", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var item2 = new ItemCard("r", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var sit1 = new ItemCard("a", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            victim.Deck.Items.Add(item);
            victim.Deck.Items.Add(item2);
            victim.Deck.Items.Add(sit1);
            //Act
            thiefChar.UserAvatar.Proficiency.StealCard(thiefChar, victim);
            //Assert
            victim.Deck.Count().Should().Be(2);
            victim.UserAvatar.WasRob.Should().BeTrue();
            thiefChar.Deck.Count().Should().Be(1);
            thief.AreYouSteal.Should().BeTrue();
        }

        [Fact]
        public void StealFailTest()
        {
            //Arrange
            var mockReadLine = new Mock<ReadLineOverride>();
            mockReadLine.Setup(x => x.GetNextString()).Returns("1");
            var random = new Random();
            var mockRandom = new Mock<Random>();
            var thief = new ThiefProficiency(mockReadLine.Object, mockRandom.Object);
            var stackCardGenedratorService = new StackCardGeneratorService();
            mockRandom.Setup(x => x.Next(6)).Returns(2);
            var mockTestReadLine = new Mock<TestReadLine>();
            mockTestReadLine.Setup(x => x.GetNextString()).Returns("1");
            var drawCardService = new DrawCardService(random);
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGenedratorService);
            var userAvatar = new UserAvatar()
            {
                Proficiency = thief
            };
            var thiefChar = new UserClass()
            {
                UserAvatar = userAvatar
            };

            var readLineOverride = new ReadLineOverride();
            var mage = new MageProficiency(readLineOverride);
            var userAvatarVictim = new UserAvatar()
            {
                Proficiency = mage,
                Build = new Build()
            };
            var victim = new UserClass()
            {
                UserAvatar = userAvatarVictim
            };
            var item = new ItemCard("g", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var item2 = new ItemCard("r", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var sit1 = new ItemCard("a", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            victim.Deck.Items.Add(item);
            victim.Deck.Items.Add(item2);
            victim.Deck.Items.Add(sit1);
            //Act
            thiefChar.UserAvatar.Proficiency.StealCard(thiefChar, victim);
            //Assert
            victim.Deck.Count().Should().Be(3);
            thiefChar.Deck.Count().Should().Be(0);
            victim.UserAvatar.WasRob.Should().BeFalse();
            thief.AreYouSteal.Should().BeTrue();
        }

        [Fact]
        public void StealTwoTimesFailTest()
        {
            //Arrange
            var mockReadLine = new Mock<ReadLineOverride>();
            mockReadLine.Setup(x => x.GetNextString()).Returns("1");
            var random = new Random();
            var mockRandom = new Mock<Random>();
            var thief = new ThiefProficiency(mockReadLine.Object, mockRandom.Object);
            var stackCardGenedratorService = new StackCardGeneratorService();
            mockRandom.Setup(x => x.Next(6)).Returns(4);
            var mockTestReadLine = new Mock<TestReadLine>();
            mockTestReadLine.Setup(x => x.GetNextString()).Returns("1");
            var drawCardService = new DrawCardService(random);
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGenedratorService);
            var userAvatar = new UserAvatar()
            {
                Proficiency = thief
            };
            var thiefChar = new UserClass()
            {
                UserAvatar = userAvatar
            };

            var readLineOverride = new ReadLineOverride();
            var mage = new MageProficiency(readLineOverride);
            var userAvatarVictim = new UserAvatar()
            {
                Proficiency = mage,
                Build = new Build()
            };
            var victim = new UserClass()
            {
                UserAvatar = userAvatarVictim
            };
            var item = new ItemCard("g", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var item2 = new ItemCard("r", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var sit1 = new ItemCard("a", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            victim.Deck.Items.Add(item);
            victim.Deck.Items.Add(item2);
            victim.Deck.Items.Add(sit1);
            //Act
            thiefChar.UserAvatar.Proficiency.StealCard(thiefChar, victim);
            thiefChar.UserAvatar.Proficiency.StealCard(thiefChar, victim);
            //Assert
            victim.Deck.Count().Should().Be(2);
            victim.UserAvatar.WasRob.Should().BeTrue();
            thiefChar.Deck.Count().Should().Be(1);
            thief.AreYouSteal.Should().BeTrue(); 
        }

        [Fact]
        public void StealTwoEnemiesFailTest()
        {
            //Arrange
            var mockReadLine = new Mock<ReadLineOverride>();
            mockReadLine.Setup(x => x.GetNextString()).Returns("1");
            var random = new Random();
            var mockRandom = new Mock<Random>();
            var thief = new ThiefProficiency(mockReadLine.Object, mockRandom.Object);
            var stackCardGenedratorService = new StackCardGeneratorService();
            mockRandom.Setup(x => x.Next(6)).Returns(4);
            var mockTestReadLine = new Mock<TestReadLine>();
            mockTestReadLine.Setup(x => x.GetNextString()).Returns("1");
            var drawCardService = new DrawCardService(random);
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGenedratorService);
            var userAvatar = new UserAvatar()
            {
                Proficiency = thief
            };
            var thiefChar = new UserClass()
            {
                UserAvatar = userAvatar
            };

            var readLineOverride = new ReadLineOverride();
            var mage = new MageProficiency(readLineOverride);
            var userAvatarVictim = new UserAvatar()
            {
                Proficiency = mage,
                Build = new Build()
            };
            var victim = new UserClass()
            {
                UserAvatar = userAvatarVictim
            };
            var userAvatarVictim2 = new UserAvatar()
            {
                Proficiency = mage,
                Build = new Build()
            };
            var victim2 = new UserClass()
            {
                UserAvatar = userAvatarVictim2
            };
            var item = new ItemCard("g", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var item2 = new ItemCard("r", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var sit1 = new ItemCard("a", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            victim.Deck.Items.Add(item);
            victim.Deck.Items.Add(item2);
            victim2.Deck.Items.Add(sit1);
            //Act
            thiefChar.UserAvatar.Proficiency.StealCard(thiefChar, victim);
            thiefChar.UserAvatar.Proficiency.StealCard(thiefChar, victim2);
            //Assert
            victim.Deck.Count().Should().Be(1);
            victim2.Deck.Count().Should().Be(1);
            victim.UserAvatar.WasRob.Should().BeTrue();
            victim2.UserAvatar.WasRob.Should().BeFalse();
            thiefChar.Deck.Count().Should().Be(1);
            thief.AreYouSteal.Should().BeTrue();
        }

        [Fact]
        public void StealTestThereAreNoItems()
        {
            //Arrange
            var mockReadLine = new Mock<ReadLineOverride>();
            mockReadLine.Setup(x => x.GetNextString()).Returns("1");
            var random = new Random();
            var mockRandom = new Mock<Random>();
            var thief = new ThiefProficiency(mockReadLine.Object, mockRandom.Object);
            var stackCardGenedratorService = new StackCardGeneratorService();
            mockRandom.Setup(x => x.Next(6)).Returns(4);
            var mockTestReadLine = new Mock<TestReadLine>();
            mockTestReadLine.Setup(x => x.GetNextString()).Returns("1");
            var drawCardService = new DrawCardService(random);
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGenedratorService);
            var userAvatar = new UserAvatar()
            {
                Proficiency = thief
            };
            var thiefChar = new UserClass()
            {
                UserAvatar = userAvatar
            };

            var readLineOverride = new ReadLineOverride();
            var mage = new MageProficiency(readLineOverride);
            var userAvatarVictim = new UserAvatar()
            {
                Proficiency = mage,
                Build = new Build()
            };
            var victim = new UserClass()
            {
                UserAvatar = userAvatarVictim
            };
            var magic = new Gambling("Gambling", CardType.Curse, random);
            var antArmy = new AntArmy("Ant Army", CardType.Monster);
            victim.Deck.MagicCards.Add(magic);
            victim.Deck.Monsters.Add(antArmy);
            //Act
            thiefChar.UserAvatar.Proficiency.StealCard(thiefChar, victim);
            //Assert
            victim.Deck.Count().Should().Be(2);
            victim.UserAvatar.WasRob.Should().BeFalse();
            thiefChar.Deck.Count().Should().Be(0);
            thief.AreYouSteal.Should().BeTrue();
        }

        [Fact]
        public void BackStabSuccessTest()
        {
            //Arrange
            var mockReadLine = new Mock<ReadLineOverride>();
            mockReadLine.Setup(x => x.GetNextString()).Returns("");
            var mockRandom = new Mock<Random>();
            mockRandom.Setup(m => m.Next(6)).Returns(4);
            var thief = new ThiefProficiency(mockReadLine.Object, mockRandom.Object);
            var avatar1 = new UserAvatar()
            {
                Proficiency = thief
            };
            var user1 = new UserClass()
            {
                UserAvatar = avatar1
            };

            var readLineOverride = new ReadLineOverride();
            var mage2 = new MageProficiency(readLineOverride);
            var avatar2 = new UserAvatar()
            {
                Proficiency = mage2
            };
            var victim = new UserClass()
            {
                UserAvatar = avatar2
            };
            //Act
            var result = user1.UserAvatar.Proficiency.BackStab(victim);
            //Assert
            result.Should().BeTrue();
            victim.UserAvatar.TempPower.Should().Be(-1);
            thief.AreYouBackStab.Should().BeTrue();
        }

        [Fact]
        public void BackStabFailTest()
        {
            //Arrange
            var mockRandom = new Mock<Random>();
            mockRandom.Setup(m => m.Next(6)).Returns(1);
            var mockReadLine = new Mock<ReadLineOverride>();
            mockReadLine.Setup(x => x.GetNextString()).Returns("");
            var thief = new ThiefProficiency(mockReadLine.Object, mockRandom.Object);
            var avatar1 = new UserAvatar()
            {
                Proficiency = thief
            };
            var user1 = new UserClass()
            {
                UserAvatar = avatar1
            };

            var readLineOverride = new ReadLineOverride();
            var mage2 = new MageProficiency(readLineOverride);
            var avatar2 = new UserAvatar()
            {
                Proficiency = mage2
            };
            var victim = new UserClass()
            {
                UserAvatar = avatar2
            };
            //Act
            var result = user1.UserAvatar.Proficiency.BackStab(victim);
            //Assert
            result.Should().BeFalse();
            victim.UserAvatar.TempPower.Should().Be(1);
            thief.AreYouBackStab.Should().BeTrue();
        }

        [Fact]
        public void BackStabFailCantTwiceTest()
        {
            //Arrange
            var mockRandom = new Mock<Random>();
            mockRandom.Setup(m => m.Next(6)).Returns(4);
            var mockReadLine = new Mock<ReadLineOverride>();
            mockReadLine.Setup(x => x.GetNextString()).Returns("");
            var thief = new ThiefProficiency(mockReadLine.Object, mockRandom.Object);
            var avatar1 = new UserAvatar()
            {
                Proficiency = thief
            };
            var user1 = new UserClass()
            {
                UserAvatar = avatar1
            };

            var readLineOverride = new ReadLineOverride();
            var mage2 = new MageProficiency(readLineOverride);
            var avatar2 = new UserAvatar()
            {
                Proficiency = mage2
            };
            var victim = new UserClass()
            {
                UserAvatar = avatar2
            };
            //Act
            var firstBackStab = user1.UserAvatar.Proficiency.BackStab(victim);
            var secondBackStab = user1.UserAvatar.Proficiency.BackStab(victim);
            //Assert
            firstBackStab.Should().BeTrue();
            secondBackStab.Should().BeFalse();
            victim.UserAvatar.TempPower.Should().Be(-1);
            thief.AreYouBackStab.Should().BeTrue();
        }

        [Fact]
        public void BackStabTwoEnemiesTest()
        {
            //Arrange
            var mockRandom = new Mock<Random>();
            mockRandom.Setup(m => m.Next(6)).Returns(4);
            var mockReadLine = new Mock<ReadLineOverride>();
            mockReadLine.Setup(x => x.GetNextString()).Returns("");
            var thief = new ThiefProficiency(mockReadLine.Object, mockRandom.Object);
            var avatar1 = new UserAvatar()
            {
                Proficiency = thief
            };
            var user1 = new UserClass()
            {
                UserAvatar = avatar1
            };

            var readLineOverride = new ReadLineOverride();
            var mage2 = new MageProficiency(readLineOverride);
            var avatar2 = new UserAvatar()
            {
                Proficiency = mage2
            };
            var victim = new UserClass()
            {
                UserAvatar = avatar2
            };
            var avatar3 = new UserAvatar()
            {
                Proficiency = mage2
            };
            var victim2 = new UserClass()
            {
                UserAvatar = avatar3
            };
            //Act
            var firstBackStab = user1.UserAvatar.Proficiency.BackStab(victim);
            var secondBackStab = user1.UserAvatar.Proficiency.BackStab(victim2);
            //Assert
            firstBackStab.Should().BeTrue();
            secondBackStab.Should().BeFalse();
            victim.UserAvatar.WasBackstab.Should().BeTrue();
            victim2.UserAvatar.WasBackstab.Should().BeFalse();
            victim.UserAvatar.TempPower.Should().Be(-1);
            thief.AreYouBackStab.Should().BeTrue();
        }
    }
}
