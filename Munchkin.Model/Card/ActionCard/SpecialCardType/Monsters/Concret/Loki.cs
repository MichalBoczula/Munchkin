﻿using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.Card.PrizeCard;
using Munchkin.Model.Character.Hero.Proficiency;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret
{
    public class Loki : MonsterCardBase
    {
        public Loki(string name, CardType cardType) : base(name, cardType)
        {
            Power = 14;
            HowManyLevels = 1;
            NumberOfPrizes = 4;
        }

        public override void DeadEnd(Game game, UserClass user)
        {
            user.UserAvatar.Level -= 2;
            var item = FindTheMostExpensiveItem(user);
            if(item != null)
            {
                DeleteMostExpensiveItem(game, user, item);
            }

        }

        public override void SpecialPower(Game game, UserClass user)
        {
            user.UserAvatar.Proficiency = new NoOneProficiency();
        }

        public ItemCard FindTheMostExpensiveItem(UserClass user)
        {
            ItemCard item = null;
            if (user.UserAvatar.Build.Helmet != null)
            {
                if (item == null)
                {
                    item = user.UserAvatar.Build.Helmet;
                }
                else if (item.Price < user.UserAvatar.Build.Helmet.Price)
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
                else if (item.Price < user.UserAvatar.Build.Armor.Price)
                {
                    item = user.UserAvatar.Build.Armor;
                }

            }
            if (user.UserAvatar.Build.Boots != null)
            {
                if (item == null)
                {
                    item = user.UserAvatar.Build.Boots;
                }
                else if (item.Price < user.UserAvatar.Build.Boots.Price)
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
                else if (item.Price < user.UserAvatar.Build.LeftHandItem.Price)
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
                else if (item.Price < user.UserAvatar.Build.RightHandItem.Price)
                {
                    item = user.UserAvatar.Build.RightHandItem;
                }
            }
            return item;
        }

        public void DeleteMostExpensiveItem(Game game, UserClass user, ItemCard item)
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
            return "Monster: Loki\n" +
                $"Power: {Power}, Prizes: {NumberOfPrizes}, Levels: {HowManyLevels}\n" +
                "SpecialPower: Player lose proficiency and is NoOne.\n" +
                "Dead End: Player lose most expensive item";
        }

    }
}
