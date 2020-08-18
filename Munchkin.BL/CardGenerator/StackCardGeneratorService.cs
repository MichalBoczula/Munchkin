using Munchkin.BL.CardGenerator.ActionCard.RaceAndProficiency;
using Munchkin.BL.CardGenerator.CardsStack;
using Munchkin.BL.CardGenerator.PrizeCard.ItemCards;
using Munchkin.Model;
using Munchkin.Model.Card.PrizeCard;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.BL.CardGenerator
{
    public class StackCardGeneratorService
    {
        private readonly RaceAndProficienyGeneratorService _raceAndProficienyGenerator;
        private readonly ItemCardGenerator _itemCardGenerator;
        private PrizeStack prizeStack; 

        public StackCardGeneratorService()
        {
            _raceAndProficienyGenerator = new RaceAndProficienyGeneratorService();
            _itemCardGenerator = new ItemCardGenerator();
        }

        public InitialCreationStack GenerateInitialCreationStack()
        {
            var races = _raceAndProficienyGenerator.GenerateRace();
            var profs = _raceAndProficienyGenerator.GenerateProfiecy();

            return new InitialCreationStack(races, profs);
        }

        public PrizeStack GeneratePrizeStack()
        {
            prizeStack = new PrizeStack(weapons: _itemCardGenerator.GenerateWeaponCards(),
                                        armors: _itemCardGenerator.GenerateArmorCards(),
                                        boots: _itemCardGenerator.GenerateBootsCards(),
                                        helmets: _itemCardGenerator.GenerateHelmetCards());
            return prizeStack;
        }

    }
}
