using FluentAssertions;
using Moq;
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
    public class ItemFairyTests
    {
        [Fact]
        public void CastSpecialSpell()
        {
            //Arrange
            var game = new Game();
            var mockRandom = new Mock<Random>();
            mockRandom.Setup(x => x.Next(It.IsAny<int>())).Returns(1);
            var curse = new ItemFairy("Item Fairy", CardType.Curse, mockRandom.Object);
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var stolen = new ItemCard("leatherArmor", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Armor, null, 300);
            user.UserAvatar.Build.Helmet = new ItemCard("leatherHelmet", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Helmet, null, 300);
            user.UserAvatar.Build.Armor = stolen;
            user.UserAvatar.Build.Boots = new ItemCard("normalBoot", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Boots, null, 300);
            //Act
            curse.CastSpecialSpell(user: user, monster: null, game: game);
            //Assert
            user.UserAvatar.Build.Armor.Should().BeNull();
            game.DestroyedPrizeCards.Should().HaveCount(1);
            game.DestroyedPrizeCards[0].Should().Be(stolen);
        }
    }
}
