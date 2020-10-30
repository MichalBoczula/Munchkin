using Munchkin.BL.Helper;
using Munchkin.Model;
using Munchkin.Model.Card.PrizeCard;
using Munchkin.Model.Character;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.BL.GameController
{
    public class DeckController
    {
        private readonly ReadLineOverride _readLineOverride;

        public DeckController(ReadLineOverride readLineOverride)
        {
            _readLineOverride = readLineOverride;
        }

        public void LookOnCard(UserClass user)
        {
            int i = 1;
            System.Console.WriteLine(LookOnItemsCard(user, ref i));
            System.Console.WriteLine(LookOnMonstersCard(user, ref i));
            System.Console.WriteLine(LookOnMagicCardsCard(user, ref i));
        }
        
        public void ChooseCard(UserClass user)
        {
            //System.Console.WriteLine($"Input number from 1 to 3 to choose a card type. Press enter to continue...");
            //System.Console.WriteLine($"1. Items: quantity {user.Deck.Items.Count}");
            //System.Console.WriteLine($"2. Monsters: quantity {user.Deck.Monsters.Count}");
            //System.Console.WriteLine($"3. Magic: quantity {user.Deck.MagicCards.Count}");
            //if (Int32.TryParse(_readLineOverride.GetNextString(), out int num))
            //{
            //    switch (num)
            //    {
            //        case 1:
            //            System.Console.WriteLine(LookOnItemsCard(user));
            //            break;
            //        case 2:
            //            System.Console.WriteLine(LookOnMonstersCard(user));
            //            break;
            //        case 3:
            //            System.Console.WriteLine(LookOnMagicCardsCard(user));
            //            break;
            //        default:
            //            System.Console.WriteLine($"Choose number from 1 to 3. Press enter to continue...");
            //            _readLineOverride.GetNextString();
            //            break;
            //    }
            //}
            //else
            //{
            //    System.Console.WriteLine("Your input it is not a number. Try again. Press enter to continue...");
            //    _readLineOverride.GetNextString();
            //}
        }

        public string LookOnItemsCard(UserClass user, ref int i)
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append("Items\n");
            strBuilder.Append("___________________________________________________________________\n");
            foreach (var card in user.Deck.Items)
            {
                strBuilder.Append($"{i}. ");
                strBuilder.Append($"Name: {card.Name}, Power: {card.Power} ");
                strBuilder.Append($"ItemType: {card.ItemType}, CardType: {card.CardType}");
                if (card.RaceRestriction != null)
                {
                    if (card.RaceRestriction.TryGetValue(true, out RaceBase value))
                    {
                        strBuilder.Append($", {value.Name}: true, ");
                    }
                    else
                    {
                        strBuilder.Append($", {card.RaceRestriction[false].Name}: false, ");
                    }
                }
                if (card.ProficiencyRestriction != null)
                {
                    if (card.ProficiencyRestriction.TryGetValue(true, out ProficiencyBase value))
                    {
                        strBuilder.Append($", {value.Name}: true, ");
                    }
                    else
                    {
                        strBuilder.Append($", {card.ProficiencyRestriction[false].Name}: false");
                    }
                }
                strBuilder.Append(";\n");
                i++;
            }
            return strBuilder.ToString();
        }

        public string LookOnMagicCardsCard(UserClass user, ref int i)
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append("Magic Cards\n");
            strBuilder.Append("___________________________________________________________________\n");
            foreach (var card in user.Deck.MagicCards)
            {
                strBuilder.Append($"{i}. ");
                strBuilder.Append($"Name: {card.Name}");
                strBuilder.Append($"Description: {card.Name}");
                strBuilder.Append(";\n");
                i++;
            }
            return strBuilder.ToString();
        }

        public string LookOnMonstersCard(UserClass user, ref int i)
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append("Monsters\n");
            strBuilder.Append("___________________________________________________________________\n");
            foreach (var card in user.Deck.Monsters)
            {
                strBuilder.Append($"{i}. ");
                strBuilder.Append($"Name: {card.Name}, Power: {card.Power}, Undead: { card.Undead}, ");
                strBuilder.Append($"Levels after fight: {card.HowManyLevels}");
                strBuilder.Append($"Prizes: {card.NumberOfPrizes}");
                strBuilder.Append(";\n");
                i++;
            }
            return strBuilder.ToString();
        }
#nullable enable
        public void UseItemCard(UserClass user, ItemCard card, Fight? fight)
        {
            if (card.ItemType == ItemType.Helmet)
            {
                if (CheckRestriction(user, card))
                {
                    if (user.UserAvatar.Build.Helmet is null)
                    {
                        user.Deck.Items.Remove(card);
                        user.UserAvatar.Build.Helmet = card;
                    }
                    else
                    {
                        while (true)
                        {
                            System.Console.WriteLine("You have equipped helment.\n");
                            System.Console.WriteLine($"To equip: Name: { card.Name}, Power: { card.Power} \n");
                            System.Console.WriteLine($"Equipped: Name: { user.UserAvatar.Build.Helmet.Name}, Power: { user.UserAvatar.Build.Helmet.Power} \n");
                            System.Console.WriteLine("Do you want change?\n1.Yes\n2.No");
                            if (Int32.TryParse(_readLineOverride.GetNextString(), out int result))
                            {
                                if (result == 1)
                                {
                                    System.Console.WriteLine("You changed item. Press enter to continue");
                                    user.Deck.Items.Remove(card);
                                    user.Deck.Items.Add(user.UserAvatar.Build.Helmet);
                                    user.UserAvatar.Build.Helmet = card;
                                    _readLineOverride.GetNextString();
                                    break;
                                }
                                else if (result == 2)
                                {
                                    System.Console.WriteLine("You did not change item. Press enter to continue");
                                    _readLineOverride.GetNextString();
                                    break;
                                }
                                else
                                {
                                    System.Console.WriteLine("Input nymber 1 or 2. Press enter to continue...");
                                    _readLineOverride.GetNextString();
                                }
                            }
                            else
                            {
                                System.Console.WriteLine("Input nymber 1 or 2. Press enter to continue...");
                                _readLineOverride.GetNextString();
                            }
                        }
                    }
                }
                else
                {
                    System.Console.WriteLine("You can not use this item . Press enter to continue...");
                    _readLineOverride.GetNextString();
                }
            }
            else if (card.ItemType == ItemType.Armor)
            {
                if (CheckRestriction(user, card))
                {
                    if (user.UserAvatar.Build.Armor is null)
                    {
                        user.Deck.Items.Remove(card);
                        user.UserAvatar.Build.Armor = card;
                    }
                    else
                    {
                        while (true)
                        {
                            System.Console.WriteLine("You have equipped helment.\n");
                            System.Console.WriteLine($"To equip: Name: { card.Name}, Power: { card.Power} \n");
                            System.Console.WriteLine($"Equipped: Name: { user.UserAvatar.Build.Armor.Name}, Power: { user.UserAvatar.Build.Armor.Power} \n");
                            System.Console.WriteLine("Do you want change?\n1.Yes\n2.No");
                            if (Int32.TryParse(_readLineOverride.GetNextString(), out int result))
                            {
                                if (result == 1)
                                {
                                    System.Console.WriteLine("You changed item. Press enter to continue");
                                    user.Deck.Items.Remove(card);
                                    user.Deck.Items.Add(user.UserAvatar.Build.Armor);
                                    user.UserAvatar.Build.Armor = card;
                                    _readLineOverride.GetNextString();
                                    break;
                                }
                                else if (result == 2)
                                {
                                    System.Console.WriteLine("You did not change item. Press enter to continue");
                                    _readLineOverride.GetNextString();
                                    break;
                                }
                                else
                                {
                                    System.Console.WriteLine("Input nymber 1 or 2. Press enter to continue...");
                                    _readLineOverride.GetNextString();
                                }
                            }
                            else
                            {
                                System.Console.WriteLine("Input nymber 1 or 2. Press enter to continue...");
                                _readLineOverride.GetNextString();
                            }
                        }
                    }
                }
                else
                {
                    System.Console.WriteLine("You can not use this item . Press enter to continue...");
                    _readLineOverride.GetNextString();
                }
            }
            else if (card.ItemType == ItemType.Boots)
            {
                if (CheckRestriction(user, card))
                {
                    if (user.UserAvatar.Build.Boots is null)
                    {
                        user.Deck.Items.Remove(card);
                        user.UserAvatar.Build.Boots = card;
                    }
                    else
                    {
                        while (true)
                        {
                            System.Console.WriteLine("You have equipped helment.\n");
                            System.Console.WriteLine($"To equip: Name: { card.Name}, Power: { card.Power} \n");
                            System.Console.WriteLine($"Equipped: Name: { user.UserAvatar.Build.Boots.Name}, Power: { user.UserAvatar.Build.Boots.Power} \n");
                            System.Console.WriteLine("Do you want change?\n1.Yes\n2.No");
                            if (Int32.TryParse(_readLineOverride.GetNextString(), out int result))
                            {
                                if (result == 1)
                                {
                                    System.Console.WriteLine("You changed item. Press enter to continue");
                                    user.Deck.Items.Remove(card);
                                    user.Deck.Items.Add(user.UserAvatar.Build.Boots);
                                    user.UserAvatar.Build.Boots = card;
                                    _readLineOverride.GetNextString();
                                    break;
                                }
                                else if (result == 2)
                                {
                                    System.Console.WriteLine("You did not change item. Press enter to continue");
                                    _readLineOverride.GetNextString();
                                    break;
                                }
                                else
                                {
                                    System.Console.WriteLine("Input nymber 1 or 2. Press enter to continue...");
                                    _readLineOverride.GetNextString();
                                }
                            }
                            else
                            {
                                System.Console.WriteLine("Input nymber 1 or 2. Press enter to continue...");
                                _readLineOverride.GetNextString();
                            }
                        }
                    }
                }
                else
                {
                    System.Console.WriteLine("You can not use this item . Press enter to continue...");
                    _readLineOverride.GetNextString();
                }
            }
            else if (card.ItemType == ItemType.Weapon)
            {
                SetWeapon(user, card);
            }
            else if (card.ItemType == ItemType.Additional)
            {
                UseAdditionalItems(user, card);
            }
            else if (card.ItemType == ItemType.Sitiuational)
            {
                UseSituationalItems(card, fight);
            }
        }


        public void UseSituationalItems(ItemCard card, Fight? fight)
        {
            if (fight == null)
            {
                System.Console.WriteLine("Man no one is fighting, use this card during a fight. Press enter to continue");
                _readLineOverride.GetNextString();
            }
            else
            {
                card.SpecialEffect(fight);
            }
        }
#nullable disable
        public void SetWeapon(UserClass user, ItemCard card)
        {
            if (!CheckRestriction(user, card))
            {
                System.Console.WriteLine($"You can not use weapon: {card.Name}, because has restriction. Press enter to continue...");
                _readLineOverride.GetNextString();
                return;
            }

            if (user.UserAvatar.Build.LeftHandItem is null && user.UserAvatar.Build.RightHandItem is null)
            {
                System.Console.WriteLine($"You equipped weapon: {card.Name} in left hand. Press enter to continue...");
                _readLineOverride.GetNextString();
                user.Deck.Items.Remove(card);
                user.UserAvatar.Build.LeftHandItem = card;
            }
            else if (user.UserAvatar.Build.LeftHandItem != null && user.UserAvatar.Build.RightHandItem == null && !card.IsTwoHanded)
            {
                System.Console.WriteLine($"You equipped weapon: {card.Name} in right hand. Press enter to continue...");
                _readLineOverride.GetNextString();
                user.Deck.Items.Remove(card);
                user.UserAvatar.Build.RightHandItem = card;
            }
            else if (user.UserAvatar.Build.LeftHandItem != null && card.IsTwoHanded
                || user.UserAvatar.Build.RightHandItem != null && card.IsTwoHanded)
            {
                while (true)
                {
                    System.Console.WriteLine("You new weapon is two handed. Do you want to equip new one instead of actual." +
                    "\nChoose what you want to do:\n1.Change Weapons\n2.Keep two old ones");
                    Int32.TryParse(_readLineOverride.GetNextString(), out int num);
                    if (num == 1)
                    {
                        if(user.UserAvatar.Build.LeftHandItem != null)
                        {
                            user.Deck.Items.Add(user.UserAvatar.Build.LeftHandItem);
                            user.UserAvatar.Build.LeftHandItem = card;
                            user.Deck.Items.Remove(card);
                            System.Console.WriteLine($"You changed weapon to: {card.Name}. Press enter to continue...");
                            _readLineOverride.GetNextString();
                        }
                        else if (user.UserAvatar.Build.RightHandItem != null)
                        {
                            user.Deck.Items.Add(user.UserAvatar.Build.RightHandItem);
                            user.UserAvatar.Build.RightHandItem = null;
                            user.UserAvatar.Build.LeftHandItem = card;
                            user.Deck.Items.Remove(card);
                            System.Console.WriteLine($"You changed weapon to: {card.Name}. Press enter to continue...");
                            _readLineOverride.GetNextString();
                        }
                        break;
                    }
                    else if (num == 2)
                    {
                        System.Console.WriteLine("You kept old weapons. Press enter to continue...");
                        _readLineOverride.GetNextString();
                        break;
                    }
                    else
                    {
                        System.Console.WriteLine("Input number 1 or 2. Press enter to continue...");
                        _readLineOverride.GetNextString();
                    }
                }
            }
            else if (user.UserAvatar.Build.LeftHandItem != null && user.UserAvatar.Build.RightHandItem != null)
            {
                while (true)
                {
                    System.Console.WriteLine("You both hands are occupie. Do you want to equip new weapon instead of actual." +
                    "\nChoose what you want to do:\n1.Change Weapons\n2.Keep old one");
                    Int32.TryParse(_readLineOverride.GetNextString(), out int num);
                    if (num == 1)
                    {
                        while (true)
                        {
                            System.Console.WriteLine("Choose which weapon should be change." +
                            "\nChoose what you want to do:\n1.Left Hand\n2.Right Hand");
                            Int32.TryParse(_readLineOverride.GetNextString(), out int result);
                            if (result == 1)
                            {
                                var lhand = user.UserAvatar.Build.LeftHandItem;
                                user.Deck.Items.Add(lhand);
                                user.UserAvatar.Build.LeftHandItem = card;
                                user.Deck.Items.Remove(card);
                                System.Console.WriteLine("You changed weapon. Press enter to continue...");
                                _readLineOverride.GetNextString();
                                return;
                            }
                            else if (result == 2)
                            {
                                var rhand = user.UserAvatar.Build.RightHandItem;
                                user.Deck.Items.Add(rhand);
                                user.UserAvatar.Build.RightHandItem = card;
                                user.Deck.Items.Remove(card);
                                System.Console.WriteLine("You changed weapon. Press enter to continue...");
                                _readLineOverride.GetNextString();
                                return;
                            }
                            else
                            {
                                System.Console.WriteLine("Input number 1 or 2. Press enter to continue...");
                                _readLineOverride.GetNextString();
                            }
                        }
                    }
                    else if (num == 2)
                    {
                        System.Console.WriteLine("You kept old weapons. Press enter to continue...");
                        _readLineOverride.GetNextString();
                        return;
                    }
                    else
                    {
                        System.Console.WriteLine("Input number 1 or 2. Press enter to continue...");
                        _readLineOverride.GetNextString();
                    }
                }
            }
        }

        public void UseAdditionalItems(UserClass user, ItemCard card)
        {
            if (card.RaceRestriction == null && card.ProficiencyRestriction == null)
            {
                user.UserAvatar.Build.AdditionalItems.Add(card);
                System.Console.WriteLine("Item added succesfully. Press enter to continue...");
                _readLineOverride.GetNextString();
            }
            else
            {
                if (card.RaceRestriction != null)
                {
                    RaceBase result;
                    if (card.RaceRestriction.TryGetValue(true, out result))
                    {
                        if (result.Name.Equals(user.UserAvatar.Race.Name))
                        {
                            System.Console.WriteLine("Item added succesfully. Press enter to continue...");
                            user.UserAvatar.Build.AdditionalItems.Add(card);
                            _readLineOverride.GetNextString();
                        }
                        else
                        {
                            System.Console.WriteLine("You can not use this item. Press enter to continue...");
                            _readLineOverride.GetNextString();
                        }
                    }
                    else
                    {
                        card.RaceRestriction.TryGetValue(false, out result);
                        if (!result.Name.Equals(user.UserAvatar.Race.Name))
                        {
                            System.Console.WriteLine("Item added succesfully. Press enter to continue...");
                            user.UserAvatar.Build.AdditionalItems.Add(card);
                            _readLineOverride.GetNextString();
                        }
                        else
                        {
                            System.Console.WriteLine("You can not use this item. Press enter to continue...");
                            _readLineOverride.GetNextString();
                        }
                    }
                }
                if (card.ProficiencyRestriction != null)
                {
                    ProficiencyBase prof;
                    if (card.ProficiencyRestriction.TryGetValue(true, out prof))
                    {
                        if (prof.Name.Equals(user.UserAvatar.Proficiency.Name))
                        {
                            System.Console.WriteLine("Item added succesfully. Press enter to continue...");
                            user.UserAvatar.Build.AdditionalItems.Add(card);
                            _readLineOverride.GetNextString();
                        }
                        else
                        {
                            System.Console.WriteLine($"You can not use this item, you are not a {prof.Name}. Press enter to continue...");
                            _readLineOverride.GetNextString();
                        }
                    }
                    else
                    {
                        card.ProficiencyRestriction.TryGetValue(false, out prof);
                        if (!prof.Name.Equals(user.UserAvatar.Proficiency.Name))
                        {
                            System.Console.WriteLine("Item added succesfully. Press enter to continue...");
                            user.UserAvatar.Build.AdditionalItems.Add(card);
                            _readLineOverride.GetNextString();
                        }
                        else
                        {
                            System.Console.WriteLine($"You can not use this item, because you are a {prof.Name}. Press enter to continue...");
                            _readLineOverride.GetNextString();
                        }
                    }
                }
            }
        }

        public bool CheckRestriction(UserClass user, ItemCard card)
        {
            if (card.RaceRestriction == null && card.ProficiencyRestriction == null) return true;

            if (card.RaceRestriction != null)
            {
                if (card.RaceRestriction.TryGetValue(true, out RaceBase value))
                {
                    if (value.Name.Equals(user.UserAvatar.Race.Name))
                    {
                        return true;
                    }
                }
                else
                {
                    card.RaceRestriction.TryGetValue(false, out RaceBase result);
                    if (!result.Name.Equals(user.UserAvatar.Race.Name))
                    {
                        return true;
                    }
                }
            }
            if (card.ProficiencyRestriction != null)
            {
                if (card.ProficiencyRestriction.TryGetValue(true, out ProficiencyBase value))
                {
                    if (value.Name.Equals(user.UserAvatar.Proficiency.Name))
                    {
                        return true;
                    }
                }
                else
                {
                    card.ProficiencyRestriction.TryGetValue(false, out ProficiencyBase result);
                    if (!result.Name.Equals(user.UserAvatar.Proficiency.Name))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
