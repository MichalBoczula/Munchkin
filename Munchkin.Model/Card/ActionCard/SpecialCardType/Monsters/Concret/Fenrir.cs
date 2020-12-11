using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.Character.Hero.Proficiency;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret
{
    public class Fenrir : MonsterCardBase
    {
        public Fenrir(string name, CardType cardType) : base(name, cardType)
        {
            Power = 16;
            HowManyLevels = 2;
            NumberOfPrizes = 4;
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
            if(user.UserAvatar.Proficiency is PriestProficiency || user.UserAvatar.Proficiency is MageProficiency)
            {
                Power -= 3;
            }
            else
            {
                Power += 5;
            }
        }

        public override string Description()
        {
            return "Monster: Fenrir\n" +
                $"Power: {Power}, Prizes: {NumberOfPrizes}, Levels: {HowManyLevels}\n" +
                "SpecialPower: Monster gain 5 when player proficiency is diffrent then Mage or Priest, other wise lose 3 point of power\n" +
                "Dead End: Player has permanent torn off arm and can't use a weapons and lose both weapons";
        }
    }
}
