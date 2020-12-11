using Munchkin.Model.Card.ActionCard;
using Munchkin.Model.Card.CardFactory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.BL.CardGenerator.ActionCard.MagicCards
{
    public class MagicCardGenerator
    {
        private readonly MagicCardFactory _magicCardFactory;
        private readonly HashSet<ActionCardBase> _magicCards;

        public MagicCardGenerator()
        {
            _magicCardFactory = new MagicCardFactory();
            _magicCards = new HashSet<ActionCardBase>();
        }

        public HashSet<ActionCardBase> GenerateMagicCards()
        {
            for (int i = 1; i < 31; i++)
            {
                _magicCards.Add(_magicCardFactory.CreateMagicCard(i));
            }
            return _magicCards;
        }
    }
}
