using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.Character;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret
{
    public class Shiva : MonsterCardBase
    {
        public Shiva(string name, CardType cardType) : base(name, cardType)
        {
            Power = 20;
            NumberOfPrizes = 5;
            HowManyLevels = 3;
        }

        public override void DeadEnd(Game game, UserClass user)
        {
            user.UserAvatar.IsDied = true;
        }

        public override void SpecialPower(Game game, UserClass user)
        {
            if(user.UserAvatar.Build.LeftHandItem != null)
            {
                Power += user.UserAvatar.Build.LeftHandItem.Power;
            }
            if (user.UserAvatar.Build.RightHandItem!= null)
            {
                Power += user.UserAvatar.Build.RightHandItem.Power;
            }
        }
    }
}
