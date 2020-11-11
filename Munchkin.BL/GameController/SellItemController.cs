using Munchkin.BL.Helper;
using Munchkin.Model;
using Munchkin.Model.Character.Hero.Race;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.BL.GameController
{
    public class SellItemController
    {
        public DeckController deckController;
        public ReadLineOverride readLineOverride;

        public SellItemController(DeckController deckController, ReadLineOverride readLineOverride)
        {
            this.deckController = deckController;
            this.readLineOverride = readLineOverride;
        }

        public bool SellItem(UserClass user)
        {
            if (user.Deck.Items.Count == 0)
            {
                System.Console.WriteLine("You don't have item to sell. Press item to continue...");
                readLineOverride.GetNextString();
                return false;
            }
            var flag = false;
            int i = 1;
            while (true)
            {
                System.Console.WriteLine("Choose item to sell");
                System.Console.WriteLine(deckController.LookOnItemsCard(user, ref i));
                System.Console.WriteLine("If you want to sell item choose one from list, otherwise press 0. " +
                    "But remember this item will be permamently destroyed, There is not possibility to restore, because item will be not existed." +
                    " Choose option to continue...");
                if (Int32.TryParse(readLineOverride.GetNextString(), out int result))
                {
                    if (result == 0)
                    {
                        System.Console.WriteLine("You didn't sell item. Press enter to continue");
                        readLineOverride.GetNextString();
                        break;
                    }
                    else if (result <= user.Deck.Items.Count)
                    {
                        var item = user.Deck.Items[result - 1];
                        user.Deck.Items.Remove(item);
                        user.UserAvatar.Wallet = user.UserAvatar.Race is Halfling ? item.Price * 2 : item.Price;
                        flag = true;
                        if (user.UserAvatar.Race is Halfling)
                        {
                            System.Console.WriteLine($"You race is halfing so you have big selling skills and " +
                                "price for item is 2 time bigger, price is: {item.Price} ." +
                                " Press enter to continue");
                            readLineOverride.GetNextString();
                            break;
                        }
                        else
                        {
                            System.Console.WriteLine($"You sell an item for {item.Price}. Press enter to continue");
                            readLineOverride.GetNextString();
                            break;
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("Bro choose option from list!!!. Pres enter to continue...");
                        readLineOverride.GetNextString();
                    }
                }
                else
                {
                    System.Console.WriteLine("Input numper bro options are on list!!!. Pres enter to continue...");
                    readLineOverride.GetNextString();
                }
            }
            return flag;
        }

        public void CheckMoneyAndAddLevel(UserClass user)
        {
            System.Console.WriteLine("If you have more or equal 1000 money in wallet yo can bu a level." +
                " Lets check it. Press enter to continue...");
            readLineOverride.GetNextString();
            if (user.UserAvatar.Wallet >= 1000)
            {
                user.UserAvatar.Level += 1;
                user.UserAvatar.Wallet -= 1000;
                System.Console.WriteLine($"You has got next level now you are on {user.UserAvatar.Level} Press enter to continue...");
                readLineOverride.GetNextString();
            }
            else
            {
                System.Console.WriteLine($"You can't buy next level, you don't have enough money. Press enter to continue...");
                readLineOverride.GetNextString();
            }
        }
    }
}
