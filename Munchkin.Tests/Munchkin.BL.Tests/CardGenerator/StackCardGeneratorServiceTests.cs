using Munchkin.BL.CardGenerator;
using Munchkin.Model;
using Munchkin.Model.Card.ActionCard.SpecialCardType;
using Munchkin.Model.Card.PrizeCard;
using System;
using System.Collections.Generic;
using Xunit;

namespace Munchkin.Tests.Munchkin.BL.Tests.CardGenerator
{
    public class StackCardGeneratorServiceTests
    {
        [Fact]
        public void GenerateInitialCreationStackTest()
        {
            //Arrange
            var generator = new StackCardGeneratorService();
            //Act
            var stack = generator.GenerateInitialCreationStack();
            //Assert
            Assert.True(stack.Races is IList<RaceCard>);
            Assert.True(stack.Proficiencies is IList<ProficiencyCard>);
            Assert.Equal(4, stack.Races.Count);
            Assert.Equal(5, stack.Proficiencies.Count);
        }

        [Fact]
        public void GeneratePrizeStackTest()
        {
            //Arrange
            var generator = new StackCardGeneratorService();
            //Act
            var stack = generator.GeneratePrizeStack();
            //Assert
            Assert.True(stack.Weapons is IList<ItemCard>);
            Assert.True(stack.Armors is IList<ItemCard>);
            Assert.True(stack.Boots is IList<ItemCard>);
            Assert.True(stack.Helmets is IList<ItemCard>);
            Assert.Equal(5, stack.Weapons.Count);
            Assert.Equal(5, stack.Armors.Count);
            Assert.Equal(5, stack.Boots.Count);
            Assert.Equal(5, stack.Helmets.Count);
        }
    }
}
