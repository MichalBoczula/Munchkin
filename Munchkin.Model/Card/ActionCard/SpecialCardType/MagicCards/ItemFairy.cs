using Munchkin.Model;
using Munchkin.Model.Card.ActionCard;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.Card.PrizeCard;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard.SpecialCardType.MagicCards
{
    public class ItemFairy : ActionCardBase
    {
        public Random random;

        public ItemFairy(string name, CardType cardType, Random random) : base(name, cardType)
        {
            MagicCardType = MagicCardType.Hero;
            this.random = random;
        }

        public override void CastSpecialSpell(UserClass user, MonsterCardBase monster, Game game)
        {
            var items = new List<ItemCard>();
            if (user.UserAvatar.Build.Helmet != null)
            {
                items.Add(user.UserAvatar.Build.Helmet);
            }
            if (user.UserAvatar.Build.Armor != null)
            {
                items.Add(user.UserAvatar.Build.Armor);
            }
            if (user.UserAvatar.Build.Boots != null)
            {
                items.Add(user.UserAvatar.Build.Boots);
            }
            if (user.UserAvatar.Build.LeftHandItem != null)
            {
                items.Add(user.UserAvatar.Build.LeftHandItem);
            }
            if (user.UserAvatar.Build.RightHandItem != null)
            {
                items.Add(user.UserAvatar.Build.RightHandItem);
            }

            var itemToRemove = items[random.Next(items.Count)];
            game.DestroyedPrizeCards.Add(itemToRemove);

            if (user.UserAvatar.Build.Helmet != null && user.UserAvatar.Build.Helmet.Equals(itemToRemove))
            {
                user.UserAvatar.Build.Helmet = null;
            }
            if (user.UserAvatar.Build.Armor != null && user.UserAvatar.Build.Armor.Equals(itemToRemove))
            {
                user.UserAvatar.Build.Armor = null;
            }
            if (user.UserAvatar.Build.Boots != null && user.UserAvatar.Build.Boots.Equals(itemToRemove))
            {
                user.UserAvatar.Build.Boots = null;
            }
            if (user.UserAvatar.Build.LeftHandItem != null && user.UserAvatar.Build.LeftHandItem.Equals(itemToRemove))
            {
                user.UserAvatar.Build.LeftHandItem = null;
            }
            if (user.UserAvatar.Build.RightHandItem != null && user.UserAvatar.Build.RightHandItem.Equals(itemToRemove))
            {
                user.UserAvatar.Build.RightHandItem = null;
            }
        }
    }
}
