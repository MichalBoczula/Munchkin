using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret
{
    public class LochNessMonster : MonsterCardBase
    {
        public LochNessMonster(string name, CardType cardType) : base(name, cardType)
        {
            Power = 14;
            NumberOfPrizes = 4;
            HowManyLevels = 1;
        }

        public override void DeadEnd(Game game, UserClass user)
        {
            user.UserAvatar.Nerfs.Poisoned.Add(true);
        }

        public override void SpecialPower(Game game, UserClass user)
        {
            user.UserAvatar.Level -= 2;
        }

        public override string Description()
        {
            return "Monster: LochNessMonster\n" +
                $"Power: {Power}, Prizes: {NumberOfPrizes}, Levels: {HowManyLevels}" +
                "SpecialPower: Player is poison.\n" +
                "Dead End: Player lose 2 levels. Player Level -= 2";
        }
    }
}
