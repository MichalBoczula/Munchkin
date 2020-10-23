using Munchkin.Model;
using Munchkin.Model.Card.PrizeCard;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.BL.GameController
{
    public class DeckController
    {
        public string LookOnCard(UserClass user)
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append("Items\n");
            strBuilder.Append("___________________________________________________________________\n");
            int i = 1;
            foreach (var card in user.Deck.Items)
            {
                strBuilder.Append($"{i}. ");
                strBuilder.Append($"Name: {card.Name}, Power: {card.Power} ");
                strBuilder.Append($"ItemType: {card.ItemType}, CardType: {card.CardType}");
                if (card.RaceRestriction != null)
                {
                    try
                    {
                        strBuilder.Append($", {card.RaceRestriction[true].Name}: true, ");
                    }
                    catch
                    {
                        strBuilder.Append($", {card.RaceRestriction[false].Name}: false, ");
                    }
                }
                if (card.ProficiencyRestriction != null)
                {
                    try
                    {
                        strBuilder.Append($", {card.ProficiencyRestriction[true].Name}: true");
                    }
                    catch
                    {
                        strBuilder.Append($", {card.ProficiencyRestriction[false].Name}: false");
                    }
                }
                strBuilder.Append(";\n");
                i++;
            }
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
        public void chooseCard(UserClass user)
        {
            System.Console.WriteLine($"Input number from 1 to {user.Deck.Items.Count}. Press enter to continue...");
            if (Int32.TryParse(System.Console.ReadLine(), out int num))
            {
                if (num > 0 || num < user.Deck.Items.Count)
                {
                   
                }
                else
                {
                    System.Console.WriteLine($"Choose number from 1 to {user.Deck.Items.Count}. Press enter to continue...");
                    System.Console.ReadLine();
                }
            }
            else
            {
                System.Console.WriteLine("Your input it is not a number. Try again. Press enter to continue...");
                System.Console.ReadLine();
            }
        }
    }
}
