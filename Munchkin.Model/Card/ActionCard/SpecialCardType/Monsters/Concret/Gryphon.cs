using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret
{
    public class Gryphon : MonsterCardBase
    {
        public Gryphon(string name, CardType cardType) : base(name, cardType)
        {
            Power = 4;
            HowManyLevels = 1;
            NumberOfPrizes = 2;
        }

        public override void DeadEnd(Game game, UserClass user)
        {
            if(user.UserAvatar.Build.LeftHandItem != null)
            {
                var item = user.UserAvatar.Build.LeftHandItem;
                user.UserAvatar.Build.LeftHandItem = null;
                game.DestroyedPrizeCards.Add(item);
            }
        }

        public override void SpecialPower(Game game, UserClass user)
        {
            if(user.UserAvatar.Level > 1)
            {
                Power += 1;
            }
            else
            {
                HowManyLevels += 1;
            }
        }

        public override string Description()
        {
            return "Monster: Gryphon\n" +
                $"Power: {Power}, Prizes: {NumberOfPrizes}, Levels: {HowManyLevels}" +
                "SpecialPower: Monster gain 1 power when Player has bigger level than 1 or when Player has 1 level then after win in fight get 2.\n" +
                "Dead End: Player lose left hand item";
        }
    }
}
