using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.Character.Hero.Proficiency;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret
{
    public class Furies : MonsterCardBase
    {
        public Furies(string name, CardType cardType) : base(name, cardType)
        {
            Power = 6;
            HowManyLevels = 1;
            NumberOfPrizes = 2;
        }

        public override void DeadEnd(Game game, UserClass user)
        {
            user.UserAvatar.Level -= 1;
            user.UserAvatar.Nerfs.Power.Add(2);
            user.UserAvatar.Nerfs.FleeChances.Add(1);
        }

        public override void SpecialPower(Game game, UserClass user)
        {
            if (user.UserAvatar.Proficiency == null) return;
            if (user.UserAvatar.Proficiency is ThiefProficiency)
            {
                Power += 4;
            }
        }
    }
}
