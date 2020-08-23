using Munchkin.BL.CardGenerator.CardsStack;
using Munchkin.BL.CardGenerator.PrizeCard.ItemCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using FluentAssertions;

namespace Munchkin.Tests.Munchkin.BL.Tests.CardGenerator.CardStack
{
    public class PrizeStackTests
    {
        [Fact]
        public void DeckCountTest()
        {
            //Arrange
            var itemCardGenerator = new ItemCardGenerator();
            //Act
            var prizeStack = new PrizeStack(
                weapons: itemCardGenerator.GenerateWeaponCards(),
                armors: itemCardGenerator.GenerateArmorCards(),
                boots: itemCardGenerator.GenerateBootsCards(),
                helmets: itemCardGenerator.GenerateHelmetCards());
            var areThereWeapons = prizeStack.Deck.Any(x => prizeStack.Weapons.Any(y => x == y));
            var areThereBoots = prizeStack.Deck.Any(x => prizeStack.Boots.Any(y => x == y));
            var areThereHelmets = prizeStack.Deck.Any(x => prizeStack.Helmets.Any(y => x == y));
            var areThereArmors = prizeStack.Deck.Any(x => prizeStack.Armors.Any(y => x == y));
            //Assert
            areThereArmors.Should().BeTrue();
            areThereBoots.Should().BeTrue();
            areThereHelmets.Should().BeTrue();
            areThereWeapons.Should().BeTrue();
            prizeStack.Deck.Should().HaveCount(20);
        }
    }
}
