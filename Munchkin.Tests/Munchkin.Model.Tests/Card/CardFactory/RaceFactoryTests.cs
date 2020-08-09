using Munchkin.Model.Card.ActionCard.SpecialCardType;
using Munchkin.Model.Card.CardFactory;
using Munchkin.Model.Character.Hero.Race;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Munchkin.Tests.Munchkin.Model.Tests.Card.CardFactory
{
    public class RaceFactoryTests
    {
        [Fact]
        public void MakeRaceCardTest()
        {
            //Arrange
            var raceFactory = new RaceFactory();
            //Act
            var shouldBeElf = raceFactory.MakeRaceCard(RaceType.ElfRace);
            var shouldBeDwarf = raceFactory.MakeRaceCard(RaceType.DwarfRace);
            var shouldBeHuman = raceFactory.MakeRaceCard(RaceType.HumaRace);
            var shouldBeHalfing = raceFactory.MakeRaceCard(RaceType.HalfingRace);
            //Assert
            //CardType
            Assert.IsType<RaceCard>(shouldBeElf);
            Assert.IsType<RaceCard>(shouldBeDwarf);
            Assert.IsType<RaceCard>(shouldBeHuman);
            Assert.IsType<RaceCard>(shouldBeHalfing);
            //RaceType
            Assert.IsType<Elf>(shouldBeElf.Race);
            Assert.IsType<Dwarf>(shouldBeDwarf.Race);
            Assert.IsType<Human>(shouldBeHuman.Race);
            Assert.IsType<Halfling>(shouldBeHalfing.Race);
        }
    }
}
