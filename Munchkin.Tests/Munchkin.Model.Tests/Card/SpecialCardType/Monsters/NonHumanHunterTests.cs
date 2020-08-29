using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using FluentAssertions;
using Munchkin.Model;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret;
using Munchkin.Model.Card.PrizeCard;
using Munchkin.Model.Character;
using Munchkin.Model.Character.Hero.Race;
using Munchkin.Model.User;
using Xunit;

namespace Munchkin.Tests.Munchkin.Model.Tests.Card.SpecialCardType.Monsters
{
    public class NonHumanHunterTests
    {
        [Fact]
        public void SpecialPowerHumanTest()
        {
            //Arrange
            var game = new Game();
            var nonHumanHunter = new NonHumanHunter("Non Human Hunter", CardType.Action);
            var human = new Human("human");
            var userAvatar = new UserAvatar()
            {
                Race = human
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            nonHumanHunter.SpecialPower(game, user);
            //Assert
            nonHumanHunter.Power.Should().Be(2);
            nonHumanHunter.NumberOfPrizes.Should().Be(1);
            nonHumanHunter.HowManyLevels.Should().Be(1);
        }

        [Fact]
        public void SpecialPowerNonHumanTest()
        {
            //Arrange
            var game = new Game();
            var nonHumanHunter = new NonHumanHunter("Non Human Hunter", CardType.Action);
            var elf = new Elf("elf");
            var userAvatar = new UserAvatar()
            {
                Race = elf
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            nonHumanHunter.SpecialPower(game, user);
            //Assert
            nonHumanHunter.Power.Should().Be(7);
        }


        [Fact]
        public void DeadEndTest()
        {
            //Arrange
            var game = new Game();
            var nonHumanHunter = new NonHumanHunter("Non Human Hunter", CardType.Action);
            var elf = new Elf("elf");
            var userAvatar = new UserAvatar()
            {
                Build = new Build(),
                Race = elf
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var armor = new ItemCard("leatherArmor", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Armor, null, 300);
            user.UserAvatar.Build.Armor = armor;
            //Act
            nonHumanHunter.DeadEnd(game, user);
            //Assert
            game.DestroyedPrizeCards.Should().HaveCount(1);
            game.DestroyedPrizeCards[0].Should().BeSameAs(armor);
            user.UserAvatar.Build.Armor.Should().BeNull();
        }

        [Fact]
        public void DeadEndNoArmorTest()
        {
            //Arrange
            var game = new Game();
            var nonHumanHunter = new NonHumanHunter("Non Human Hunter", CardType.Action);
            var elf = new Elf("elf");
            var userAvatar = new UserAvatar()
            {
                Build = new Build(),
                Race = elf
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            nonHumanHunter.DeadEnd(game, user);
            //Assert
            game.DestroyedPrizeCards.Should().HaveCount(0);
            user.UserAvatar.Build.Armor.Should().BeNull();
        }
    }
}
