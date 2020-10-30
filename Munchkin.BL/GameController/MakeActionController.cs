using Munchkin.BL.Helper;
using Munchkin.Model;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.Card.PrizeCard;
using Munchkin.Model.Character;
using Munchkin.Model.Character.Hero.Proficiency;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.BL.GameController
{
    public class MakeActionController
    {
        public Game Game;
        public GameAction GameAction;
        public FightController FightController;
        public PrizeStackController PrizeStackController;
        public Random Random;
        public DeckController DeckController;
        public ReadLineOverride ReadLineOverride;

        public MakeActionController(Game game, FightController fightController)
        {
            Game = game;
            GameAction = new GameAction();
            FightController = fightController;
        }

        public MakeActionController(Game game, FightController fightController, PrizeStackController prizeStackController)
        {
            Game = game;
            GameAction = new GameAction();
            FightController = fightController;
            PrizeStackController = prizeStackController;
        }
        public MakeActionController(Game game, FightController fightController, PrizeStackController prizeStackController, Random random)
        {
            Game = game;
            GameAction = new GameAction();
            FightController = fightController;
            PrizeStackController = prizeStackController;
            Random = random;
        }

        public MakeActionController(Game game, FightController fightController, PrizeStackController prizeStackController, Random random, DeckController deckController, ReadLineOverride readLineOverride)
        {
            Game = game;
            GameAction = new GameAction();
            FightController = fightController;
            PrizeStackController = prizeStackController;
            Random = random;
            DeckController = deckController;
            ReadLineOverride = readLineOverride;
        }

        public void OpenMisteryDoor(UserClass user)
        {
            if (GameAction.IsFirstTime)
            {
                GameAction.IsFirstTime = false;
                var action = Game.ActionCards[0];
                if (action.CardType is CardType.Monster)
                {
                    GameAction.IsFight = true;
                    action.SpecialPower(Game, user);
                    var fight = new Fight();
                    fight.Heros.Add(user);
                    fight.Monsters.Add((MonsterCardBase)action);
                    if (FightController.WhoWinFight(fight))
                    {
                        Game.DestroyedActionCards.AddRange(fight.Monsters);
                        GetPrizes(fight);
                    }
                    else
                    {
                        DeadEnd(fight);
                    }
                }

                Game.ActionCards.Remove(action);
                Game.DestroyedActionCards.Add(action);
            }
            //else
            //{
            //    IsFirstTime = false;
            //    var action = Game.ActionCards[0];
            //    if (action.CardType is CardType.Monster)
            //    {
            //        IsFight = true;
            //        //Fight
            //    }
            //    else
            //    {
            //        user.Deck.MagicCards.Add(action);
            //    }
            //    Game.ActionCards.Remove(action);
            //    Game.DestroyedActionCards.Add(action);
            //}

            //if (!IsFight)
            //{
            //    IsFight = true;
            //    OpenMisteryDoor(user, monster);
            //}
        }

        public void DeadEnd(Fight fight)
        {
            foreach (var monster in fight.Monsters)
            {
                foreach (var hero in fight.Heros)
                {
                    monster.DeadEnd(Game, hero);
                }
            }
        }

        public void GetPrizes(Fight fight)
        {
            if (fight.Heros.Count == 1)
            {
                var prizes = 0;
                foreach (var monster in fight.Monsters)
                {
                    prizes += monster.NumberOfPrizes;
                }

                while (prizes > 0)
                {
                    var card = PrizeStackController.DrawCard();
                    fight.Heros[0].Deck.Items.Add(card);
                    prizes--;
                }
            }
            else if (fight.Heros.Count > 1)
            {
                var list = new List<ItemCard>();
                var prizes = 0;
                foreach (var monster in fight.Monsters)
                {
                    prizes += monster.NumberOfPrizes;
                }

                while (prizes > 0)
                {
                    foreach (var hero in fight.Heros)
                    {
                        if (prizes == 0) return;
                        var card = PrizeStackController.DrawCard();
                        hero.Deck.Items.Add(card);
                        prizes--;
                    }
                }
            }
        }

        public List<UserAvatar> AskForHelp()
        {
            return null;
        }

        public void UseSpecialPower(UserClass user)
        {
            if (user.UserAvatar.Proficiency is WarriorProficiency)
            {
                while (true)
                {
                    System.Console.WriteLine("Throw card and be stronger");
                    System.Console.WriteLine("How many cards to throw out?\n1. one\n2. Two\n3. Three");
                    if (Int32.TryParse(ReadLineOverride.GetNextString(), out int result))
                    {
                        user.UserAvatar.Proficiency.BeStronger(user, result);
                        break;
                    }
                    else
                    {
                        System.Console.WriteLine("Choose number from 1 to 3. Press enter to continue...");
                        ReadLineOverride.GetNextString();
                    }
                }
                System.Console.WriteLine("You are much Stronger. Press enter to continue...");
                ReadLineOverride.GetNextString();
            }
            else if (user.UserAvatar.Proficiency is MageProficiency)
            {
                while (true)
                {
                    System.Console.WriteLine("Choose which spell you want cast:\n1. Flee spell - move much faster\n2. Try charm a monster");
                    if (Int32.TryParse(ReadLineOverride.GetNextString(), out int choice))
                    {
                        if (choice == 1)
                        {
                            while (true)
                            {
                                System.Console.WriteLine("How many cards to throw out?\n1. one\n2. Two\n3. Three");
                                if (Int32.TryParse(ReadLineOverride.GetNextString(), out int result))
                                {
                                    user.UserAvatar.Proficiency.FleeSpell(user, result);
                                    System.Console.WriteLine("You move much Faster. Press enter to continue...");
                                    ReadLineOverride.GetNextString();
                                    return;
                                }
                                else
                                {
                                    System.Console.WriteLine("Choose number from 1 to 3. Press enter to continue...");
                                    ReadLineOverride.GetNextString();
                                }
                            }
                        }
                        else if (choice == 2)
                        {
                            user.UserAvatar.Proficiency.CharmSpell(user);
                            System.Console.WriteLine("Press enter to continue...");
                            ReadLineOverride.GetNextString();
                            return;

                        }
                        else
                        {
                            System.Console.WriteLine("Choose first or second option");
                            ReadLineOverride.GetNextString();
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("Choose first or second option. Press enter to continue...");
                        ReadLineOverride.GetNextString();
                    }
                }
            }
            else if (user.UserAvatar.Proficiency is PriestProficiency)
            {

            }
            else if (user.UserAvatar.Proficiency is ThiefProficiency)
            {
                while (true)
                {
                    System.Console.WriteLine("Choose which spell you want cast:\n1. Backstab another user\n2. Try to steal an item");
                    if (Int32.TryParse(ReadLineOverride.GetNextString(), out int choice))
                    {
                        //if (choice == 1)
                        //{
                        //    while (true)
                        //    {

                        //        System.Console.WriteLine("How many cards to throw out?\n1. one\n2. Two\n3. Three");
                        //        if (Int32.TryParse(ReadLineOverride.GetNextString(), out int result))
                        //        {
                        //            user.UserAvatar.Proficiency.FleeSpell(user, result);
                        //            System.Console.WriteLine("You move much Faster. Press enter to continue...");
                        //            ReadLineOverride.GetNextString();
                        //            return;
                        //        }
                        //        else
                        //        {
                        //            System.Console.WriteLine("Choose number from 1 to 3. Press enter to continue...");
                        //            ReadLineOverride.GetNextString();
                        //        }
                        //    }
                        //}
                        //else if (choice == 2)
                        //{
                        //    user.UserAvatar.Proficiency.CharmSpell(user);
                        //    System.Console.WriteLine("Press enter to continue...");
                        //    ReadLineOverride.GetNextString();
                        //    return;

                        //}
                        //else
                        //{
                        //    System.Console.WriteLine("Choose first or second option");
                        //    ReadLineOverride.GetNextString();
                        //}
                    }
                    else
                    {
                        System.Console.WriteLine("Choose first or second option. Press enter to continue...");
                        ReadLineOverride.GetNextString();
                    }
                }
            }
            else
            {
                System.Console.WriteLine("You don't have special power. Press enter to continue...");
                ReadLineOverride.GetNextString();
            }
        }

        public bool Flee(UserClass user)
        {
            var chance = user.UserAvatar.FleeChances + Random.Next(6) + 1;
            if (chance >= 6)
            {
                return true;
            }
            return false;
        }

        public void UseSituationalCard(UserClass user)
        {
            //Add Look on SituationalItems
        }

    }
}
