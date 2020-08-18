using Munchkin.BL.CardGenerator.CardsStack;
using Munchkin.BL.CardGenerator.PrizeCard.ItemCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

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
            //Assert
            var areThereWeapons = prizeStack.Deck.Any(x => prizeStack.Weapons.Any(y => x == y));
            var areThereBoots = prizeStack.Deck.Any(x => prizeStack.Boots.Any(y => x == y));
            var areThereHelmets = prizeStack.Deck.Any(x => prizeStack.Helmets.Any(y => x == y));
            var areThereArmors = prizeStack.Deck.Any(x => prizeStack.Armors.Any(y => x == y));
            Assert.True(areThereWeapons);
            Assert.True(areThereBoots);
            Assert.True(areThereHelmets);
            Assert.True(areThereArmors);
            Assert.Equal(20, prizeStack.Deck.Count);
        }
    }
}
