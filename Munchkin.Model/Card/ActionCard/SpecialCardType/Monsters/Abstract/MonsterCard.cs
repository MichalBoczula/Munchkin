using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract
{
    public abstract class MonsterCardBase : ActionCardBase
    {
        public int Power { get; set; }

        public MonsterCardBase(string name, CardType cardType) : base(name, cardType)
        {
            ActionCardType = ActionCardType.Monster;
        }

        public abstract void DeadEnd(Game game, UserClass user);

        public abstract void SpecialPower(Game game, UserClass user);

        public abstract int GetNumberOfPrizes();

    }
}
