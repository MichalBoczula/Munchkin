using Munchkin.BL.CardGenerator;
using Munchkin.Model;
using Munchkin.Model.Card.ActionCard.SpecialCardType;
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
    }
}
