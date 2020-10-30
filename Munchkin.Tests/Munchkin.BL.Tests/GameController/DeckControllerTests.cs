using FluentAssertions;
using Moq;
using Munchkin.BL.GameController;
using Munchkin.BL.Helper;
using Munchkin.Model;
using Munchkin.Model.Card.ActionCard.SpecialCardType.MagicCards;
using Munchkin.Model.Card.PrizeCard;
using Munchkin.Model.Card.PrizeCard.SituationalItems;
using Munchkin.Model.Character;
using Munchkin.Model.Character.Hero.Proficiency;
using Munchkin.Model.Character.Hero.Race;
using Munchkin.Model.User;
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
            deckController.UseItemCard(user, card, null);
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
            deckController.UseItemCard(user, card, null);
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
            deckController.UseItemCard(user, card, null);
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
            deckController.UseItemCard(user, card, null);
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
                Proficiency = new WarriorProficiency(mockReadLineOverride.Object)
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var betterDefenceSpray = new Dictionary<bool, ProficiencyBase>
            {
                { true, new WarriorProficiency(mockReadLineOverride.Object) }
            };
            ItemCard card = new ItemCard("BetterDefenceSpray", CardType.Prize, PrizeCardType.Item, 4, null, false, ItemType.Additional, betterDefenceSpray, 400);
            //Act
            deckController.UseItemCard(user, card, null);
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
                Proficiency = new WarriorProficiency(mockReadLineOverride.Object)
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var betterDefenceSpray = new Dictionary<bool, ProficiencyBase>
            {
                { false, new WarriorProficiency(mockReadLineOverride.Object) }
            };
            ItemCard card = new ItemCard("BetterDefenceSpray", CardType.Prize, PrizeCardType.Item, 4, null, false, ItemType.Additional, betterDefenceSpray, 400);
            //Act
            deckController.UseItemCard(user, card, null);
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
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var mage = new MageProficiency(mock.Object);
            var userAvatar = new UserAvatar()
            {
                Proficiency = mage
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var betterDefenceSpray = new Dictionary<bool, ProficiencyBase>
            {
                { true, new WarriorProficiency(mockReadLineOverride.Object) }
            };
            ItemCard card = new ItemCard("BetterDefenceSpray", CardType.Prize, PrizeCardType.Item, 4, null, false, ItemType.Additional, betterDefenceSpray, 400);
            //Act
            deckController.UseItemCard(user, card, null);
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
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var mage = new MageProficiency(mock.Object);
            var userAvatar = new UserAvatar()
            {
                Proficiency = mage
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var betterDefenceSpray = new Dictionary<bool, ProficiencyBase>
            {
                { false, new WarriorProficiency(mockReadLineOverride.Object) }
            };
            ItemCard card = new ItemCard("BetterDefenceSpray", CardType.Prize, PrizeCardType.Item, 4, null, false, ItemType.Additional, betterDefenceSpray, 400);
            //Act
            deckController.UseItemCard(user, card, null);
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
            mockReadLineOverride.Setup(x => x.GetNextString()).Returns("1");
            var userAvatar = new UserAvatar()
            {
                Proficiency = new WarriorProficiency(mockReadLineOverride.Object)
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var cyberCoat = new Dictionary<bool, ProficiencyBase>
            {
                { true, new WarriorProficiency(mockReadLineOverride.Object) }
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
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var mage = new MageProficiency(mock.Object);
            var userAvatar = new UserAvatar()
            {
                Proficiency = mage
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var cyberCoat = new Dictionary<bool, ProficiencyBase>
            {
                { true, new WarriorProficiency(mock.Object) }
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
            mockReadLineOverride.Setup(x => x.GetNextString()).Returns("1");
            var userAvatar = new UserAvatar()
            {
                Proficiency = new WarriorProficiency(mockReadLineOverride.Object)
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var cyberCoat = new Dictionary<bool, ProficiencyBase>
            {
                { false, new WarriorProficiency(mockReadLineOverride.Object) }
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
            mockReadLineOverride.Setup(x => x.GetNextString()).Returns("1");
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
                { false, new WarriorProficiency(mockReadLineOverride.Object) }
            };
            ItemCard card = new ItemCard("CyberCoat", CardType.Prize, PrizeCardType.Item, 2, null, false, ItemType.Additional, cyberCoat, 300);
            var deckController = new DeckController(mockReadLineOverride.Object);
            //Act
            var result = deckController.CheckRestriction(user, card);
            //Assert
            result.Should().BeTrue();
        }
        #endregion

        #region UseCardItemCard
        [Fact]
        public void UseCardItemCardHelmetNullPathWithoutRestriction()
        {
            //Arrange
            var mockReadLineOverride = new Mock<ReadLineOverride>();
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            ItemCard card = new ItemCard("CyberHelment", CardType.Prize, PrizeCardType.Item, 2, null, false, ItemType.Helmet, null, 300);
            user.Deck.Items.Add(card);
            var deckController = new DeckController(mockReadLineOverride.Object);
            //Act
            deckController.UseItemCard(user, card, null);
            //Assert
            user.UserAvatar.Build.Helmet.Should().BeSameAs(card);
            user.Deck.Items.Should().BeEmpty();
        }

        [Fact]
        public void UseCardItemCardHelmetNullPathWithRestriction()
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
            ItemCard card = new ItemCard("CyberHelment", CardType.Prize, PrizeCardType.Item, 2, cyberCoat, false, ItemType.Helmet, null, 300);
            user.Deck.Items.Add(card);
            var deckController = new DeckController(mockReadLineOverride.Object);
            //Act
            deckController.UseItemCard(user, card, null);
            //Assert
            user.UserAvatar.Build.Helmet.Should().BeNull();
            user.Deck.Items.Should().HaveCount(1);
            user.Deck.Items[0].Should().BeSameAs(card);
        }

        [Fact]
        public void UseCardItemCardHelmetChangePathChangeItems()
        {
            //Arrange
            var mockReadLineOverride = new Mock<ReadLineOverride>();
            mockReadLineOverride.Setup(x => x.GetNextString()).Returns("1");
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
            ItemCard card = new ItemCard("CyberHelment", CardType.Prize, PrizeCardType.Item, 2, cyberCoat, false, ItemType.Helmet, null, 300);
            ItemCard oldHelmet = new ItemCard("OldHelmet", CardType.Prize, PrizeCardType.Item, 2, cyberCoat, false, ItemType.Helmet, null, 300);
            user.UserAvatar.Build.Helmet = oldHelmet;
            user.Deck.Items.Add(card);
            var deckController = new DeckController(mockReadLineOverride.Object);
            //Act
            deckController.UseItemCard(user, card, null);
            //Assert
            user.UserAvatar.Build.Helmet.Should().BeSameAs(card);
            user.Deck.Items.Should().HaveCount(1);
            user.Deck.Items[0].Should().BeSameAs(oldHelmet);
        }

        [Fact]
        public void UseCardItemCardHelmetChangePathDoNothing()
        {
            //Arrange
            var mockReadLineOverride = new Mock<ReadLineOverride>();
            mockReadLineOverride.Setup(x => x.GetNextString()).Returns("2");
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
            ItemCard card = new ItemCard("CyberHelment", CardType.Prize, PrizeCardType.Item, 2, cyberCoat, false, ItemType.Helmet, null, 300);
            ItemCard oldHelmet = new ItemCard("OldHelmet", CardType.Prize, PrizeCardType.Item, 2, cyberCoat, false, ItemType.Helmet, null, 300);
            user.UserAvatar.Build.Helmet = oldHelmet;
            user.Deck.Items.Add(card);
            var deckController = new DeckController(mockReadLineOverride.Object);
            //Act
            deckController.UseItemCard(user, card, null);
            //Assert
            user.UserAvatar.Build.Helmet.Should().BeSameAs(oldHelmet);
            user.Deck.Items.Should().HaveCount(1);
            user.Deck.Items[0].Should().BeSameAs(card);
        }

        [Fact]
        public void UseCardItemCardArmorNullPathWithoutRestriction()
        {
            //Arrange
            var mockReadLineOverride = new Mock<ReadLineOverride>();
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            ItemCard card = new ItemCard("CyberArmor", CardType.Prize, PrizeCardType.Item, 2, null, false, ItemType.Armor, null, 300);
            user.Deck.Items.Add(card);
            var deckController = new DeckController(mockReadLineOverride.Object);
            //Act
            deckController.UseItemCard(user, card, null);
            //Assert
            user.UserAvatar.Build.Armor.Should().BeSameAs(card);
            user.Deck.Items.Should().BeEmpty();
        }

        [Fact]
        public void UseCardItemCardArmorNullPathWithRestriction()
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
            ItemCard card = new ItemCard("CyberArmor", CardType.Prize, PrizeCardType.Item, 2, cyberCoat, false, ItemType.Armor, null, 300);
            user.Deck.Items.Add(card);
            var deckController = new DeckController(mockReadLineOverride.Object);
            //Act
            deckController.UseItemCard(user, card, null);
            //Assert
            user.UserAvatar.Build.Armor.Should().BeNull();
            user.Deck.Items.Should().HaveCount(1);
            user.Deck.Items[0].Should().BeSameAs(card);
        }

        [Fact]
        public void UseCardItemCardArmorChangePathChangeItems()
        {
            //Arrange
            var mockReadLineOverride = new Mock<ReadLineOverride>();
            mockReadLineOverride.Setup(x => x.GetNextString()).Returns("1");
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
            ItemCard card = new ItemCard("CyberArmor", CardType.Prize, PrizeCardType.Item, 2, cyberCoat, false, ItemType.Armor, null, 300);
            ItemCard oldArmor = new ItemCard("OldArmor", CardType.Prize, PrizeCardType.Item, 2, cyberCoat, false, ItemType.Armor, null, 300);
            user.UserAvatar.Build.Armor = oldArmor;
            user.Deck.Items.Add(card);
            var deckController = new DeckController(mockReadLineOverride.Object);
            //Act
            deckController.UseItemCard(user, card, null);
            //Assert
            user.UserAvatar.Build.Armor.Should().BeSameAs(card);
            user.Deck.Items.Should().HaveCount(1);
            user.Deck.Items[0].Should().BeSameAs(oldArmor);
        }

        [Fact]
        public void UseCardItemCardArmorChangePathDoNothing()
        {
            //Arrange
            var mockReadLineOverride = new Mock<ReadLineOverride>();
            mockReadLineOverride.Setup(x => x.GetNextString()).Returns("2");
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
            ItemCard card = new ItemCard("CyberArmor", CardType.Prize, PrizeCardType.Item, 2, cyberCoat, false, ItemType.Armor, null, 300);
            ItemCard oldArmor = new ItemCard("OldArmor", CardType.Prize, PrizeCardType.Item, 2, cyberCoat, false, ItemType.Armor, null, 300);
            user.UserAvatar.Build.Armor = oldArmor;
            user.Deck.Items.Add(card);
            var deckController = new DeckController(mockReadLineOverride.Object);
            //Act
            deckController.UseItemCard(user, card, null);
            //Assert
            user.UserAvatar.Build.Armor.Should().BeSameAs(oldArmor);
            user.Deck.Items.Should().HaveCount(1);
            user.Deck.Items[0].Should().BeSameAs(card);
        }

        [Fact]
        public void UseCardItemCardBootsNullPathWithoutRestriction()
        {
            //Arrange
            var mockReadLineOverride = new Mock<ReadLineOverride>();
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            ItemCard card = new ItemCard("CyberBoots", CardType.Prize, PrizeCardType.Item, 2, null, false, ItemType.Boots, null, 300);
            user.Deck.Items.Add(card);
            var deckController = new DeckController(mockReadLineOverride.Object);
            //Act
            deckController.UseItemCard(user, card, null);
            //Assert
            user.UserAvatar.Build.Boots.Should().BeSameAs(card);
            user.Deck.Items.Should().BeEmpty();
        }

        [Fact]
        public void UseCardItemCardBootsNullPathWithRestriction()
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
            ItemCard card = new ItemCard("CyberBoots", CardType.Prize, PrizeCardType.Item, 2, cyberCoat, false, ItemType.Boots, null, 300);
            user.Deck.Items.Add(card);
            var deckController = new DeckController(mockReadLineOverride.Object);
            //Act
            deckController.UseItemCard(user, card, null);
            //Assert
            user.UserAvatar.Build.Boots.Should().BeNull();
            user.Deck.Items.Should().HaveCount(1);
            user.Deck.Items[0].Should().BeSameAs(card);
        }

        [Fact]
        public void UseCardItemCardBootsChangePathChangeItems()
        {
            //Arrange
            var mockReadLineOverride = new Mock<ReadLineOverride>();
            mockReadLineOverride.Setup(x => x.GetNextString()).Returns("1");
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
            ItemCard card = new ItemCard("CyberBoots", CardType.Prize, PrizeCardType.Item, 2, cyberCoat, false, ItemType.Boots, null, 300);
            ItemCard oldBoots = new ItemCard("OldBoots", CardType.Prize, PrizeCardType.Item, 2, cyberCoat, false, ItemType.Boots, null, 300);
            user.UserAvatar.Build.Boots = oldBoots;
            user.Deck.Items.Add(card);
            var deckController = new DeckController(mockReadLineOverride.Object);
            //Act
            deckController.UseItemCard(user, card, null);
            //Assert
            user.UserAvatar.Build.Boots.Should().BeSameAs(card);
            user.Deck.Items.Should().HaveCount(1);
            user.Deck.Items[0].Should().BeSameAs(oldBoots);
        }

        [Fact]
        public void UseCardItemCardBootsChangePathDoNothing()
        {
            //Arrange
            var mockReadLineOverride = new Mock<ReadLineOverride>();
            mockReadLineOverride.Setup(x => x.GetNextString()).Returns("2");
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
            ItemCard card = new ItemCard("CyberBoots", CardType.Prize, PrizeCardType.Item, 2, cyberCoat, false, ItemType.Boots, null, 300);
            ItemCard oldBoots = new ItemCard("OldBoots", CardType.Prize, PrizeCardType.Item, 2, cyberCoat, false, ItemType.Boots, null, 300);
            user.UserAvatar.Build.Boots = oldBoots;
            user.Deck.Items.Add(card);
            var deckController = new DeckController(mockReadLineOverride.Object);
            //Act
            deckController.UseItemCard(user, card, null);
            //Assert
            user.UserAvatar.Build.Boots.Should().BeSameAs(oldBoots);
            user.Deck.Items.Should().HaveCount(1);
            user.Deck.Items[0].Should().BeSameAs(card);
        }
        #endregion

        #region UseSituationalItems
        [Fact]
        public void UseSituationalItemsThereIsNoFight()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var userAvatar = new UserAvatar()
            {
                Power = 5
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var deckController = new DeckController(mock.Object);
            var dionisiosWine = new DionisiosWine("DionisiosWine", CardType.Special, PrizeCardType.Sitiuational, 0, null, false, ItemType.Sitiuational, null, 400, mock.Object);
            //Act
            deckController.UseSituationalItems(dionisiosWine, null);
            //Assert
            user.UserAvatar.Power.Should().Be(5);
            user.UserAvatar.FleeChances.Should().Be(3);
        }

        [Fact]
        public void UseSituationalItemsWithFight()
        {
            ///Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var userAvatar = new UserAvatar()
            {
                Power = 5
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var deckController = new DeckController(mock.Object);
            var fight = new Fight();
            fight.Heros.Add(user);
            var dionisiosWine = new DionisiosWine("DionisiosWine", CardType.Special, PrizeCardType.Sitiuational, 0, null, false, ItemType.Sitiuational, null, 400, mock.Object);
            //Act
            deckController.UseSituationalItems(dionisiosWine, fight);
            //Assert
            user.UserAvatar.Power.Should().Be(8);
            user.UserAvatar.FleeChances.Should().Be(1);
        }
        #endregion

        #region SetWeapon
        [Fact]
        public void SetWeaponBothHandsNullWithoutRestrictionOneHanded()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var deckController = new DeckController(mock.Object);
            var weapon = new ItemCard("MaceOfDestraction", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Weapon, null, 600);
            user.Deck.Items.Add(weapon);
            //Act
            deckController.SetWeapon(user, weapon);
            //Assert
            user.UserAvatar.Build.LeftHandItem.Should().BeSameAs(weapon);
            user.Deck.Items.Should().BeEmpty();
        }

        [Fact]
        public void SetWeaponBothHandsNullWithRaceRestrictionOneHanded()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var userAvatar = new UserAvatar()
            {
                Race = new Elf("elf")
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var deckController = new DeckController(mock.Object);
            var maceOfDestraction = new Dictionary<bool, RaceBase>
            {
                { true, new Elf("elf") }
            };
            var weapon = new ItemCard("MaceOfDestraction", CardType.Prize, PrizeCardType.Item, 5, maceOfDestraction, false, ItemType.Weapon, null, 600);
            user.Deck.Items.Add(weapon);
            //Act
            deckController.SetWeapon(user, weapon);
            //Assert
            user.UserAvatar.Build.LeftHandItem.Should().BeSameAs(weapon);
            user.Deck.Items.Should().BeEmpty();
        }

        [Fact]
        public void SetWeaponBothHandsNullWithProficiencyRestrictionOneHanded()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var userAvatar = new UserAvatar()
            {
                Proficiency = new WarriorProficiency(mock.Object)
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var deckController = new DeckController(mock.Object);
            var maceOfDestraction = new Dictionary<bool, ProficiencyBase>
            {
                { true, new WarriorProficiency(mock.Object) }
            };
            var weapon = new ItemCard("MaceOfDestraction", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Weapon, maceOfDestraction, 600);
            user.Deck.Items.Add(weapon);
            //Act
            deckController.SetWeapon(user, weapon);
            //Assert
            user.UserAvatar.Build.LeftHandItem.Should().BeSameAs(weapon);
            user.Deck.Items.Should().BeEmpty();
        }

        [Fact]
        public void SetWeaponLeftHandOccupiedWithoutRestrictionOneHanded()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var deckController = new DeckController(mock.Object);
            var weapon = new ItemCard("MaceOfDestraction", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Weapon, null, 600);
            var secondWeapon = new ItemCard("SecondSword", CardType.Prize, PrizeCardType.Item, 2, null, false, ItemType.Weapon, null, 200);
            user.UserAvatar.Build.LeftHandItem = weapon;
            user.Deck.Items.Add(secondWeapon);
            //Act
            deckController.SetWeapon(user, secondWeapon);
            //Assert
            user.UserAvatar.Build.LeftHandItem.Should().BeSameAs(weapon);
            user.UserAvatar.Build.RightHandItem.Should().BeSameAs(secondWeapon);
            user.Deck.Items.Should().BeEmpty();
        }

        [Fact]
        public void SetWeaponLeftHandOccupiedWithoutRestrictionTwoHanded()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var deckController = new DeckController(mock.Object);
            var weapon = new ItemCard("MaceOfDestraction", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Weapon, null, 600);
            var secondWeapon = new ItemCard("SecondSword", CardType.Prize, PrizeCardType.Item, 2, null, true, ItemType.Weapon, null, 200);
            user.UserAvatar.Build.LeftHandItem = weapon;
            user.Deck.Items.Add(secondWeapon);
            //Act
            deckController.SetWeapon(user, secondWeapon);
            //Assert
            user.UserAvatar.Build.LeftHandItem.Should().BeSameAs(secondWeapon);
            user.UserAvatar.Build.RightHandItem.Should().BeNull();
            user.Deck.Items.Should().HaveCount(1);
            user.Deck.Items[0].Should().Be(weapon);
        }

        [Fact]
        public void SetWeaponRightHandOccupiedWithoutRestrictionTwoHanded()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var deckController = new DeckController(mock.Object);
            var weapon = new ItemCard("MaceOfDestraction", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Weapon, null, 600);
            var secondWeapon = new ItemCard("SecondSword", CardType.Prize, PrizeCardType.Item, 2, null, true, ItemType.Weapon, null, 200);
            user.UserAvatar.Build.RightHandItem = weapon;
            user.Deck.Items.Add(secondWeapon);
            //Act
            deckController.SetWeapon(user, secondWeapon);
            //Assert
            user.UserAvatar.Build.LeftHandItem.Should().BeSameAs(secondWeapon);
            user.UserAvatar.Build.RightHandItem.Should().BeNull();
            user.Deck.Items.Should().HaveCount(1);
            user.Deck.Items[0].Should().Be(weapon);
        }

        [Fact]
        public void SetWeaponKeepOldWeapondWithoutRestrictionTwoHanded()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("2");
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var deckController = new DeckController(mock.Object);
            var weapon = new ItemCard("MaceOfDestraction", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Weapon, null, 600);
            var secondWeapon = new ItemCard("SecondSword", CardType.Prize, PrizeCardType.Item, 2, null, true, ItemType.Weapon, null, 200);
            user.UserAvatar.Build.LeftHandItem = weapon;
            user.Deck.Items.Add(secondWeapon);
            //Act
            deckController.SetWeapon(user, secondWeapon);
            //Assert
            user.UserAvatar.Build.LeftHandItem.Should().BeSameAs(weapon);
            user.UserAvatar.Build.RightHandItem.Should().BeNull();
            user.Deck.Items.Should().HaveCount(1);
            user.Deck.Items[0].Should().Be(secondWeapon);
        }

        [Fact]
        public void SetWeaponBothHandsOccupiedWithoutRestrictionOneHandedChangeInLeftHand()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var deckController = new DeckController(mock.Object);
            var weapon = new ItemCard("MaceOfDestraction", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Weapon, null, 600);
            var secondWeapon = new ItemCard("SecondSword", CardType.Prize, PrizeCardType.Item, 2, null, false, ItemType.Weapon, null, 200);
            var toChange = new ItemCard("NewSword", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            user.UserAvatar.Build.LeftHandItem = weapon;
            user.UserAvatar.Build.RightHandItem = secondWeapon;
            user.Deck.Items.Add(toChange);
            //Act
            deckController.SetWeapon(user, toChange);
            //Assert
            user.UserAvatar.Build.LeftHandItem.Should().BeSameAs(toChange);
            user.UserAvatar.Build.RightHandItem.Should().BeSameAs(secondWeapon);
            user.Deck.Items.Should().HaveCount(1);
            user.Deck.Items[0].Should().Be(weapon);
        }

        [Fact]
        public void SetWeaponBothHandsOccupiedWithoutRestrictionOneHandedChangeInRightHand()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns(new Queue<string>(new[] { "1", "2", "0" }).Dequeue);
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var deckController = new DeckController(mock.Object);
            var weapon = new ItemCard("MaceOfDestraction", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Weapon, null, 600);
            var secondWeapon = new ItemCard("SecondSword", CardType.Prize, PrizeCardType.Item, 2, null, false, ItemType.Weapon, null, 200);
            var toChange = new ItemCard("NewSword", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            user.UserAvatar.Build.LeftHandItem = weapon;
            user.UserAvatar.Build.RightHandItem = secondWeapon;
            user.Deck.Items.Add(toChange);
            //Act
            deckController.SetWeapon(user, toChange);
            //Assert
            user.UserAvatar.Build.LeftHandItem.Should().BeSameAs(weapon);
            user.UserAvatar.Build.RightHandItem.Should().BeSameAs(toChange);
            user.Deck.Items.Should().HaveCount(1);
            user.Deck.Items[0].Should().Be(secondWeapon);
        }

        [Fact]
        public void SetWeaponBothHandsOccupiedWithoutRestrictionOneHandedDoNothing()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("2");
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var deckController = new DeckController(mock.Object);
            var weapon = new ItemCard("MaceOfDestraction", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Weapon, null, 600);
            var secondWeapon = new ItemCard("SecondSword", CardType.Prize, PrizeCardType.Item, 2, null, false, ItemType.Weapon, null, 200);
            var toChange = new ItemCard("NewSword", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            user.UserAvatar.Build.LeftHandItem = weapon;
            user.UserAvatar.Build.RightHandItem = secondWeapon;
            user.Deck.Items.Add(toChange);
            //Act
            deckController.SetWeapon(user, toChange);
            //Assert
            user.UserAvatar.Build.LeftHandItem.Should().BeSameAs(weapon);
            user.UserAvatar.Build.RightHandItem.Should().BeSameAs(secondWeapon);
            user.Deck.Items.Should().HaveCount(1);
            user.Deck.Items[0].Should().Be(toChange);
        }

        #endregion
    }
}