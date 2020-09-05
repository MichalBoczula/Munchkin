using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Munchkin.BL.CardGenerator;
using Munchkin.BL.CharacterCreator;
using Munchkin.BL.GameController;
using Munchkin.Model;
using Munchkin.Model.Character;
using Munchkin.Model.Character.Hero.Proficiency;
using Xunit;

namespace Munchkin.Tests.Munchkin.Model.Tests.Character.Hero.Proficiency
{
    public class WarriorProficiencyTests
    {
        [Fact]
        public void BeStrongerSuccessTest()
        {
            //Arrange
            var random = new Random();
            var drawCard = new DrawCardService(random);
            var stackCardGeneratorService = new StackCardGeneratorService();
            var prizeStackGenerator = new PrizeStackController(drawCard, stackCardGeneratorService);
            var warrior = new WarriorProficiency();
            var userAvatar = new UserAvatar()
            {
                Proficiency = warrior
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            user = prizeStackGenerator.DrawCardsForStartDeck(user);
            //Act
            user.UserAvatar.Proficiency.BeStronger(user, 1);
            user.UserAvatar.Proficiency.BeStronger(user, 1);
            user.UserAvatar.Proficiency.BeStronger(user, 1);
            //Assert
            user.UserAvatar.TempPower.Should().Be(4);
            user.Deck.Count().Should().Be(2);
        }

        [Fact]
        public void BeStrongerFailNotEnoughCardsTest()
        {
            //Arrange
            var random = new Random();
            var drawCard = new DrawCardService(random);
            var stackCardGeneratorService = new StackCardGeneratorService();
            var prizeStackGenerator = new PrizeStackController(drawCard, stackCardGeneratorService);
            var warrior = new WarriorProficiency();
            var userAvatar = new UserAvatar()
            {
                Proficiency = warrior
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            user = prizeStackGenerator.DrawCardsForStartDeck(user);
            user.Deck.Clear();
            //Act
            user.UserAvatar.Proficiency.BeStronger(user, 1);
            //Assert
            user.UserAvatar.TempPower.Should().Be(1);
            user.Deck.Count().Should().Be(0);
        }

        [Fact]
        public void BeStrongerDeckIsNullTest()
        {
            //Arrange
            var random = new Random();
            var drawCard = new DrawCardService(random);
            var stackCardGeneratorService = new StackCardGeneratorService();
            var prizeStackGenerator = new PrizeStackController(drawCard, stackCardGeneratorService);
            var warrior = new WarriorProficiency();
            var userAvatar = new UserAvatar()
            {
                Proficiency = warrior
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            user.UserAvatar.Proficiency.BeStronger(user, 1);
            //Assert
            user.UserAvatar.TempPower.Should().Be(1);
            user.Deck.Count().Should().Be(0);
        }

        [Fact]
        public void BeStrongerCastFourTimesTest()
        {
            //Arrange
            var random = new Random();
            var drawCard = new DrawCardService(random);
            var stackCardGeneratorService = new StackCardGeneratorService();
            var prizeStackGenerator = new PrizeStackController(drawCard, stackCardGeneratorService);
            var warrior = new WarriorProficiency();
            var userAvatar = new UserAvatar()
            {
                Proficiency = warrior
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            user = prizeStackGenerator.DrawCardsForStartDeck(user);
            //Act
            user.UserAvatar.Proficiency.BeStronger(user, 1);
            user.UserAvatar.Proficiency.BeStronger(user, 1);
            user.UserAvatar.Proficiency.BeStronger(user, 1);
            user.UserAvatar.Proficiency.BeStronger(user, 1);
            //Assert
            user.UserAvatar.TempPower.Should().Be(4);
            user.Deck.Count().Should().Be(2);
        }
    }
}
