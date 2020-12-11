using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.Character.Hero.Proficiency;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret
{
    public class Sirens : MonsterCardBase
    {
        public Sirens(string name, CardType cardType) : base(name, cardType)
        {
            Power = 1;
            NumberOfPrizes = 1;
            HowManyLevels = 1;
        }

        public override void DeadEnd(Game game, UserClass user)
        {
            if(user.UserAvatar.Build.Helmet != null)
            {
                var item = user.UserAvatar.Build.Helmet;
                user.UserAvatar.Build.Helmet = null;
                game.DestroyedPrizeCards.Add(item);
            }
        }

        public override void SpecialPower(Game game, UserClass user)
        {
            if(user.UserAvatar.Proficiency != null && user.UserAvatar.Proficiency is WarriorProficiency)
            {
                Power += 5;
            }
        }

        public override string Description()
        {
            return "Monster: Sirens\n" +
                $"Power: {Power}, Prizes: {NumberOfPrizes}, Levels: {HowManyLevels}\n" +
                "SpecialPower: Monster gain 5 power when player proficiency is Warrior.\n" +
                "Dead End: Player lose helmet.";
        }
    }
}
