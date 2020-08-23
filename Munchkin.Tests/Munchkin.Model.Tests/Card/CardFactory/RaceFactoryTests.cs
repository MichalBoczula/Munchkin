using Munchkin.Model.Card.ActionCard.SpecialCardType;
using Munchkin.Model.Card.CardFactory;
using Munchkin.Model.Character.Hero.Race;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;

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
            shouldBeElf.Should().BeOfType<RaceCard>();
            shouldBeDwarf.Should().BeOfType<RaceCard>();
            shouldBeHuman.Should().BeOfType<RaceCard>();
            shouldBeHalfing.Should().BeOfType<RaceCard>();
            //RaceType
            shouldBeElf.Race.Should().BeOfType<Elf>();
            shouldBeDwarf.Race.Should().BeOfType<Dwarf>();
            shouldBeHuman.Race.Should().BeOfType<Human>();
            shouldBeHalfing.Race.Should().BeOfType<Halfling>();
        }
    }
}
