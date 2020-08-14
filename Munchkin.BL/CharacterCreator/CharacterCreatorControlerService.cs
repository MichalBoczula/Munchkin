using Munchkin.BL.CardGenerator;
using Munchkin.BL.CardGenerator.ActionCard.RaceAndProficiency;
using Munchkin.BL.CardGenerator.CardsStack;
using Munchkin.Model;
using Munchkin.Model.Card.ActionCard;
using Munchkin.Model.Card.ActionCard.SpecialCardType;
using Munchkin.Model.Character;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.BL.CharacterCreator
{
    public class CharacterCreatorControlerService
    {

        private StackCardGeneratorService _stackCardGeneratorService;
        private DrawCardService _drawCardService;
        private InitialCreationStack _initialCreationStack;

        public CharacterCreatorControlerService(StackCardGeneratorService stackCardGeneratorService,
                                                DrawCardService drawCardService)
        {
            _stackCardGeneratorService = stackCardGeneratorService;
            _drawCardService = drawCardService;
            _initialCreationStack = _stackCardGeneratorService.GenerateInitialCreationStack();
        }

        public Character CreateCharacter()
        {
            var character = new Character()
            {
                Race = DrawRaceCard().Race,
                Proficiency = DrawProficiencyCard().Proficiency
            };

            return character;
        }


        private RaceCard DrawRaceCard()
        {
            return _initialCreationStack
                .Races[_drawCardService.RandomRaceCard()];
        }

        private ProficiencyCard DrawProficiencyCard()
        {
            return _initialCreationStack
                .Proficiencies[_drawCardService.RandomProficiencyCard()];
        }
    }
}
