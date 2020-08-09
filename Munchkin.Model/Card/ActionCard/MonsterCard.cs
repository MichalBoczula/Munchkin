using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard
{
    public class MonsterCard : ActionCardBase
    {
        public int Power { get; set; }

        public MonsterCard(string name, CardType cardType) : base(name, cardType)
        {
            ActionCardType = ActionCardType.Monster;
        }

        public void DeadEnd()
        {

        }

    }
}
