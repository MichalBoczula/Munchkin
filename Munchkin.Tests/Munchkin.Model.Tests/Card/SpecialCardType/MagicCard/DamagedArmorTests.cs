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
    public class DamagedArmorTests
    {
        [Fact]
        public void CastSpecialSpellWithArmorTest()
        {
            //Arrange
            var game = new Game();
            var curse = new DamagedArmor("Damaged Armor", CardType.Curse);
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var armor = new ItemCard("leatherArmor", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Armor, null, 300);
            user.UserAvatar.Build.Armor = armor;
            //Act
            curse.CastSpecialSpell(user, null, game);
            //Assert
            game.DestroyedPrizeCards.Should().HaveCount(1);
            game.DestroyedPrizeCards[0].Should().BeSameAs(armor);
            user.UserAvatar.Build.Armor.Should().BeNull();
        }

        [Fact]
        public void CastSpecialSpellNoArmorTest()
        {
            //Arrange
            var game = new Game();
            var curse = new DamagedArmor("Damaged Armor", CardType.Curse);
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            curse.CastSpecialSpell(user, null, game);
            //Assert
            game.DestroyedPrizeCards.Should().HaveCount(0);
            user.UserAvatar.Build.Armor.Should().BeNull();
        }
    }
}
