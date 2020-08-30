using Munchkin.Model;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret;
using Munchkin.Model.Character;
using Munchkin.Model.Character.Hero.Race;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;

namespace Munchkin.Tests.Munchkin.Model.Tests.Card.SpecialCardType.Monsters
{
    public class DemonicFlyTests
    {
        [Fact]
        public void SpecialPowerElfTest()
        {
            //Arrange
            var game = new Game();
            var demonicFly = new DemonicFly("Demonic Fly", CardType.Action);
            var elf = new Elf("elf");
            var userAvatar = new UserAvatar()
            {
                Race = elf,
                Build = new Build()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            demonicFly.SpecialPower(game, user);
            //Assert
            demonicFly.Power.Should().Be(10);
            demonicFly.NumberOfPrizes.Should().Be(2);
            demonicFly.HowManyLevels.Should().Be(1);
        }

        [Fact]
        public void SpecialPowerDiffrentRaceTest()
        {
            //Arrange
            var game = new Game();
            var demonicFly = new DemonicFly("Demonic Fly", CardType.Action);
            var dwarf = new Dwarf("dwarf");
            var userAvatar = new UserAvatar()
            {
                Race = dwarf,
                Build = new Build()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            demonicFly.SpecialPower(game, user);
            //Assert
            demonicFly.Power.Should().Be(6);
            demonicFly.NumberOfPrizes.Should().Be(2);
            demonicFly.HowManyLevels.Should().Be(1);
        }


        [Fact]
        public void DeadEndElfTest()
        {
            //Arrange
            var game = new Game();
            var demonicFly = new DemonicFly("Demonic Fly", CardType.Action);
            var elf = new Elf("elf");
            var userAvatar = new UserAvatar()
            {
                Race = elf,
                Build = new Build()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            demonicFly.DeadEnd(game, user);
            //Assert
            user.UserAvatar.Level.Should().Be(-1);
        }

        [Fact]
        public void DeadEndDiffrentRaceTest()
        {
            //Arrange
            var game = new Game();
            var demonicFly = new DemonicFly("Demonic Fly", CardType.Action);
            var dwarf = new Dwarf("dwarf");
            var userAvatar = new UserAvatar()
            {
                Race = dwarf,
                Build = new Build()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            demonicFly.DeadEnd(game, user);
            //Assert
            user.UserAvatar.Level.Should().Be(0);
        }
    }
}
