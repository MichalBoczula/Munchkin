using Munchkin.BL.Helper;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.Card.PrizeCard;
using Munchkin.Model.Character.Action;
using Munchkin.Model.Helper;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Character.Hero.Proficiency
{
    public class PriestProficiency : ProficiencyBase, IPriestAction
    {
        public new ReadLineOverride readLineOverride;

        public PriestProficiency(ReadLineOverride readLineOverride)
        {
            Name = "Priest";
            this.readLineOverride = readLineOverride;
        }

#nullable enable
        public override DestroyedCards MakeMonsterAPet(UserClass user, Fight? fight)
        {
            var destroyedCards = new DestroyedCards();
            if (fight == null) return destroyedCards;
            System.Console.WriteLine("You are trying to cast spell, to cast it you need 3 cards and more. Press enter to continue to check cards");
            readLineOverride.GetNextString();
            if (user.Deck.Count() >= 3)
            {
                while (true)
                {

                    System.Console.WriteLine("You have enough cards do you want cast spell. Remember you will lose you whole deck.\n" +
                        "Choose option:\n1.Yes\n2.No");
                    readLineOverride.GetNextString();
                    if (Int32.TryParse(readLineOverride.GetNextString(), out int result))
                    {
                        if (result == 1)
                        {
                            destroyedCards.DestroyedPrizeCards.AddRange(user.Deck.Items);
                            destroyedCards.DestroyedActionCards.AddRange(user.Deck.Monsters);
                            destroyedCards.DestroyedActionCards.AddRange(user.Deck.MagicCards);
                            user.Deck.Clear();
                            MonsterCardBase monster = fight.Monsters[0];
                            foreach (var mon in fight.Monsters)
                            {
                                if (mon.Power > monster.Power)
                                {
                                    monster = mon;
                                }
                            }
                            user.Deck.Monsters.Add(monster);
                            return destroyedCards;
                        }
                        else if (result == 2)
                        {
                            System.Console.WriteLine("You didn't cast a spell. Press enter to continue...");
                            readLineOverride.GetNextString();
                            return destroyedCards;
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("Choose one option 1 or 2. Press enter to continue...");
                        readLineOverride.GetNextString();
                    }
                }

            }
            else
            {
                System.Console.WriteLine("You don't have enough cards to cast spell. Press enter to continue...");
                readLineOverride.GetNextString();
                return destroyedCards;
            }
        }
#nullable disable

        public override DestroyedCards RestorePrizeCard(UserClass user, Game game)
        {
            var destroyedCards = new DestroyedCards();
            if (game.DestroyedPrizeCards.Count == 0)
            {
                System.Console.WriteLine("There are not prize cards to restore. Press enter to continue...");
                readLineOverride.GetNextString();
                return destroyedCards;
            }
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
                                ChooseCardToRestore(user, game);
                                Console.WriteLine("You Successfully destroyed card. Press enter to continue...");
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
                                ChooseCardToRestore(user, game);
                                Console.WriteLine("You Successfully destroyed card. Press enter to continue...");
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
                            ChooseCardToRestore(user, game);
                            Console.WriteLine("You Successfully destroyed card. Press enter to continue...");
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
                System.Console.WriteLine("Sorry Bro you don't have cards. Press enter to continue...");
                readLineOverride.GetNextString();
                return destroyedCards;
            }
            return destroyedCards;
        }

        public void ChooseCardToRestore(UserClass user, Game game)
        {
            if (game.DestroyedPrizeCards.Count != 0)
            {
                int i = 1;
                while (true)
                {
                    StringBuilder strBuilder = new StringBuilder();
                    foreach (var action in game.DestroyedPrizeCards)
                    {
                        if (action.PrizeCardType == PrizeCardType.Item)
                        {
                            strBuilder.Append($"{i}. ");
                            strBuilder.Append($"Name: {action.Name}, Power: {action.Power} ");
                            strBuilder.Append($"ItemType: {action.ItemType}, CardType: {action.CardType}");
                            if (action.RaceRestriction != null)
                            {
                                if (action.RaceRestriction.TryGetValue(true, out RaceBase value))
                                {
                                    strBuilder.Append($", {value.Name}: true, ");
                                }
                                else
                                {
                                    strBuilder.Append($", {action.RaceRestriction[false].Name}: false, ");
                                }
                            }
                            if (action.ProficiencyRestriction != null)
                            {
                                if (action.ProficiencyRestriction.TryGetValue(true, out ProficiencyBase value))
                                {
                                    strBuilder.Append($", {value.Name}: true, ");
                                }
                                else
                                {
                                    strBuilder.Append($", {action.ProficiencyRestriction[false].Name}: false");
                                }
                            }
                            strBuilder.Append(";\n");
                            i++;
                        }
                    }
                    System.Console.WriteLine("Choose Card To Restore from list. Input num of card:");
                    if (Int32.TryParse(readLineOverride.GetNextString(), out int result))
                    {
                        if(result <= game.DestroyedPrizeCards.Count)
                        {
                            var card = game.DestroyedPrizeCards[result - 1];
                            user.Deck.Items.Add(card);
                            game.DestroyedPrizeCards.Remove(card);
                            System.Console.WriteLine("You restore item. Press enter to continue");
                            readLineOverride.GetNextString();
                            break;
                        }
                        else
                        {
                            System.Console.WriteLine("Choose Card To Restore from list. Press enter to continue");
                            readLineOverride.GetNextString();
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("Choose Card To Restore from list. Press enter to continue");
                        readLineOverride.GetNextString();
                    }
                }
            }
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
