using Munchkin.BL.CardGenerator.ActionCard.RaceAndProficiency;
using Munchkin.Model.Character.Hero.Proficiency;
using Munchkin.Model.Character.Hero.Race;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Munchkin.Tests.Munchkin.BL.Tests.CardGenerator.RaceAndProficiency
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
                              ele => Assert.IsType<Elf>(ele.Race),
                              ele => Assert.IsType<Dwarf>(ele.Race),
                              ele => Assert.IsType<Halfling>(ele.Race),
                              ele => Assert.IsType<Human>(ele.Race));
        }

        [Fact]
        public void GenerateProfiecyTest()
        {
            //In Constructor
            //Act
            var profs = _raceAndProficiency.GenerateProfiecy();
            //Assert
            Assert.Collection(profs,
                              ele => Assert.IsType<MageProficiency>(ele.Proficiency),
                              ele => Assert.IsType<NoOneProficiency>(ele.Proficiency),
                              ele => Assert.IsType<PriestProficiency>(ele.Proficiency),
                              ele => Assert.IsType<ThiefProficiency>(ele.Proficiency),
                              ele => Assert.IsType<WarriorProficiency>(ele.Proficiency));
        }
    }
}
