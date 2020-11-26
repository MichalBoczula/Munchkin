using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret
{
    public class BloodyMary : MonsterCardBase
    {
        public BloodyMary(string name, CardType cardType) : base(name, cardType)
        {
            Power = 8;
            HowManyLevels = 1;
            NumberOfPrizes = 2;
        }

        public override void DeadEnd(Game game, UserClass user)
        {
            if (user.UserAvatar.Build.Helmet != null)
            {
                var item = user.UserAvatar.Build.Helmet;
                user.UserAvatar.Build.Helmet = null;
                game.DestroyedPrizeCards.Add(item);
            }
            user.UserAvatar.Nerfs.DamagedHead = true;
        }

        public override void SpecialPower(Game game, UserClass user)
        {
            user.UserAvatar.Level -= 1;
            user.UserAvatar.Nerfs.Power.Add(2);
            user.UserAvatar.Nerfs.FleeChances.Add(1);
        }

        public override string Description()
        {
            return "Monster: BloodyMary\n" +
                "SpecialPower: Player Power Nerf += 2 && Player Flee Chances Nerf += 1 && Player Level -= 2\n" +
                "Dead End: Player has permanent dameged head and can use a helmet and lose actual equipped helmet";
        }
    }
}
