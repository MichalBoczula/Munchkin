using Munchkin.BL.CardGenerator.ActionCard.Monsters;
using Munchkin.BL.CardGenerator.ActionCard.RaceAndProficiency;
using Munchkin.BL.CardGenerator.CardsStack;
using Munchkin.BL.CardGenerator.PrizeCard.ItemCards;
using Munchkin.Model;
using Munchkin.Model.Card.ActionCard;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.Card.PrizeCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Munchkin.BL.CardGenerator
{
    public class StackCardGeneratorService
    {
        private readonly RaceAndProficienyGeneratorService _raceAndProficienyGenerator;
        private readonly ItemCardGenerator _itemCardGenerator;
        private readonly MonstersGenerator _monstersGenerator;
        private PrizeStack prizeStack; 

        public StackCardGeneratorService()
        {
            _raceAndProficienyGenerator = new RaceAndProficienyGeneratorService();
            _itemCardGenerator = new ItemCardGenerator();
            _monstersGenerator = new MonstersGenerator();
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
                                        helmets: _itemCardGenerator.GenerateHelmetCards(),
                                        additional: _itemCardGenerator.GenerateAdditionalCards());
            return prizeStack;
        }

        public List<MonsterCardBase> GenerateMonsterCards()
        {
            return _monstersGenerator.GenerateMonsterCards().ToList();
        }

    }
}
