using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.Card.PrizeCard;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret
{
    public class Gremlin : MonsterCardBase
    {
        public Gremlin(string name, CardType cardType) : base(name, cardType)
        {
            Power = 1;
            NumberOfPrizes = 1;
            HowManyLevels = 1;
        }

        public override void DeadEnd(Game game, UserClass user)
        {
            var item = FindTheMostPowerfulItem(user);
            if (item != null)
            {
                DeleteMostPowerfulItem(game, user, item);
            }
        }

        public override void SpecialPower(Game game, UserClass user)
        {
            var item = FindTheMostPowerfulItem(user);
            if (item != null)
            {
                user.UserAvatar.TempPower -= item.Power;
            }
        }

        public ItemCard FindTheMostPowerfulItem(UserClass user)
        {
            ItemCard item = null;
            if (user.UserAvatar.Build.Helmet != null)
            {
                if(item == null)
                {
                    item = user.UserAvatar.Build.Helmet;
                }
                else if (item.Power < user.UserAvatar.Build.Helmet.Power)
                {
                    item = user.UserAvatar.Build.Helmet;
                }
            }
            if (user.UserAvatar.Build.Armor != null)
            {
                if (item == null)
                {
                    item = user.UserAvatar.Build.Armor;
                }
                else if (item.Power < user.UserAvatar.Build.Armor.Power)
                {
                    item = user.UserAvatar.Build.Armor;
                }
               
            }
            if (user.UserAvatar.Build.Boots != null )
            {
                if (item == null)
                {
                    item = user.UserAvatar.Build.Boots;
                }
                else if (item.Power < user.UserAvatar.Build.Boots.Power)
                {
                    item = user.UserAvatar.Build.Boots;
                }
            }
            if (user.UserAvatar.Build.LeftHandItem != null)
            {
                if (item == null)
                {
                    item = user.UserAvatar.Build.LeftHandItem;
                }
                else if (item.Power < user.UserAvatar.Build.LeftHandItem.Power)
                {
                    item = user.UserAvatar.Build.LeftHandItem;
                }
            }
            if (user.UserAvatar.Build.RightHandItem != null)
            {
                if (item == null)
                {
                    item = user.UserAvatar.Build.RightHandItem;
                }
                else if (item.Power < user.UserAvatar.Build.RightHandItem.Power)
                {
                    item = user.UserAvatar.Build.RightHandItem;
                }
            }
            return item;
        }

        public void DeleteMostPowerfulItem(Game game, UserClass user,ItemCard item)
        {
            if (user.UserAvatar.Build.Helmet != null && user.UserAvatar.Build.Helmet.Equals(item))
            {
                user.UserAvatar.Build.Helmet = null;
                game.DestroyedPrizeCards.Add(item);
            }
            else if (user.UserAvatar.Build.Armor != null && user.UserAvatar.Build.Armor.Equals(item))
            {
                user.UserAvatar.Build.Armor = null;
                game.DestroyedPrizeCards.Add(item);
            }
            else if (user.UserAvatar.Build.Boots != null && user.UserAvatar.Build.Boots.Equals(item))
            {
                user.UserAvatar.Build.Boots = null;
                game.DestroyedPrizeCards.Add(item);
            }
            else if (user.UserAvatar.Build.LeftHandItem != null && user.UserAvatar.Build.LeftHandItem.Equals(item))
            {
                user.UserAvatar.Build.LeftHandItem = null;
                game.DestroyedPrizeCards.Add(item);
            }
            else if (user.UserAvatar.Build.RightHandItem != null && user.UserAvatar.Build.RightHandItem.Equals(item))
            {
                user.UserAvatar.Build.RightHandItem = null;
                game.DestroyedPrizeCards.Add(item);
            }
        }

        public override string Description()
        {
            return "Monster: Gremlin\n" +
                $"Power: {Power}, Prizes: {NumberOfPrizes}, Levels: {HowManyLevels}" +
                "SpecialPower: Player lose the most powerful item\n" +
                "Dead End: again... Player lose the most powerful item";
        }
    }
}
