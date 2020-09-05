using FluentAssertions;
using Munchkin.BL.CardGenerator.ActionCard.Monsters;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Munchkin.Tests.Munchkin.BL.Tests.CardGenerator.CardStack.Monsters
{
    public class MonstersGeneratorTests
    {
        [Fact]
        public void GenerateRaceTest()
        {
            //Arrange
            var monsterGenerator = new MonstersGenerator();
            //Act
            var result = monsterGenerator.GenerateMonsterCards();
            //Assert
            result.Should().HaveCount(34);
            result.Should().NotContainNulls();
        }
    }
}
