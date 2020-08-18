﻿using Munchkin.Model;
using Munchkin.Model.Card.ActionCard.SpecialCardType;
using Munchkin.Model.Character;
using Munchkin.Model.Character.Hero.Proficiency;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Munchkin.Tests.Munchkin.Model.Tests.Card.SpecialCardType
{
    public class ProficiencyCardTests
    {
        [Fact]
        public void SpecialEffectsTests()
        {
            //Arrange
            var mage = new MageProficiency();
            var raceCard = new ProficiencyCard("mage", CardType.Action, mage);
            var userAvatar = new UserAvatar();
            var userClass = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            raceCard.SpecialEffect(userClass);
            //Assert
            Assert.NotNull(userClass.UserAvatar.Proficiency);
            Assert.IsType<MageProficiency>(userClass.UserAvatar.Proficiency);
        }
    }
}
