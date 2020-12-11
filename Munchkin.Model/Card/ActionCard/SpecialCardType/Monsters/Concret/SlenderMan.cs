using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.Character.Hero.Proficiency;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret
{
    public class SlenderMan : MonsterCardBase
    {
        public SlenderMan(string name, CardType cardType) : base(name, cardType)
        {
            Power = 12;
            NumberOfPrizes = 3;
            HowManyLevels = 1;
        }

        public override void DeadEnd(Game game, UserClass user)
        {
            user.UserAvatar.Nerfs.Wounded.Add(true);
        }

        public override void SpecialPower(Game game, UserClass user)
        {
            user.UserAvatar.Proficiency = new NoOneProficiency();
        }

        public override string Description()
        {
            return "Monster: SlenderMan\n" +
                $"Power: {Power}, Prizes: {NumberOfPrizes}, Levels: {HowManyLevels}" +
                "SpecialPower: Player get wound nerf.\n" +
                "Dead End: Player lose proficiency and now is NoOne.";
        }
    }
}
