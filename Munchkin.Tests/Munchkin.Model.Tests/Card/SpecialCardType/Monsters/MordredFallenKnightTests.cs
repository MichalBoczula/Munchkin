using FluentAssertions;
using Munchkin.Model;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret;
using Munchkin.Model.Card.PrizeCard;
using Munchkin.Model.Character;
using Munchkin.Model.Character.Hero.Proficiency;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Munchkin.Tests.Munchkin.Model.Tests.Card.SpecialCardType.Monsters
{
    public class MordredFallenKnightTests
    {
        [Fact]
        public void SpecialPowerWarriorTest()
        {
            //Arrange
            var game = new Game();
            var mordredFallenKnight = new MordredFallenKnight("Mordred Fallen Knight", CardType.Monster);
            var proficiency = new WarriorProficiency();
            var userAvatar = new UserAvatar()
            {
                Proficiency = proficiency
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            mordredFallenKnight.SpecialPower(game, user);
            //Assert
            mordredFallenKnight.Power.Should().Be(8);
            mordredFallenKnight.NumberOfPrizes.Should().Be(2);
            mordredFallenKnight.HowManyLevels.Should().Be(1);
        }

        [Fact]
        public void SpecialPowerDiffrentProficiencyTest()
        {
            //Arrange
            var game = new Game();
            var mordredFallenKnight = new MordredFallenKnight("Mordred Fallen Knight", CardType.Monster);
            var priest = new PriestProficiency();
            var userAvatar = new UserAvatar()
            {
                Proficiency = priest
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            mordredFallenKnight.SpecialPower(game, user);
            //Assert
            mordredFallenKnight.Power.Should().Be(11);
            mordredFallenKnight.NumberOfPrizes.Should().Be(2);
            mordredFallenKnight.HowManyLevels.Should().Be(1);
        }

        [Fact]
        public void DeadEndTest()
        {
            //Arrange
            var game = new Game();
            var mordredFallenKnight = new MordredFallenKnight("Mordred Fallen Knight", CardType.Monster);
            var priest = new PriestProficiency();
            var userAvatar = new UserAvatar()
            {
                Proficiency = priest
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            mordredFallenKnight.DeadEnd(game, user);
            user.UserAvatar.EndTurn();
            //Assert
            user.UserAvatar.Nerfs.Wounded.Should().Contain(true);
            user.UserAvatar.Nerfs.Wounded.Should().HaveCount(1);
            user.UserAvatar.Power.Should().Be(-1);
            user.UserAvatar.FleeChances.Should().Be(2);
        }
    }
}
