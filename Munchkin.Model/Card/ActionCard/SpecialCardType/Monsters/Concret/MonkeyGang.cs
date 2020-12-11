using Munchkin.BL.Helper;
using Munchkin.Model;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.Card.PrizeCard;
using Munchkin.Model.Character.Hero.Proficiency;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret
{
    public class MonkeyGang : MonsterCardBase
    {
        private Random _random;

        public MonkeyGang(string name, CardType cardType, Random random) : base(name, cardType)
        {
            Power = 6;
            HowManyLevels = 1;
            NumberOfPrizes = 2;
            _random = random;
        }

        public override void DeadEnd(Game game, UserClass user)
        {
            var helmet = TryStealHelmet(user);
            var armor = TryStealArmor(user);
            var boots= TryStealBoots(user);
            var lHand = TryStealLHand(user);
            var rHand = TryStealRHand(user);
            if(helmet != null)
            {
                game.DestroyedPrizeCards.Add(helmet);
            }
            if (armor != null)
            {
                game.DestroyedPrizeCards.Add(armor);
            }
            if (boots != null)
            {
                game.DestroyedPrizeCards.Add(boots);
            }
            if (lHand != null)
            {
                game.DestroyedPrizeCards.Add(lHand);
            }
            if (rHand != null)
            {
                game.DestroyedPrizeCards.Add(rHand);
            }
        }

        public override void SpecialPower(Game game, UserClass user)
        {
            if (user.UserAvatar.Proficiency != null && !(user.UserAvatar.Proficiency is ThiefProficiency))
            {
                Power += 2;
            }
        }

        public ItemCard TryStealHelmet(UserClass user)
        {
            ItemCard item = null;
            if (user.UserAvatar.Build.Helmet != null)
            {
                if(user.UserAvatar.Proficiency.RollDice(_random) > 4)
                {
                    item = user.UserAvatar.Build.Helmet;
                    user.UserAvatar.Build.Helmet = null;
                }
            }
            return item;
        }

        public ItemCard TryStealArmor(UserClass user)
        {
            ItemCard item = null;
            if (user.UserAvatar.Build.Armor != null)
            {
                if (user.UserAvatar.Proficiency.RollDice(_random) > 4)
                {
                    item = user.UserAvatar.Build.Armor;
                    user.UserAvatar.Build.Armor = null;
                }
            }
            return item;
        }

        public ItemCard TryStealBoots(UserClass user)
        {
            ItemCard item = null;
            if (user.UserAvatar.Build.Boots != null)
            {
                if (user.UserAvatar.Proficiency.RollDice(_random) > 4)
                {
                    item = user.UserAvatar.Build.Boots;
                    user.UserAvatar.Build.Boots = null;
                }
            }
            return item;
        }

        public ItemCard TryStealLHand(UserClass user)
        {
            ItemCard item = null;
            if (user.UserAvatar.Build.LeftHandItem != null)
            {
                if (user.UserAvatar.Proficiency.RollDice(_random) > 4)
                {
                    item = user.UserAvatar.Build.LeftHandItem;
                    user.UserAvatar.Build.LeftHandItem = null;
                }
            }
            return item; ;
        }

        public ItemCard TryStealRHand(UserClass user)
        {
            ItemCard item = null;
            if (user.UserAvatar.Build.RightHandItem != null)
            {
                if (user.UserAvatar.Proficiency.RollDice(_random) > 4)
                {
                    item = user.UserAvatar.Build.RightHandItem;
                    user.UserAvatar.Build.RightHandItem = null;
                }
            }
            return item;
        }

        public override string Description()
        {
            return "Monster: MonkeyGang\n" +
                $"Power: {Power}, Prizes: {NumberOfPrizes}, Levels: {HowManyLevels}\n" +
                "SpecialPower: If Player proficiency is Thief, Monsters power increase by 2.\n" +
                "Dead End: Monkey try to steal each item from players build";
        }
    }
}
