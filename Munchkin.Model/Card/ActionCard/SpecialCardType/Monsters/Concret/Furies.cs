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

        public override string Description()
        {
            return "Monster: Furies\n" +
                $"Power: {Power}, Prizes: {NumberOfPrizes}, Levels: {HowManyLevels}\n" +
                "SpecialPower: Monster gain 4 when player proficiency is Thief\n" +
                "Dead End: Player Level -= 1 && Player Power Nerf += 2 && Player Flee Chances Nerf += 1";
        }
    }
}
