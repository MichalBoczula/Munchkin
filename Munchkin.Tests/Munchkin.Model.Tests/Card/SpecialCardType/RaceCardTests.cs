using FluentAssertions;
using Munchkin.Model;
using Munchkin.Model.Card.ActionCard.SpecialCardType;
using Munchkin.Model.Character;
using Munchkin.Model.Character.Hero.Race;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Munchkin.Tests.Munchkin.Model.Tests.Card.SpecialCardType
{
    public class RaceCardTests
    {
        [Fact]
        public void SpecialEffectsTests()
        {
            //Arrange
            var elf = new Elf("elf");
            var raceCard = new RaceCard("elf", CardType.Initial, elf);
            var userAvatar = new UserAvatar();
            var userClass = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            raceCard.SpecialEffect(userClass);
            //Assert
            userClass.UserAvatar.Race.Should().NotBeNull();
            userClass.UserAvatar.Race.Should().BeOfType<Elf>();
        }
    }
}
