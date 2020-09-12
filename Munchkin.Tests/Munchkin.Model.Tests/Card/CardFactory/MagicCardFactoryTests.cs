using FluentAssertions;
using Munchkin.Model.Card.ActionCard.SpecialCardType.MagicCards;
using Munchkin.Model.Card.CardFactory;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Munchkin.Tests.Munchkin.Model.Tests.Card.CardFactory
{
    public class MagicCardFactoryTests
    {
        [Fact]
        public void CreateWeaponCardTest()
        {
            //Arrange
            var magicCardFactory = new MagicCardFactory();
            //Act
            var m1 = magicCardFactory.CreateMonsterCard(1);
            //Assert
            m1.Should().BeOfType<PayToHaron>();
        }
    }
}
