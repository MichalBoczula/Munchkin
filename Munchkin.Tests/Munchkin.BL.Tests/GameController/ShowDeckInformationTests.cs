using FluentAssertions;
using Moq;
using Munchkin.BL.GameController;
using Munchkin.BL.Helper;
using Munchkin.Model;
using Munchkin.Model.Card.ActionCard;
using Munchkin.Model.Card.ActionCard.SpecialCardType;
using Munchkin.Model.Card.ActionCard.SpecialCardType.MagicCards;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret;
using Munchkin.Model.Card.PrizeCard;
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
    public class ShowDeckInformationTests
    {
        [Fact]
        public void CreateProficiencyRestrictionInformationTest()
        {
            //Arrange
            var mockReadLineOverride = new Mock<ReadLineOverride>();
            mockReadLineOverride.Setup(x => x.GetNextString()).Returns("1");
            var userInformationController = new UserInformationController();
            var thorsHammerRestrictions = new Dictionary<bool, ProficiencyBase>
            {
                { true, new WarriorProficiency(mockReadLineOverride.Object) }
            };
            var user = new UserClass();
            user.Deck.Items.Add(new ItemCard("thorsHammer", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, thorsHammerRestrictions, 300));
            //Act
            var result = userInformationController.CreateProficiencyRestrictionInformation(user.Deck.Items[0]);
            //Assert
            result.Trim().Should().Be("Warrior: true;");
        }

        [Fact]
        public void CreateProficiencyRestrictionInformationWithNullTest()
        {
            //Arrange
            var userInformationController = new UserInformationController();

            var user = new UserClass();
            user.Deck.Items.Add(new ItemCard("thorsHammer", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300));
            //Act
            var result = userInformationController.CreateProficiencyRestrictionInformation(user.Deck.Items[0]);
            //Assert
            result.Should().Be("");
        }

        [Fact]
        public void CreateRaceRestrictionInformationTest()
        {
            //Arrange
            var userInformationController = new UserInformationController();
            var khazaDumRestrictions = new Dictionary<bool, RaceBase>
            {
                { true, new Dwarf("Dwarf") }
            };
            var user = new UserClass();
            user.Deck.Items.Add(new ItemCard("khazaDumHammer", CardType.Prize, PrizeCardType.Item, 3, khazaDumRestrictions, true, ItemType.Weapon, null, 300));
            //Act
            var result = userInformationController.CreateRaceRestrictionInformation(user.Deck.Items[0]);
            //Assert
            result.Trim().Should().Be("Dwarf: true;");
        }

        [Fact]
        public void CreateRaceRestrictionInformationWithNullTest()
        {
            //Arrange
            var userInformationController = new UserInformationController();
            var user = new UserClass();
            user.Deck.Items.Add(new ItemCard("khazaDumHammer", CardType.Prize, PrizeCardType.Item, 3, null, true, ItemType.Weapon, null, 300));
            //Act
            var result = userInformationController.CreateRaceRestrictionInformation(user.Deck.Items[0]);
            //Assert
            result.Should().Be("");
        }

        [Fact]
        public void ShowDeckInformationOnlyItemTest()
        {
            //Arrange
            var userInformationController = new UserInformationController();
            var user = new UserClass();
            var khazaDumRestrictions = new Dictionary<bool, RaceBase>
            {
                { true, new Dwarf("Dwarf") }
            };
            user.Deck.Items.Add(new ItemCard("khazaDumHammer", CardType.Prize, PrizeCardType.Item, 3, khazaDumRestrictions, true, ItemType.Weapon, null, 300));
            //Act
            var result = userInformationController.ShowDeckInformation(user).Split(';');
            //Assert
            result[0].Substring(0, 2).Trim().Should().Be("1.");
            result[0].Substring(2).Trim().Should().Be("Name: khazaDumHammer");
            result[1].Trim().Should().Be("ItemType: Weapon");
            result[2].Trim().Should().Be("Power: 3");
            result[3].Trim().Should().Be("ItemType: Weapon");
            result[4].Trim().Should().Be("Dwarf: true");
            result[5].Trim().Should().Be("Price: 300");
        }

        [Fact]
        public void ShowDeckInformationOnlyMonsterTest()
        {
            //Arrange
            var userInformationController = new UserInformationController();
            var user = new UserClass();
            user.Deck.Monsters.Add(new AntArmy("AntArmy", CardType.Monster));
            //Act
            var result = userInformationController.ShowDeckInformation(user).Split(';');
            //Assert
            result[0].Substring(0, 2).Trim().Should().Be("1.");
            result[0].Substring(2).Trim().Should().Be("Name: AntArmy");
            result[1].Trim().Should().Be("Power: 8");
            result[2].Trim().Should().Be("HowManyLevels: 1");
            result[3].Trim().Should().Be("NumberOfPrizes: 2");
            result[4].Trim().Should().Be("Undead: False");
        }

        [Fact]
        public void ShowDeckInformationOnlyMagicCardTest()
        {
            //Arrange
            var userInformationController = new UserInformationController();
            var user = new UserClass();
            user.Deck.MagicCards.Add(new PayToHaron("Pay To Haron", CardType.Curse));
            //Act
            var result = userInformationController.ShowDeckInformation(user).Split(';');
            //Assert
            result[0].Substring(0, 2).Trim().Should().Be("1.");
            result[0].Substring(2).Trim().Should().Be("Name: Pay To Haron");
        }

        [Fact]
        public void ShowDeckInformationAllTypeOfCardsTest()
        {
            //Arrange
            var userInformationController = new UserInformationController();
            var user = new UserClass();
            var khazaDumRestrictions = new Dictionary<bool, RaceBase>
            {
                { true, new Dwarf("Dwarf") }
            };
            user.Deck.Items.Add(new ItemCard("khazaDumHammer", CardType.Prize, PrizeCardType.Item, 3, khazaDumRestrictions, true, ItemType.Weapon, null, 300));
            user.Deck.Monsters.Add(new AntArmy("AntArmy", CardType.Monster));
            user.Deck.MagicCards.Add(new PayToHaron("Pay To Haron", CardType.Curse));
            //Act
            var result = userInformationController.ShowDeckInformation(user).Split(';');
            //Assert
            result[0].Substring(0, 2).Trim().Should().Be("1.");
            result[0].Substring(2).Trim().Should().Be("Name: khazaDumHammer");
            result[1].Trim().Should().Be("ItemType: Weapon");
            result[2].Trim().Should().Be("Power: 3");
            result[3].Trim().Should().Be("ItemType: Weapon");
            result[4].Trim().Should().Be("Dwarf: true");
            result[5].Trim().Should().Be("Price: 300");
            result[6].Trim().Substring(0, 2).Trim().Should().Be("2.");
            result[6].Substring(3).Trim().Should().Be("Name: AntArmy");
            result[7].Trim().Should().Be("Power: 8");
            result[8].Trim().Should().Be("HowManyLevels: 1");
            result[9].Trim().Should().Be("NumberOfPrizes: 2");
            result[10].Trim().Should().Be("Undead: False");
            result[11].Trim().Substring(0, 2).Should().Contain("3.");
            result[11].Trim().Substring(3).Should().Contain("Name: Pay To Haron");
        }
    }
}
