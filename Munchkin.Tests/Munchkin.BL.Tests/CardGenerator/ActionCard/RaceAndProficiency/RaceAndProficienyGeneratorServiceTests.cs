using FluentAssertions;
using Munchkin.BL.CardGenerator.ActionCard.RaceAndProficiency;
using Munchkin.Model.Character.Hero.Proficiency;
using Munchkin.Model.Character.Hero.Race;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Munchkin.Tests.Munchkin.BL.Tests.CardGenerator.CardStack.RaceAndProficiency
{
    public class RaceAndProficienyGeneratorServiceTests
    {
        private RaceAndProficienyGeneratorService _raceAndProficiency;

        public RaceAndProficienyGeneratorServiceTests()
        {
            //Arrage
            _raceAndProficiency = new RaceAndProficienyGeneratorService();
        }

        [Fact]
        public void GenerateRaceTest()
        {
            //In Constructor
            //Act
            var races = _raceAndProficiency.GenerateRace();
            //Assert
            Assert.Collection(races,
                              ele => ele.Race.Should().BeOfType<Elf>(),
                              ele => ele.Race.Should().BeOfType<Dwarf>(),
                              ele => ele.Race.Should().BeOfType<Halfling>(),
                              ele => ele.Race.Should().BeOfType<Human>());
        }

        [Fact]
        public void GenerateProfiecyTest()
        {
            //In Constructor
            //Act
            var profs = _raceAndProficiency.GenerateProfiecy();
            //Assert
            Assert.Collection(profs,
                              ele => ele.Proficiency.Should().BeOfType<MageProficiency>(),
                              ele => ele.Proficiency.Should().BeOfType<NoOneProficiency>(),
                              ele => ele.Proficiency.Should().BeOfType<PriestProficiency>(),
                              ele => ele.Proficiency.Should().BeOfType<ThiefProficiency>(),
                              ele => ele.Proficiency.Should().BeOfType<WarriorProficiency>());
        }
    }
}
