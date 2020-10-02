using FluentAssertions;
using Moq;
using Munchkin.Model;
using Munchkin.Model.Card.ActionCard.SpecialCardType.MagicCards;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret;
using Munchkin.Model.Card.PrizeCard;
using Munchkin.Model.Character;
using Munchkin.Model.User;
using Munchkin.Tests.Munchkin.Model.Tests.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Munchkin.Tests.Munchkin.Model.Tests.Card.SpecialCardType.MagicCard
{
    public class WhatAMessTests
    {
        [Fact]
        public void CastSpecialSpellDestroyFirstItemCard()
        {
            //Arrange
            var game = new Game();
            var mockRandom = new Mock<Random>();
            mockRandom.Setup(x => x.Next(It.IsAny<int>())).Returns(0);
            var curse = new WhatAMess("WhatAMess", CardType.Monster, mockRandom.Object);
            var userAvatar = new UserAvatar()
            {
                Build = new Build()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var cardToDestroy = new ItemCard("leatherArmor", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Armor, null, 300);
            user.Deck.Items.Add(cardToDestroy);
            user.Deck.Items.Add(new ItemCard("leatherHelmet", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Helmet, null, 300));
            user.Deck.MagicCards.Add(new BackToSchool("BackToSchool", CardType.Curse));
            user.Deck.MagicCards.Add(new Crook("Crook", CardType.Special));
            user.Deck.Monsters.Add(new AntArmy("Ant Army", CardType.Monster));
            //Act
            curse.CastSpecialSpell(user: user, monster: null, game: game);
            //Assert
            user.Deck.Count().Should().Be(4);
            user.Deck.Items.Count.Should().Be(1);
            user.Deck.MagicCards.Count.Should().Be(2);
            user.Deck.Monsters.Count.Should().Be(1);
            game.DestroyedPrizeCards.Should().HaveCount(1);
            game.DestroyedPrizeCards[0].Should().BeSameAs(cardToDestroy);
        }

        [Fact]
        public void CastSpecialSpellDestroySecondItemCard()
        {
            //Arrange
            var game = new Game();
            var mockRandom = new Mock<Random>();
            mockRandom.Setup(x => x.Next(It.IsAny<int>())).Returns(1);
            var curse = new WhatAMess("WhatAMess", CardType.Monster, mockRandom.Object);
            var userAvatar = new UserAvatar()
            {
                Build = new Build()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var cardToDestroy = new ItemCard("leatherHelmet", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Helmet, null, 300);
            user.Deck.Items.Add(new ItemCard("leatherArmor", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Armor, null, 300));
            user.Deck.Items.Add(cardToDestroy);
            user.Deck.MagicCards.Add(new BackToSchool("BackToSchool", CardType.Curse));
            user.Deck.MagicCards.Add(new Crook("Crook", CardType.Special));
            user.Deck.Monsters.Add(new AntArmy("Ant Army", CardType.Monster));
            //Act
            curse.CastSpecialSpell(user: user, monster: null, game: game);
            //Assert
            user.Deck.Count().Should().Be(4);
            user.Deck.Items.Count.Should().Be(1);
            user.Deck.MagicCards.Count.Should().Be(2);
            user.Deck.Monsters.Count.Should().Be(1);
            game.DestroyedPrizeCards.Should().HaveCount(1);
            game.DestroyedPrizeCards[0].Should().BeSameAs(cardToDestroy);
        }

        [Fact]
        public void CastSpecialSpellDestroyMagicCardFirst()
        {
            //Arrange
            var game = new Game();
            var mockRandom = new Mock<Random>();
            mockRandom.Setup(x => x.Next(It.IsAny<int>())).Returns(2);
            var curse = new WhatAMess("WhatAMess", CardType.Monster, mockRandom.Object);
            var userAvatar = new UserAvatar()
            {
                Build = new Build()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var cardToDestroy = new BackToSchool("BackToSchool", CardType.Curse);
            user.Deck.Items.Add(new ItemCard("leatherArmor", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Armor, null, 300));
            user.Deck.Items.Add(new ItemCard("leatherHelmet", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Helmet, null, 300));
            user.Deck.MagicCards.Add(cardToDestroy);
            user.Deck.MagicCards.Add(new Crook("Crook", CardType.Special));
            user.Deck.Monsters.Add(new AntArmy("Ant Army", CardType.Monster));
            //Act
            curse.CastSpecialSpell(user: user, monster: null, game: game);
            //Assert
            user.Deck.Count().Should().Be(4);
            user.Deck.Items.Count.Should().Be(2);
            user.Deck.MagicCards.Count.Should().Be(1);
            user.Deck.Monsters.Count.Should().Be(1);
            game.DestroyedActionCards.Should().HaveCount(1);
            game.DestroyedActionCards[0].Should().BeSameAs(cardToDestroy);
        }


        [Fact]
        public void CastSpecialSpellDestroyMagicCardSecond()
        {
            //Arrange
            var game = new Game();
            var mockRandom = new Mock<Random>();
            mockRandom.Setup(x => x.Next(It.IsAny<int>())).Returns(3);
            var curse = new WhatAMess("WhatAMess", CardType.Monster, mockRandom.Object);
            var userAvatar = new UserAvatar()
            {
                Build = new Build()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var cardToDestroy = new Crook("Crook", CardType.Special);
            user.Deck.Items.Add(new ItemCard("leatherArmor", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Armor, null, 300));
            user.Deck.Items.Add(new ItemCard("leatherHelmet", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Helmet, null, 300));
            user.Deck.MagicCards.Add(new BackToSchool("BackToSchool", CardType.Curse));
            user.Deck.MagicCards.Add(cardToDestroy);
            user.Deck.Monsters.Add(new AntArmy("Ant Army", CardType.Monster));
            //Act
            curse.CastSpecialSpell(user: user, monster: null, game: game);
            //Assert
            user.Deck.Count().Should().Be(4);
            user.Deck.Items.Count.Should().Be(2);
            user.Deck.MagicCards.Count.Should().Be(1);
            user.Deck.Monsters.Count.Should().Be(1);
            game.DestroyedActionCards.Should().HaveCount(1);
            game.DestroyedActionCards[0].Should().BeSameAs(cardToDestroy);
        }

        [Fact]
        public void CastSpecialSpellDestroyMonsterCard()
        {
            //Arrange
            var game = new Game();
            var mockRandom = new Mock<Random>();
            mockRandom.Setup(x => x.Next(It.IsAny<int>())).Returns(4);
            var curse = new WhatAMess("WhatAMess", CardType.Monster, mockRandom.Object);
            var userAvatar = new UserAvatar()
            {
                Build = new Build()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var cardToDestroy = new AntArmy("Ant Army", CardType.Monster);
            user.Deck.Items.Add(new ItemCard("leatherArmor", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Armor, null, 300));
            user.Deck.Items.Add(new ItemCard("leatherHelmet", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Helmet, null, 300));
            user.Deck.MagicCards.Add(new BackToSchool("BackToSchool", CardType.Curse));
            user.Deck.MagicCards.Add(new Crook("Crook", CardType.Special));
            user.Deck.Monsters.Add(cardToDestroy);
            //Act
            curse.CastSpecialSpell(user: user, monster: null, game: game);
            //Assert
            user.Deck.Count().Should().Be(4);
            user.Deck.Items.Count.Should().Be(2);
            user.Deck.MagicCards.Count.Should().Be(2);
            user.Deck.Monsters.Count.Should().Be(0);
            game.DestroyedActionCards.Should().HaveCount(1);
            game.DestroyedActionCards[0].Should().BeSameAs(cardToDestroy);
        }

        [Fact]
        public void CastSpecialSpellNoCardInDeck()
        {
            //Arrange
            var game = new Game();
            var mockRandom = new Mock<Random>();
            mockRandom.Setup(x => x.Next(It.IsAny<int>())).Returns(1);
            var curse = new WhatAMess("WhatAMess", CardType.Monster, mockRandom.Object);
            var userAvatar = new UserAvatar()
            {
                Build = new Build()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            curse.CastSpecialSpell(user: user, monster: null, game: game);
            //Assert
            user.Deck.Count().Should().Be(0);
            game.DestroyedActionCards.Should().HaveCount(0);
            game.DestroyedPrizeCards.Should().HaveCount(0);
        }
    }
}
