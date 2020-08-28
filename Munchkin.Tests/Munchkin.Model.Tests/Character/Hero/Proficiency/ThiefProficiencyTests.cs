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
using Munchkin.Model.Card.PrizeCard;
using Munchkin.Model.Character;
using Munchkin.Model.Character.Hero.Proficiency;
using Xunit;

namespace Munchkin.Tests.Munchkin.Model.Tests.Character.Hero.Proficiency
{
    public class ThiefProficiencyTests
    {
        [Fact]
        public void StealHelmetSuccessTest()
        {
            //Arrange
            var stackCardGenedratorService = new StackCardGeneratorService();
            var random = new Random();
            var mockRandom = new Mock<Random>();
            mockRandom.Setup(x => x.Next(6)).Returns(4);
            var mockTestReadLine = new Mock<TestReadLine>();
            mockTestReadLine.Setup(x => x.GetNextString()).Returns("1");
            var drawCardService = new DrawCardService(random);
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGenedratorService);
            var thief = new ThiefProficiency();
            var userAvatar = new UserAvatar()
            {
                Proficiency = thief
            };
            var thiefChar = new UserClass()
            {
                UserAvatar = userAvatar
            };

            var mage = new MageProficiency();
            var userAvatarVictim = new UserAvatar()
            {
                Proficiency = mage,
                Build = new Build()
            };
            var victim = new UserClass()
            {
                UserAvatar = userAvatarVictim
            };
            var itemToSteal = new ItemCard("leatherHelmet", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Helmet, null);
            victim.UserAvatar.Build.Helmet = itemToSteal;
            victim = prizeStackController.DrawCardsForStartDeck(victim);
            victim.Deck.Clear();
            thiefChar = prizeStackController.DrawCardsForStartDeck(thiefChar);
            thiefChar.Deck.Clear();
            //Act
            thief.StealCard(thiefChar, victim, mockRandom.Object, mockTestReadLine.Object);
            //Assert
            thiefChar.Deck.Should().HaveCount(1);
            thiefChar.Deck[0].Should().BeSameAs(itemToSteal);
            victim.UserAvatar.Build.Helmet.Should().BeNull();
        }

        [Fact]
        public void StealArmorSuccessTest()
        {
            //Arrange
            var stackCardGenedratorService = new StackCardGeneratorService();
            var random = new Random();
            var mockRandom = new Mock<Random>();
            mockRandom.Setup(x => x.Next(6)).Returns(4);
            var mockTestReadLine = new Mock<TestReadLine>();
            mockTestReadLine.Setup(x => x.GetNextString()).Returns("2");
            var drawCardService = new DrawCardService(random);
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGenedratorService);
            var thief = new ThiefProficiency();
            var userAvatar = new UserAvatar()
            {
                Proficiency = thief
            };
            var thiefChar = new UserClass()
            {
                UserAvatar = userAvatar
            };

            var mage = new MageProficiency();
            var userAvatarVictim = new UserAvatar()
            {
                Proficiency = mage,
                Build = new Build()
            };
            var victim = new UserClass()
            {
                UserAvatar = userAvatarVictim
            };
            var itemToSteal = new ItemCard("leatherArmor", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Armor, null);
            victim.UserAvatar.Build.Helmet = new ItemCard("leatherHelmet", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Helmet, null);
            victim.UserAvatar.Build.Armor = itemToSteal;
            victim = prizeStackController.DrawCardsForStartDeck(victim);
            victim.Deck.Clear();
            thiefChar = prizeStackController.DrawCardsForStartDeck(thiefChar);
            thiefChar.Deck.Clear();
            //Act
            thief.StealCard(thiefChar, victim, mockRandom.Object, mockTestReadLine.Object);
            //Assert
            thiefChar.Deck.Should().HaveCount(1);
            thiefChar.Deck[0].Should().BeSameAs(itemToSteal);
            victim.UserAvatar.Build.Helmet.Should().NotBeNull();
            victim.UserAvatar.Build.Armor.Should().BeNull();
        }

        [Fact]
        public void StealBootsSuccessTest()
        {
            //Arrange
            var stackCardGenedratorService = new StackCardGeneratorService();
            var random = new Random();
            var mockRandom = new Mock<Random>();
            mockRandom.Setup(x => x.Next(6)).Returns(4);
            var mockTestReadLine = new Mock<TestReadLine>();
            mockTestReadLine.Setup(x => x.GetNextString()).Returns("3");
            var drawCardService = new DrawCardService(random);
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGenedratorService);
            var thief = new ThiefProficiency();
            var userAvatar = new UserAvatar()
            {
                Proficiency = thief
            };
            var thiefChar = new UserClass()
            {
                UserAvatar = userAvatar
            };

            var mage = new MageProficiency();
            var userAvatarVictim = new UserAvatar()
            {
                Proficiency = mage,
                Build = new Build()
            };
            var victim = new UserClass()
            {
                UserAvatar = userAvatarVictim
            };
            var itemToSteal = new ItemCard("normalBoot", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Boots, null);
            victim.UserAvatar.Build.Helmet = new ItemCard("leatherHelmet", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Helmet, null);
            victim.UserAvatar.Build.Armor = new ItemCard("leatherArmor", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Armor, null);
            victim.UserAvatar.Build.Boots = itemToSteal;
            victim = prizeStackController.DrawCardsForStartDeck(victim);
            victim.Deck.Clear();
            thiefChar = prizeStackController.DrawCardsForStartDeck(thiefChar);
            thiefChar.Deck.Clear();
            //Act
            thief.StealCard(thiefChar, victim, mockRandom.Object, mockTestReadLine.Object);
            //Assert
            thiefChar.Deck.Should().HaveCount(1);
            thiefChar.Deck[0].Should().BeSameAs(itemToSteal);
            victim.UserAvatar.Build.Boots.Should().BeNull();
            victim.UserAvatar.Build.Helmet.Should().NotBeNull();
            victim.UserAvatar.Build.Armor.Should().NotBeNull();
        }

        [Fact]
        public void StealLeftHandItemSuccessTest()
        {
            //Arrange
            var stackCardGenedratorService = new StackCardGeneratorService();
            var random = new Random();
            var mockRandom = new Mock<Random>();
            mockRandom.Setup(x => x.Next(6)).Returns(4);
            var mockTestReadLine = new Mock<TestReadLine>();
            mockTestReadLine.Setup(x => x.GetNextString()).Returns("4");
            var drawCardService = new DrawCardService(random);
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGenedratorService);
            var thief = new ThiefProficiency();
            var userAvatar = new UserAvatar()
            {
                Proficiency = thief
            };
            var thiefChar = new UserClass()
            {
                UserAvatar = userAvatar
            };

            var mage = new MageProficiency();
            var userAvatarVictim = new UserAvatar()
            {
                Proficiency = mage,
                Build = new Build()
            };
            var victim = new UserClass()
            {
                UserAvatar = userAvatarVictim
            };
            var itemToSteal = new ItemCard("sword1H", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null);
            victim.UserAvatar.Build.Helmet = new ItemCard("leatherHelmet", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Helmet, null);
            victim.UserAvatar.Build.Armor = new ItemCard("leatherArmor", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Armor, null);
            victim.UserAvatar.Build.Boots = new ItemCard("normalBoot", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Boots, null);
            victim.UserAvatar.Build.LeftHandItem = itemToSteal;
            victim = prizeStackController.DrawCardsForStartDeck(victim);
            victim.Deck.Clear();
            thiefChar = prizeStackController.DrawCardsForStartDeck(thiefChar);
            thiefChar.Deck.Clear();
            //Act
            thief.StealCard(thiefChar, victim, mockRandom.Object, mockTestReadLine.Object);
            //Assert
            thiefChar.Deck.Should().HaveCount(1);
            thiefChar.Deck[0].Should().BeSameAs(itemToSteal);
            victim.UserAvatar.Build.LeftHandItem.Should().BeNull();
            victim.UserAvatar.Build.Helmet.Should().NotBeNull();
            victim.UserAvatar.Build.Armor.Should().NotBeNull();
            victim.UserAvatar.Build.Boots.Should().NotBeNull();

        }

        [Fact]
        public void StealRightHandItemSuccessTest()
        {
            //Arrange
            var stackCardGenedratorService = new StackCardGeneratorService();
            var random = new Random();
            var mockRandom = new Mock<Random>();
            mockRandom.Setup(x => x.Next(6)).Returns(4);
            var mockTestReadLine = new Mock<TestReadLine>();
            mockTestReadLine.Setup(x => x.GetNextString()).Returns("5");
            var drawCardService = new DrawCardService(random);
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGenedratorService);
            var thief = new ThiefProficiency();
            var userAvatar = new UserAvatar()
            {
                Proficiency = thief
            };
            var thiefChar = new UserClass()
            {
                UserAvatar = userAvatar
            };

            var mage = new MageProficiency();
            var userAvatarVictim = new UserAvatar()
            {
                Proficiency = mage,
                Build = new Build()
            };
            var victim = new UserClass()
            {
                UserAvatar = userAvatarVictim
            };
            var itemToSteal = new ItemCard("axe", CardType.Prize, PrizeCardType.Item, 3, null, true, ItemType.Weapon, null);
            victim.UserAvatar.Build.Helmet = new ItemCard("leatherHelmet", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Helmet, null);
            victim.UserAvatar.Build.Armor = new ItemCard("leatherArmor", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Armor, null);
            victim.UserAvatar.Build.Boots = new ItemCard("normalBoot", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Boots, null);
            victim.UserAvatar.Build.LeftHandItem = new ItemCard("sword1H", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null);
            victim.UserAvatar.Build.RightHandItem = itemToSteal;
            victim = prizeStackController.DrawCardsForStartDeck(victim);
            victim.Deck.Clear();
            thiefChar = prizeStackController.DrawCardsForStartDeck(thiefChar);
            thiefChar.Deck.Clear();
            //Act
            thief.StealCard(thiefChar, victim, mockRandom.Object, mockTestReadLine.Object);
            //Assert
            thiefChar.Deck.Should().HaveCount(1);
            thiefChar.Deck[0].Should().BeSameAs(itemToSteal);
            victim.UserAvatar.Build.RightHandItem.Should().BeNull();
            victim.UserAvatar.Build.Helmet.Should().NotBeNull();
            victim.UserAvatar.Build.Armor.Should().NotBeNull();
            victim.UserAvatar.Build.Boots.Should().NotBeNull();
            victim.UserAvatar.Build.LeftHandItem.Should().NotBeNull();
        }

        [Fact]
        public void StealAdditionalItemSuccessTest()
        {
            //Arrange
            var stackCardGenedratorService = new StackCardGeneratorService();
            var random = new Random();
            var mockRandom = new Mock<Random>();
            mockRandom.Setup(x => x.Next(6)).Returns(4);
            var mockTestReadLine = new Mock<TestReadLine>();
            mockTestReadLine.Setup(x => x.GetNextString()).Returns("7");
            var drawCardService = new DrawCardService(random);
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGenedratorService);
            var thief = new ThiefProficiency();
            var userAvatar = new UserAvatar()
            {
                Proficiency = thief
            };
            var thiefChar = new UserClass()
            {
                UserAvatar = userAvatar
            };

            var mage = new MageProficiency();
            var userAvatarVictim = new UserAvatar()
            {
                Proficiency = mage,
                Build = new Build()
            };
            var victim = new UserClass()
            {
                UserAvatar = userAvatarVictim
            };
            var itemToSteal = new ItemCard("manaPotion", CardType.Prize, PrizeCardType.Additional, 2, null, false, ItemType.Additional, null);
            victim.UserAvatar.Build.Helmet = new ItemCard("leatherHelmet", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Helmet, null);
            victim.UserAvatar.Build.Armor = new ItemCard("leatherArmor", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Armor, null);
            victim.UserAvatar.Build.Boots = new ItemCard("normalBoot", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Boots, null);
            victim.UserAvatar.Build.LeftHandItem = new ItemCard("sword1H", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null);
            victim.UserAvatar.Build.RightHandItem = new ItemCard("axe", CardType.Prize, PrizeCardType.Item, 3, null, true, ItemType.Weapon, null); ;
            victim.UserAvatar.Build.AdditionalItems = new List<ItemCard>()
            {
                new ItemCard("healthPotion", CardType.Prize, PrizeCardType.Additional, 4, null, false, ItemType.Additional, null),
                itemToSteal,
                new ItemCard("testItem", CardType.Prize, PrizeCardType.Additional, 1, null, false, ItemType.Additional, null),
                new ItemCard("something", CardType.Prize, PrizeCardType.Additional, 0, null, false, ItemType.Additional, null),
            };
            victim = prizeStackController.DrawCardsForStartDeck(victim);
            victim.Deck.Clear();
            thiefChar = prizeStackController.DrawCardsForStartDeck(thiefChar);
            thiefChar.Deck.Clear();
            //Act
            thief.StealCard(thiefChar, victim, mockRandom.Object, mockTestReadLine.Object);
            //Assert
            thiefChar.Deck.Should().HaveCount(1);
            thiefChar.Deck[0].Should().BeSameAs(itemToSteal);
            victim.UserAvatar.Build.RightHandItem.Should().NotBeNull();
            victim.UserAvatar.Build.Helmet.Should().NotBeNull();
            victim.UserAvatar.Build.Armor.Should().NotBeNull();
            victim.UserAvatar.Build.Boots.Should().NotBeNull();
            victim.UserAvatar.Build.LeftHandItem.Should().NotBeNull();
            victim.UserAvatar.Build.AdditionalItems.Should().HaveCount(3);
        }

        [Fact]
        public void StealFailTest()
        {
            //Arrange
            var stackCardGenedratorService = new StackCardGeneratorService();
            var random = new Random();
            var mockRandom = new Mock<Random>();
            mockRandom.Setup(x => x.Next(6)).Returns(3);
            var mockTestReadLine = new Mock<TestReadLine>();
            mockTestReadLine.Setup(x => x.GetNextString()).Returns("1");
            var drawCardService = new DrawCardService(random);
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGenedratorService);
            var thief = new ThiefProficiency();
            var userAvatar = new UserAvatar()
            {
                Proficiency = thief
            };
            var thiefChar = new UserClass()
            {
                UserAvatar = userAvatar
            };

            var mage = new MageProficiency();
            var userAvatarVictim = new UserAvatar()
            {
                Proficiency = mage,
                Build = new Build()
            };
            var victim = new UserClass()
            {
                UserAvatar = userAvatarVictim
            };
            var itemToSteal = new ItemCard("leatherHelmet", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Helmet, null);
            victim.UserAvatar.Build.Helmet = itemToSteal;
            victim = prizeStackController.DrawCardsForStartDeck(victim);
            victim.Deck.Clear();
            thiefChar = prizeStackController.DrawCardsForStartDeck(thiefChar);
            thiefChar.Deck.Clear();
            //Act
            thief.StealCard(thiefChar, victim, mockRandom.Object, mockTestReadLine.Object);
            //Assert
            thiefChar.Deck.Should().HaveCount(0);
            victim.UserAvatar.Build.Helmet.Should().BeSameAs(itemToSteal);
            victim.UserAvatar.WasRob.Should().BeTrue();
        }


        [Fact]
        public void StealTwoTimesTest()
        {
            //Arrange
            var stackCardGenedratorService = new StackCardGeneratorService();
            var random = new Random();
            var mockRandom = new Mock<Random>();
            mockRandom.Setup(x => x.Next(6)).Returns(4);
            var mockTestReadLine = new Mock<TestReadLine>();
            mockTestReadLine.Setup(x => x.GetNextString()).Returns("1");
            var drawCardService = new DrawCardService(random);
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGenedratorService);
            var thief = new ThiefProficiency();
            var userAvatar = new UserAvatar()
            {
                Proficiency = thief
            };
            var thiefChar = new UserClass()
            {
                UserAvatar = userAvatar
            };

            var mage = new MageProficiency();
            var userAvatarVictim = new UserAvatar()
            {
                Proficiency = mage,
                Build = new Build()
            };
            var victim = new UserClass()
            {
                UserAvatar = userAvatarVictim
            };
            var itemToSteal = new ItemCard("leatherHelmet", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Helmet, null);
            var secondItem = new ItemCard("leatherArmor", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Armor, null);
            victim.UserAvatar.Build.Helmet = itemToSteal;
            victim.UserAvatar.Build.Armor = secondItem;
            victim = prizeStackController.DrawCardsForStartDeck(victim);
            victim.Deck.Clear();
            thiefChar = prizeStackController.DrawCardsForStartDeck(thiefChar);
            thiefChar.Deck.Clear();
            //Act
            thief.StealCard(thiefChar, victim, mockRandom.Object, mockTestReadLine.Object);
            thief.StealCard(thiefChar, victim, mockRandom.Object, mockTestReadLine.Object);
            //Assert
            thiefChar.Deck.Should().HaveCount(1);
            thiefChar.Deck[0].Should().BeSameAs(itemToSteal);
            victim.UserAvatar.Build.Helmet.Should().BeNull();
            victim.UserAvatar.Build.Armor.Should().BeSameAs(secondItem);
            victim.UserAvatar.WasRob.Should().BeTrue();
        }

        [Fact]
        public void BackStabSuccessTest()
        {
            //Arrange
            var mockRandom = new Mock<Random>();
            mockRandom.Setup(m => m.Next(6)).Returns(4);
            var thief = new ThiefProficiency();
            var avatar1 = new UserAvatar()
            {
                Proficiency = thief
            };
            var user1 = new UserClass()
            {
                UserAvatar = avatar1
            };

            var mage2 = new MageProficiency();
            var avatar2 = new UserAvatar()
            {
                Proficiency = mage2
            };
            var victim = new UserClass()
            {
                UserAvatar = avatar2
            };
            //Act
            var result = user1.UserAvatar.Proficiency.BackStab(victim, mockRandom.Object);
            //Assert
            result.Should().BeTrue();
            victim.UserAvatar.TempPower.Should().Be(-1);
        }

        [Fact]
        public void BackStabFailTest()
        {
            //Arrange
            var mockRandom = new Mock<Random>();
            mockRandom.Setup(m => m.Next(6)).Returns(1);
            var thief = new ThiefProficiency();
            var avatar1 = new UserAvatar()
            {
                Proficiency = thief
            };
            var user1 = new UserClass()
            {
                UserAvatar = avatar1
            };

            var mage2 = new MageProficiency();
            var avatar2 = new UserAvatar()
            {
                Proficiency = mage2
            };
            var victim = new UserClass()
            {
                UserAvatar = avatar2
            };
            //Act
            var result = user1.UserAvatar.Proficiency.BackStab(victim, mockRandom.Object);
            //Assert
            result.Should().BeFalse();
            victim.UserAvatar.TempPower.Should().Be(1);
        }

        [Fact]
        public void BackStabFailCantTwiceTest()
        {
            //Arrange
            var mockRandom = new Mock<Random>();
            mockRandom.Setup(m => m.Next(6)).Returns(4);
            var thief = new ThiefProficiency();
            var avatar1 = new UserAvatar()
            {
                Proficiency = thief
            };
            var user1 = new UserClass()
            {
                UserAvatar = avatar1
            };

            var mage2 = new MageProficiency();
            var avatar2 = new UserAvatar()
            {
                Proficiency = mage2
            };
            var victim = new UserClass()
            {
                UserAvatar = avatar2
            };
            //Act
            var firstBackStab = user1.UserAvatar.Proficiency.BackStab(victim, mockRandom.Object);
            var secondBackStab = user1.UserAvatar.Proficiency.BackStab(victim, mockRandom.Object);
            //Assert
            firstBackStab.Should().BeTrue();
            secondBackStab.Should().BeFalse();
            victim.UserAvatar.TempPower.Should().Be(-1);
        }
    }

    public class TestReadLine : ReadLineOverride
    {
        public override string GetNextString()
        {
            return "";
        }
    }
}
