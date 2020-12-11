using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret
{
    public class Scarabs : MonsterCardBase
    {
        public Scarabs(string name, CardType cardType) : base(name, cardType)
        {
            Power = 1;
            NumberOfPrizes = 1;
            HowManyLevels = 1;
        }

        public override void DeadEnd(Game game, UserClass user)
        {
            user.UserAvatar.Nerfs.Power.Add(2);
            user.UserAvatar.Nerfs.FleeChances.Add(1);
        }

        public override void SpecialPower(Game game, UserClass user)
        {
            if(user.UserAvatar.Build.Boots != null)
            {
                Power += 3;
            }
        }

        public override string Description()
        {
            return "Monster: Scarabs\n" +
                $"Power: {Power}, Prizes: {NumberOfPrizes}, Levels: {HowManyLevels}" +
                "SpecialPower: Player don't have a boot then monster gain 3 power.\n" +
                "Dead End: Player Power Nerf += 2 && Player Flee Chances Nerf += 2.";
        }
    }
}
