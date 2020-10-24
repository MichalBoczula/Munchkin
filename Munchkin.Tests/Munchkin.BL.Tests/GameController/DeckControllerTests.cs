using FluentAssertions;
using Moq;
using Munchkin.BL.GameController;
using Munchkin.BL.Helper;
using Munchkin.Model;
using Munchkin.Model.Card.PrizeCard;
using Munchkin.Model.Character;
using Munchkin.Model.Character.Hero.Proficiency;
using Munchkin.Model.Character.Hero.Race;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Munchkin.Tests.Munchkin.BL.Tests.GameController
{
    public class DeckControllerTests
    {
        #region AdditionalCard
        [Fact]
        public void UseCardItemCardTestRaceFalseDiffrentRace()
        {
            //Arrange
            var mockReadLineOverride = new Mock<ReadLineOverride>();
            mockReadLineOverride.Setup(x => x.GetNextString()).Returns("1");
            var deckController = new DeckController(mockReadLineOverride.Object);
            var userAvatar = new UserAvatar()
            {
                Race = new Human("Human")
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var cyberCoat = new Dictionary<bool, RaceBase>
            {
                { false, new Elf("elf") }
            };
            ItemCard card = new ItemCard("CyberCoat", CardType.Prize, PrizeCardType.Item, 2, cyberCoat, false, ItemType.Additional, null, 300);
            //Act
            deckController.UseCardItemCard(user, card, null);
            //Assert
            user.UserAvatar.Build.AdditionalItems.Should().HaveCount(1);
            user.UserAvatar.Build.AdditionalItems[0].Should().BeSameAs(card);
        }

        [Fact]
        public void UseCardItemCardTestRaceFalseSameRace()
        {
            //Arrange
            var mockReadLineOverride = new Mock<ReadLineOverride>();
            mockReadLineOverride.Setup(x => x.GetNextString()).Returns("1");
            var deckController = new DeckController(mockReadLineOverride.Object);
            var userAvatar = new UserAvatar()
            {
                Race = new Elf("elf")
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var cyberCoat = new Dictionary<bool, RaceBase>
            {
                { false, new Elf("elf") }
            };
            ItemCard card = new ItemCard("CyberCoat", CardType.Prize, PrizeCardType.Item, 2, cyberCoat, false, ItemType.Additional, null, 300);
            //Act
            deckController.UseCardItemCard(user, card, null);
            //Assert
            user.UserAvatar.Build.AdditionalItems.Should().HaveCount(0);
        }

        [Fact]
        public void UseCardItemCardTestRaceTrueDiffrentRace()
        {
            //Arrange
            var mockReadLineOverride = new Mock<ReadLineOverride>();
            mockReadLineOverride.Setup(x => x.GetNextString()).Returns("1");
            var deckController = new DeckController(mockReadLineOverride.Object);
            var userAvatar = new UserAvatar()
            {
                Race = new Human("Human")
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var cyberCoat = new Dictionary<bool, RaceBase>
            {
                { true, new Elf("elf") }
            };
            ItemCard card = new ItemCard("CyberCoat", CardType.Prize, PrizeCardType.Item, 2, cyberCoat, false, ItemType.Additional, null, 300);
            //Act
            deckController.UseCardItemCard(user, card, null);
            //Assert
            user.UserAvatar.Build.AdditionalItems.Should().HaveCount(0);
        }

        [Fact]
        public void UseCardItemCardTestRaceTrueSameRace()
        {
            //Arrange
            var mockReadLineOverride = new Mock<ReadLineOverride>();
            mockReadLineOverride.Setup(x => x.GetNextString()).Returns("1");
            var deckController = new DeckController(mockReadLineOverride.Object);
            var userAvatar = new UserAvatar()
            {
                Race = new Elf("elf")
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var cyberCoat = new Dictionary<bool, RaceBase>
            {
                { true, new Elf("elf") }
            };
            ItemCard card = new ItemCard("CyberCoat", CardType.Prize, PrizeCardType.Item, 2, cyberCoat, false, ItemType.Additional, null, 300);
            //Act
            deckController.UseCardItemCard(user, card, null);
            //Assert
            user.UserAvatar.Build.AdditionalItems.Should().HaveCount(1);
            user.UserAvatar.Build.AdditionalItems[0].Should().BeSameAs(card);
        }

        [Fact]
        public void UseCardItemCardTestProficiencyTrueSameProficiency()
        {
            //Arrange
            var mockReadLineOverride = new Mock<ReadLineOverride>();
            mockReadLineOverride.Setup(x => x.GetNextString()).Returns("1");
            var deckController = new DeckController(mockReadLineOverride.Object);
            var userAvatar = new UserAvatar()
            {
                Proficiency = new WarriorProficiency()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var betterDefenceSpray = new Dictionary<bool, ProficiencyBase>
            {
                { true, new WarriorProficiency() }
            };
            ItemCard card = new ItemCard("BetterDefenceSpray", CardType.Prize, PrizeCardType.Item, 4, null, false, ItemType.Additional, betterDefenceSpray, 400);
            //Act
            deckController.UseCardItemCard(user, card, null);
            //Assert
            user.UserAvatar.Build.AdditionalItems.Should().HaveCount(1);
            user.UserAvatar.Build.AdditionalItems[0].Should().BeSameAs(card);
        }

        [Fact]
        public void UseCardItemCardTestProficiencyFalseSameProficiency()
        {
            //Arrange
            var mockReadLineOverride = new Mock<ReadLineOverride>();
            mockReadLineOverride.Setup(x => x.GetNextString()).Returns("1");
            var deckController = new DeckController(mockReadLineOverride.Object);
            var userAvatar = new UserAvatar()
            {
                Proficiency = new WarriorProficiency()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var betterDefenceSpray = new Dictionary<bool, ProficiencyBase>
            {
                { false, new WarriorProficiency() }
            };
            ItemCard card = new ItemCard("BetterDefenceSpray", CardType.Prize, PrizeCardType.Item, 4, null, false, ItemType.Additional, betterDefenceSpray, 400);
            //Act
            deckController.UseCardItemCard(user, card, null);
            //Assert
            user.UserAvatar.Build.AdditionalItems.Should().HaveCount(0);
        }

        [Fact]
        public void UseCardItemCardTestProficiencyTrueDiffrentProficiency()
        {
            //Arrange
            var mockReadLineOverride = new Mock<ReadLineOverride>();
            mockReadLineOverride.Setup(x => x.GetNextString()).Returns("1");
            var deckController = new DeckController(mockReadLineOverride.Object);
            var userAvatar = new UserAvatar()
            {
                Proficiency = new MageProficiency()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var betterDefenceSpray = new Dictionary<bool, ProficiencyBase>
            {
                { true, new WarriorProficiency() }
            };
            ItemCard card = new ItemCard("BetterDefenceSpray", CardType.Prize, PrizeCardType.Item, 4, null, false, ItemType.Additional, betterDefenceSpray, 400);
            //Act
            deckController.UseCardItemCard(user, card, null);
            //Assert
            user.UserAvatar.Build.AdditionalItems.Should().HaveCount(0);
        }

        [Fact]
        public void UseCardItemCardTestProficiencyFalseDiffrentProficiency()
        {
            //Arrange
            var mockReadLineOverride = new Mock<ReadLineOverride>();
            mockReadLineOverride.Setup(x => x.GetNextString()).Returns("1");
            var deckController = new DeckController(mockReadLineOverride.Object);
            var userAvatar = new UserAvatar()
            {
                Proficiency = new MageProficiency()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var betterDefenceSpray = new Dictionary<bool, ProficiencyBase>
            {
                { false, new WarriorProficiency() }
            };
            ItemCard card = new ItemCard("BetterDefenceSpray", CardType.Prize, PrizeCardType.Item, 4, null, false, ItemType.Additional, betterDefenceSpray, 400);
            //Act
            deckController.UseCardItemCard(user, card, null);
            //Assert
            user.UserAvatar.Build.AdditionalItems.Should().HaveCount(1);
            user.UserAvatar.Build.AdditionalItems[0].Should().BeSameAs(card);
        }
        #endregion

        #region ChackRestriction
        [Fact]
        public void CheckRestrictionRaceTrueSameRace()
        {
            //Arrange
            var mockReadLineOverride = new Mock<ReadLineOverride>();
            var userAvatar = new UserAvatar()
            {
                Race = new Elf("elf")
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var cyberCoat = new Dictionary<bool, RaceBase>
            {
                { true, new Elf("elf") }
            };
            ItemCard card = new ItemCard("CyberCoat", CardType.Prize, PrizeCardType.Item, 2, cyberCoat, false, ItemType.Additional, null, 300);
            var deckController = new DeckController(mockReadLineOverride.Object);
            //Act
            var result = deckController.CheckRestriction(user, card);
            //Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void CheckRestrictionRaceTrueDiffrentRace()
        {
            //Arrange
            var mockReadLineOverride = new Mock<ReadLineOverride>();
            var userAvatar = new UserAvatar()
            {
                Race = new Human("human")
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var cyberCoat = new Dictionary<bool, RaceBase>
            {
                { true, new Elf("elf") }
            };
            ItemCard card = new ItemCard("CyberCoat", CardType.Prize, PrizeCardType.Item, 2, cyberCoat, false, ItemType.Additional, null, 300);
            var deckController = new DeckController(mockReadLineOverride.Object);
            //Act
            var result = deckController.CheckRestriction(user, card);
            //Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void CheckRestrictionRaceFalseSameRace()
        {
            //Arrange
            var mockReadLineOverride = new Mock<ReadLineOverride>();
            var userAvatar = new UserAvatar()
            {
                Race = new Elf("elf")
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var cyberCoat = new Dictionary<bool, RaceBase>
            {
                { false, new Elf("elf") }
            };
            ItemCard card = new ItemCard("CyberCoat", CardType.Prize, PrizeCardType.Item, 2, cyberCoat, false, ItemType.Additional, null, 300);
            var deckController = new DeckController(mockReadLineOverride.Object);
            //Act
            var result = deckController.CheckRestriction(user, card);
            //Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void CheckRestrictionRaceFalseDiffrentRace()
        {
            //Arrange
            var mockReadLineOverride = new Mock<ReadLineOverride>();
            var userAvatar = new UserAvatar()
            {
                Race = new Human("human")
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var cyberCoat = new Dictionary<bool, RaceBase>
            {
                { false, new Elf("elf") }
            };
            ItemCard card = new ItemCard("CyberCoat", CardType.Prize, PrizeCardType.Item, 2, cyberCoat, false, ItemType.Additional, null, 300);
            var deckController = new DeckController(mockReadLineOverride.Object);
            //Act
            var result = deckController.CheckRestriction(user, card);
            //Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void CheckRestrictionProficiencyTrueSameProficiency()
        {
            //Arrange
            var mockReadLineOverride = new Mock<ReadLineOverride>();
            var userAvatar = new UserAvatar()
            {
                Proficiency = new WarriorProficiency()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var cyberCoat = new Dictionary<bool, ProficiencyBase>
            {
                { true, new WarriorProficiency() }
            };
            ItemCard card = new ItemCard("CyberCoat", CardType.Prize, PrizeCardType.Item, 2, null, false, ItemType.Additional, cyberCoat, 300);
            var deckController = new DeckController(mockReadLineOverride.Object);
            //Act
            var result = deckController.CheckRestriction(user, card);
            //Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void CheckRestrictionProficiencyTrueDiffrentProficiency()
        {
            //Arrange
            var mockReadLineOverride = new Mock<ReadLineOverride>();
            var userAvatar = new UserAvatar()
            {
                Proficiency = new MageProficiency()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var cyberCoat = new Dictionary<bool, ProficiencyBase>
            {
                { true, new WarriorProficiency() }
            };
            ItemCard card = new ItemCard("CyberCoat", CardType.Prize, PrizeCardType.Item, 2, null, false, ItemType.Additional, cyberCoat, 300);
            var deckController = new DeckController(mockReadLineOverride.Object);
            //Act
            var result = deckController.CheckRestriction(user, card);
            //Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void CheckRestrictionProficiencyFalseSameProficiency()
        {
            //Arrange
            var mockReadLineOverride = new Mock<ReadLineOverride>();
            var userAvatar = new UserAvatar()
            {
                Proficiency = new WarriorProficiency()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var cyberCoat = new Dictionary<bool, ProficiencyBase>
            {
                { false, new WarriorProficiency() }
            };
            ItemCard card = new ItemCard("CyberCoat", CardType.Prize, PrizeCardType.Item, 2, null, false, ItemType.Additional, cyberCoat, 300);
            var deckController = new DeckController(mockReadLineOverride.Object);
            //Act
            var result = deckController.CheckRestriction(user, card);
            //Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void CheckRestrictionProficiencyFalseDiffrentProficiency()
        {
            //Arrange
            var mockReadLineOverride = new Mock<ReadLineOverride>();
            var userAvatar = new UserAvatar()
            {
                Proficiency = new NoOneProficiency()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var cyberCoat = new Dictionary<bool, ProficiencyBase>
            {
                { false, new WarriorProficiency() }
            };
            ItemCard card = new ItemCard("CyberCoat", CardType.Prize, PrizeCardType.Item, 2, null, false, ItemType.Additional, cyberCoat, 300);
            var deckController = new DeckController(mockReadLineOverride.Object);
            //Act
            var result = deckController.CheckRestriction(user, card);
            //Assert
            result.Should().BeTrue();
        }
        #endregion
    }
}