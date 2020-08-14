using Munchkin.BL.CardGenerator.CardsStack;
using Munchkin.Model.Card.ActionCard.SpecialCardType;
using Munchkin.Model.Character;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.BL.CharacterCreator
{
    public class DrawCardService
    {
        private Random _random { get; }

        public DrawCardService(Random random)
        {
            _random = random;
        }

        public int RandomRaceCard()
        {
            return _random.Next(4);
        }

        public int RandomProficiencyCard()
        {
            return _random.Next(5);
        }
       
    }
}
