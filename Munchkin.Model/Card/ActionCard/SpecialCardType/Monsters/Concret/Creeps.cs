using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.Character.Hero.Proficiency;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret
{
    public class Creeps : MonsterCardBase
    {
        public Creeps(string name, CardType cardType) : base(name, cardType)
        {
            Power = 1;
            Undead = true;
            NumberOfPrizes = 1;
            HowManyLevels = 1;
        }

        public override void DeadEnd(Game game, UserClass user)
        {
            user.UserAvatar.Level -= 2;
        }

        public override void SpecialPower(Game game, UserClass user)
        {
            if(user.UserAvatar.Proficiency != null && user.UserAvatar.Proficiency is MageProficiency)
            {
                Power += 3;
            }
        }

        public override string Description()
        {
            return "Monster: Creeps\n" +
                $"Power: {Power}, Prizes: {NumberOfPrizes}, Levels: {HowManyLevels}\n" +
                "SpecialPower: Monster gain 3 power when player proficiency is Mage\n" +
                "Dead End: Player Level -= 2";
        }
    }
}
