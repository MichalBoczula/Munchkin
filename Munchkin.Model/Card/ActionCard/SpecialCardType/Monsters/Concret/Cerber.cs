using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.Character.Hero.Proficiency;
using Munchkin.Model.User;

using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret
{
    public class Cerber : MonsterCardBase
    {
        public Cerber(string name, CardType cardType) : base(name, cardType)
        {
            Power = 6;
            Undead = true;
            NumberOfPrizes = 2;
            HowManyLevels = 1;
        }

        public override void DeadEnd(Game game, UserClass user)
        {
            user.UserAvatar.Nerfs.TornOffArms.Add(true);
        }

        public override void SpecialPower(Game game, UserClass user)
        {
            if (user.UserAvatar.Proficiency == null) return;
            if (user.UserAvatar.Proficiency is PriestProficiency)
            {
                Power += 3;
            }
        }
    }
}
