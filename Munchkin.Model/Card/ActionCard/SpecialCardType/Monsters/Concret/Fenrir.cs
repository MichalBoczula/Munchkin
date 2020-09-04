using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.Character.Hero.Proficiency;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret
{
    public class Fenrir : MonsterCardBase
    {
        public Fenrir(string name, CardType cardType) : base(name, cardType)
        {
            Power = 16;
            HowManyLevels = 2;
            NumberOfPrizes = 4;
        }

        public override void DeadEnd(Game game, UserClass user)
        {
            user.UserAvatar.Nerfs.TornOffArms.Add(true);
        }

        public override void SpecialPower(Game game, UserClass user)
        {
            if(user.UserAvatar.Proficiency is PriestProficiency || user.UserAvatar.Proficiency is MageProficiency)
            {
                Power -= 3;
            }
            else
            {
                Power += 5;
            }
        }
    }
}
