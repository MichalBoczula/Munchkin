using FluentAssertions;
using Munchkin.BL.CardGenerator;
using Munchkin.Model;
using Munchkin.Model.Card.ActionCard.SpecialCardType;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
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
            stack.Races.Should().BeOfType<List<RaceCard>>();
            stack.Proficiencies.Should().BeOfType<List<ProficiencyCard>>();
            stack.Races.Should().HaveCount(4);
            stack.Proficiencies.Should().HaveCount(5);
        }

        [Fact]
        public void GeneratePrizeStackTest()
        {
            //Arrange
            var generator = new StackCardGeneratorService();
            //Act
            var stack = generator.GeneratePrizeStack();
            //Assert
            stack.Weapons.Should().BeOfType<List<ItemCard>>();
            stack.Armors.Should().BeOfType<List<ItemCard>>();
            stack.Boots.Should().BeOfType<List<ItemCard>>();
            stack.Helmets.Should().BeOfType<List<ItemCard>>();
            stack.Weapons.Should().HaveCount(15);
            stack.Armors.Should().HaveCount(5);
            stack.Boots.Should().HaveCount(5);
            stack.Helmets.Should().HaveCount(5);
            stack.Additional.Should().HaveCount(6);
            stack.Situational.Should().HaveCount(14);
        }

        [Fact]
        public void GenerateMonsterCardsTest()
        {
            //Arrange
            var generator = new StackCardGeneratorService();
            //Act
            var stack = generator.GenerateMonsterCards();
            //Assert
            stack.Should().BeOfType<List<MonsterCardBase>>();
            stack.Should().HaveCount(34);
        }
    }
}
