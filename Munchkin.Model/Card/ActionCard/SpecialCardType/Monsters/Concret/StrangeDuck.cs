using Munchkin.Model;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret
{
    public class StrangeDuck : MonsterCardBase
    {
        public StrangeDuck(string name, CardType cardType) : base(name, cardType)
        {
            Power = 4;
            NumberOfPrizes = 2;
            HowManyLevels = 1;
        }

        public override void DeadEnd(Game game, UserClass user)
        {
            if (Power > 4)
            {
                var helmet = user.UserAvatar.Build.Helmet;
                if(helmet != null)
                {
                    user.UserAvatar.Build.Helmet = null;
                    game.DestroyedPrizeCards.Add(helmet);
                }
                var armor = user.UserAvatar.Build.Armor;
                if (armor != null)
                {
                    user.UserAvatar.Build.Armor = null;
                    game.DestroyedPrizeCards.Add(armor);
                }
                var boots = user.UserAvatar.Build.Boots;
                if (boots != null)
                {
                    user.UserAvatar.Build.Boots = null;
                    game.DestroyedPrizeCards.Add(boots);
                }
            }
            else
            {
                var lHand = user.UserAvatar.Build.LeftHandItem;
                if (lHand != null)
                {
                    user.UserAvatar.Build.LeftHandItem = null;
                    game.DestroyedPrizeCards.Add(lHand);
                }
                var rHand = user.UserAvatar.Build.RightHandItem;
                if (rHand != null)
                {
                    user.UserAvatar.Build.RightHandItem = null;
                    game.DestroyedPrizeCards.Add(rHand);
                }
            }
        }

        public override void SpecialPower(Game game, UserClass user)
        {
            if (HowManyItems(user))
            {
                Power += 10;
                NumberOfPrizes += 1;
                HowManyLevels += 1;
            }
        }
        public bool HowManyItems(UserClass user)
        {
            int numberOfItemsInSet = 0;
            if (user.UserAvatar.Build == null) return false;
            if (user.UserAvatar.Build.Helmet != null)
            {
                numberOfItemsInSet++;
            }
            if (user.UserAvatar.Build.Armor != null)
            {
                numberOfItemsInSet++;
            }
            if (user.UserAvatar.Build.Boots != null)
            {
                numberOfItemsInSet++;
            }
            if (user.UserAvatar.Build.LeftHandItem != null)
            {
                numberOfItemsInSet++;
            }
            if (user.UserAvatar.Build.RightHandItem != null)
            {
                numberOfItemsInSet++;
            }
            return numberOfItemsInSet > 2 ?
                true :
                false;
        }

        public override string Description()
        {
            return "Monster: StrangeDuck\n" +
                "SpecialPower: If Player has 3 or more items in buld, monster gain 10 power and 1 prize and 1 level.\n" +
                "Dead End: If Player has 5 or more power then lose helmet, armor and boots, otherwise lose both weapons.";
        }
    }
}
