using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.Character.Hero.Proficiency;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret
{
    public class MordredFallenKnight : MonsterCardBase
    {
        public MordredFallenKnight(string name, CardType cardType) : base(name, cardType)
        {
            Power = 8;
            HowManyLevels = 1;
            NumberOfPrizes = 2;
        }

        public override void DeadEnd(Game game, UserClass user)
        {
            user.UserAvatar.Nerfs.Wounded.Add(true);
        }

        public override void SpecialPower(Game game, UserClass user)
        {
            if(user.UserAvatar.Proficiency == null)
            {
                Power += 3;
            }
            else if(!(user.UserAvatar.Proficiency is WarriorProficiency))
            {
                Power += 3;
            }
        }
    }
}
