using Munchkin.Model;
using Munchkin.Model.Card.CardFactory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.BL.CardGenerator.RaceAndProficiency
{
    internal class RaceAndProficienyGenerator
    {
        private readonly RaceFactory _raceFactory;
        private readonly List<CardGameBase> Cards = new List<CardGameBase>();

        internal RaceAndProficienyGenerator()
        {
            _raceFactory = new RaceFactory();
        }

        internal IList<CardGameBase> GetRaceAndProfiecy()
        {
            return Cards;
        }

        private IList<CardGameBase> GenerateRace()
        {
            var ElfRaceCard = _raceFactory.MakeRaceCard(RaceType.ElfRace);
            var DwarfRaceCard = _raceFactory.MakeRaceCard(RaceType.DwarfRace);
            var HalfingRaceCard = _raceFactory.MakeRaceCard(RaceType.HalfingRace);
            var HumanRaceCard = _raceFactory.MakeRaceCard(RaceType.HumaRace);
            Cards.Add(ElfRaceCard);
            Cards.Add(DwarfRaceCard);
            Cards.Add(HalfingRaceCard);
            Cards.Add(HumanRaceCard);
            return Cards;
        }

        private IList<CardGameBase> GenerateProfiecy()
        {
            return null;
        }
    }
}
