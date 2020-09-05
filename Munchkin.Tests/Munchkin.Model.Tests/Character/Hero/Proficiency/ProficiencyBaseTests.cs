using FluentAssertions;
using Moq;
using Munchkin.BL.Helper;
using Munchkin.Model;
using Munchkin.Model.Card.ActionCard;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret;
using Munchkin.Model.Card.PrizeCard;
using Munchkin.Model.Character;
using Munchkin.Model.Character.Hero.Proficiency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Munchkin.Tests.Munchkin.Model.Tests.Character.Hero.Proficiency
{
    public class ProficiencyBaseTests
    {
        [Fact]
        public void ThrowOutCartOnlyItemsTest()
        {
            //Arrange
            var userAvatar = new UserAvatar()
            {
                Proficiency = new NoOneProficiency()
            };
            var user = new UserClass()
            {
              UserAvatar = userAvatar 
            };
            var one = new ItemCard("1", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Armor, null, 300);
            var two = new ItemCard("2", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Armor, null, 300);
            var three = new ItemCard("3", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Armor, null, 300);
            var four = new ItemCard("4", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Armor, null, 300);
            var five = new ItemCard("5", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Armor, null, 300);
            user.Deck.Items.Add(one);
            user.Deck.Items.Add(two);
            user.Deck.Items.Add(three);
            user.Deck.Items.Add(four);
            user.Deck.Items.Add(five);
            //Act
            var result = user.UserAvatar.Proficiency.ThrowOutCart(4, user);
            //Assert
            result.Should().BeTrue();
            user.Deck.Items.Count().Should().Be(4);
            user.Deck.Items.Should().NotContain(four);
        }

        [Fact]
        public void ThrowOutCartItemsAndMonstersTest()
        {
            //Arrange
            var userAvatar = new UserAvatar()
            {
                Proficiency = new NoOneProficiency()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var one = new ItemCard("1", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Armor, null, 300);
            var two = new ItemCard("2", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Armor, null, 300);
            var three = new ItemCard("3", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Armor, null, 300);
            var m1 = new Witch("Witch", CardType.Action);
            var m2 = new Witch("Witch", CardType.Action);
            user.Deck.Monsters.Add(m1);
            user.Deck.Monsters.Add(m2);
            user.Deck.Items.Add(one);
            user.Deck.Items.Add(two);
            user.Deck.Items.Add(three);
            //Act
            var result = user.UserAvatar.Proficiency.ThrowOutCart(4, user);
            //Assert
            result.Should().BeTrue();
            user.Deck.Items.Count().Should().Be(3);
            user.Deck.Monsters.Count().Should().Be(1);
            user.Deck.Monsters.Should().NotContain(m1);
        }

        [Fact]
        public void ThrowOutCartAllCardsTypesTest()
        {
            //Arrange
            var userAvatar = new UserAvatar()
            {
                Proficiency = new NoOneProficiency()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var one = new ItemCard("1", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Armor, null, 300);
            var two = new ItemCard("2", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Armor, null, 300);
            var m1 = new Witch("Witch", CardType.Action);
            var m2 = new Witch("Witch", CardType.Action);
            var magicCard = new MagicCard("do", CardType.Action);
            user.Deck.Monsters.Add(m1);
            user.Deck.Monsters.Add(m2);
            user.Deck.Items.Add(one);
            user.Deck.Items.Add(two);
            user.Deck.MagicCards.Add(magicCard);
            //Act
            var result = user.UserAvatar.Proficiency.ThrowOutCart(5, user);
            //Assert
            result.Should().BeTrue();
            user.Deck.Items.Count().Should().Be(2);
            user.Deck.Monsters.Count().Should().Be(2);
            user.Deck.MagicCards.Count().Should().Be(0);
        }

        [Fact]
        public void ThrowOutCartMultipleThrowOutTest()
        {
            //Arrange
            var userAvatar = new UserAvatar()
            {
                Proficiency = new NoOneProficiency()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var one = new ItemCard("1", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Armor, null, 300);
            var two = new ItemCard("2", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Armor, null, 300);
            var m1 = new Witch("Witch", CardType.Action);
            var m2 = new Witch("Witch", CardType.Action);
            var magicCard = new MagicCard("do", CardType.Action);
            user.Deck.Monsters.Add(m1);
            user.Deck.Monsters.Add(m2);
            user.Deck.Items.Add(one);
            user.Deck.Items.Add(two);
            user.Deck.MagicCards.Add(magicCard);
            //Act
            var result1 = user.UserAvatar.Proficiency.ThrowOutCart(5, user);
            var result2 = user.UserAvatar.Proficiency.ThrowOutCart(4, user);
            //Assert
            result1.Should().BeTrue();
            result2.Should().BeTrue();
            user.Deck.Items.Count().Should().Be(2);
            user.Deck.Monsters.Count().Should().Be(1);
            user.Deck.Monsters.Should().NotContain(m2);
            user.Deck.MagicCards.Count().Should().Be(0);
        }

        [Fact]
        public void ThrowOutCartMultipleThrowOutFalseTest()
        {
            //Arrange
            var mockReadLineOverride = new Mock<ReadLineOverride>();
            mockReadLineOverride.Setup(x => x.GetNextString()).Returns("");
            var userAvatar = new UserAvatar()
            {
                Proficiency = new NoOneProficiency()
                {
                    readLineOverride = mockReadLineOverride.Object
                }
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var one = new ItemCard("1", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Armor, null, 300);
            var two = new ItemCard("2", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Armor, null, 300);
            var m1 = new Witch("Witch", CardType.Action);
            var m2 = new Witch("Witch", CardType.Action);
            var magicCard = new MagicCard("do", CardType.Action);
            user.Deck.Monsters.Add(m1);
            user.Deck.Monsters.Add(m2);
            user.Deck.Items.Add(one);
            user.Deck.Items.Add(two);
            user.Deck.MagicCards.Add(magicCard);
            //Act
            var result1 = user.UserAvatar.Proficiency.ThrowOutCart(5, user);
            var result2 = user.UserAvatar.Proficiency.ThrowOutCart(5, user);
            //Assert
            result1.Should().BeTrue();
            result2.Should().BeFalse();
            user.Deck.Items.Count().Should().Be(2);
            user.Deck.Monsters.Count().Should().Be(2);
            user.Deck.MagicCards.Count().Should().Be(0);
        }
    }
}
