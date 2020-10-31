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
        public Game game;
        public GameAction gameAction;
        public FightController fightController;
        public PrizeStackController prizeStackController;
        public Random random;
        public DeckController deckController;
        public ReadLineOverride readLineOverride;

        public MakeActionController(Game game, FightController fightController)
        {
            this.game = game;
            gameAction = new GameAction();
            this.fightController = fightController;
        }

        public MakeActionController(Game game, FightController fightController, PrizeStackController prizeStackController)
        {
            this.game = game;
            gameAction = new GameAction();
            this.fightController = fightController;
            this.prizeStackController = prizeStackController;
        }
        public MakeActionController(Game game, FightController fightController, PrizeStackController prizeStackController, Random random)
        {
            this.game = game;
            gameAction = new GameAction();
            this.fightController = fightController;
            this.prizeStackController = prizeStackController;
            this.random = random;
        }

        public MakeActionController(Game game, FightController fightController, PrizeStackController prizeStackController, Random random, DeckController deckController, ReadLineOverride readLineOverride)
        {
            this.game = game;
            gameAction = new GameAction();
            this.fightController = fightController;
            this.prizeStackController = prizeStackController;
            this.random = random;
            this.deckController = deckController;
            this.readLineOverride = readLineOverride;
        }

        public void OpenMisteryDoor(UserClass user)
        {
            if (gameAction.IsFirstTime)
            {
                gameAction.IsFirstTime = false;
                var action = game.ActionCards[0];
                if (action.CardType is CardType.Monster)
                {
                    gameAction.IsFight = true;
                    action.SpecialPower(game, user);
                    var fight = new Fight();
                    fight.Heros.Add(user);
                    fight.Monsters.Add((MonsterCardBase)action);
                    if (fightController.WhoWinFight(fight))
                    {
                        game.DestroyedActionCards.AddRange(fight.Monsters);
                        GetPrizes(fight);
                    }
                    else
                    {
                        DeadEnd(fight);
                    }
                }

                game.ActionCards.Remove(action);
                game.DestroyedActionCards.Add(action);
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
                    monster.DeadEnd(game, hero);
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
                    var card = prizeStackController.DrawCard();
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
                        var card = prizeStackController.DrawCard();
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

#nullable enable
        public void UseSpecialPower(UserClass user, Fight? fight)
        {
            if (user.UserAvatar.Proficiency is WarriorProficiency)
            {
                while (true)
                {
                    System.Console.WriteLine("Throw card and be stronger");
                    System.Console.WriteLine("Do you want throw card to gain strenght?\n 1.Yes\n2.No");
                    if (Int32.TryParse(readLineOverride.GetNextString(), out int result))
                    {
                        if (result == 1)
                        {
                            var card = user.UserAvatar.Proficiency.BeStronger(user);
                            if (card.DestroyedPrizeCards.Count > 0)
                            {
                                game.DestroyedPrizeCards.Add(card.DestroyedPrizeCards[0]);
                            }
                            else
                            {
                                game.DestroyedActionCards.Add(card.DestroyedActionCards[0]);
                            }
                            System.Console.WriteLine("Now you are stronger. Press enter to continue...");
                            readLineOverride.GetNextString();
                            break;
                        }
                        else if (result == 2)
                        {
                            System.Console.WriteLine("You didn't use skill. Press enter to continue...");
                            readLineOverride.GetNextString();
                        }
                        else
                        {
                            System.Console.WriteLine("Choose option 1 or 2. Press enter to continue...");
                            readLineOverride.GetNextString();
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("Choose option 1 or 2. Press enter to continue...");
                        readLineOverride.GetNextString();
                    }
                }
                System.Console.WriteLine("You are much Stronger. Press enter to continue...");
                readLineOverride.GetNextString();
            }
            else if (user.UserAvatar.Proficiency is MageProficiency)
            {
                while (true)
                {
                    System.Console.WriteLine("Choose which spell you want cast:\n1. Flee spell - move much faster\n2. Instant Kill monster\n3. Quit");
                    if (Int32.TryParse(readLineOverride.GetNextString(), out int choice))
                    {
                        if (choice == 1)
                        {
                            while (true)
                            {
                                System.Console.WriteLine("Throw card and be faster, it is easier to flee from monster");
                                System.Console.WriteLine("Do you want throw card to move faster?\n 1.Yes\n2.No");
                                if (Int32.TryParse(readLineOverride.GetNextString(), out int result))
                                {
                                    if (result == 1)
                                    {
                                        var card = user.UserAvatar.Proficiency.FleeSpell(user);
                                        if (card.DestroyedPrizeCards.Count > 0)
                                        {
                                            game.DestroyedPrizeCards.Add(card.DestroyedPrizeCards[0]);
                                        }
                                        else
                                        {
                                            game.DestroyedActionCards.Add(card.DestroyedActionCards[0]);
                                        }
                                        System.Console.WriteLine("Now you are faster. Press enter to continue...");
                                        readLineOverride.GetNextString();
                                        break;
                                    }
                                    else if (result == 2)
                                    {
                                        System.Console.WriteLine("You didn't use skill. Press enter to continue...");
                                        readLineOverride.GetNextString();
                                    }
                                    else
                                    {
                                        System.Console.WriteLine("Choose option 1 or 2. Press enter to continue...");
                                        readLineOverride.GetNextString();
                                    }
                                }
                                else
                                {
                                    System.Console.WriteLine("Choose option 1 or 2. Press enter to continue...");
                                    readLineOverride.GetNextString();
                                }
                            }
                            System.Console.WriteLine("You are much Faster. Press enter to continue...");
                            readLineOverride.GetNextString();
                        }
                        else if (choice == 2)
                        {
                            if (fight != null)
                            {
                                var result = user.UserAvatar.Proficiency.InstantKill(user);
                                if (result)
                                {
                                    if (fight.Monsters.Count == 0)
                                    {
                                        fight.Monsters[0].Power = -999;
                                    }
                                    else
                                    {
                                        while (true)
                                        {
                                            System.Console.WriteLine("Choose which monster will be killed?");
                                            int i = 1;
                                            foreach (var monster in fight.Monsters)
                                            {
                                                System.Console.WriteLine($"{i}. {monster.Name}, Power: {monster.Power}");
                                            }
                                            if (Int32.TryParse(readLineOverride.GetNextString(), out int whichOne))
                                            {
                                                if (whichOne <= fight.Monsters.Count)
                                                {
                                                    fight.Monsters[whichOne - 1].Power = -999;
                                                }
                                                else
                                                {
                                                    System.Console.WriteLine($"Choose monster from 1 to {fight.Monsters.Count}. Press enter to continue...");
                                                    readLineOverride.GetNextString();
                                                }
                                            }
                                            else
                                            {
                                                System.Console.WriteLine($"Choose monster from 1 to {fight.Monsters.Count}. Press enter to continue...");
                                                readLineOverride.GetNextString();
                                            }
                                        }

                                    }
                                    System.Console.WriteLine("Monster is dying. Press enter to continue");
                                    readLineOverride.GetNextString();
                                }
                                else
                                {
                                    System.Console.WriteLine("Spell didn't cast Press enter to continue...");
                                    readLineOverride.GetNextString();
                                }

                            }
                            else
                            {
                                System.Console.WriteLine("Use this spell when you will be fighting. Press enter to continue...");
                                readLineOverride.GetNextString();
                            }
                            return;

                        }
                        else if (choice == 3)
                        {
                            System.Console.WriteLine("You didn't cast a spell. Press enter to continue...");
                            readLineOverride.GetNextString();
                        }
                        else
                        {
                            System.Console.WriteLine("Choose option from 1 to 3. Press enter to continue...");
                            readLineOverride.GetNextString();
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("Choose first or second option. Press enter to continue...");
                        readLineOverride.GetNextString();
                    }
                }
            }
            else if (user.UserAvatar.Proficiency is PriestProficiency)
            {
                System.Console.WriteLine("Choose which spell you want cast:\n1. Flee spell - move much faster\n2. Instant Kill monster\n3. Quit");
                if (Int32.TryParse(readLineOverride.GetNextString(), out int choice))
                {
                    if (fight != null)
                    {

                    }
                    else
                    {
                        System.Console.WriteLine("Currently no one is fighting, use this skill when is a fight. Press enter to continue");
                        readLineOverride.GetNextString();
                    }
                }
            }
            else if (user.UserAvatar.Proficiency is ThiefProficiency)
            {
                while (true)
                {
                    System.Console.WriteLine("Choose which spell you want cast:\n1. Backstab another user\n2. Try to steal an item\n3. Quit");
                    if (Int32.TryParse(readLineOverride.GetNextString(), out int choice))
                    {
                        while (true)
                        {
                            if (choice == 1)
                            {
                                System.Console.WriteLine("Your opponents:");
                                int i = 1;
                                foreach (var hero in game.Users)
                                {
                                    if (!user.Equals(hero))
                                    {
                                        System.Console.WriteLine($"{i}. {hero.Name}, Power: {hero.UserAvatar.Power}");
                                    }
                                }
                                System.Console.WriteLine($"Choose one from you opponents, choose option from 1 to {game.Users.Count}");
                                if (Int32.TryParse(readLineOverride.GetNextString(), out int opponent))
                                {
                                    if (opponent <= game.Users.Count)
                                    {
                                        var victim = game.Users[opponent - 1];
                                        user.UserAvatar.Proficiency.BackStab(victim);
                                        System.Console.WriteLine($"You backstabbed {victim.Name}. Press enter to continue...");
                                        readLineOverride.GetNextString();
                                        break;
                                    }
                                    else
                                    {
                                        System.Console.WriteLine($"Choose one from you opponents, choose option from 1 to {game.Users.Count}");
                                        readLineOverride.GetNextString();
                                    }
                                }
                                else
                                {
                                    System.Console.WriteLine($"Choose one from you opponents, choose option from 1 to {game.Users.Count}");
                                    readLineOverride.GetNextString();
                                }
                            }
                            else if (choice == 2)
                            {
                                System.Console.WriteLine("Your opponents:");
                                int i = 1;
                                foreach (var hero in game.Users)
                                {
                                    if (!user.Equals(hero))
                                    {
                                        System.Console.WriteLine($"{i}. {hero.Name}, Power: {hero.UserAvatar.Power}");
                                    }
                                }
                                System.Console.WriteLine($"Choose one from you opponents, choose option from 1 to {game.Users.Count}");
                                if (Int32.TryParse(readLineOverride.GetNextString(), out int opponent))
                                {
                                    if (opponent <= game.Users.Count)
                                    {
                                        var victim = game.Users[opponent - 1];
                                        user.UserAvatar.Proficiency.StealCard(user, victim);
                                        System.Console.WriteLine($"You stole item from {victim.Name}. Press enter to continue...");
                                        readLineOverride.GetNextString();
                                        break;
                                    }
                                    else
                                    {
                                        System.Console.WriteLine($"Choose one from you opponents, choose option from 1 to {game.Users.Count}");
                                        readLineOverride.GetNextString();
                                    }
                                }
                                else
                                {
                                    System.Console.WriteLine($"Choose one from you opponents, choose option from 1 to {game.Users.Count}");
                                    readLineOverride.GetNextString();
                                }

                            }
                            else if (choice == 3)
                            {
                                System.Console.WriteLine("You didn't use skill. Press enter to continue...");
                                readLineOverride.GetNextString();
                            }
                            else
                            {
                                System.Console.WriteLine("Choose one option from 1 to 3. Press enter to continue...");
                                readLineOverride.GetNextString();
                            }
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("Choose one option from 1 to 3. Press enter to continue...");
                        readLineOverride.GetNextString();
                    }
                }
            }
            else
            {
                System.Console.WriteLine("You don't have special power. Press enter to continue...");
                readLineOverride.GetNextString();
            }
        }
#nullable enable

        public bool Flee(UserClass user)
        {
            var chance = user.UserAvatar.FleeChances + random.Next(6) + 1;
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
