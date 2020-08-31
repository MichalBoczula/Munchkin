using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret
{
    public class Jackarey : MonsterCardBase
    {
        public Jackarey(string name, CardType cardType) : base(name, cardType)
        {
            Power = 10;
            HowManyLevels = 1;
            NumberOfPrizes = 3;
        }

        public override void DeadEnd(Game game, UserClass user)
        {
            user.UserAvatar.Nerfs.Poisoned.Add(true);
        }

        public override void SpecialPower(Game game, UserClass user)
        {
            if(user.UserAvatar.Build.Helmet == null)
            {
                user.UserAvatar.Level -= 1;
            }
            if(user.UserAvatar.Build.Armor == null)
            {
                user.UserAvatar.Nerfs.Power.Add(2);
            }
            if (user.UserAvatar.Build.Boots == null)
            {
                user.UserAvatar.Nerfs.FleeChances.Add(1);
            }
        }
    }
}
