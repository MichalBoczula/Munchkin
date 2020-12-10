using FluentAssertions;
using Munchkin.BL.CardGenerator;
using Munchkin.BL.CharacterCreator;
using Munchkin.BL.GameController;
using Munchkin.BL.Helper;
using Munchkin.Model;
using Munchkin.Model.Card.ActionCard.SpecialCardType.MagicCards;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret;
using Munchkin.Model.Card.PrizeCard;
using Munchkin.Model.Card.PrizeCard.SituationalItems;
using Munchkin.Model.Character;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace Munchkin.Tests.Munchkin.BL.Tests.GameController
{
    public class FileIOControllerTests
    {
        [Fact]
        public void SaveGameToFile()
        {
            //Arrange
            var readLine = new ReadLineOverride();
            var random = new Random();
            var game = new Game();
            var fightController = new FightController();
            var drawCardService = new DrawCardService(random);
            var stackCardGeneratorService = new StackCardGeneratorService();
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGeneratorService);
            var deckController = new DeckController(readLine);
            var sellItemController = new SellItemController(deckController, readLine);
            var makeActionController = new MakeActionController(game,
                                                                fightController,
                                                                prizeStackController,
                                                                random,
                                                                deckController,
                                                                readLine,
                                                                drawCardService,
                                                                sellItemController);
            var filePath = @"A:\Programowanie\C#\Kurs\Apps\Munchkin\Saves\Tests.txt";
            FileIOController fileIOController = new FileIOController(filePath);
            var userAvatar = new UserAvatar
            {
                Level = 2
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar,
                Name = "user"
            };
            var enemyAvater = new UserAvatar
            {
                Level = 1
            };
            var enemy = new UserClass()
            {
                UserAvatar = enemyAvater,
                Name = "enemy"
            };
            var secondEnemy = new UserAvatar
            {
                Level = 1
            };
            var second = new UserClass()
            {
                UserAvatar = secondEnemy,
                Name = "second"
            };
            var antArmy = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 3,
                HowManyLevels = 1,
                NumberOfPrizes = 2
            };
            var fireBall = new FireBall("FireBall", CardType.Special, PrizeCardType.Sitiuational, 0, null, false, ItemType.Sitiuational, null, 400);
            var curse = new BackToSchool("BackToSchool", CardType.Curse);
            GodIsAngry secondCurse = new GodIsAngry("GodIsAngry", CardType.Curse);
            user.UserAvatar.CountPower();
            game.ActionCards.Add(antArmy);
            user.Deck.Items.Add(fireBall);
            enemy.Deck.MagicCards.Add(curse);
            second.Deck.MagicCards.Add(secondCurse);
            game.Users.Add(user);
            game.Users.Add(enemy);
            game.Users.Add(second);
            game.ActionCards.Add(antArmy);
            //Act
            fileIOController.SaveGame(game);
            //Assert

        }

        [Fact]
        public void ReadGamesFromFile()
        {
            //Arrange
            var readLine = new ReadLineOverride();
            var random = new Random();
            var game = new Game();
            var fightController = new FightController();
            var drawCardService = new DrawCardService(random);
            var stackCardGeneratorService = new StackCardGeneratorService();
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGeneratorService);
            var deckController = new DeckController(readLine);
            var sellItemController = new SellItemController(deckController, readLine);
            var makeActionController = new MakeActionController(game,
                                                                fightController,
                                                                prizeStackController,
                                                                random,
                                                                deckController,
                                                                readLine,
                                                                drawCardService,
                                                                sellItemController);
            var filePath = @"A:\Programowanie\C#\Kurs\Apps\Munchkin\Saves\Tests.txt";
            FileIOController fileIOController = new FileIOController(filePath);
            var userAvatar = new UserAvatar
            {
                Level = 2
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar,
                Name = "user"
            };
            var enemyAvater = new UserAvatar
            {
                Level = 1
            };
            var enemy = new UserClass()
            {
                UserAvatar = enemyAvater,
                Name = "enemy"
            };
            var secondEnemy = new UserAvatar
            {
                Level = 1
            };
            var second = new UserClass()
            {
                UserAvatar = secondEnemy,
                Name = "second"
            };
            var antArmy = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 3,
                HowManyLevels = 1,
                NumberOfPrizes = 2
            };
            var fireBall = new FireBall("FireBall", CardType.Special, PrizeCardType.Sitiuational, 0, null, false, ItemType.Sitiuational, null, 400);
            var curse = new BackToSchool("BackToSchool", CardType.Curse);
            GodIsAngry secondCurse = new GodIsAngry("GodIsAngry", CardType.Curse);
            user.UserAvatar.CountPower();
            game.ActionCards.Add(antArmy);
            user.Deck.Items.Add(fireBall);
            enemy.Deck.MagicCards.Add(curse);
            second.Deck.MagicCards.Add(secondCurse);
            game.Users.Add(user);
            game.Users.Add(enemy);
            game.Users.Add(second);
            game.ActionCards.Add(antArmy);
            //Act
            var readedGame = fileIOController.ReadSavedGame();
            //Assert
            game.Should().BeSameAs(readedGame);
        }
    }
}
