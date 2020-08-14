using Munchkin.BL.CardGenerator.ActionCard.RaceAndProficiency;
using Munchkin.BL.CardGenerator.CardsStack;
using Munchkin.Model;
using System;
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

    }
}
