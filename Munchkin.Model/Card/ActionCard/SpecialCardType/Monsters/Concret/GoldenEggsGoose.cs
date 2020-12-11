using Munchkin.BL.Helper;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.Card.PrizeCard;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret
{
    public class GoldenEggsGoose : MonsterCardBase
    {
        private GoldenEggsGooseInformationModel _goldenEggsGooseInformation;
        private ReadLineOverride _readLineOverride;

        public GoldenEggsGoose(string name, CardType cardType, ReadLineOverride readLineOverride) : base(name, cardType)
        {
            Power = 2;
            NumberOfPrizes = 0;
            HowManyLevels = 0;
            _goldenEggsGooseInformation = new GoldenEggsGooseInformationModel();
            _readLineOverride = readLineOverride;
        }

        public override void DeadEnd(Game game, UserClass user)
        {
            var item = FindTheMostExpensiveItem(user);
            if (item != null)
            {
                DeleteMostExpensiveItem(game, user, item);
            }
        }

        public override void SpecialPower(Game game, UserClass user)
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine(_goldenEggsGooseInformation.InitMsg);
                if (Int32.TryParse(_readLineOverride.GetNextString(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            HowManyLevels = 1;
                            Console.WriteLine(_goldenEggsGooseInformation.ChoosenLevel);
                            _readLineOverride.GetNextString();
                            flag = false;
                            break;
                        case 2:
                            NumberOfPrizes = 3;
                            Console.WriteLine(_goldenEggsGooseInformation.ChoosenPrizes);
                            _readLineOverride.GetNextString();
                            flag = false;
                            break;
                        default:
                            Console.WriteLine(_goldenEggsGooseInformation.FailMsg);
                            _readLineOverride.GetNextString();
                            break;
                    }
                }
            }
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
            return "Monster: GoldenEggsGoose\n" +
                $"Power: {Power}, Prizes: {NumberOfPrizes}, Levels: {HowManyLevels}\n" +
                "SpecialPower: Player has to choose which prize prefer: Level or Items\n" +
                "Dead End: Player lose the most expensive item";
        }
    }

    public class GoldenEggsGooseInformationModel
    {
        public string InitMsg { get => "Choose Your Price:\n1. Level = 1\n2. Prizes = 3"; }
        public string FailMsg { get => "Input 1 or 2, it is not difficult!\nPress any key to continue"; }
        public string ChoosenLevel { get => "You Choose 1 Level"; }
        public string ChoosenPrizes { get => "You 3 Prizes"; }

    }
}
