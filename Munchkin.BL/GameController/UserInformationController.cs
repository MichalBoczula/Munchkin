using Munchkin.Model;
using Munchkin.Model.Card.PrizeCard;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.BL.GameController
{
    public class UserInformationController
    {
        public string ShowDeckInformation(UserClass user)
        {
            var result = new StringBuilder();
            int i = 0;
            foreach (var card in user.Deck.Items)
            {
                i++;
                string raceResult = CreateRaceRestrictionInformation(card);
                string profResult = CreateProficiencyRestrictionInformation(card);
                result.Append($"{i}.\tName: {card.Name};\n");
                result.Append($"\tItemType: {card.ItemType};\n");
                result.Append($"\tPower: {card.Power};\n");
                result.Append($"\tItemType: {card.ItemType};\n");
                result.Append($"\t{raceResult}");
                result.Append($"\t{profResult}");
                result.Append($"Price: {card.Price};\n");
            }

            foreach (var card in user.Deck.Monsters)
            {
                i++;
                result.Append($"{i}.\tName: {card.Name};\n");
                result.Append($"\tPower: {card.Power};\n");
                result.Append($"\tHowManyLevels: {card.HowManyLevels};\n");
                result.Append($"\tNumberOfPrizes: {card.NumberOfPrizes};\n");
                result.Append($"\tUndead: {card.Undead};\n");
            }

            foreach (var card in user.Deck.MagicCards)
            {
                i++;
                result.Append($"{i}.\tName: {card.Name};\n");
            }
            return result.ToString();
        }

        public string CreateProficiencyRestrictionInformation(ItemCard card)
        {
            return card.ProficiencyRestriction == null ? "" :
                        card.ProficiencyRestriction[true] != null ?
                            $"{card.ProficiencyRestriction[true].Name}: true;\n" :
                            $"{card.ProficiencyRestriction[false].Name}: false;\n";
        }

        public string CreateRaceRestrictionInformation(ItemCard card)
        {
            return card.RaceRestriction == null ? "" :
                        card.RaceRestriction[true] != null ?
                            $"{card.RaceRestriction[true].Name}: true;\n" :
                            $"{card.RaceRestriction[false].Name}: false;\n";
        }
    }
}
