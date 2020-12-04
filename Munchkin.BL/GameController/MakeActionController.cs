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
using Munchkin.Model.Card.ActionCard.SpecialCardType;
using Munchkin.BL.CharacterCreator;
using System.Linq;
using Munchkin.Model.Card.ActionCard;

namespace Munchkin.BL.GameController
{
    public class MakeActionController
    {
        public Game game;
        public GameAction gameAction;
        public ReadLineOverride readLineOverride;
        public FightController fightController;
        public PrizeStackController prizeStackController;
        public Random random;
        public DeckController deckController;
        private readonly DrawCardService _drawCardService;
        public SellItemController sellItemController;

        public MakeActionController(Game game, FightController fightController)
        {
            this.game = game;
            gameAction = new GameAction();
            this.fightController = fightController;
        }

        public MakeActionController(Game game, FightController fightController, PrizeStackController prizeStackController, ReadLineOverride readLineOverride)
        {
            this.game = game;
            gameAction = new GameAction();
            this.fightController = fightController;
            this.prizeStackController = prizeStackController;
            this.readLineOverride = readLineOverride;
        }

        public MakeActionController(Game game, FightController fightController, PrizeStackController prizeStackController, Random random)
        {
            this.game = game;
            gameAction = new GameAction();
            this.fightController = fightController;
            this.prizeStackController = prizeStackController;
            this.random = random;
        }

        public MakeActionController(Game game, FightController fightController, PrizeStackController prizeStackController, DrawCardService drawCardService)
        {
            this.game = game;
            gameAction = new GameAction();
            this.fightController = fightController;
            this.prizeStackController = prizeStackController;
            _drawCardService = drawCardService;
        }

        public MakeActionController(Game game, FightController fightController, PrizeStackController prizeStackController, Random random, DeckController deckController, ReadLineOverride readLineOverride, DrawCardService drawCardService)
        {
            this.game = game;
            gameAction = new GameAction();
            this.fightController = fightController;
            this.prizeStackController = prizeStackController;
            this.random = random;
            this.deckController = deckController;
            this.readLineOverride = readLineOverride;
            _drawCardService = drawCardService;
        }

        public MakeActionController(Game game, FightController fightController, PrizeStackController prizeStackController, Random random, DeckController deckController, ReadLineOverride readLineOverride, DrawCardService drawCardService, SellItemController sellItemController)
        {
            this.game = game;
            gameAction = new GameAction();
            this.fightController = fightController;
            this.prizeStackController = prizeStackController;
            this.random = random;
            this.deckController = deckController;
            this.readLineOverride = readLineOverride;
            _drawCardService = drawCardService;
            this.sellItemController = sellItemController;
        }

        public void FightWithYouMonster(UserClass user)
        {
            MonsterCardBase monster;
            while (true)
            {
                int i = 1;
                System.Console.WriteLine(deckController.LookOnMonstersCard(user, ref i));
                System.Console.WriteLine("Select monster to fight:");
                if (Int32.TryParse(readLineOverride.GetNextString(), out int result))
                {
                    if (result <= user.Deck.Monsters.Count)
                    {
                        monster = user.Deck.Monsters[result - 1];
                        user.Deck.Monsters.Remove(monster);
                        break;
                    }
                    else
                    {
                        System.Console.WriteLine($"Choose number from 1 to {user.Deck.Monsters.Count}");
                        readLineOverride.GetNextString();
                    }
                }
                else
                {
                    System.Console.WriteLine($"Choose number from 1 to {user.Deck.Monsters.Count}");
                    readLineOverride.GetNextString();
                }
            }
            var fight = new Fight();
            fight.Heros.Add(user);
            fight.Monsters.Add(monster);
            while (true)
            {
                System.Console.WriteLine("Would you like to make an action?\n" +
                            "You can ask for help, use special skill or card from your deck.\n" +
                            "Press 1 to make an action or press diffrent key to abort.");
                if (Int32.TryParse(readLineOverride.GetNextString(), out int act))
                {
                    if (act == 1)
                    {
                        ChooseFightAction(user, fight);
                    }
                    else
                    {
                        System.Console.WriteLine("You chose to do nothing. Press enter to fight with monster.");
                        readLineOverride.GetNextString();
                        break;
                    }
                }
                else
                {
                    System.Console.WriteLine("You chose to do nothing. Press enter to fight with monster.");
                    readLineOverride.GetNextString();
                }
            }
            if (fightController.WhoWinFight(fight))
            {
                System.Console.WriteLine("You won a figh get some prizes!!!. Press enter to continue...");
                readLineOverride.GetNextString();
                game.DestroyedActionCards.AddRange(fight.Monsters);
                GetPrizes(fight);
            }
            else
            {
                System.Console.WriteLine("You lost a fight, now wait for you dead end!!!. Press enter to continue...");
                readLineOverride.GetNextString();
                game.DestroyedActionCards.AddRange(fight.Monsters);
                DeadEnd(fight);
            }
        }

        public void OpenMisteryDoor(UserClass user)
        {
            CheckNumberOfActionCards();
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
                    System.Console.WriteLine(action.Description());
                    PlayerAction(user, fight);
                    EnemyChooseAction(user, fight);
                    PlayerAction(user, fight);
                    if (fightController.WhoWinFight(fight))
                    {
                        System.Console.WriteLine("You won a figh get some prizes!!!. Press enter to continue...");
                        readLineOverride.GetNextString();
                        game.DestroyedActionCards.AddRange(fight.Monsters);
                        game.ActionCards.Remove(action);
                        GetPrizes(fight);
                    }
                    else
                    {
                        System.Console.WriteLine("You lost a figh, now wait for you dead end!!!. Press enter to continue...");
                        readLineOverride.GetNextString();
                        game.DestroyedActionCards.AddRange(fight.Monsters);
                        game.ActionCards.Remove(action);
                        DeadEnd(fight);
                    }
                }
                else
                {
                    System.Console.WriteLine(action.Description());
                    if (action.MagicCardType is MagicCardType.Hero || action.MagicCardType is MagicCardType.Crook)
                    {
                        game.ActionCards.Remove(action);
                        game.DestroyedActionCards.Add(action);
                        action.CastSpecialSpell(user, null, game);
                    }
                    else
                    {
                        game.ActionCards.Remove(action);
                        game.DestroyedActionCards.Add(action);
                        user.Deck.MagicCards.Add(action);
                    }
                }

                if (!gameAction.IsFight)
                {
                    if (user.Deck.Monsters.Count > 0)
                    {
                        while (true)
                        {
                            System.Console.WriteLine("You have monster in you deck, if you don't choose fight with, you have to open next door.\n" +
                            "Do you want fight with monster from your deck?\n1.Yes\n2.No");
                            if (Int32.TryParse(readLineOverride.GetNextString(), out int result))
                            {
                                if (result == 1)
                                {
                                    System.Console.WriteLine("You chose to fight with monster. Press enter to continue...");
                                    readLineOverride.GetNextString();
                                    FightWithYouMonster(user);
                                    break;
                                }
                                else if (result == 2)
                                {
                                    System.Console.WriteLine("You chose don't fight, lets open next door. Press enter to continue...");
                                    readLineOverride.GetNextString();
                                    break;
                                }
                                else
                                {
                                    System.Console.WriteLine("Choose one option 1 or 2. Press enter to continue...");
                                    readLineOverride.GetNextString();
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
                        OpenMisteryDoor(user);
                    }
                }
            }
            else
            {
                var action = game.ActionCards[0];
                if (action.CardType is CardType.Monster)
                {
                    game.ActionCards.Remove(action);
                    user.Deck.Monsters.Add((MonsterCardBase)action);
                }
                else
                {
                    game.ActionCards.Remove(action);
                    user.Deck.MagicCards.Add(action);
                }
            }
        }

        public void PlayerAction(UserClass user, Fight fight)
        {
            while (true)
            {
                System.Console.WriteLine("Would you like to make an action?\n" +
                "You can ask for help, use special skill or use card from your deck.\n" +
                "Press 1 to make an action or press 0 to abort.");
                if (Int32.TryParse(readLineOverride.GetNextString(), out int act))
                {
                    if (act == 1)
                    {
                        ChooseFightAction(user, fight);
                    }
                    else if (act == 0)
                    {
                        System.Console.WriteLine("It' time let's fight. Press enter to fight with monster.");
                        readLineOverride.GetNextString();
                        break;
                    }
                    else
                    {
                        System.Console.WriteLine("Choose option form list. Press enter to continue");
                        readLineOverride.GetNextString();
                    }
                }
                else
                {
                    System.Console.WriteLine("Choose option form list. Press enter to continue.");
                    readLineOverride.GetNextString();
                }
            }
        }

        public void EnemyChooseAction(UserClass user, Fight fight)
        {
            foreach (var enemy in game.Users)
            {
                if (!user.Equals(enemy))
                {
                    while (true)
                    {
                        System.Console.WriteLine("Do you want to make an Action.\n" +
                            "1. Yes.\n" +
                            "2. Skip.");
                        if (Int32.TryParse(readLineOverride.GetNextString(), out int result))
                        {
                            if (result == 1)
                            {
                                ChooseNoFightAction(enemy, fight);
                            }
                            else if (result == 0)
                            {
                                System.Console.WriteLine("You chose to pass. Press any key to continue.");
                                readLineOverride.GetNextString();
                                break;
                            }
                            else
                            {
                                System.Console.WriteLine("Bro input 1 or 0. Press any key to continue.");
                                readLineOverride.GetNextString();
                            }
                        }
                        else
                        {
                            System.Console.WriteLine("Something gone wrong Pleas try again. Press any key to continue.");
                            readLineOverride.GetNextString();
                        }
                    }
                }
            }
        }

        public void CheckNumberOfActionCards()
        {
            if (game.ActionCards.Count == 0)
            {
                game.ActionCards.AddRange(game.DestroyedActionCards);
                game.DestroyedActionCards.RemoveRange(0, game.DestroyedActionCards.Count);
                _drawCardService.Shuffle(game.ActionCards);
            }
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

#nullable enable
        public void UseSpecialPower(UserClass user, Fight? fight)
        {
            if (user.UserAvatar.Proficiency is WarriorProficiency)
            {
                while (true)
                {
                    if (fight == null)
                    {
                        System.Console.WriteLine("There is no fight use this skill during fight. Press enter to continue...");
                        readLineOverride.GetNextString();
                        break;
                    }
                    else
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
                                    System.Console.WriteLine("Now you are stronger. Press enter to continue...");
                                    readLineOverride.GetNextString();
                                }
                                else
                                {
                                    System.Console.WriteLine("You don't have cards. Press enter to continue...");
                                    readLineOverride.GetNextString();
                                }
                                break;
                            }
                            else if (result == 2)
                            {
                                System.Console.WriteLine("You didn't use skill. Press enter to continue...");
                                readLineOverride.GetNextString();
                                break;
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
            }
            else if (user.UserAvatar.Proficiency is MageProficiency)
            {
                while (true)
                {
                    if (fight == null)
                    {
                        System.Console.WriteLine("There is no fight use this skill during fight. Press enter to continue...");
                        readLineOverride.GetNextString();
                        break;
                    }
                    else
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
                                                System.Console.WriteLine("Now you are faster. Press enter to continue...");
                                                readLineOverride.GetNextString();
                                                return;
                                            }
                                            else
                                            {
                                                System.Console.WriteLine("You don't have cards. Press enter to continue...");
                                                readLineOverride.GetNextString();
                                                return;
                                            }
                                        }
                                        else if (result == 2)
                                        {
                                            System.Console.WriteLine("You didn't use skill. Press enter to continue...");
                                            readLineOverride.GetNextString();
                                            return;
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
                            }
                            else if (choice == 2)
                            {
                                if (fight != null)
                                {
                                    var result = user.UserAvatar.Proficiency.InstantKill(user);
                                    if (result.DestroyedActionCards.Count + result.DestroyedPrizeCards.Count > 3)
                                    {
                                        if (result.DestroyedActionCards.Count > 0)
                                        {
                                            game.DestroyedActionCards.AddRange(result.DestroyedActionCards);
                                        }
                                        if (result.DestroyedPrizeCards.Count > 0)
                                        {
                                            game.DestroyedPrizeCards.AddRange(result.DestroyedPrizeCards);
                                        }
                                        if (fight.Monsters.Count == 1)
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
                                                        break;
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
            }
            else if (user.UserAvatar.Proficiency is PriestProficiency)
            {
                while (true)
                {
                    System.Console.WriteLine("Choose which spell you want cast:\n1. Make monster your pet- monster is going to your Deck\n" +
                        "2.Restore card - drop one card and get one from destroyed\n3. Quit");
                    if (Int32.TryParse(readLineOverride.GetNextString(), out int choice))
                    {
                        if (choice == 1)
                        {
                            if (fight != null)
                            {
                                var result = user.UserAvatar.Proficiency.MakeMonsterAPet(user, fight);
                                if (result.DestroyedActionCards.Count > 0)
                                {
                                    game.DestroyedActionCards.AddRange(result.DestroyedActionCards);
                                }
                                if (result.DestroyedPrizeCards.Count > 0)
                                {
                                    game.DestroyedPrizeCards.AddRange(result.DestroyedPrizeCards);

                                }
                                if (result.DestroyedActionCards.Count + result.DestroyedPrizeCards.Count >= 3)
                                {
                                    System.Console.WriteLine("You made monster a pet use it carefully. Press enter to continue");
                                    readLineOverride.GetNextString();
                                    break;
                                }
                                else
                                {
                                    System.Console.WriteLine("You didn't make monster a pet. Press enter to continue");
                                    readLineOverride.GetNextString();
                                    break;
                                }
                            }
                            else
                            {
                                System.Console.WriteLine("Currently no one is fighting, use this skill when is a fight. Press enter to continue");
                                readLineOverride.GetNextString();
                                break;
                            }
                        }
                        else if (choice == 2)
                        {
                            var result = user.UserAvatar.Proficiency.RestorePrizeCard(user, game);
                            if (result.DestroyedActionCards.Count > 0 || result.DestroyedPrizeCards.Count > 0)
                            {
                                if (result.DestroyedActionCards.Count > 0)
                                {
                                    game.DestroyedActionCards.AddRange(result.DestroyedActionCards);
                                }
                                if (result.DestroyedPrizeCards.Count > 0)
                                {
                                    game.DestroyedPrizeCards.AddRange(result.DestroyedPrizeCards);
                                }

                                System.Console.WriteLine("You restored a card. Press enter to continue");
                                readLineOverride.GetNextString();
                            }
                            else
                            {
                                System.Console.WriteLine("You didn't restore a card. Press enter to continue");
                                readLineOverride.GetNextString();
                            }
                            break;
                        }
                        else if (choice == 3)
                        {
                            System.Console.WriteLine("You didn't use a skill. Press enter to continue");
                            readLineOverride.GetNextString();
                            return;
                        }
                        else
                        {
                            System.Console.WriteLine("Choose option from 1 to 3. Press enter to continue");
                            readLineOverride.GetNextString();
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("Choose option from 1 to 3. Press enter to continue");
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
                                List<UserClass> users = new List<UserClass>();
                                System.Console.WriteLine("Your opponents:");
                                int i = 1;
                                foreach (var hero in game.Users)
                                {
                                    if (!user.Equals(hero))
                                    {
                                        users.Add(hero);
                                        System.Console.WriteLine($"{i}. {hero.Name}, Power: {hero.UserAvatar.Power}");
                                        i++;
                                    }
                                }
                                System.Console.WriteLine($"Choose one from you opponents, choose option from 1 to {game.Users.Count}");
                                if (Int32.TryParse(readLineOverride.GetNextString(), out int opponent))
                                {
                                    if (opponent <= game.Users.Count)
                                    {
                                        var victim = users[opponent - 1];
                                        user.UserAvatar.Proficiency.BackStab(victim);
                                        System.Console.WriteLine($"You backstabbed {victim.Name}. Press enter to continue...");
                                        readLineOverride.GetNextString();
                                        return;
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
                                List<UserClass> users = new List<UserClass>();
                                System.Console.WriteLine("Your opponents:");
                                int i = 1;
                                foreach (var hero in game.Users)
                                {
                                    if (!user.Equals(hero))
                                    {
                                        users.Add(hero);
                                        System.Console.WriteLine($"{i}. {hero.Name}, Power: {hero.UserAvatar.Power}");
                                        i++;
                                    }
                                }
                                System.Console.WriteLine($"Choose one from you opponents, choose option from 1 to {game.Users.Count}");
                                if (Int32.TryParse(readLineOverride.GetNextString(), out int opponent))
                                {
                                    if (opponent <= game.Users.Count)
                                    {
                                        var victim = users[opponent - 1];
                                        user.UserAvatar.Proficiency.StealCard(user, victim);
                                        System.Console.WriteLine($"You stole item from {victim.Name}. Press enter to continue...");
                                        readLineOverride.GetNextString();
                                        return;
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
                                return;
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

        public bool Flee(UserClass user)
        {
            var chance = user.UserAvatar.FleeChances + random.Next(6) + 1;
            if (chance >= 6)
            {
                return true;
            }
            return false;
        }

        public void UseSituationalCard(UserClass user, Fight? fight)
        {
            if (fight == null)
            {
                System.Console.WriteLine("Use this items when you or someone fighting. Press enter to continue...");
                readLineOverride.GetNextString();
                return;
            }
            int i = 1;
            var items = deckController.LookOnSituationalCard(user, ref i);
            while (true)
            {
                if (string.IsNullOrEmpty(items))
                {
                    System.Console.WriteLine("You don't have situational items. Press enter to continue...");
                    readLineOverride.GetNextString();
                    return;
                }
                else
                {
                    System.Console.WriteLine(items);
                }
                System.Console.WriteLine("Choose option from list, or press 0 to abort");
                if (Int32.TryParse(readLineOverride.GetNextString(), out int result))
                {
                    if (result == 0)
                    {
                        System.Console.WriteLine("You decided to not use item. Press enter to continue...");
                        readLineOverride.GetNextString();
                        return;
                    }
                    else if (result <= i)
                    {
                        var sit = user.Deck.Items.Where(x => x.ItemType == ItemType.Sitiuational).ToList();
                        var item = sit[result - 1];
                        user.Deck.Items.Remove(item);
                        game.DestroyedPrizeCards.Add(item);
                        item.SpecialEffect(fight);
                        return;
                    }
                    else
                    {
                        System.Console.WriteLine("Broo choose option from list. Press enter to continue...");
                        readLineOverride.GetNextString();
                    }
                }
                else
                {
                    System.Console.WriteLine("Broo choose option from list. Press enter to continue...");
                    readLineOverride.GetNextString();
                }
            }

        }

        public void UseMonsterCard(UserClass user, Fight? fight)
        {
            if (fight == null)
            {
                System.Console.WriteLine("Bro add monster to fight, Currently noone is fighting. Press enter to continue...");
                readLineOverride.GetNextString();
                return;
            }
            if (user.Deck.Monsters.Count == 0)
            {
                System.Console.WriteLine("Bro you don't have monsters. Press enter to continue...");
                readLineOverride.GetNextString();
                return;
            }
            var card = user.Deck.MagicCards.FirstOrDefault(x => x.Name.Equals("AdditionalMonster"));
            if (card == null)
            {
                var monsters = user.Deck.Monsters.Where(x => x.Undead.Equals(true)).ToList();
                if (monsters.Count == 0)
                {
                    System.Console.WriteLine("You don't have undead monster in deck and AdditionalMonster magic card. " +
                        "You can't add monster to fight. Press enter to continue...");
                    readLineOverride.GetNextString();
                }
                else
                {
                    while (true)
                    {
                        System.Console.WriteLine("You can add undead monsters to fight:");
                        int i = 0;
                        foreach (var mon in monsters)
                        {
                            i++;
                            System.Console.WriteLine($"{i}. {mon.Name}, {mon.Power}");
                            System.Console.WriteLine("______________________________________________________________________________");
                        }
                        System.Console.WriteLine("Choose option from above list or press 0 to don't do anything");
                        if (Int32.TryParse(readLineOverride.GetNextString(), out int result))
                        {
                            if (result <= i)
                            {
                                var monster = monsters[result - 1];
                                fight.Monsters.Add(monster);
                                user.Deck.Monsters.Remove(monster);
                                return;
                            }
                            else if (result == 0)
                            {
                                System.Console.WriteLine("You decide to not add monster to fight. Press enter to continue...");
                                readLineOverride.GetNextString();
                            }
                            else
                            {
                                System.Console.WriteLine("Choose option from above list or press 0 to don't do anything");
                                readLineOverride.GetNextString();
                            }
                        }
                        else
                        {
                            System.Console.WriteLine("Choose option from above list or press 0 to don't do anything");
                            readLineOverride.GetNextString();
                        }
                    }
                }
            }
            else
            {
                while (true)
                {
                    System.Console.WriteLine("You can add monsters to fight:");
                    int i = 0;
                    foreach (var mon in user.Deck.Monsters)
                    {
                        i++;
                        System.Console.WriteLine($"{i}. {mon.Name}, {mon.Power}");
                        System.Console.WriteLine("______________________________________________________________________________");
                    }
                    System.Console.WriteLine("Choose option from above list or press 0 to don't do anything");
                    if (Int32.TryParse(readLineOverride.GetNextString(), out int result))
                    {
                        if (result <= i)
                        {
                            var monster = user.Deck.Monsters[result - 1];
                            fight.Monsters.Add(monster);
                            user.Deck.Monsters.Remove(monster);
                            foreach (var addMon in user.Deck.MagicCards)
                            {
                                if (addMon.Name.Equals("AdditionalMonster"))
                                {
                                    user.Deck.MagicCards.Remove(addMon);
                                    game.DestroyedActionCards.Add(addMon);
                                    break;
                                }
                            }
                            return;
                        }
                        else if (result == 0)
                        {
                            System.Console.WriteLine("You decide to not add monster to fight. Press enter to continue...");
                            readLineOverride.GetNextString();
                        }
                        else
                        {
                            System.Console.WriteLine("Choose option from above list or press 0 to don't do anything");
                            readLineOverride.GetNextString();
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("Choose option from above list or press 0 to don't do anything");
                        readLineOverride.GetNextString();
                    }
                }
            }
        }

        public void UseMagicCard(UserClass user)
        {
            if (user.Deck.MagicCards.Count == 0)
            {
                System.Console.WriteLine("Broo you don't have magic card. Press enter to continue...");
                readLineOverride.GetNextString();
                return;
            }
            else
            {
                while (true)
                {
                    int i = 0;
                    foreach (var magic in user.Deck.MagicCards)
                    {
                        i++;
                        System.Console.WriteLine($"{i}. {magic.Name}");
                        magic.Description();
                        System.Console.WriteLine("______________________________________________________________________________");
                    }
                    System.Console.WriteLine($"Choose card from 1 to {i}, or press 0 to abort.");
                    if (Int32.TryParse(readLineOverride.GetNextString(), out int result))
                    {
                        if (result <= user.Deck.MagicCards.Count && result > 0)
                        {
                            var card = user.Deck.MagicCards[result - 1];
                            user.Deck.MagicCards.Remove(card);
                            game.DestroyedActionCards.Add(card);
                            UseMagicCardOnUser(card, user);
                            readLineOverride.GetNextString();
                            return;
                        }
                        else if (result == 0)
                        {
                            System.Console.WriteLine($"You didn't use magic card. Press enter to continue");
                            readLineOverride.GetNextString();
                            return;
                        }
                        else
                        {
                            System.Console.WriteLine($"Broo it's easy!!! Choose card from 1 to {i}, " +
                                $"or press 0 to abort. Press enter to continue");
                            readLineOverride.GetNextString();
                        }
                    }
                    else
                    {
                        System.Console.WriteLine($"Something gone wrong. Please try again. " +
                            $"Choose card from 1 to {i}, or press 0 to abort. Press enter to continue");
                        readLineOverride.GetNextString();
                    }
                }
            }
        }

        public void UseMagicCardOnUser(ActionCardBase card, UserClass user)
        {
            while (true)
            {
                int i = 0;
                foreach (var hero in game.Users)
                {
                    if (user.Equals(hero))
                    {
                        i++;
                        System.Console.WriteLine($"{i}.It's your Hero Broo!!! Name: {hero.Name}, Power: {hero.UserAvatar.Power}, Level: {hero.UserAvatar.Level}");
                    }
                    else
                    {
                        i++;
                        System.Console.WriteLine($"{i}.Enemy! Name: {hero.Name}, Power: {hero.UserAvatar.Power}, Level: {hero.UserAvatar.Level}");
                    }

                }
                System.Console.WriteLine("Choose her on which you would like to use magic card, or choose 0 to abort.");
                if (Int32.TryParse(readLineOverride.GetNextString(), out int result))
                {
                    if (result <= i && result > 0)
                    {
                        card.CastSpecialSpell(game.Users[result - 1], null, game);
                        System.Console.WriteLine($"You used magic card on {user.Name }. Press enter to continue");
                        readLineOverride.GetNextString();
                        return;
                    }
                    else if (result == 0)
                    {
                        System.Console.WriteLine($"You didn't use magic card. Press enter to continue");
                        readLineOverride.GetNextString();
                        return;
                    }
                    else
                    {
                        System.Console.WriteLine("Bro something gone wrong...\n" +
                            "Choose her on which you would like to use magic card, or choose 0 to abort.\n" +
                            "Press enter to continue");
                        readLineOverride.GetNextString();
                    }
                }
                else
                {
                    System.Console.WriteLine("Bro something gone wrong...\n" +
                            "Choose her on which you would like to use magic card, or choose 0 to abort.\n" +
                            "Press enter to continue");
                    readLineOverride.GetNextString();
                }
            }
        }

        public void AskForHelp(UserClass user, Fight fight)
        {
            foreach (var hero in game.Users)
            {
                if (!(hero.Equals(user)))
                {
                    while (true)
                    {
                        System.Console.WriteLine($"{hero.Name} Do you want to join to fight?\n1.Yes\n2.No");
                        if (Int32.TryParse(readLineOverride.GetNextString(), out int result))
                        {
                            if (result == 1)
                            {
                                System.Console.WriteLine("You have choosen to join!!! Press enter to continue...");
                                JoinToFight(hero, fight);
                                readLineOverride.GetNextString();
                                break;
                            }
                            else if (result == 2)
                            {
                                System.Console.WriteLine("You have choosen to not join to fight. Press enter to continue...");
                                readLineOverride.GetNextString();
                                break;
                            }
                            else
                            {
                                System.Console.WriteLine("Choose option from list. Press enter to continue...");
                                readLineOverride.GetNextString();
                            }
                        }
                        else
                        {
                            System.Console.WriteLine("Choose option from list. Press enter to continue...");
                            readLineOverride.GetNextString();
                        }
                    }
                }
            }
        }

#nullable disable

        public void JoinToFight(UserClass user, Fight fight)
        {
            if (fight == null)
            {
                System.Console.WriteLine($"There is no fight brooo. Press enter to continue...");
                readLineOverride.GetNextString();
            }
            fight.Heros.Add(user);
            System.Console.WriteLine($"Hero {user.Name} joined to fight. Press enter to continue...");
            readLineOverride.GetNextString();
        }

        public void SellItem(UserClass user)
        {
            if (sellItemController.SellItem(user))
            {
                sellItemController.CheckMoneyAndAddLevel(user);
            }
        }

        public void ChooseFightAction(UserClass user, Fight fight)
        {
            while (true)
            {
                System.Console.WriteLine("Choose an action:\n" +
                    "1. Ask for Help\n" +
                    "2. Use Situational Card\n" +
                    "3. Use Skill\n" +
                    "4. Use Monster Card\n" +
                    "0. Don't make an Action.");
                if (Int32.TryParse(readLineOverride.GetNextString(), out int result))
                {
                    if (result < 0 || result > 4)
                    {
                        System.Console.WriteLine("Choose action from list brooo. Press enter to continue.");
                        readLineOverride.GetNextString();
                    }
                    switch (result)
                    {
                        case 0:
                            System.Console.WriteLine("You chose to don't make an action. Press enter to continue.");
                            readLineOverride.GetNextString();
                            return;
                        case 1:
                            AskForHelp(user, fight);
                            return;
                        case 2:
                            UseSituationalCard(user, fight);
                            return;
                        case 3:
                            UseSpecialPower(user, fight);
                            return;
                        case 4:
                            UseMonsterCard(user, fight);
                            return;
                    }
                }
                else
                {
                    System.Console.WriteLine("Something gone wrong pls try again choose option from list. Press enter to continue.");
                    readLineOverride.GetNextString();
                }
            }
        }

        public void ChooseNoFightAction(UserClass user, Fight fight)
        {
            while (true)
            {
                System.Console.WriteLine("Choose an action:\n" +
                    "1. Use Magic Card\n" +
                    "2. Use Situational Card\n" +
                    "3. Use Skill\n" +
                    "4. Use Monster Card\n" +
                    "0. Don't make an Action.");
                if (Int32.TryParse(readLineOverride.GetNextString(), out int result))
                {
                    if (result < 0 || result > 4)
                    {
                        System.Console.WriteLine("Choose action from list brooo. Press enter to continue.");
                        readLineOverride.GetNextString();
                    }
                    switch (result)
                    {
                        case 0:
                            System.Console.WriteLine("You chose to don't make an action. Press enter to continue.");
                            readLineOverride.GetNextString();
                            return;
                        case 1:
                            UseMagicCard(user);
                            return;
                        case 2:
                            UseSituationalCard(user, fight);
                            return;
                        case 3:
                            UseSpecialPower(user, fight);
                            return;
                        case 4:
                            UseMonsterCard(user, fight);
                            return;
                    }
                }
                else
                {
                    System.Console.WriteLine("Something gone wrong pls try again choose option from list. Press enter to continue.");
                    readLineOverride.GetNextString();
                }
            }
        }
    }
}
