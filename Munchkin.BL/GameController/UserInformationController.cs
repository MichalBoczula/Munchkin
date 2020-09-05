using Munchkin.Model;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.BL.GameController
{
    public class UserInformationController
    {
        public void ShowDeckInformation(UserClass user)
        {
            int i = 0;
            foreach(var card in user.Deck.Items)
            {
                i++;
                Console.WriteLine($"{i}. \tName: {card.Name}");
                Console.WriteLine($"\tItemType: {card.ItemType}");
                Console.WriteLine($"\tPower: {card.Power}");
                Console.WriteLine($"\t{card.ProficiencyRestriction}");
                var raceResult = card.RaceRestriction[true] != null ?
                        $", {card.RaceRestriction[true].Name}: true" :
                        $", {card.RaceRestriction[false].Name}: false";
                Console.WriteLine($"\t{raceResult}");
                var profResult = card.ProficiencyRestriction[true] != null ?
                        $", {card.ProficiencyRestriction[true].Name}: true" :
                        $", {card.ProficiencyRestriction[false].Name}: false";
                Console.WriteLine($"\t{profResult}");
                Console.WriteLine($"\t{card.Price}");
            }

            foreach (var card in user.Deck.Monsters)
            {
                i++;
                Console.WriteLine($"{i}.\tName: {card.Name}");
                Console.WriteLine($"\tPower: {card.Power}");
                Console.WriteLine($"\tHowManyLevels: {card.HowManyLevels}");
                Console.WriteLine($"\tNumberOfPrizes: {card.NumberOfPrizes}");
                Console.WriteLine($"\tUndead: {card.Undead}");
            }

            foreach (var card in user.Deck.MagicCards)
            {
                i++;
                Console.WriteLine($"{i}.\tName: {card.Name}");
            }
        }
    }
}
