using Munchkin.Model;
using Munchkin.Model.Card.ActionCard.SpecialCardType;
using Munchkin.Model.Character;
using Munchkin.Model.Character.Hero.Proficiency;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;
using Munchkin.BL.Helper;
using Moq;

namespace Munchkin.Tests.Munchkin.Model.Tests.Card.SpecialCardType
{
    public class ProficiencyCardTests
    {
        [Fact]
        public void SpecialEffectsTests()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var mage = new MageProficiency(mock.Object);
            var raceCard = new ProficiencyCard("mage", CardType.Initial, mage);
            var userAvatar = new UserAvatar();
            var userClass = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            raceCard.SpecialEffect(userClass);
            //Assert
            userClass.UserAvatar.Proficiency.Should().NotBeNull();
            userClass.UserAvatar.Proficiency.Should().BeOfType<MageProficiency>();
        }
    }
}
