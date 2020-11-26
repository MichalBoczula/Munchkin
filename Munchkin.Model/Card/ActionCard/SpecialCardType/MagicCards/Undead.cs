using Munchkin.Model;
using Munchkin.Model.Card.ActionCard;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard.SpecialCardType.MagicCards
{
    public class Undead : ActionCardBase
    {
        public Undead(string name, CardType cardType) : base(name, cardType)
        {
            MagicCardType = MagicCardType.Monster;
        }

        public override void CastSpecialSpell(UserClass user, MonsterCardBase monster, Game game)
        {
            monster.Power += 5;
            monster.Undead = true;
            monster.NumberOfPrizes += 2;
        }

        public override void Description()
        {
            System.Console.WriteLine("Monster start be undead and get additional 5 power point and 2 prizes.");
        }
    }
}
