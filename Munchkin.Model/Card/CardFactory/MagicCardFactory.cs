using Munchkin.Model.Card.ActionCard;
using Munchkin.Model.Card.ActionCard.SpecialCardType.MagicCards;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.CardFactory
{
    public class MagicCardFactory
    {
        public ActionCardBase CreateMonsterCard(int num)
        {
            ActionCardBase result = num switch
            {
                1 => new PayToHaron("PayToHaron", CardType.Curse),
               
                _ => null
            };
            return result;
        }
    }
}
