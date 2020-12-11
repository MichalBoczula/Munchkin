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
            if(!(user.UserAvatar.Proficiency is WarriorProficiency))
            {
                Power += 3;
            }
        }

        public override string Description()
        {
            return "Monster: MordredFallenKnight\n" +
                $"Power: {Power}, Prizes: {NumberOfPrizes}, Levels: {HowManyLevels}\n" +
                "SpecialPower: Monster gain 3 power when Player has diffren proficiency then Warrior.\n" +
                "Dead End: Player get wound nerf.";
        }
    }
}
