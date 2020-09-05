using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;
using Munchkin.Model;
using Munchkin.Model.Character.Hero.Proficiency;
using Munchkin.Model.Character;
using Munchkin.BL.CardGenerator;
using Munchkin.BL.GameController;
using Munchkin.BL.CharacterCreator;
using Moq;
using Munchkin.Model.Card.PrizeCard;
using Munchkin.Model.Character.Hero.Race;
using Munchkin.BL.Helper;

namespace Munchkin.Tests.Munchkin.Model.Tests.Character.Hero.Proficiency
{
    public class InformationModelThiefProficiencyTests
    {
        [Fact]
        public void ShowItemsToStealFullBuild()
        {
            //Arrange
            var mockReadLine = new Mock<ReadLineOverride>();
            mockReadLine.Setup(x => x.GetNextString()).Returns("");
            var thief = new ThiefProficiency(mockReadLine.Object);
            var informationModelThiefProficiency = new InformationModelThiefProficiency();
            var userAvatar = new UserAvatar()
            {
                Proficiency = thief,
                Build =  new Build()
            };
            var thiefChar = new UserClass()
            {
                UserAvatar = userAvatar
            };

            thiefChar.UserAvatar.Build.Armor = new ItemCard("leatherArmor", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Armor, null, 300);
            thiefChar.UserAvatar.Build.Helmet = new ItemCard("leatherHelmet", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Helmet, null, 300);
            thiefChar.UserAvatar.Build.Boots = new ItemCard("normalBoot", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Boots, null, 300);
            thiefChar.UserAvatar.Build.LeftHandItem = new ItemCard("sword1H", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            thiefChar.UserAvatar.Build.RightHandItem = new ItemCard("axe", CardType.Prize, PrizeCardType.Item, 3, null, true, ItemType.Weapon, null, 300);

            //Act
            var result = informationModelThiefProficiency.ShowItemsToSteal(thiefChar.UserAvatar.Build);
            var arr = result.ItemDescription.Split(";");
            //Assert
            arr[0].Trim().Should().Be("1. Name: leatherHelmet, Power: 3");
            arr[1].Trim().Should().Contain("2. Name: leatherArmor, Power: 5");
            arr[2].Trim().Should().Contain("3. Name: normalBoot, Power: 3");
            arr[3].Trim().Should().Contain("4. Name: sword1H, Power: 3, IsTwoHanded: False");
            arr[4].Trim().Should().Contain("5. Name: axe, Power: 3, IsTwoHanded: True");
            result.ItemCount.Should().Be(5);
        }

        [Fact]
        public void ShowItemsToStealOnlyAdditionalItems()
        {
            //Arrange
            var mockReadLine = new Mock<ReadLineOverride>();
            mockReadLine.Setup(x => x.GetNextString()).Returns("");
            var thief = new ThiefProficiency(mockReadLine.Object);
            var informationModelThiefProficiency = new InformationModelThiefProficiency();
            var dwarf = new Dwarf("dwarf");
            var userAvatar = new UserAvatar()
            {
                Proficiency = thief,
                Build = new Build(),
                Race = dwarf

            };
            var thiefChar = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var additionalItems = new List<ItemCard>()
            {
                new ItemCard("healthPotion", CardType.Prize, PrizeCardType.Additional, 4, null, false, ItemType.Additional, null, 300),
                new ItemCard("manaPotion", CardType.Prize, PrizeCardType.Additional, 2, null, false, ItemType.Additional, null, 300),
                new ItemCard("testItem", CardType.Prize, PrizeCardType.Additional, 1, null, false, ItemType.Additional, null, 300),
                new ItemCard("something", CardType.Prize, PrizeCardType.Additional, 0, null, false, ItemType.Additional, null, 300),
            };
            thiefChar.UserAvatar.Build.AdditionalItems = additionalItems;
            //Act
            var result = informationModelThiefProficiency.ShowItemsToSteal(thiefChar.UserAvatar.Build);
            var arr = result.ItemDescription.Split(";");
            //Assert
            arr[0].Trim().Should().Be("1. Name: healthPotion, Power: 4");
            arr[1].Trim().Should().Be("2. Name: manaPotion, Power: 2");
            arr[2].Trim().Should().Be("3. Name: testItem, Power: 1");
            arr[3].Trim().Should().Be("4. Name: something, Power: 0");
            result.ItemCount.Should().Be(4);
        }

        [Fact]
        public void ShowItemsToStealMixedItems()
        {
            //Arrange
            var mockReadLine = new Mock<ReadLineOverride>();
            mockReadLine.Setup(x => x.GetNextString()).Returns("");
            var thief = new ThiefProficiency(mockReadLine.Object);
            var informationModelThiefProficiency = new InformationModelThiefProficiency();
            var dwarf = new Dwarf("dwarf");
            var userAvatar = new UserAvatar()
            {
                Proficiency = thief,
                Build = new Build(),
                Race = dwarf

            };
            var thiefChar = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var khazaDumRestrictions = new Dictionary<bool, RaceBase>
            {
                { true, new Dwarf("dwarf") }
            };
            var additionalItems = new List<ItemCard>()
            {
                new ItemCard("healthPotion", CardType.Prize, PrizeCardType.Additional, 4, null, false, ItemType.Additional, null, 300),
                new ItemCard("manaPotion", CardType.Prize, PrizeCardType.Additional, 2, null, false, ItemType.Additional, null, 300),
            };
            thiefChar.UserAvatar.Build.LeftHandItem = new ItemCard("khazaDumHammer", CardType.Prize, PrizeCardType.Item, 3, khazaDumRestrictions, true, ItemType.Weapon, null, 300);
            thiefChar.UserAvatar.Build.AdditionalItems = additionalItems;
            //Act
            var result = informationModelThiefProficiency.ShowItemsToSteal(thiefChar.UserAvatar.Build);
            var arr = result.ItemDescription.Split(";");
            //Assert
            arr[0].Trim().Should().Be("1. Name: khazaDumHammer, Power: 3, IsTwoHanded: True, dwarf: true");
            arr[1].Trim().Should().Be("2. Name: healthPotion, Power: 4");
            arr[2].Trim().Should().Be("3. Name: manaPotion, Power: 2");
            result.ItemCount.Should().Be(3);
        }
    }
}
