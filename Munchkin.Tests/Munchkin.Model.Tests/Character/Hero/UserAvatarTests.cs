using FluentAssertions;
using Munchkin.Model;
using Munchkin.Model.Card.PrizeCard;
using Munchkin.Model.Character;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Munchkin.Tests.Munchkin.Model.Tests.Character.Hero
{
    public class UserAvatarTests
    {
        [Fact]
        public void CountPowerFullBuildTest()
        {
            //Arrange
            var userAvatar = new UserAvatar
            {
                Level = 3
            };
            userAvatar.Build.Helmet = new ItemCard("leatherHelmet", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Helmet, null, 300);
            userAvatar.Build.Armor = new ItemCard("leatherArmor", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Armor, null, 300);
            userAvatar.Build.Boots = new ItemCard("normalBoot", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Boots, null, 300);
            userAvatar.Build.LeftHandItem = new ItemCard("sword1H", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            userAvatar.Build.RightHandItem = new ItemCard("axe", CardType.Prize, PrizeCardType.Item, 3, null, true, ItemType.Weapon, null, 300);
            //Act
            userAvatar.CountPower();
            //Assert
            userAvatar.Power.Should().Be(18);
        }

        [Fact]
        public void CountPowerWitNothingTest()
        {
            //Arrange
            var userAvatar = new UserAvatar();
            //Act
            userAvatar.CountPower();
            //Assert
            userAvatar.Power.Should().Be(1);
        }

        [Fact]
        public void CountPowerWhenPowerNerfedTest()
        {
            //Arrange
            var userAvatar = new UserAvatar()
            {
                Level = 2
            };
            userAvatar.Nerfs.Power.Add(1);
            userAvatar.Nerfs.Power.Add(1);
            userAvatar.Nerfs.Power.Add(2);
            //Act
            userAvatar.CountPower();
            //Assert
            userAvatar.Power.Should().Be(-2);
        }


        [Fact]
        public void CountPowerWhenWoundedTest()
        {
            //Arrange
            var userAvatar = new UserAvatar
            {
                Level = 5
            };
            userAvatar.Nerfs.Wounded.Add(true);
            //Act
            userAvatar.CountPower();
            //Assert
            userAvatar.Power.Should().Be(3);
        }

        [Fact]
        public void CheckWoundsOnlyOneTest()
        {
            //Arrange
            var userAvatar = new UserAvatar();
            userAvatar.Nerfs.Wounded.Add(true);
            //Act
            userAvatar.CheckWounds();
            //Assert
            userAvatar.Power.Should().Be(-1);
            userAvatar.IsDied.Should().BeFalse();
        }

        [Fact]
        public void CheckWoundsDeadTest()
        {
            //Arrange
            var userAvatar = new UserAvatar();
            userAvatar.Nerfs.Wounded.Add(true);
            userAvatar.Nerfs.Wounded.Add(true);
            //Act
            userAvatar.CheckWounds();
            //Assert
            userAvatar.Power.Should().Be(1);
            userAvatar.IsDied.Should().BeTrue();
        }

        [Fact]
        public void CheckPoisonOneStacksTest()
        {
            //Arrange
            var userAvatar = new UserAvatar()
            {
                Level = 2,
                Power = 2
            };
            userAvatar.Nerfs.Poisoned.Add(true);
            //Act
            userAvatar.CheckPoison();
            //Assert
            userAvatar.Level.Should().Be(1);
            userAvatar.Power.Should().Be(1);
            userAvatar.IsDied.Should().BeFalse();
        }

        [Fact]
        public void CheckPoisonTwoStacksTest()
        {
            //Arrange
            var userAvatar = new UserAvatar()
            {
                Level = 3,
                Power = 3
            };
            userAvatar.Nerfs.Poisoned.Add(true);
            userAvatar.Nerfs.Poisoned.Add(true);
            //Act
            userAvatar.CheckPoison();
            //Assert
            userAvatar.Level.Should().Be(1);
            userAvatar.Power.Should().Be(1);
            userAvatar.IsDied.Should().BeFalse();
        }

        [Fact]
        public void CheckPoisonThreeStacksTest()
        {
            //Arrange
            var userAvatar = new UserAvatar()
            {
                Level = 3,
                Power = 3
            };
            userAvatar.Nerfs.Poisoned.Add(true);
            userAvatar.Nerfs.Poisoned.Add(true);
            userAvatar.Nerfs.Poisoned.Add(true);
            //Act
            userAvatar.CheckPoison();
            //Assert
            userAvatar.Level.Should().Be(3);
            userAvatar.Power.Should().Be(3);
            userAvatar.IsDied.Should().BeTrue();
        }

        [Fact]
        public void GlatorsDontHaveDefenceNoItemsTest()
        {
            //Arrange
            var userAvatar = new UserAvatar()
            {
                Level = 3
            };
            userAvatar.Curses.NoDefence = true;
            //Act
            userAvatar.CountPower();
            //Assert
            userAvatar.Power.Should().Be(3);
            userAvatar.Curses.NoDefence.Should().BeFalse();
        }


        [Fact]
        public void GlatorsDontHaveDefenceOnlyWeaponsTest()
        {
            //Arrange
            var userAvatar = new UserAvatar()
            {
                Level = 3
            };
            userAvatar.Build.LeftHandItem = new ItemCard("sword1H", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            userAvatar.Build.RightHandItem = new ItemCard("axe", CardType.Prize, PrizeCardType.Item, 3, null, true, ItemType.Weapon, null, 300);
            userAvatar.Curses.NoDefence = true;
            //Act
            userAvatar.CountPower();
            //Assert
            userAvatar.Power.Should().Be(9);
            userAvatar.Curses.NoDefence.Should().BeFalse();
        }

        [Fact]
        public void GlatorsDontHaveDefenceFullBuildTest()
        {
            //Arrange
            var userAvatar = new UserAvatar()
            {
                Level = 3
            };
            userAvatar.Build.Helmet = new ItemCard("leatherHelmet", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Helmet, null, 300);
            userAvatar.Build.Armor = new ItemCard("leatherArmor", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Armor, null, 300);
            userAvatar.Build.Boots = new ItemCard("normalBoot", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Boots, null, 300);
            userAvatar.Build.LeftHandItem = new ItemCard("sword1H", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            userAvatar.Build.RightHandItem = new ItemCard("axe", CardType.Prize, PrizeCardType.Item, 3, null, true, ItemType.Weapon, null, 300);
            userAvatar.Curses.NoDefence = true;
            //Act
            userAvatar.CountPower();
            //Assert
            userAvatar.Power.Should().Be(9);
            userAvatar.Curses.NoDefence.Should().BeFalse();
        }

        [Fact]
        public void CountFleeChancesNoNerfsTest()
        {
            //Arrange
            var userAvatar = new UserAvatar();
            //Act
            userAvatar.CountFleeChances();
            //Assert
            userAvatar.FleeChances.Should().Be(3);
        }

        [Fact]
        public void CountFleeChancesWithNerfsTest()
        {
            //Arrange
            var userAvatar = new UserAvatar();
            userAvatar.Nerfs.FleeChances.Add(1);
            userAvatar.Nerfs.FleeChances.Add(1);
            //Act
            userAvatar.CountFleeChances();
            //Assert
            userAvatar.FleeChances.Should().Be(1);
        }

        [Fact]
        public void CountFleeChancesSholdBe0Test()
        {
            //Arrange
            var userAvatar = new UserAvatar();
            userAvatar.Nerfs.FleeChances.Add(1);
            userAvatar.Nerfs.FleeChances.Add(1);
            userAvatar.Nerfs.FleeChances.Add(1);
            userAvatar.Nerfs.FleeChances.Add(1);
            userAvatar.Nerfs.FleeChances.Add(1);
            //Act
            userAvatar.CountFleeChances();
            //Assert
            userAvatar.FleeChances.Should().Be(0);
        }

        [Fact]
        public void CountFleeChancesNerfAndWoundTest()
        {
            //Arrange
            var userAvatar = new UserAvatar();
            userAvatar.Nerfs.FleeChances.Add(1);
            userAvatar.Nerfs.Wounded.Add(true);
            //Act
            userAvatar.CountFleeChances();
            //Assert
            userAvatar.FleeChances.Should().Be(1);
        }
    }
}
