using Munchkin.BL.CardGenerator.RaceAndProficiency;
using Munchkin.Model;
using Munchkin.Model.Card.ActionCard.SpecialCardType;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.BL.CardGenerator
{
    public class StackCardGeneratorService
    {
        private readonly RaceAndProficienyGeneratorService _raceAndProficienyGenerator;

        public StackCardGeneratorService()
        {
            _raceAndProficienyGenerator = new RaceAndProficienyGeneratorService();
            
        }

        public InitialCreationStack GenerateInitialCreationStack()
        {
            var races = _raceAndProficienyGenerator.GenerateRace();
            var profs = _raceAndProficienyGenerator.GenerateProfiecy();

            return new InitialCreationStack(races, profs);
        }

        public IList<CardGameBase> GenerateActionCards()
        {
            throw new NotImplementedException();
        }

        public IList<CardGameBase> GeneratePrizeCards()
        {
            throw new NotImplementedException();
        }
    }

    public class InitialCreationStack
    {
        public List<RaceCard> Races { get; }
        public List<ProficiencyCard> Proficiencies { get;}

        public InitialCreationStack(List<RaceCard> races, List<ProficiencyCard> proficiencies)
        {
            Races = races;
            Proficiencies = proficiencies;
        }

    }
}
