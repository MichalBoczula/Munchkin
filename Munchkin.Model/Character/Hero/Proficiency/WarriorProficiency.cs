using Munchkin.BL.Helper;
using Munchkin.Model.Character.Action;
using Munchkin.Model.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Character.Hero.Proficiency
{
    public class WarriorProficiency : ProficiencyBase, IWarriorAction
    {
        private readonly InformationModelWarriorProficiency _informationModelWarriorProficiency;
        private new ReadLineOverride readLineOverride { get; set; }

        public WarriorProficiency(ReadLineOverride readLineOverride)
        {
            Name = "Warrior";
            _informationModelWarriorProficiency = new InformationModelWarriorProficiency();
            this.readLineOverride = readLineOverride;
        }

        public override DestroyedCards BeStronger(UserClass user)
        {
            var destroyedCards = new DestroyedCards();
            if (user.UserAvatar.HowManyCardsThrowToUseSkill < 3)
            {
                if (user.Deck != null && user.Deck.Count() > 0)
                {
                    int i = 1;
                    System.Console.WriteLine(LookOnItemsCard(user, ref i));
                    System.Console.WriteLine(LookOnMagicCardsCard(user, ref i));
                    System.Console.WriteLine(LookOnMonstersCard(user, ref i));
                    while (true)
                    {
                        System.Console.WriteLine($"Choose card from 1 to {user.Deck.Count()}");
                        if (Int32.TryParse(readLineOverride.GetNextString(), out int result))
                        {
                            if (result > user.Deck.Items.Count)
                            {
                                result -= user.Deck.Items.Count;
                                if (result > user.Deck.MagicCards.Count)
                                {
                                    result -= user.Deck.MagicCards.Count;
                                    user.UserAvatar.HowManyCardsThrowToUseSkill++;
                                    user.UserAvatar.TempPower++;
                                    var card = user.Deck.Monsters[result - 1];
                                    destroyedCards.DestroyedActionCards.Add(card);
                                    user.Deck.Monsters.RemoveAt(result - 1);
                                    Console.WriteLine(_informationModelWarriorProficiency.Success);
                                    readLineOverride.GetNextString();
                                    break;
                                }
                                else
                                {
                                    user.UserAvatar.HowManyCardsThrowToUseSkill++;
                                    user.UserAvatar.TempPower++;
                                    var card = user.Deck.MagicCards[result - 1];
                                    destroyedCards.DestroyedActionCards.Add(card);
                                    user.Deck.MagicCards.RemoveAt(result - 1);
                                    Console.WriteLine(_informationModelWarriorProficiency.Success);
                                    readLineOverride.GetNextString();
                                    break;
                                }
                            }
                            else
                            {
                                user.UserAvatar.HowManyCardsThrowToUseSkill++;
                                user.UserAvatar.TempPower++;
                                var card = user.Deck.Items[result - 1];
                                destroyedCards.DestroyedPrizeCards.Add(card);
                                user.Deck.Items.RemoveAt(result - 1);
                                Console.WriteLine(_informationModelWarriorProficiency.Success);
                                readLineOverride.GetNextString();
                                break;
                            }
                        }
                        else
                        {
                            System.Console.WriteLine($"Broo Choose card from 1 to {user.Deck.Count()}. Press enter to continue...");
                            readLineOverride.GetNextString();
                        }
                    }
                }
                else
                {
                    System.Console.WriteLine(_informationModelWarriorProficiency.NotEnoughCards);
                    readLineOverride.GetNextString();
                    return destroyedCards;
                }
            }
            else
            {
                System.Console.WriteLine(_informationModelWarriorProficiency.SkillHasBeenUsedMaxTimes);
                readLineOverride.GetNextString();
                return destroyedCards;
            }
            return destroyedCards;
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
    }
}
