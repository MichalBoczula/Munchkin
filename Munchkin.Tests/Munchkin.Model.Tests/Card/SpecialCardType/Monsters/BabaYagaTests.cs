using FluentAssertions;
using Munchkin.BL.CardGenerator;
using Munchkin.BL.CharacterCreator;
using Munchkin.BL.GameController;
using Munchkin.Model;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret;
using Munchkin.Model.Character;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Munchkin.Tests.Munchkin.Model.Tests.Card.SpecialCardType.Monsters
{
    public class BabaYagaTests
    {
        [Fact]
        public void SpecialPowerTest()
        {
            //Arrange
            var game = new Game();
            var babaYaga = new BabaYaga("Baba Yaga", CardType.Action);
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            babaYaga.SpecialPower(game, user);
            //Assert
            babaYaga.Power.Should().Be(18);
            babaYaga.NumberOfPrizes.Should().Be(4);
            babaYaga.HowManyLevels.Should().Be(2);
            user.UserAvatar.Nerfs.Wounded.Should().HaveCount(1);
            user.UserAvatar.Nerfs.Wounded.Should().Contain(true);
        }

        [Fact]
        public void DeadEndTest()
        {
            //Arrange
            var stackCardGenedratorService = new StackCardGeneratorService();
            var random = new Random();
            var drawCardService = new DrawCardService(random);
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGenedratorService);
            var game = new Game();
            var babaYaga = new BabaYaga("Baba Yaga", CardType.Action);
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            user = prizeStackController.DrawCardsForStartDeck(user);
            //Act
            babaYaga.DeadEnd(game, user);
            //Assert
            user.Deck.Should().BeEmpty();
            user.Deck.Should().NotBeNull();
        }
    }
}
