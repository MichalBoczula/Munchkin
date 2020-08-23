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
    public class MageProficiencyTests
    {
        [Fact]
        public void FleeSpellSuccessTest()
        {
            //Arrange
            var stackCardGenedratorService = new StackCardGeneratorService();
            var random = new Random();
            var drawCardService = new DrawCardService(random);
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGenedratorService);
            var mage1 = new MageProficiency();
            var avatar1 = new UserAvatar()
            {
                Proficiency = mage1
            };
            var user1 = new UserClass()
            {
                UserAvatar = avatar1
            };
            user1 = prizeStackController.DrawCardsForStartDeck(user1);
            //Act
            user1.UserAvatar.Proficiency.FleeSpell(user1, 1);
            user1.UserAvatar.Proficiency.FleeSpell(user1, 1);
            user1.UserAvatar.Proficiency.FleeSpell(user1, 1);
            //Assert
            user1.UserAvatar.FleeChances.Should().Be(6);
            user1.Deck.Should().HaveCount(2);
        }

        [Fact]
        public void FleeSpellEmptyDecktTest()
        {
            //Arrange
            var stackCardGenedratorService = new StackCardGeneratorService();
            var random = new Random();
            var drawCardService = new DrawCardService(random);
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGenedratorService);
            var mage1 = new MageProficiency();
            var avatar1 = new UserAvatar()
            {
                Proficiency = mage1
            };
            var user1 = new UserClass()
            {
                UserAvatar = avatar1
            };
            user1 = prizeStackController.DrawCardsForStartDeck(user1);
            user1.Deck.Clear();
            //Act
            user1.UserAvatar.Proficiency.FleeSpell(user1, 1);
            //Assert
            user1.UserAvatar.FleeChances.Should().Be(3);
            user1.Deck.Should().HaveCount(0);
        }

        [Fact]
        public void FleeSpellDeckIsNullTest()
        {
            //Arrange
            var stackCardGenedratorService = new StackCardGeneratorService();
            var random = new Random();
            var drawCardService = new DrawCardService(random);
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGenedratorService);
            var mage1 = new MageProficiency();
            var avatar1 = new UserAvatar()
            {
                Proficiency = mage1
            };
            var user = new UserClass()
            {
                UserAvatar = avatar1
            };
            //Act
            user.UserAvatar.Proficiency.FleeSpell(user, 1);
            user.UserAvatar.Proficiency.FleeSpell(user, 1);
            user.UserAvatar.Proficiency.FleeSpell(user, 1);
            //Assert
            user.UserAvatar.FleeChances.Should().Be(3);
            user.Deck.Should().BeNull();
        }

        [Fact]
        public void FleeSpellCastFourTimesTest()
        {
            //Arrange
            var stackCardGenedratorService = new StackCardGeneratorService();
            var random = new Random();
            var drawCardService = new DrawCardService(random);
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGenedratorService);
            var mage1 = new MageProficiency();
            var avatar1 = new UserAvatar()
            {
                Proficiency = mage1
            };
            var user = new UserClass()
            {
                UserAvatar = avatar1
            };
            user = prizeStackController.DrawCardsForStartDeck(user);
            //Act
            user.UserAvatar.Proficiency.FleeSpell(user, 1);
            user.UserAvatar.Proficiency.FleeSpell(user, 1);
            user.UserAvatar.Proficiency.FleeSpell(user, 1);
            user.UserAvatar.Proficiency.FleeSpell(user, 1);
            //Assert
            user.UserAvatar.FleeChances.Should().Be(6);
            user.Deck.Should().HaveCount(2);
        }

        [Fact]
        public void CharmSpellSuccessTest()
        {
            //Arrange
            var stackCardGenedratorService = new StackCardGeneratorService();
            var random = new Random();
            var drawCardService = new DrawCardService(random);
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGenedratorService);
            var mage = new MageProficiency();
            var avatar = new UserAvatar()
            {
                Proficiency = mage
            };
            var user = new UserClass()
            {
                UserAvatar = avatar
            };
            user = prizeStackController.DrawCardsForStartDeck(user);
            //Act
            var result = user.UserAvatar.Proficiency.CharmSpell(user);
            //Assert
            result.Should().BeTrue();
            user.Deck.Count.Should().Be(0);
        }

        [Fact]
        public void CharmSpellFailTest()
        {
            //Arrange
            var stackCardGenedratorService = new StackCardGeneratorService();
            var random = new Random();
            var drawCardService = new DrawCardService(random);
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGenedratorService);
            var mage = new MageProficiency();
            var avatar = new UserAvatar()
            {
                Proficiency = mage
            };
            var user = new UserClass()
            {
                UserAvatar = avatar
            };
            user = prizeStackController.DrawCardsForStartDeck(user);
            user.Deck.Clear();
            //Act
            var result = user.UserAvatar.Proficiency.CharmSpell(user);
            //Assert
            result.Should().BeFalse();
            user.Deck.Should().BeEmpty();
        }
    }
}
