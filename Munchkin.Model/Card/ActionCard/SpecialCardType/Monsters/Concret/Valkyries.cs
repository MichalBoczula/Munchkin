using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.Card.PrizeCard;
using Munchkin.Model.Character.Hero.Proficiency;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret
{
    public class Valkyries : MonsterCardBase
    {
        public Valkyries(string name, CardType cardType) : base(name, cardType)
        {
            Power = 12;
            HowManyLevels = 1;
            NumberOfPrizes = 3;
        }

        public override void DeadEnd(Game game, UserClass user)
        {
            var item = FindTheMostPowerfulItemInBuild(user);
            if (item != null)
            {
                DeleteMostPowerfulItemFromBuild(game, user, item);
            }
        }

        public override void SpecialPower(Game game, UserClass user)
        {
            if (user.UserAvatar.Proficiency is WarriorProficiency)
            {
                Power += 2;
            }
            if (user.UserAvatar.Build.LeftHandItem != null || user.UserAvatar.Build.RightHandItem != null)
            {
                Power += 4;
            }
        }

        public ItemCard FindTheMostPowerfulItemInBuild(UserClass user)
        {
            ItemCard item = null;
            if (user.UserAvatar.Build.Helmet != null)
            {
                if (item == null)
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
            if (user.UserAvatar.Build.Boots != null)
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

        public void DeleteMostPowerfulItemFromBuild(Game game, UserClass user, ItemCard item)
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
            return "Monster: Valkyries\n" +
                $"Power: {Power}, Prizes: {NumberOfPrizes}, Levels: {HowManyLevels}" +
                "SpecialPower: Monster get 4 power when player has weapon and get 2 power when player proficiency is Warrior.\n" +
                "Dead End: Player lose most powerful item.";
        }
    }
}
