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
    public class GamblingTests
    {
        [Fact]
        public void CastSpecialSpell()
        {
            //Arrange
            var game = new Game();
            var mockRandom = new Mock<Random>();
            mockRandom.Setup(x => x.Next(It.IsAny<int>())).Returns(1);
            var curse = new Gambling("Item Fairy", CardType.Curse, mockRandom.Object);
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var stolen = new ItemCard("sword1H", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            user.UserAvatar.Build.Helmet = new ItemCard("leatherHelmet", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Helmet, null, 300);
            user.UserAvatar.Build.LeftHandItem = stolen;
            user.UserAvatar.Build.RightHandItem = new ItemCard("axe", CardType.Prize, PrizeCardType.Item, 3, null, true, ItemType.Weapon, null, 300);
            //Act
            curse.CastSpecialSpell(user: user, monster: null, game: game);
            //Assert
            user.UserAvatar.Build.Armor.Should().BeNull();
            game.DestroyedPrizeCards.Should().HaveCount(1);
            game.DestroyedPrizeCards[0].Should().Be(stolen);
        }
    }
}
