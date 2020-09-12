using FluentAssertions;
using Munchkin.Model;
using Munchkin.Model.Card.ActionCard.SpecialCardType.MagicCards;
using Munchkin.Model.Card.PrizeCard;
using Munchkin.Model.Character;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Munchkin.Tests.Munchkin.Model.Tests.Card.SpecialCardType.MagicCard
{
    public class DropWeaponsTests
    {
        [Fact]
        public void CastSpecialSpellWithTwoWeaponsTest()
        {
            //Arrange
            var game = new Game();
            var curse = new DropWeapons("Drop Weapons", CardType.Curse);
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var lHand = new ItemCard("sword1H", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var rHand = new ItemCard("axe", CardType.Prize, PrizeCardType.Item, 3, null, true, ItemType.Weapon, null, 300);
            user.UserAvatar.Build.LeftHandItem = lHand;
            user.UserAvatar.Build.RightHandItem = rHand;
            //Act
            curse.CastSpecialSpell(user, null, game);
            //Assert
            game.DestroyedPrizeCards.Should().HaveCount(2);
            game.DestroyedPrizeCards[0].Should().BeSameAs(lHand);
            game.DestroyedPrizeCards[1].Should().BeSameAs(rHand);
            user.UserAvatar.Build.LeftHandItem.Should().BeNull();
            user.UserAvatar.Build.RightHandItem.Should().BeNull();
        }

        [Fact]
        public void CastSpecialSpellWithOneWeaponLeftTest()
        {
            //Arrange
            var game = new Game();
            var curse = new DropWeapons("Drop Weapons", CardType.Curse);
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var lHand = new ItemCard("sword1H", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            user.UserAvatar.Build.LeftHandItem = lHand;
            //Act
            curse.CastSpecialSpell(user, null, game);
            //Assert
            game.DestroyedPrizeCards.Should().HaveCount(1);
            game.DestroyedPrizeCards[0].Should().BeSameAs(lHand);
            user.UserAvatar.Build.LeftHandItem.Should().BeNull();
        }

        [Fact]
        public void CastSpecialSpellWithOneWeaponRightTest()
        {
            //Arrange
            var game = new Game();
            var curse = new DropWeapons("Drop Weapons", CardType.Curse);
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var rHand = new ItemCard("axe", CardType.Prize, PrizeCardType.Item, 3, null, true, ItemType.Weapon, null, 300);
            user.UserAvatar.Build.RightHandItem = rHand;
            //Act
            curse.CastSpecialSpell(user, null, game);
            //Assert
            game.DestroyedPrizeCards.Should().HaveCount(1);
            game.DestroyedPrizeCards[0].Should().BeSameAs(rHand);
            user.UserAvatar.Build.RightHandItem.Should().BeNull();
        }

        [Fact]
        public void CastSpecialSpellNoWeaponsTest()
        {
            //Arrange
            var game = new Game();
            var curse = new DropWeapons("Drop Weapons", CardType.Curse);
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            curse.CastSpecialSpell(user, null, game);
            //Assert
            game.DestroyedPrizeCards.Should().HaveCount(0);
            user.UserAvatar.Build.LeftHandItem.Should().BeNull();
            user.UserAvatar.Build.RightHandItem.Should().BeNull();
        }
    }
}
