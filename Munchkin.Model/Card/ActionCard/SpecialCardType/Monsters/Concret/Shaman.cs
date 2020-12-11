using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.Character.Hero.Proficiency;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret
{
    public class Shaman : MonsterCardBase
    {
        public Shaman(string name, CardType cardType) : base(name, cardType)
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
            if(user.UserAvatar.Proficiency is MageProficiency || user.UserAvatar.Proficiency is PriestProficiency)
            {
                Power += 5;
            }
        }

        public override string Description()
        {
            return "Monster: Shaman\n" +
                $"Power: {Power}, Prizes: {NumberOfPrizes}, Levels: {HowManyLevels}" +
                "SpecialPower: If player proficiency is Mage or Priest then monster gain 5 power.\n" +
                "Dead End: Player poison by Shaman.";
        }
    }
}
