﻿using FluentAssertions;
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
    public class DamagedHelmetTests
    {
        [Fact]
        public void CastSpecialSpellWithHelmetTest()
        {
            //Arrange
            var game = new Game();
            var curse = new DamagedHelmet("Damaged Helmet", CardType.Curse);
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var helmet = new ItemCard("leatherHelmet", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Helmet, null, 300);
            user.UserAvatar.Build.Helmet = helmet;
            //Act
            curse.CastSpecialSpell(user, null, game);
            //Assert
            game.DestroyedPrizeCards.Should().HaveCount(1);
            game.DestroyedPrizeCards[0].Should().BeSameAs(helmet);
            user.UserAvatar.Build.Helmet.Should().BeNull();
        }

        [Fact]
        public void CastSpecialSpellNoHelmetTest()
        {
            //Arrange
            var game = new Game();
            var curse = new DamagedHelmet("Damaged Helmet", CardType.Curse);
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            curse.CastSpecialSpell(user, null, game);
            //Assert
            game.DestroyedPrizeCards.Should().HaveCount(0);
            user.UserAvatar.Build.Helmet.Should().BeNull();
        }
    }
}
