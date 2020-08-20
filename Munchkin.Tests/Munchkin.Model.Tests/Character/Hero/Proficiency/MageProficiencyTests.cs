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
        public void FleeSpellTest()
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
            
            var mage2 = new MageProficiency();
            var avatar2 = new UserAvatar()
            {
                Proficiency = mage2
            };
            var userWithOutCards = new UserClass()
            {
                UserAvatar = avatar2
            };
            user1 = prizeStackController.DrawCardsForStartDeck(user1);
            userWithOutCards = prizeStackController.DrawCardsForStartDeck(userWithOutCards);
            userWithOutCards.Deck.Clear();
            //Act
            user1.UserAvatar.Proficiency.FleeSpell(user1, 2);
            userWithOutCards.UserAvatar.Proficiency.FleeSpell(userWithOutCards, 2);
            //Assert
            //User1
            user1.UserAvatar.FleeChances.Should().Be(5);
            user1.Deck.Should().HaveCount(3);
            //UserWithOutCards        
            userWithOutCards.UserAvatar.FleeChances.Should().Be(3);
            userWithOutCards.Deck.Should().HaveCount(0);
        }

        [Fact]
        public void FleeSpellCastTwoTimesTest()
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
            user.UserAvatar.Proficiency.FleeSpell(user, 2);
            user.UserAvatar.Proficiency.FleeSpell(user, 2);
            //Assert
            user.UserAvatar.FleeChances.Should().Be(6);
            user.Deck.Should().HaveCount(2);
        }

        [Fact]
        public void CharmSpellTest()
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
            var userWithRequiaredCards = new UserClass()
            {
                UserAvatar = avatar
            };
            var userWithOutRequiaredCards = new UserClass()
            {
                UserAvatar = avatar
            };
            userWithRequiaredCards = prizeStackController.DrawCardsForStartDeck(userWithRequiaredCards);
            userWithOutRequiaredCards = prizeStackController.DrawCardsForStartDeck(userWithOutRequiaredCards);
            userWithOutRequiaredCards.Deck.Clear();
            //Act
            var resultT = userWithRequiaredCards.UserAvatar.Proficiency.CharmSpell(userWithRequiaredCards);
            var resultF = userWithOutRequiaredCards.UserAvatar.Proficiency.CharmSpell(userWithOutRequiaredCards);
            //Assert
            resultT.Should().BeTrue();
            resultF.Should().BeFalse();
        }
    }
}
