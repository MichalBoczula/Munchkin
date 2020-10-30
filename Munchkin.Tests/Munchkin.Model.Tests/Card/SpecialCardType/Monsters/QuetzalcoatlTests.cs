using FluentAssertions;
using Moq;
using Munchkin.BL.CardGenerator;
using Munchkin.BL.CharacterCreator;
using Munchkin.BL.GameController;
using Munchkin.BL.Helper;
using Munchkin.Model;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret;
using Munchkin.Model.Character;
using Munchkin.Model.Character.Hero.Proficiency;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Munchkin.Tests.Munchkin.Model.Tests.Card.SpecialCardType.Monsters
{
    public class QuetzalcoatlTests
    {
        [Fact]
        public void SpecialPowerDiffrentClassTest()
        {
            //Arrange
            var game = new Game();
            var quetzalcoatl = new Quetzalcoatl("Quetzalcoatl", CardType.Monster);
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            quetzalcoatl.SpecialPower(game, user);
            //Assert
            quetzalcoatl.Power.Should().Be(21);
            quetzalcoatl.NumberOfPrizes.Should().Be(4);
            quetzalcoatl.HowManyLevels.Should().Be(2);
        }


        [Fact]
        public void SpecialPowerPriestTest()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var game = new Game();
            var quetzalcoatl = new Quetzalcoatl("Quetzalcoatl", CardType.Monster);
            var userAvatar = new UserAvatar()
            {
                Proficiency = new PriestProficiency(mock.Object)
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            quetzalcoatl.SpecialPower(game, user);
            //Assert
            quetzalcoatl.Power.Should().Be(16);
            quetzalcoatl.NumberOfPrizes.Should().Be(4);
            quetzalcoatl.HowManyLevels.Should().Be(2);
        }

        [Fact]
        public void DeadEndDiffrentClassTest()
        {
            //Arrange
            var stackCardGenedratorService = new StackCardGeneratorService();
            var random = new Random();
            var drawCardService = new DrawCardService(random);
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGenedratorService);
            var game = new Game();
            var quetzalcoatl = new Quetzalcoatl("Quetzalcoatl", CardType.Monster);
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            user = prizeStackController.DrawCardsForStartDeck(user);
            //Act
            quetzalcoatl.DeadEnd(game, user);
            //Assert
            user.UserAvatar.IsDied.Should().BeTrue();
            user.Deck.Count().Should().BeGreaterThan(0);
        }

        [Fact]
        public void DeadEndPriestTest()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var stackCardGenedratorService = new StackCardGeneratorService();
            var random = new Random();
            var drawCardService = new DrawCardService(random);
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGenedratorService);
            var game = new Game();
            var quetzalcoatl = new Quetzalcoatl("Quetzalcoatl", CardType.Monster);
            var userAvatar = new UserAvatar()
            {
                Proficiency = new PriestProficiency(mock.Object)
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            user = prizeStackController.DrawCardsForStartDeck(user);
            //Act
            quetzalcoatl.DeadEnd(game, user);
            //Assert
            //Assert
            user.UserAvatar.IsDied.Should().BeFalse();
            user.Deck.Count().Should().Be(0);
        }
    }
}
