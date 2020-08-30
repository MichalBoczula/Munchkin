using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret
{
    public class BoogieManDanceFloorKing : MonsterCardBase
    {
        public BoogieManDanceFloorKing(string name, CardType cardType) : base(name, cardType)
        {
            Power = 10;
            HowManyLevels = 1;
            NumberOfPrizes = 3;
        }

        public override void DeadEnd(Game game, UserClass user)
        {
            user.UserAvatar.Nerfs.BrokenLegs = true;
            if(user.UserAvatar.Build.Boots != null)
            {
                var item = user.UserAvatar.Build.Boots;
                user.UserAvatar.Build.Boots = null;
                game.DestroyedPrizeCards.Add(item);
            }

        }

        public override void SpecialPower(Game game, UserClass user)
        {
            if (user.UserAvatar.Build.Boots != null)
            {
                Power += user.UserAvatar.Build.Boots.Power;
            }
        }
    }
}
