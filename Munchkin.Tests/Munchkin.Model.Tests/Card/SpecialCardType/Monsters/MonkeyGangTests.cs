using FluentAssertions;
using Moq;
using Munchkin.BL.Helper;
using Munchkin.Model;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret;
using Munchkin.Model.Card.PrizeCard;
using Munchkin.Model.Character;
using Munchkin.Model.Character.Hero.Proficiency;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Munchkin.Tests.Munchkin.Model.Tests.Card.SpecialCardType.Monsters
{
    public class MonkeyGangTests
    {
        [Fact]
        public void SpecialPowerThiefTest()
        {
            //Arrange
            var mockReadLine = new Mock<ReadLineOverride>();
            mockReadLine.Setup(x => x.GetNextString()).Returns("");
            var random = new Random();
            var thief = new ThiefProficiency(mockReadLine.Object, random);
            var game = new Game();
            var mockRandom = new Mock<Random>();
            var monkeyGang = new MonkeyGang("Monkey Gang", CardType.Monster, mockRandom.Object);
            var userAvatar = new UserAvatar()
            {
                Proficiency = thief
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            monkeyGang.SpecialPower(game, user);
            //Assert
            monkeyGang.Power.Should().Be(6);
            monkeyGang.NumberOfPrizes.Should().Be(2);
            monkeyGang.HowManyLevels.Should().Be(1);
        }

        [Fact]
        public void SpecialPowerDiffrentProficiencyTest()
        {
            //Arrange
            var game = new Game();
            var mockRandom = new Mock<Random>();
            var monkeyGang = new MonkeyGang("Monkey Gang", CardType.Monster, mockRandom.Object);
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
            //Act
            monkeyGang.SpecialPower(game, user);
            //Assert
            monkeyGang.Power.Should().Be(8);
            monkeyGang.NumberOfPrizes.Should().Be(2);
            monkeyGang.HowManyLevels.Should().Be(1);
        }

        [Fact]
        public void TryStealHelmetSuccessTest()
        {
            //Arrange
            var game = new Game();
            var mockRandom = new Mock<Random>();
            mockRandom.Setup(x => x.Next(6)).Returns(4);
            var monkeyGang = new MonkeyGang("Monkey Gang", CardType.Monster, mockRandom.Object);
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var mage = new MageProficiency(mock.Object);
            var userAvatar = new UserAvatar()
            {
                Build = new Build(),
                Proficiency = mage
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var helmet = new ItemCard("leatherHelmet", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Helmet, null, 300);
            user.UserAvatar.Build.Helmet = helmet;
            //Act
            var item = monkeyGang.TryStealHelmet(user);
            //Assert
            user.UserAvatar.Build.Helmet.Should().BeNull();
            item.Should().BeSameAs(helmet);
        }

        [Fact]
        public void TryStealNoHelmetTest()
        {
            //Arrange
            var game = new Game();
            var mockRandom = new Mock<Random>();
            mockRandom.Setup(x => x.Next(6)).Returns(4);
            var monkeyGang = new MonkeyGang("Monkey Gang", CardType.Monster, mockRandom.Object);
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var mage = new MageProficiency(mock.Object);
            var userAvatar = new UserAvatar()
            {
                Build = new Build(),
                Proficiency = mage
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            var item = monkeyGang.TryStealHelmet(user);
            //Assert
            user.UserAvatar.Build.Helmet.Should().BeNull();
            item.Should().BeNull();
        }

        [Fact]
        public void TryStealHelmetFailTest()
        {
            //Arrange
            var game = new Game();
            var mockRandom = new Mock<Random>();
            mockRandom.Setup(x => x.Next(6)).Returns(3);
            var monkeyGang = new MonkeyGang("Monkey Gang", CardType.Monster, mockRandom.Object);
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var mage = new MageProficiency(mock.Object);
            var userAvatar = new UserAvatar()
            {
                Build = new Build(),
                Proficiency = mage
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var helmet = new ItemCard("leatherHelmet", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Helmet, null, 300);
            user.UserAvatar.Build.Helmet = helmet;
            //Act
            var item = monkeyGang.TryStealHelmet(user);
            //Assert
            user.UserAvatar.Build.Helmet.Should().BeSameAs(helmet);
            item.Should().BeNull();
        }

        [Fact]
        public void TryStealArmorSuccessTest()
        {
            //Arrange
            var game = new Game();
            var mockRandom = new Mock<Random>();
            mockRandom.Setup(x => x.Next(6)).Returns(4);
            var monkeyGang = new MonkeyGang("Monkey Gang", CardType.Monster, mockRandom.Object);
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var mage = new MageProficiency(mock.Object);
            var userAvatar = new UserAvatar()
            {
                Build = new Build(),
                Proficiency = mage
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var armor = new ItemCard("leatherArmor", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Armor, null, 300);
            user.UserAvatar.Build.Armor = armor;
            //Act
            var item = monkeyGang.TryStealArmor(user);
            //Assert
            user.UserAvatar.Build.Armor.Should().BeNull();
            item.Should().BeSameAs(armor);
        }

        [Fact]
        public void TryStealNoArmorTest()
        {
            //Arrange
            var game = new Game();
            var mockRandom = new Mock<Random>();
            mockRandom.Setup(x => x.Next(6)).Returns(4);
            var monkeyGang = new MonkeyGang("Monkey Gang", CardType.Monster, mockRandom.Object);
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var mage = new MageProficiency(mock.Object);
            var userAvatar = new UserAvatar()
            {
                Build = new Build(),
                Proficiency = mage
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            var item = monkeyGang.TryStealArmor(user);
            //Assert
            user.UserAvatar.Build.Armor.Should().BeNull();
            item.Should().BeNull();
        }

        [Fact]
        public void TryStealArmorFailTest()
        {
            //Arrange
            var game = new Game();
            var mockRandom = new Mock<Random>();
            mockRandom.Setup(x => x.Next(6)).Returns(3);
            var monkeyGang = new MonkeyGang("Monkey Gang", CardType.Monster, mockRandom.Object);
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var mage = new MageProficiency(mock.Object);
            var userAvatar = new UserAvatar()
            {
                Build = new Build(),
                Proficiency = mage
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var armor = new ItemCard("leatherArmor", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Armor, null, 300);
            user.UserAvatar.Build.Armor = armor;
            //Act
            var item = monkeyGang.TryStealHelmet(user);
            //Assert
            user.UserAvatar.Build.Armor.Should().BeSameAs(armor);
            item.Should().BeNull();
        }

        [Fact]
        public void TryStealBootsSuccessTest()
        {
            //Arrange
            var game = new Game();
            var mockRandom = new Mock<Random>();
            mockRandom.Setup(x => x.Next(6)).Returns(4);
            var monkeyGang = new MonkeyGang("Monkey Gang", CardType.Monster, mockRandom.Object);
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var mage = new MageProficiency(mock.Object);
            var userAvatar = new UserAvatar()
            {
                Build = new Build(),
                Proficiency = mage
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var boots = new ItemCard("normalBoot", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Boots, null, 300);
            user.UserAvatar.Build.Boots = boots;
            //Act
            var item = monkeyGang.TryStealBoots(user);
            //Assert
            user.UserAvatar.Build.Boots.Should().BeNull();
            item.Should().BeSameAs(boots);
        }

        [Fact]
        public void TryStealNoBootsTest()
        {
            //Arrange
            var game = new Game();
            var mockRandom = new Mock<Random>();
            mockRandom.Setup(x => x.Next(6)).Returns(4);
            var monkeyGang = new MonkeyGang("Monkey Gang", CardType.Monster, mockRandom.Object);
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var mage = new MageProficiency(mock.Object);
            var userAvatar = new UserAvatar()
            {
                Build = new Build(),
                Proficiency = mage
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            var item = monkeyGang.TryStealBoots(user);
            //Assert
            user.UserAvatar.Build.Boots.Should().BeNull();
            item.Should().BeNull();
        }

        [Fact]
        public void TryStealBootsFailTest()
        {
            //Arrange
            var game = new Game();
            var mockRandom = new Mock<Random>();
            mockRandom.Setup(x => x.Next(6)).Returns(3);
            var monkeyGang = new MonkeyGang("Monkey Gang", CardType.Monster, mockRandom.Object);
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var mage = new MageProficiency(mock.Object);
            var userAvatar = new UserAvatar()
            {
                Build = new Build(),
                Proficiency = mage
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var boots = new ItemCard("normalBoot", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Boots, null, 300);
            user.UserAvatar.Build.Boots = boots;
            //Act
            var item = monkeyGang.TryStealBoots(user);
            //Assert
            user.UserAvatar.Build.Boots.Should().BeSameAs(boots);
            item.Should().BeNull();
        }

        [Fact]
        public void TryStealLHandWeaponSuccessTest()
        {
            //Arrange
            var game = new Game();
            var mockRandom = new Mock<Random>();
            mockRandom.Setup(x => x.Next(6)).Returns(4);
            var monkeyGang = new MonkeyGang("Monkey Gang", CardType.Monster, mockRandom.Object);
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var mage = new MageProficiency(mock.Object);
            var userAvatar = new UserAvatar()
            {
                Build = new Build(),
                Proficiency = mage
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var lHand = new ItemCard("sword1H", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            user.UserAvatar.Build.LeftHandItem = lHand;
            //Act
            var item = monkeyGang.TryStealLHand(user);
            //Assert
            user.UserAvatar.Build.LeftHandItem.Should().BeNull();
            item.Should().BeSameAs(lHand);
        }

        [Fact]
        public void TryStealNoLHandWeaponTest()
        {
            //Arrange
            var game = new Game();
            var mockRandom = new Mock<Random>();
            mockRandom.Setup(x => x.Next(6)).Returns(4);
            var monkeyGang = new MonkeyGang("Monkey Gang", CardType.Monster, mockRandom.Object);
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var mage = new MageProficiency(mock.Object);
            var userAvatar = new UserAvatar()
            {
                Build = new Build(),
                Proficiency = mage
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            var item = monkeyGang.TryStealLHand(user);
            //Assert
            user.UserAvatar.Build.LeftHandItem.Should().BeNull();
            item.Should().BeNull();
        }

        [Fact]
        public void TryStealLHandWeaponFailTest()
        {
            //Arrange
            var game = new Game();
            var mockRandom = new Mock<Random>();
            mockRandom.Setup(x => x.Next(6)).Returns(3);
            var monkeyGang = new MonkeyGang("Monkey Gang", CardType.Monster, mockRandom.Object);
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var mage = new MageProficiency(mock.Object);
            var userAvatar = new UserAvatar()
            {
                Build = new Build(),
                Proficiency = mage
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var lHand = new ItemCard("sword1H", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            user.UserAvatar.Build.LeftHandItem = lHand;
            //Act
            var item = monkeyGang.TryStealLHand(user);
            //Assert
            user.UserAvatar.Build.LeftHandItem.Should().BeSameAs(lHand);
            item.Should().BeNull();
        }

        [Fact]
        public void TryStealRHandWeaponSuccessTest()
        {
            //Arrange
            var game = new Game();
            var mockRandom = new Mock<Random>();
            mockRandom.Setup(x => x.Next(6)).Returns(4);
            var monkeyGang = new MonkeyGang("Monkey Gang", CardType.Monster, mockRandom.Object);
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var mage = new MageProficiency(mock.Object);
            var userAvatar = new UserAvatar()
            {
                Build = new Build(),
                Proficiency = mage
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var rHand = new ItemCard("axe", CardType.Prize, PrizeCardType.Item, 3, null, true, ItemType.Weapon, null, 300);
            user.UserAvatar.Build.RightHandItem = rHand;
            //Act
            var item = monkeyGang.TryStealRHand(user);
            //Assert
            user.UserAvatar.Build.RightHandItem.Should().BeNull();
            item.Should().BeSameAs(rHand);
        }

        [Fact]
        public void TryStealNoRHandWeaponTest()
        {
            //Arrange
            var game = new Game();
            var mockRandom = new Mock<Random>();
            mockRandom.Setup(x => x.Next(6)).Returns(4);
            var monkeyGang = new MonkeyGang("Monkey Gang", CardType.Monster, mockRandom.Object);
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var mage = new MageProficiency(mock.Object);
            var userAvatar = new UserAvatar()
            {
                Build = new Build(),
                Proficiency = mage
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            var item = monkeyGang.TryStealLHand(user);
            //Assert
            user.UserAvatar.Build.RightHandItem.Should().BeNull();
            item.Should().BeNull();
        }

        [Fact]
        public void TryStealRHandWeaponFailTest()
        {
            //Arrange
            var game = new Game();
            var mockRandom = new Mock<Random>();
            mockRandom.Setup(x => x.Next(6)).Returns(3);
            var monkeyGang = new MonkeyGang("Monkey Gang", CardType.Monster, mockRandom.Object);
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var mage = new MageProficiency(mock.Object);
            var userAvatar = new UserAvatar()
            {
                Build = new Build(),
                Proficiency = mage
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var rHand = new ItemCard("axe", CardType.Prize, PrizeCardType.Item, 3, null, true, ItemType.Weapon, null, 300);
            user.UserAvatar.Build.LeftHandItem = rHand;
            //Act
            var item = monkeyGang.TryStealRHand(user);
            //Assert
            user.UserAvatar.Build.LeftHandItem.Should().BeSameAs(rHand);
            item.Should().BeNull();
        }

        [Fact]
        public void DeadEndFullBuildSuccessTest()
        {
            //Arrange
            var game = new Game();
            var mockRandom = new Mock<Random>();
            mockRandom.Setup(x => x.Next(6)).Returns(4);
            var monkeyGang = new MonkeyGang("Monkey Gang", CardType.Monster, mockRandom.Object);
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var mage = new MageProficiency(mock.Object);
            var userAvatar = new UserAvatar()
            {
                Build = new Build(),
                Proficiency = mage
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var helmet = new ItemCard("leatherHelmet", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Helmet, null, 300);
            var armor = new ItemCard("leatherArmor", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Armor, null, 300);
            var boots = new ItemCard("normalBoot", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Boots, null, 300);
            var lHand = new ItemCard("sword1H", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var rHand = new ItemCard("axe", CardType.Prize, PrizeCardType.Item, 3, null, true, ItemType.Weapon, null, 300);
            user.UserAvatar.Build.Helmet = helmet;
            user.UserAvatar.Build.Armor = armor;
            user.UserAvatar.Build.Boots = boots;
            user.UserAvatar.Build.LeftHandItem = lHand;
            user.UserAvatar.Build.RightHandItem = rHand;
            //Act
            monkeyGang.DeadEnd(game, user);
            //Assert
            game.DestroyedPrizeCards.Should().HaveCount(5);
            game.DestroyedPrizeCards.Should().Contain(helmet);
            game.DestroyedPrizeCards.Should().Contain(armor);
            game.DestroyedPrizeCards.Should().Contain(boots);
            game.DestroyedPrizeCards.Should().Contain(lHand);
            game.DestroyedPrizeCards.Should().Contain(rHand);
            user.UserAvatar.Build.Helmet.Should().BeNull();
            user.UserAvatar.Build.Armor.Should().BeNull();
            user.UserAvatar.Build.Boots.Should().BeNull();
            user.UserAvatar.Build.LeftHandItem.Should().BeNull();
            user.UserAvatar.Build.RightHandItem.Should().BeNull();
        }

        [Fact]
        public void DeadEndFullBuildFailTest()
        {
            //Arrange
            var game = new Game();
            var mockRandom = new Mock<Random>();
            mockRandom.Setup(x => x.Next(6)).Returns(3);
            var monkeyGang = new MonkeyGang("Monkey Gang", CardType.Monster, mockRandom.Object);
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var mage = new MageProficiency(mock.Object);
            var userAvatar = new UserAvatar()
            {
                Build = new Build(),
                Proficiency = mage
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var helmet = new ItemCard("leatherHelmet", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Helmet, null, 300);
            var armor = new ItemCard("leatherArmor", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Armor, null, 300);
            var boots = new ItemCard("normalBoot", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Boots, null, 300);
            var lHand = new ItemCard("sword1H", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var rHand = new ItemCard("axe", CardType.Prize, PrizeCardType.Item, 3, null, true, ItemType.Weapon, null, 300);
            user.UserAvatar.Build.Helmet = helmet;
            user.UserAvatar.Build.Armor = armor;
            user.UserAvatar.Build.Boots = boots;
            user.UserAvatar.Build.LeftHandItem = lHand;
            user.UserAvatar.Build.RightHandItem = rHand;
            //Act
            monkeyGang.DeadEnd(game, user);
            //Assert
            game.DestroyedPrizeCards.Should().HaveCount(0);
            user.UserAvatar.Build.Helmet.Should().BeSameAs(helmet);
            user.UserAvatar.Build.Armor.Should().BeSameAs(armor);
            user.UserAvatar.Build.Boots.Should().BeSameAs(boots);
            user.UserAvatar.Build.LeftHandItem.Should().BeSameAs(lHand);
            user.UserAvatar.Build.RightHandItem.Should().BeSameAs(rHand);
        }

        [Fact]
        public void DeadEndNoCompleteBuildSuccessTest()
        {
            //Arrange
            var game = new Game();
            var mockRandom = new Mock<Random>();
            mockRandom.Setup(x => x.Next(6)).Returns(4);
            var monkeyGang = new MonkeyGang("Monkey Gang", CardType.Monster, mockRandom.Object);
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var mage = new MageProficiency(mock.Object);
            var userAvatar = new UserAvatar()
            {
                Build = new Build(),
                Proficiency = mage
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var armor = new ItemCard("leatherArmor", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Armor, null, 300);
            var lHand = new ItemCard("sword1H", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            user.UserAvatar.Build.Armor = armor;
            user.UserAvatar.Build.LeftHandItem = lHand;
            //Act
            monkeyGang.DeadEnd(game, user);
            //Assert
            game.DestroyedPrizeCards.Should().HaveCount(2);
            game.DestroyedPrizeCards.Should().Contain(armor);
            game.DestroyedPrizeCards.Should().Contain(lHand);
            user.UserAvatar.Build.Armor.Should().BeNull();
            user.UserAvatar.Build.LeftHandItem.Should().BeNull();
        }

        [Fact]
        public void DeadEndNoCompleteBuildFailTest()
        {
            //Arrange
            var game = new Game();
            var mockRandom = new Mock<Random>();
            mockRandom.Setup(x => x.Next(6)).Returns(3);
            var monkeyGang = new MonkeyGang("Monkey Gang", CardType.Monster, mockRandom.Object);
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var mage = new MageProficiency(mock.Object);
            var userAvatar = new UserAvatar()
            {
                Build = new Build(),
                Proficiency = mage
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var armor = new ItemCard("leatherArmor", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Armor, null, 300);
            var boots = new ItemCard("normalBoot", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Boots, null, 300);
            user.UserAvatar.Build.Armor = armor;
            user.UserAvatar.Build.Boots = boots;
            //Act
            monkeyGang.DeadEnd(game, user);
            //Assert
            game.DestroyedPrizeCards.Should().HaveCount(0);
            user.UserAvatar.Build.Armor.Should().BeSameAs(armor);
            user.UserAvatar.Build.Boots.Should().BeSameAs(boots);
        }
    }
}
