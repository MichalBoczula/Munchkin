using FluentAssertions;
using Moq;
using Munchkin.BL.CardGenerator;
using Munchkin.BL.CharacterCreator;
using Munchkin.BL.GameController;
using Munchkin.BL.Helper;
using Munchkin.Model;
using Munchkin.Model.Card.ActionCard.SpecialCardType.MagicCards;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret;
using Munchkin.Model.Card.PrizeCard;
using Munchkin.Model.Character;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Munchkin.Tests.Munchkin.BL.Tests.GameController
{
    public class MakeActionControllerOpenMisteryDoorTests
    {

        [Fact]
        public void OpenMisteryDoorMonsters()
        {
            //Arrange
            var random = new Random();
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("0");
            var game = new Game();
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var fightController = new FightController();
            var drawCardService = new DrawCardService(random);
            var stackCardGeneratorService = new StackCardGeneratorService();
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGeneratorService);
            var makeActionController = new MakeActionController(game, fightController, prizeStackController, mock.Object);
            var antArmy = new AntArmy("Ant Army", CardType.Monster);
            var antArmy2 = new AntArmy("Ant Army", CardType.Monster);
            game.ActionCards.Add(antArmy);
            game.ActionCards.Add(antArmy2);
            //Act
            makeActionController.OpenMisteryDoor(user);
            //Assert
            userAvatar.Nerfs.FleeChances.Should().HaveCount(1);
            game.DestroyedActionCards.Should().HaveCount(1);
            game.DestroyedActionCards[0].Should().BeSameAs(antArmy);
            game.ActionCards.Should().HaveCount(1);
            game.ActionCards[0].Should().BeSameAs(antArmy2);
        }

        [Fact]
        public void OpenMisteryDoorLoseFight()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("0");
            var random = new Random();
            var game = new Game();
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var fightController = new FightController();
            var drawCardService = new DrawCardService(random);
            var stackCardGeneratorService = new StackCardGeneratorService();
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGeneratorService);
            var makeActionController = new MakeActionController(game, fightController, prizeStackController, mock.Object);
            var antArmy = new AntArmy("Ant Army", CardType.Monster);
            game.ActionCards.Add(antArmy);
            //Act
            makeActionController.OpenMisteryDoor(user);
            //Assert
            userAvatar.Nerfs.FleeChances.Should().HaveCount(1);
            game.DestroyedActionCards.Should().HaveCount(1);
            game.DestroyedActionCards[0].Should().BeSameAs(antArmy);
        }

        [Fact]
        public void OpenMisteryDoorWinFight()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("0");
            var random = new Random();
            var game = new Game();
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var fightController = new FightController();
            var drawCardService = new DrawCardService(random);
            var stackCardGeneratorService = new StackCardGeneratorService();
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGeneratorService);
            var makeActionController = new MakeActionController(game, fightController, prizeStackController, mock.Object);
            var antArmy = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 0,
                NumberOfPrizes = 2
            };
            var grall = new ItemCard("Graal", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var egida = new ItemCard("Egida", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 500);
            game.ActionCards.Add(antArmy);
            prizeStackController.PrizeStack.Deck.Clear();
            prizeStackController.PrizeStack.Deck.Add(grall);
            prizeStackController.PrizeStack.Deck.Add(egida);
            //Act
            makeActionController.OpenMisteryDoor(user);
            //Assert
            user.Deck.Items.Should().HaveCount(2);
            game.DestroyedActionCards.Should().HaveCount(1);
            game.DestroyedActionCards[0].Should().BeSameAs(antArmy);
            prizeStackController.PrizeStack.Deck.Count.Should().Be(0);
        }

        [Fact]
        public void OpenMisteryDoorWinFightNotEnoughPrizes()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("0");
            var random = new Random();
            var game = new Game();
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var fightController = new FightController();
            var drawCardService = new DrawCardService(random);
            var stackCardGeneratorService = new StackCardGeneratorService();
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGeneratorService, game);
            var makeActionController = new MakeActionController(game, fightController, prizeStackController, mock.Object);
            var antArmy = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 0,
                NumberOfPrizes = 2
            };
            var grall = new ItemCard("Graal", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var egida = new ItemCard("Egida", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 500);
            game.ActionCards.Add(antArmy);
            prizeStackController.PrizeStack.Deck.Clear();
            prizeStackController.PrizeStack.Deck.Add(grall);
            game.DestroyedPrizeCards.Add(egida);
            //Act
            makeActionController.OpenMisteryDoor(user);
            //Assert
            user.Deck.Items.Should().HaveCount(2);
            game.DestroyedActionCards.Should().HaveCount(1);
            game.DestroyedActionCards[0].Should().BeSameAs(antArmy);
            prizeStackController.PrizeStack.Deck.Count.Should().Be(0);
        }

        [Fact]
        public void OpenMisteryDoorTwoCurse()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("0");
            var random = new Random();
            var game = new Game();
            var userAvatar = new UserAvatar
            {
                Level = 1
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var fightController = new FightController();
            var drawCardService = new DrawCardService(random);
            var stackCardGeneratorService = new StackCardGeneratorService();
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGeneratorService);
            var makeActionController = new MakeActionController(game, fightController, prizeStackController, mock.Object);
            var curse = new BackToSchool("BackToSchool", CardType.Curse);
            var curse2 = new BackToSchool("BackToSchool", CardType.Curse);
            game.ActionCards.Add(curse);
            game.ActionCards.Add(curse2);
            //Act
            makeActionController.OpenMisteryDoor(user);
            //Assert
            userAvatar.Level.Should().Be(0);
            game.DestroyedActionCards.Should().HaveCount(1);
            user.Deck.MagicCards.Count.Should().Be(1);
            user.Deck.MagicCards[0].Should().BeSameAs(curse2);
        }

        [Fact]
        public void OpenMisteryDoorFirstMonsterThanCurse()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("0");
            var random = new Random();
            var game = new Game();
            var userAvatar = new UserAvatar
            {
                Level = 1
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var fightController = new FightController();
            var drawCardService = new DrawCardService(random);
            var stackCardGeneratorService = new StackCardGeneratorService();
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGeneratorService);
            var makeActionController = new MakeActionController(game, fightController, prizeStackController, mock.Object);
            var curse = new BackToSchool("BackToSchool", CardType.Curse);
            var antArmy = new AntArmy("Ant Army", CardType.Monster);
            game.ActionCards.Add(antArmy);
            game.ActionCards.Add(curse);
            //Act
            makeActionController.OpenMisteryDoor(user);
            //Assert
            userAvatar.Nerfs.FleeChances.Should().HaveCount(1);
            game.DestroyedActionCards.Should().HaveCount(1);
            game.ActionCards.Should().HaveCount(1);
            game.ActionCards[0].Should().Be(curse);
        }

        [Fact]
        public void OpenMisteryDoorFirstCurseThanMonster()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("0");
            var random = new Random();
            var game = new Game();
            var userAvatar = new UserAvatar
            {
                Level = 1
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var fightController = new FightController();
            var drawCardService = new DrawCardService(random);
            var stackCardGeneratorService = new StackCardGeneratorService();
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGeneratorService);
            var makeActionController = new MakeActionController(game, fightController, prizeStackController, mock.Object);
            var curse = new BackToSchool("BackToSchool", CardType.Curse);
            var antArmy = new AntArmy("Ant Army", CardType.Monster);
            game.ActionCards.Add(curse);
            game.ActionCards.Add(antArmy);
            //Act
            makeActionController.OpenMisteryDoor(user);
            //Assert
            userAvatar.Level.Should().Be(0);
            user.Deck.Monsters.Should().HaveCount(1);
            user.Deck.Monsters[0].Should().BeSameAs(antArmy);
            game.DestroyedActionCards.Should().HaveCount(1);
            game.DestroyedActionCards[0].Should().BeSameAs(curse);
        }

        [Fact]
        public void OpenMisteryDoorNoActionCard()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("0");
            var random = new Random();
            var game = new Game();
            var userAvatar = new UserAvatar
            {
                Level = 1
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var fightController = new FightController();
            var drawCardService = new DrawCardService(random);
            var stackCardGeneratorService = new StackCardGeneratorService();
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGeneratorService);
            var makeActionController = new MakeActionController(game, fightController, prizeStackController, drawCardService)
            {
                readLineOverride = mock.Object
            };
            var antArmy = new AntArmy("Ant Army", CardType.Monster);
            game.DestroyedActionCards.Add(antArmy);
            //Act
            makeActionController.OpenMisteryDoor(user);
            //Assert
            userAvatar.Nerfs.FleeChances.Should().HaveCount(1);
            game.DestroyedActionCards.Should().HaveCount(1);
            game.DestroyedActionCards[0].Should().BeSameAs(antArmy);
        }

        [Fact]
        public void OpenMisteryDoorFirstCurseThanFightWithMonsterFromDeck()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns(new Queue<string>(new[] { "1", "1", "1", "0", "0", "0", "0" }).Dequeue);
            var random = new Random();
            var game = new Game();
            var userAvatar = new UserAvatar
            {
                Level = 1
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var fightController = new FightController();
            var drawCardService = new DrawCardService(random);
            var stackCardGeneratorService = new StackCardGeneratorService();
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGeneratorService);
            var deckController = new DeckController(mock.Object);
            var makeActionController = new MakeActionController(game, fightController, prizeStackController, random, deckController, mock.Object, drawCardService);
            var curse = new BackToSchool("BackToSchool", CardType.Curse);
            var antArmy = new AntArmy("Ant Army", CardType.Monster);
            game.ActionCards.Add(curse);
            user.Deck.Monsters.Add(antArmy);
            //Act
            makeActionController.OpenMisteryDoor(user);
            //Assert
            userAvatar.Nerfs.FleeChances.Should().HaveCount(1);
            game.DestroyedActionCards.Should().HaveCount(2);
            user.Deck.Monsters.Should().HaveCount(0);
        }

        [Fact]
        public void OpenMisteryDoorFirstCurseThanOpenDoorNoCards()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("0");
            var random = new Random();
            var game = new Game();
            var userAvatar = new UserAvatar
            {
                Level = 1
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var fightController = new FightController();
            var drawCardService = new DrawCardService(random);
            var stackCardGeneratorService = new StackCardGeneratorService();
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGeneratorService);
            var deckController = new DeckController(mock.Object);
            var makeActionController = new MakeActionController(game, fightController, prizeStackController, random, deckController, mock.Object, drawCardService);
            var curse = new BackToSchool("BackToSchool", CardType.Curse);
            var antArmy = new AntArmy("Ant Army", CardType.Monster);
            game.ActionCards.Add(curse);
            game.DestroyedActionCards.Add(antArmy);
            //Act
            makeActionController.OpenMisteryDoor(user);
            //Assert
            game.DestroyedActionCards.Should().HaveCount(0);
            user.Deck.Count().Should().Be(1);
            userAvatar.Level.Should().Be(0);
        }

        [Fact]
        public void FightWithYourMonsterWinFight()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns(new Queue<string>(new[] { "1", "1", "1", "0", "0", "0" }).Dequeue);
            var random = new Random();
            var game = new Game();
            var userAvatar = new UserAvatar
            {
                Power = 20,
                Level = 1
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var fightController = new FightController();
            var drawCardService = new DrawCardService(random);
            var stackCardGeneratorService = new StackCardGeneratorService();
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGeneratorService);
            var deckController = new DeckController(mock.Object);
            var makeActionController = new MakeActionController(game, fightController, prizeStackController, random, deckController, mock.Object, drawCardService);
            var curse = new BackToSchool("BackToSchool", CardType.Curse);
            var antArmy = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 5,
                NumberOfPrizes = 2
            };
            game.ActionCards.Add(curse);
            user.Deck.Monsters.Add(antArmy);
            //Act
            makeActionController.OpenMisteryDoor(user);
            //Assert
            user.Deck.Items.Should().HaveCount(2);
            game.DestroyedActionCards.Should().HaveCount(2);
            user.Deck.Monsters.Should().HaveCount(0);
            userAvatar.Level.Should().Be(0);
        }

        [Fact]
        public void FightWithYourMonsterLoseFight()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns(new Queue<string>(new[] { "1", "1", "1", "0", "0", "0" }).Dequeue);
            var random = new Random();
            var game = new Game();
            var userAvatar = new UserAvatar
            {
                Level = 1
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var fightController = new FightController();
            var drawCardService = new DrawCardService(random);
            var stackCardGeneratorService = new StackCardGeneratorService();
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGeneratorService);
            var deckController = new DeckController(mock.Object);
            var makeActionController = new MakeActionController(game, fightController, prizeStackController, random, deckController, mock.Object, drawCardService);
            var curse = new BackToSchool("BackToSchool", CardType.Curse);
            var antArmy = new AntArmy("Ant Army", CardType.Monster);
            game.ActionCards.Add(curse);
            user.Deck.Monsters.Add(antArmy);
            //Act
            makeActionController.OpenMisteryDoor(user);
            //Assert
            userAvatar.Nerfs.FleeChances.Should().HaveCount(1);
            game.DestroyedActionCards.Should().HaveCount(2);
            user.Deck.Monsters.Should().HaveCount(0);
            userAvatar.Level.Should().Be(0);
        }
    }
}
