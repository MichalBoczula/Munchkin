using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.Character.Hero.Race;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret
{
    public class DemonicFly : MonsterCardBase
    {
        public DemonicFly(string name, CardType cardType) : base(name, cardType)
        {
            Power = 6;
            HowManyLevels = 1;
            NumberOfPrizes = 2;
        }

        public override void DeadEnd(Game game, UserClass user)
        {
            if(user.UserAvatar.Race == null)
            {
                user.UserAvatar.Level -= 1;
            }
            else if (user.UserAvatar.Race is Elf)
            {
                user.UserAvatar.Level -= 2;
            }
            else
            {
                user.UserAvatar.Level -= 1;
            }
        }

        public override void SpecialPower(Game game, UserClass user)
        {
            if (user.UserAvatar.Race == null) return;
            if(user.UserAvatar.Race is Elf)
            {
                Power += 4;
            }
        }

        public override string Description()
        {
            return "Monster: DemonicFly\n" +
                $"Power: {Power}, Prizes: {NumberOfPrizes}, Levels: {HowManyLevels}\n" +
                "SpecialPower: Monster gain 4 power when player race is Elf\n" +
                "Dead End: Player Level -= 1 || Player Level -= 2 when race is Elf";
        }
    }
}
