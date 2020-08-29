using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Munchkin.Model;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret;
using Munchkin.Model.Card.PrizeCard;
using Munchkin.Model.Character;
using Munchkin.Model.User;
using Xunit;

namespace Munchkin.Tests.Munchkin.Model.Tests.Card.SpecialCardType.Monsters
{
    public class StrangeDuckTests
    {
        [Fact]
        public void HowManyItemsShouldTrueTest()
        {
            //Arrange
            var strangeDuck = new StrangeDuck("Strange Duck", CardType.Action);
            var userAvatar = new UserAvatar()
            {
                Build = new Build()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            user.UserAvatar.Build.Armor = new ItemCard("leatherArmor", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Armor, null, 300);
            user.UserAvatar.Build.Helmet = new ItemCard("leatherHelmet", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Helmet, null, 300);
            user.UserAvatar.Build.Boots = new ItemCard("normalBoot", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Boots, null, 300);
            //user.UserAvatar.Build.LeftHandItem = new ItemCard("sword1H", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            //user.UserAvatar.Build.RightHandItem = new ItemCard("axe", CardType.Prize, PrizeCardType.Item, 3, null, true, ItemType.Weapon, null, 300);
            //Act
            var result = strangeDuck.HowManyItems(user);
            //Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void HowManyItemsShouldFalseTest()
        {
            //Arrange
            var strangeDuck = new StrangeDuck("Strange Duck", CardType.Action);
            var userAvatar = new UserAvatar()
            {
                Build = new Build()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            user.UserAvatar.Build.Armor = new ItemCard("leatherArmor", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Armor, null, 300);
            user.UserAvatar.Build.Helmet = new ItemCard("leatherHelmet", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Helmet, null, 300);
            //Act
            var result = strangeDuck.HowManyItems(user);
            //Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void SpecialPowerTrueTest()
        {
            //Arrange
            var game = new Game();
            var strangeDuck = new StrangeDuck("Strange Duck", CardType.Action);
            var userAvatar = new UserAvatar()
            {
                Build = new Build()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            user.UserAvatar.Build.Armor = new ItemCard("leatherArmor", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Armor, null, 300);
            user.UserAvatar.Build.Helmet = new ItemCard("leatherHelmet", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Helmet, null, 300);
            user.UserAvatar.Build.Boots = new ItemCard("normalBoot", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Boots, null, 300);
            //Act
            strangeDuck.SpecialPower(game, user);
            //Assert
            strangeDuck.Power.Should().Be(14);
            strangeDuck.NumberOfPrizes.Should().Be(3);
            strangeDuck.HowManyLevels.Should().Be(2);
        }

        [Fact]
        public void SpecialPowerFalseTest()
        {
            //Arrange
            var game = new Game();
            var strangeDuck = new StrangeDuck("Strange Duck", CardType.Action);
            var userAvatar = new UserAvatar()
            {
                Build = new Build()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            user.UserAvatar.Build.Armor = new ItemCard("leatherArmor", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Armor, null, 300);
            user.UserAvatar.Build.Helmet = new ItemCard("leatherHelmet", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Helmet, null, 300);
            //Act
            strangeDuck.SpecialPower(game, user);
            //Assert
            strangeDuck.Power.Should().Be(4);
            strangeDuck.NumberOfPrizes.Should().Be(2);
            strangeDuck.HowManyLevels.Should().Be(1);
        }

        [Fact]
        public void DeadEndStrongerWayTest()
        {
            //Arrange
            var game = new Game();
            var strangeDuck = new StrangeDuck("Strange Duck", CardType.Action);
            var userAvatar = new UserAvatar()
            {
                Build = new Build()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var helmet = new ItemCard("leatherHelmet", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Helmet, null, 300);
            var armor = new ItemCard("leatherArmor", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Armor, null, 300);
            var lHand = new ItemCard("sword1H", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            user.UserAvatar.Build.Helmet = helmet;
            user.UserAvatar.Build.Armor = armor;
            user.UserAvatar.Build.LeftHandItem = lHand;
            //Act
            strangeDuck.SpecialPower(game, user);
            strangeDuck.DeadEnd(game, user);
            //Assert
            strangeDuck.Power.Should().Be(14);
            strangeDuck.NumberOfPrizes.Should().Be(3);
            strangeDuck.HowManyLevels.Should().Be(2);
            user.UserAvatar.Build.Armor.Should().BeNull();
            user.UserAvatar.Build.Helmet.Should().BeNull();
            user.UserAvatar.Build.LeftHandItem.Should().BeSameAs(lHand);
            game.DestroyedPrizeCards.Should().HaveCount(2);
            game.DestroyedPrizeCards.Should().Contain(helmet);
            game.DestroyedPrizeCards.Should().Contain(armor);

        }

        [Fact]
        public void DeadEndWeakerWayTest()
        {
            //Arrange
            var game = new Game();
            var strangeDuck = new StrangeDuck("Strange Duck", CardType.Action);
            var userAvatar = new UserAvatar()
            {
                Build = new Build()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var helmet = new ItemCard("leatherHelmet", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Helmet, null, 300);
            var lHand = new ItemCard("sword1H", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            user.UserAvatar.Build.Helmet = helmet;
            user.UserAvatar.Build.LeftHandItem = lHand;
            //Act
            strangeDuck.SpecialPower(game, user);
            strangeDuck.DeadEnd(game, user);
            //Assert
            strangeDuck.Power.Should().Be(4);
            strangeDuck.NumberOfPrizes.Should().Be(2);
            strangeDuck.HowManyLevels.Should().Be(1);
            user.UserAvatar.Build.Helmet.Should().BeSameAs(helmet);
            user.UserAvatar.Build.LeftHandItem.Should().BeNull();
            game.DestroyedPrizeCards.Should().HaveCount(1);
            game.DestroyedPrizeCards.Should().Contain(lHand);
        }
    }
}
