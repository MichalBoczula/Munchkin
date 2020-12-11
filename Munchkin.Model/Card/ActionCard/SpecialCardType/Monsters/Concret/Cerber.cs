using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.Character.Hero.Proficiency;
using Munchkin.Model.User;

using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret
{
    public class Cerber : MonsterCardBase
    {
        public Cerber(string name, CardType cardType) : base(name, cardType)
        {
            Power = 6;
            Undead = true;
            NumberOfPrizes = 2;
            HowManyLevels = 1;
        }

        public override void DeadEnd(Game game, UserClass user)
        {
            if (user.UserAvatar.Build.LeftHandItem != null)
            {
                var item = user.UserAvatar.Build.LeftHandItem;
                user.UserAvatar.Build.LeftHandItem = null;
                game.DestroyedPrizeCards.Add(item);
            }
            if (user.UserAvatar.Build.RightHandItem != null)
            {
                var item = user.UserAvatar.Build.RightHandItem;
                user.UserAvatar.Build.RightHandItem = null;
                game.DestroyedPrizeCards.Add(item);
            }
            user.UserAvatar.Nerfs.TornOffArms.Add(true);
        }

        public override void SpecialPower(Game game, UserClass user)
        {
            if (user.UserAvatar.Proficiency == null) return;
            if (user.UserAvatar.Proficiency is PriestProficiency)
            {
                Power += 3;
            }
        }

        public override string Description()
        {
            return "Monster: Cerber\n" +
                $"Power: {Power}, Prizes: {NumberOfPrizes}, Levels: {HowManyLevels}" +
                "SpecialPower: Monster gain 3 power when player proficiency is Priest\n" +
                "Dead End: Player has permanent torn off arm and can't use a weapons and lose both weapons";
        }
    }
}
