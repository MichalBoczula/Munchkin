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
using Munchkin.Model.Card.PrizeCard.SituationalItems;
using Munchkin.Model.Character;
using Munchkin.Model.Character.Hero.Proficiency;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Munchkin.Tests.Munchkin.BL.Tests.GameController
{
    public class MakeActionControllerUseSpecialPowerTests
    {
        [Fact]
        public void UseSpecialPowerWarriorTestNoFight()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var random = new Random();
            var game = new Game();
            var userAvatar = new UserAvatar
            {
                Level = 1,
                Proficiency = new WarriorProficiency(mock.Object)
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
            var item = new ItemCard("g", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var item1 = new ItemCard("r", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var item2 = new ItemCard("a", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var item3 = new ItemCard("a", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var item4 = new ItemCard("l", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            user.Deck.Items.Add(item);
            user.Deck.Items.Add(item1);
            user.Deck.Items.Add(item2);
            user.Deck.Items.Add(item3);
            user.Deck.Items.Add(item4);
            user.UserAvatar.CountPower();
            //Act
            makeActionController.UseSpecialPower(user, null);
            //Assert
            user.UserAvatar.Power.Should().Be(1);
            game.DestroyedActionCards.Should().HaveCount(0);
            user.Deck.Items.Count.Should().Be(5);
        }

        [Fact]
        public void UseSpecialPowerWarriorTestFullDeckUsedThreeTimes()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var random = new Random();
            var game = new Game();
            var userAvatar = new UserAvatar
            {
                Level = 1,
                Proficiency = new WarriorProficiency(mock.Object)
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
            var item = new ItemCard("g", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var item1 = new ItemCard("r", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var item2 = new ItemCard("a", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var item3 = new ItemCard("a", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var item4 = new ItemCard("l", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var fight = new Fight();
            user.Deck.Items.Add(item);
            user.Deck.Items.Add(item1);
            user.Deck.Items.Add(item2);
            user.Deck.Items.Add(item3);
            user.Deck.Items.Add(item4);
            user.UserAvatar.CountPower();
            //Act
            makeActionController.UseSpecialPower(user, fight);
            makeActionController.UseSpecialPower(user, fight);
            makeActionController.UseSpecialPower(user, fight);
            //Assert
            user.UserAvatar.TempPower.Should().Be(4);
            game.DestroyedPrizeCards.Should().HaveCount(3);
            user.Deck.Items.Count.Should().Be(2);
        }

        [Fact]
        public void UseSpecialPowerWarriorTestOnlyTwoCardsUsedThreeTimes()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var random = new Random();
            var game = new Game();
            var userAvatar = new UserAvatar
            {
                Level = 1,
                Proficiency = new WarriorProficiency(mock.Object)
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
            var item = new ItemCard("g", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var item1 = new ItemCard("r", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var fight = new Fight();
            user.Deck.Items.Add(item);
            user.Deck.Items.Add(item1);
            user.UserAvatar.CountPower();
            //Act
            makeActionController.UseSpecialPower(user, fight);
            makeActionController.UseSpecialPower(user, fight);
            makeActionController.UseSpecialPower(user, fight);
            //Assert
            user.UserAvatar.TempPower.Should().Be(3);
            game.DestroyedPrizeCards.Should().HaveCount(2);
            user.Deck.Items.Count.Should().Be(0);
        }

        [Fact]
        public void UseSpecialPowerWarriorTestFullDeckDidntUsedSkill()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("2");
            var random = new Random();
            var game = new Game();
            var userAvatar = new UserAvatar
            {
                Level = 1,
                Proficiency = new WarriorProficiency(mock.Object)
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
            var item = new ItemCard("g", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var item1 = new ItemCard("r", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var item2 = new ItemCard("a", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var item3 = new ItemCard("a", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var item4 = new ItemCard("l", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var fight = new Fight();
            user.Deck.Items.Add(item);
            user.Deck.Items.Add(item1);
            user.Deck.Items.Add(item2);
            user.Deck.Items.Add(item3);
            user.Deck.Items.Add(item4);
            user.UserAvatar.CountPower();
            //Act
            makeActionController.UseSpecialPower(user, fight);
            makeActionController.UseSpecialPower(user, fight);
            //Assert
            user.UserAvatar.TempPower.Should().Be(1);
            game.DestroyedPrizeCards.Should().HaveCount(0);
            user.Deck.Items.Count.Should().Be(5);
        }

        [Fact]
        public void UseSpecialPowerMageFleeSpellTestNoFight()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var random = new Random();
            var game = new Game();
            var userAvatar = new UserAvatar
            {
                Level = 1,
                Proficiency = new MageProficiency(mock.Object)
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
            var item = new ItemCard("g", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var item1 = new ItemCard("r", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var item2 = new ItemCard("a", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var item3 = new ItemCard("a", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var item4 = new ItemCard("l", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            user.Deck.Items.Add(item);
            user.Deck.Items.Add(item1);
            user.Deck.Items.Add(item2);
            user.Deck.Items.Add(item3);
            user.Deck.Items.Add(item4);
            user.UserAvatar.EndTurn();
            //Act
            makeActionController.UseSpecialPower(user, null);
            //Assert
            user.UserAvatar.FleeChances.Should().Be(3);
            game.DestroyedPrizeCards.Should().HaveCount(0);
            user.Deck.Items.Count.Should().Be(5);
        }

        [Fact]
        public void UseSpecialPowerMageFleeSpellTestUsedThreeTimes()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var random = new Random();
            var game = new Game();
            var userAvatar = new UserAvatar
            {
                Level = 1,
                Proficiency = new MageProficiency(mock.Object)
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
            var item = new ItemCard("g", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var item1 = new ItemCard("r", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var item2 = new ItemCard("a", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var item3 = new ItemCard("a", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var item4 = new ItemCard("l", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var fight = new Fight();
            user.Deck.Items.Add(item);
            user.Deck.Items.Add(item1);
            user.Deck.Items.Add(item2);
            user.Deck.Items.Add(item3);
            user.Deck.Items.Add(item4);
            user.UserAvatar.EndTurn();
            //Act
            makeActionController.UseSpecialPower(user, fight);
            makeActionController.UseSpecialPower(user, fight);
            makeActionController.UseSpecialPower(user, fight);
            //Assert
            user.UserAvatar.FleeChances.Should().Be(6);
            game.DestroyedPrizeCards.Should().HaveCount(3);
            user.Deck.Items.Count.Should().Be(2);
        }

        [Fact]
        public void UseSpecialPowerMageFleeSpellTestOnlyTwoCardsUsedThreeTimes()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var random = new Random();
            var game = new Game();
            var userAvatar = new UserAvatar
            {
                Level = 1,
                Proficiency = new MageProficiency(mock.Object)
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
            var item = new ItemCard("g", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var item1 = new ItemCard("r", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var fight = new Fight();
            user.Deck.Items.Add(item);
            user.Deck.Items.Add(item1);
            user.UserAvatar.EndTurn();
            //Act
            makeActionController.UseSpecialPower(user, fight);
            makeActionController.UseSpecialPower(user, fight);
            makeActionController.UseSpecialPower(user, fight);
            //Assert
            user.UserAvatar.FleeChances.Should().Be(5);
            game.DestroyedPrizeCards.Should().HaveCount(2);
            user.Deck.Items.Count.Should().Be(0);
        }

        [Fact]
        public void UseSpecialPowerMageFleeSpellTestFullDeckDidntUsedSkill()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns(new Queue<string>(new[] { "1", "2", "1" }).Dequeue);
            var random = new Random();
            var game = new Game();
            var userAvatar = new UserAvatar
            {
                Level = 1,
                Proficiency = new MageProficiency(mock.Object)
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
            var item = new ItemCard("g", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var item1 = new ItemCard("r", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var fight = new Fight();
            user.Deck.Items.Add(item);
            user.Deck.Items.Add(item1);
            user.UserAvatar.EndTurn();
            //Act
            makeActionController.UseSpecialPower(user, fight);
            //Assert
            user.UserAvatar.FleeChances.Should().Be(3);
            game.DestroyedPrizeCards.Should().HaveCount(0);
            user.Deck.Items.Count.Should().Be(2);
        }

        [Fact]
        public void UseSpecialPowerMageInstantKillTestOnlyThreeCards()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("2");
            var random = new Random();
            var game = new Game();
            var userAvatar = new UserAvatar
            {
                Level = 1,
                Proficiency = new MageProficiency(mock.Object)
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
            var item = new ItemCard("g", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var item1 = new ItemCard("r", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var fight = new Fight();
            var antArmy = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 5,
                HowManyLevels = 1,
                NumberOfPrizes = 2
            };
            user.Deck.Items.Add(item);
            user.Deck.Items.Add(item1);
            user.Deck.Monsters.Add(antArmy);
            user.UserAvatar.EndTurn();
            //Act
            makeActionController.UseSpecialPower(user, fight);
            //Assert
            user.Deck.Items.Count.Should().Be(2);
            antArmy.Power.Should().Be(5);
            game.DestroyedActionCards.Count.Should().Be(0);
            game.DestroyedPrizeCards.Count.Should().Be(0);
        }

        [Fact]
        public void UseSpecialPowerMageInstantKillTestThereIsNoFight()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("2");
            var random = new Random();
            var game = new Game();
            var userAvatar = new UserAvatar
            {
                Level = 1,
                Proficiency = new MageProficiency(mock.Object)
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
            var item = new ItemCard("g", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var item1 = new ItemCard("r", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            user.Deck.Items.Add(item);
            user.Deck.Items.Add(item1);
            user.UserAvatar.EndTurn();
            //Act
            makeActionController.UseSpecialPower(user, null);
            //Assert
            user.Deck.Items.Count.Should().Be(2);
            game.DestroyedActionCards.Count.Should().Be(0);
            game.DestroyedPrizeCards.Count.Should().Be(0);
        }

        [Fact]
        public void UseSpecialPowerMageInstantKillTestFullDeck()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("2");
            var random = new Random();
            var game = new Game();
            var userAvatar = new UserAvatar
            {
                Level = 1,
                Proficiency = new MageProficiency(mock.Object)
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
            var item = new ItemCard("g", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var item1 = new ItemCard("r", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var sit1 = new DeadlyBerries("DeadlyBerries", CardType.Special, PrizeCardType.Sitiuational, 0, null, false, ItemType.Sitiuational, null, 500, mock.Object);
            var magic = new Gambling("Gambling", CardType.Curse, random);
            var fight = new Fight();
            var antArmy = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 5,
                HowManyLevels = 1,
                NumberOfPrizes = 2
            };
            user.Deck.Items.Add(item);
            user.Deck.Items.Add(item1);
            user.Deck.Items.Add(sit1);
            user.Deck.MagicCards.Add(magic);
            user.Deck.Monsters.Add(antArmy);
            user.UserAvatar.EndTurn();
            fight.Heros.Add(user);
            fight.Monsters.Add(antArmy);
            //Act
            makeActionController.UseSpecialPower(user, fight);
            //Assert
            user.Deck.Items.Count.Should().Be(0);
            user.Deck.Monsters.Count.Should().Be(0);
            user.Deck.MagicCards.Count.Should().Be(0);
            antArmy.Power.Should().Be(-999);
            game.DestroyedActionCards.Count.Should().Be(2);
            game.DestroyedPrizeCards.Count.Should().Be(3);
        }

        [Fact]
        public void UseSpecialPowerMageInstantKillTestFullDeckTwoMonsters()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns(new Queue<string>(new[] { "2", "2", "2", "2", "2" }).Dequeue);
            var random = new Random();
            var game = new Game();
            var userAvatar = new UserAvatar
            {
                Level = 1,
                Proficiency = new MageProficiency(mock.Object)
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
            var item = new ItemCard("g", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var item1 = new ItemCard("r", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var sit1 = new DeadlyBerries("DeadlyBerries", CardType.Special, PrizeCardType.Sitiuational, 0, null, false, ItemType.Sitiuational, null, 500, mock.Object);
            var magic = new Gambling("Gambling", CardType.Curse, random);
            var fight = new Fight();
            var fenrir = new Fenrir("Fenrir", CardType.Monster)
            {
                Power = 20
            };
            var antArmy = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 5,
                HowManyLevels = 1,
                NumberOfPrizes = 2
            };
            user.Deck.Items.Add(item);
            user.Deck.Items.Add(item1);
            user.Deck.Items.Add(sit1);
            user.Deck.MagicCards.Add(magic);
            user.Deck.Monsters.Add(antArmy);
            user.UserAvatar.EndTurn();
            fight.Heros.Add(user);
            fight.Monsters.Add(antArmy);
            fight.Monsters.Add(fenrir);
            //Act
            makeActionController.UseSpecialPower(user, fight);
            //Assert
            user.Deck.Items.Count.Should().Be(0);
            user.Deck.Monsters.Count.Should().Be(0);
            user.Deck.MagicCards.Count.Should().Be(0);
            antArmy.Power.Should().Be(5);
            fenrir.Power.Should().Be(-999);
            game.DestroyedActionCards.Count.Should().Be(2);
            game.DestroyedPrizeCards.Count.Should().Be(3);
        }

        [Fact]
        public void UseSpecialPowerPriestRestoreCardFullDeck()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns(new Queue<string>(new[] { "2", "2", "1", "2", "2", "2", "2", "2", "2" }).Dequeue);
            var random = new Random();
            var game = new Game();
            var userAvatar = new UserAvatar
            {
                Level = 1,
                Proficiency = new PriestProficiency(mock.Object)
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
            var item = new ItemCard("g", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var item1 = new ItemCard("r", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var restored = new ItemCard("r", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var sit1 = new DeadlyBerries("DeadlyBerries", CardType.Special, PrizeCardType.Sitiuational, 0, null, false, ItemType.Sitiuational, null, 500, mock.Object);
            var magic = new Gambling("Gambling", CardType.Curse, random);
            var antArmy = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 5,
                HowManyLevels = 1,
                NumberOfPrizes = 2
            };
            user.Deck.Items.Add(item);
            user.Deck.Items.Add(item1);
            user.Deck.Items.Add(sit1);
            user.Deck.MagicCards.Add(magic);
            user.Deck.Monsters.Add(antArmy);
            user.UserAvatar.EndTurn();
            game.DestroyedPrizeCards.Add(restored);
            //Act
            makeActionController.UseSpecialPower(user, null);
            //Assert
            user.Deck.Items.Count.Should().Be(3);
            user.Deck.Items.Should().Contain(restored);
            user.Deck.Monsters.Count.Should().Be(1);
            user.Deck.MagicCards.Count.Should().Be(1);
            game.DestroyedPrizeCards.Count.Should().Be(1);
        }

        [Fact]
        public void UseSpecialPowerPriestRestoreCardFullDeckNoCardToRestore()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns(new Queue<string>(new[] { "2", "2", "1", "2", "2", "2", "2", "2", "2" }).Dequeue);
            var random = new Random();
            var game = new Game();
            var userAvatar = new UserAvatar
            {
                Level = 1,
                Proficiency = new PriestProficiency(mock.Object)
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
            var item = new ItemCard("g", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var item1 = new ItemCard("r", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var sit1 = new DeadlyBerries("DeadlyBerries", CardType.Special, PrizeCardType.Sitiuational, 0, null, false, ItemType.Sitiuational, null, 500, mock.Object);
            var magic = new Gambling("Gambling", CardType.Curse, random);
            var antArmy = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 5,
                HowManyLevels = 1,
                NumberOfPrizes = 2
            };
            user.Deck.Items.Add(item);
            user.Deck.Items.Add(item1);
            user.Deck.Items.Add(sit1);
            user.Deck.MagicCards.Add(magic);
            user.Deck.Monsters.Add(antArmy);
            user.UserAvatar.EndTurn();
            //Act
            makeActionController.UseSpecialPower(user, null);
            //Assert
            user.Deck.Items.Count.Should().Be(3);
            user.Deck.Monsters.Count.Should().Be(1);
            user.Deck.MagicCards.Count.Should().Be(1);
            game.DestroyedPrizeCards.Count.Should().Be(0);
        }

        [Fact]
        public void UseSpecialPowerPriestRestoreCardFullDeckEmptyDeck()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns(new Queue<string>(new[] { "2", "2", "1", "2", "2", "2", "2", "2", "2" }).Dequeue);
            var random = new Random();
            var game = new Game();
            var userAvatar = new UserAvatar
            {
                Level = 1,
                Proficiency = new PriestProficiency(mock.Object)
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
            var restored = new ItemCard("r", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            game.DestroyedPrizeCards.Add(restored);
            //Act
            makeActionController.UseSpecialPower(user, null);
            //Assert
            user.Deck.Items.Count.Should().Be(0);
            user.Deck.Monsters.Count.Should().Be(0);
            user.Deck.MagicCards.Count.Should().Be(0);
            game.DestroyedPrizeCards.Count.Should().Be(1);
        }

        [Fact]
        public void UseSpecialPowerPriestMakeMonsterAPetFullDeckNoFight()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var random = new Random();
            var game = new Game();
            var userAvatar = new UserAvatar
            {
                Level = 1,
                Proficiency = new PriestProficiency(mock.Object)
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
            var item = new ItemCard("g", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var item1 = new ItemCard("r", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var sit1 = new DeadlyBerries("DeadlyBerries", CardType.Special, PrizeCardType.Sitiuational, 0, null, false, ItemType.Sitiuational, null, 500, mock.Object);
            var magic = new Gambling("Gambling", CardType.Curse, random);
            var antArmy = new AntArmy("Ant Army", CardType.Monster);
            user.Deck.Items.Add(item);
            user.Deck.Items.Add(item1);
            user.Deck.Items.Add(sit1);
            user.Deck.MagicCards.Add(magic);
            user.Deck.Monsters.Add(antArmy);
            user.UserAvatar.EndTurn();
            //Act
            makeActionController.UseSpecialPower(user, null);
            //Assert
            user.Deck.Items.Count.Should().Be(3);
            user.Deck.Monsters.Count.Should().Be(1);
            user.Deck.MagicCards.Count.Should().Be(1);
            game.DestroyedPrizeCards.Count.Should().Be(0);
        }

        [Fact]
        public void UseSpecialPowerPriestMakeMonsterAPetOnlyTwoCards()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var random = new Random();
            var game = new Game();
            var userAvatar = new UserAvatar
            {
                Level = 1,
                Proficiency = new PriestProficiency(mock.Object)
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
            var item = new ItemCard("g", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var magic = new Gambling("Gambling", CardType.Curse, random);
            var fenrir = new Fenrir("Fenrir", CardType.Monster);
            var fight = new Fight();
            user.Deck.Items.Add(item);
            user.Deck.MagicCards.Add(magic);
            user.UserAvatar.EndTurn();
            fight.Heros.Add(user);
            fight.Monsters.Add(fenrir);
            //Act
            makeActionController.UseSpecialPower(user, null);
            //Assert
            user.Deck.Items.Count.Should().Be(1);
            user.Deck.Monsters.Count.Should().Be(0);
            user.Deck.MagicCards.Count.Should().Be(1);
            game.DestroyedPrizeCards.Count.Should().Be(0);
            fight.Heros.Count.Should().Be(1);
            fight.Monsters.Count.Should().Be(1);
        }

        [Fact]
        public void UseSpecialPowerPriestMakeMonsterAPetFullDeck()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var random = new Random();
            var game = new Game();
            var userAvatar = new UserAvatar
            {
                Level = 1,
                Proficiency = new PriestProficiency(mock.Object)
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
            var item = new ItemCard("g", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var item2 = new ItemCard("r", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var sit1 = new DeadlyBerries("DeadlyBerries", CardType.Special, PrizeCardType.Sitiuational, 0, null, false, ItemType.Sitiuational, null, 500, mock.Object);
            var magic = new Gambling("Gambling", CardType.Curse, random);
            var antArmy = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 5,
                HowManyLevels = 1,
                NumberOfPrizes = 2
            };
            var fenrir = new Fenrir("Fenrir", CardType.Monster);
            var fight = new Fight();
            user.Deck.Items.Add(item);
            user.Deck.Items.Add(item2);
            user.Deck.Items.Add(sit1);
            user.Deck.MagicCards.Add(magic);
            user.Deck.Monsters.Add(antArmy);
            user.UserAvatar.EndTurn();
            fight.Heros.Add(user);
            fight.Monsters.Add(fenrir);
            //Act
            makeActionController.UseSpecialPower(user, fight);
            //Assert
            user.Deck.Items.Count.Should().Be(0);
            user.Deck.Monsters.Count.Should().Be(1);
            user.Deck.Monsters[0].Should().BeSameAs(fenrir);
            user.Deck.MagicCards.Count.Should().Be(0);
            game.DestroyedPrizeCards.Count.Should().Be(3);
            game.DestroyedActionCards.Count.Should().Be(2);
        }

        [Fact]
        public void UseSpecialPowerPriestMakeMonsterAPetFullDeckTwoMonsters()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var random = new Random();
            var game = new Game();
            var userAvatar = new UserAvatar
            {
                Level = 1,
                Proficiency = new PriestProficiency(mock.Object)
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
            var item = new ItemCard("g", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var item2 = new ItemCard("r", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var sit1 = new DeadlyBerries("DeadlyBerries", CardType.Special, PrizeCardType.Sitiuational, 0, null, false, ItemType.Sitiuational, null, 500, mock.Object);
            var magic = new Gambling("Gambling", CardType.Curse, random);
            var antArmy = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 5
            };
            var fenrir = new Fenrir("Fenrir", CardType.Monster)
            {
                Power = 20
            };
            var fight = new Fight();
            user.Deck.Items.Add(item);
            user.Deck.Items.Add(item);
            user.Deck.Items.Add(item2);
            user.Deck.Items.Add(sit1);
            user.Deck.MagicCards.Add(magic);
            user.UserAvatar.EndTurn();
            fight.Heros.Add(user);
            fight.Monsters.Add(fenrir);
            fight.Monsters.Add(antArmy);
            //Act
            makeActionController.UseSpecialPower(user, fight);
            //Assert
            user.Deck.Items.Count.Should().Be(0);
            user.Deck.Monsters.Count.Should().Be(1);
            user.Deck.Monsters[0].Should().BeSameAs(fenrir);
            user.Deck.MagicCards.Count.Should().Be(0);
            game.DestroyedPrizeCards.Count.Should().Be(4);
            game.DestroyedActionCards.Count.Should().Be(1);
            fight.Monsters.Count.Should().Be(1);
        }

        [Fact]
        public void UseSpecialPowerNoOneSpecialSkillDoNothing()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var random = new Random();
            var game = new Game();
            var userAvatar = new UserAvatar
            {
                Level = 1,
                Proficiency = new NoOneProficiency()
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
            var item = new ItemCard("g", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            var sit1 = new DeadlyBerries("DeadlyBerries", CardType.Special, PrizeCardType.Sitiuational, 0, null, false, ItemType.Sitiuational, null, 500, mock.Object);
            var magic = new Gambling("Gambling", CardType.Curse, random);
            var antArmy = new AntArmy("Ant Army", CardType.Monster);
            var fenrir = new Fenrir("Fenrir", CardType.Monster);
            var fight = new Fight();
            user.Deck.Items.Add(item);
            user.Deck.Items.Add(sit1);
            user.Deck.MagicCards.Add(magic);
            user.Deck.Monsters.Add(fenrir);
            fight.Heros.Add(user);
            fight.Monsters.Add(antArmy);
            //Act
            makeActionController.UseSpecialPower(user, fight);
            //Assert
            user.Deck.Items.Count.Should().Be(2);
            user.Deck.Monsters.Count.Should().Be(1);
            user.Deck.MagicCards.Count.Should().Be(1);
            game.DestroyedPrizeCards.Count.Should().Be(0);
            game.DestroyedActionCards.Count.Should().Be(0);
            fight.Monsters.Count.Should().Be(1);
            fight.Heros.Count.Should().Be(1);
        }

        [Fact]
        public void UseSpecialPowerThiefBackstabOpponentBackstabSuccess()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var random = new Random();
            var mockRandom = new Mock<Random>();
            mockRandom.Setup(x => x.Next(6)).Returns(4);
            var game = new Game();
            var userAvatar = new UserAvatar
            {
                Level = 1,
                Proficiency = new ThiefProficiency(mock.Object, mockRandom.Object)
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar,
                Name = "Majk"
            };
            var opponentAvatar = new UserAvatar
            {
                Level = 1,
                Proficiency = new NoOneProficiency()
            };
            var opponent = new UserClass()
            {
                UserAvatar = opponentAvatar,
                Name = "Victim"
            };
            var fightController = new FightController();
            var drawCardService = new DrawCardService(random);
            var stackCardGeneratorService = new StackCardGeneratorService();
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGeneratorService);
            var deckController = new DeckController(mock.Object);
            var makeActionController = new MakeActionController(game, fightController, prizeStackController, random, deckController, mock.Object, drawCardService);
            game.Users.Add(user);
            game.Users.Add(opponent);
            //Act
            makeActionController.UseSpecialPower(user, null);
            //Assert
            opponent.UserAvatar.WasBackstab.Should().BeTrue();
        }

        [Fact]
        public void UseSpecialPowerThiefBackstabOpponentBackstabFailure()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var random = new Random();
            var mockRandom = new Mock<Random>();
            mockRandom.Setup(x => x.Next(6)).Returns(2);
            var game = new Game();
            var userAvatar = new UserAvatar
            {
                Level = 1,
                Proficiency = new ThiefProficiency(mock.Object, mockRandom.Object)
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar,
                Name = "Majk"
            };
            var opponentAvatar = new UserAvatar
            {
                Level = 1,
                Proficiency = new NoOneProficiency()
            };
            var opponent = new UserClass()
            {
                UserAvatar = opponentAvatar,
                Name = "Victim"
            };
            var fightController = new FightController();
            var drawCardService = new DrawCardService(random);
            var stackCardGeneratorService = new StackCardGeneratorService();
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGeneratorService);
            var deckController = new DeckController(mock.Object);
            var makeActionController = new MakeActionController(game, fightController, prizeStackController, random, deckController, mock.Object, drawCardService);
            game.Users.Add(user);
            game.Users.Add(opponent);
            //Act
            makeActionController.UseSpecialPower(user, null);
            //Assert
            opponent.UserAvatar.WasBackstab.Should().BeFalse();
        }

        [Fact]
        public void UseSpecialPowerThiefBackstabOpponentBackstabTwoTimesFail()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var random = new Random();
            var mockRandom = new Mock<Random>();
            mockRandom.Setup(x => x.Next(6)).Returns(4);
            var game = new Game();
            var userAvatar = new UserAvatar
            {
                Level = 1,
                Proficiency = new ThiefProficiency(mock.Object, mockRandom.Object)
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar,
                Name = "Majk"
            };
            var opponentAvatar = new UserAvatar
            {
                Level = 1,
                Proficiency = new NoOneProficiency(),
                TempPower = 2
            };
            var opponent = new UserClass()
            {
                UserAvatar = opponentAvatar,
                Name = "Victim"
            };
            var fightController = new FightController();
            var drawCardService = new DrawCardService(random);
            var stackCardGeneratorService = new StackCardGeneratorService();
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGeneratorService);
            var deckController = new DeckController(mock.Object);
            var makeActionController = new MakeActionController(game, fightController, prizeStackController, random, deckController, mock.Object, drawCardService);
            game.Users.Add(user);
            game.Users.Add(opponent);
            //Act
            makeActionController.UseSpecialPower(user, null);
            makeActionController.UseSpecialPower(user, null);
            //Assert
            opponent.UserAvatar.TempPower.Should().Be(0);
            opponent.UserAvatar.WasBackstab.Should().BeTrue();
        }

        [Fact]
        public void UseSpecialPowerThiefBackstabOpponentBackstabSecondBackstabFail()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var random = new Random();
            var mockRandom = new Mock<Random>();
            mockRandom.Setup(x => x.Next(6)).Returns(4);
            var game = new Game();
            var userAvatar = new UserAvatar
            {
                Level = 1,
                Proficiency = new ThiefProficiency(mock.Object, mockRandom.Object)
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar,
                Name = "Majk"
            };
            var opponentAvatar = new UserAvatar
            {
                Level = 1,
                Proficiency = new NoOneProficiency(),
                TempPower = 2,
                WasBackstab = true
            };
            var opponent = new UserClass()
            {
                UserAvatar = opponentAvatar,
                Name = "Victim"
            };
            var fightController = new FightController();
            var drawCardService = new DrawCardService(random);
            var stackCardGeneratorService = new StackCardGeneratorService();
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGeneratorService);
            var deckController = new DeckController(mock.Object);
            var makeActionController = new MakeActionController(game, fightController, prizeStackController, random, deckController, mock.Object, drawCardService);
            game.Users.Add(user);
            game.Users.Add(opponent);
            //Act
            makeActionController.UseSpecialPower(user, null);
            //Assert
            opponent.UserAvatar.TempPower.Should().Be(2);
            opponent.UserAvatar.WasBackstab.Should().BeTrue();
        }

        [Fact]
        public void UseSpecialPowerThiefBackstabOpponentBackstabTwoEnemiesBackstabFirst()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var random = new Random();
            var mockRandom = new Mock<Random>();
            mockRandom.Setup(x => x.Next(6)).Returns(4);
            var game = new Game();
            var userAvatar = new UserAvatar
            {
                Level = 1,
                Proficiency = new ThiefProficiency(mock.Object, mockRandom.Object)
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar,
                Name = "Majk"
            };
            var opponentAvatar = new UserAvatar
            {
                Level = 1,
                Proficiency = new NoOneProficiency(),
                TempPower = 2,
            };
            var opponent = new UserClass()
            {
                UserAvatar = opponentAvatar,
                Name = "Victim"
            };
            var opponentAvatar2 = new UserAvatar
            {
                Level = 1,
                Proficiency = new NoOneProficiency(),
                TempPower = 2,
            };
            var opponent2 = new UserClass()
            {
                UserAvatar = opponentAvatar2,
                Name = "Victim2"
            };
            var fightController = new FightController();
            var drawCardService = new DrawCardService(random);
            var stackCardGeneratorService = new StackCardGeneratorService();
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGeneratorService);
            var deckController = new DeckController(mock.Object);
            var makeActionController = new MakeActionController(game, fightController, prizeStackController, random, deckController, mock.Object, drawCardService);
            game.Users.Add(user);
            game.Users.Add(opponent);
            game.Users.Add(opponent2);
            //Act
            makeActionController.UseSpecialPower(user, null);
            //Assert
            opponent.UserAvatar.TempPower.Should().Be(0);
            opponent2.UserAvatar.TempPower.Should().Be(2);
            opponent.UserAvatar.WasBackstab.Should().BeTrue();
            opponent2.UserAvatar.WasBackstab.Should().BeFalse();
        }

        [Fact]
        public void UseSpecialPowerThiefBackstabOpponentBackstabTwoEnemiesBackstabSecond()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns(new Queue<string>(new[] { "1", "2", "1", "1", "1" }).Dequeue);
            var random = new Random();
            var mockRandom = new Mock<Random>();
            mockRandom.Setup(x => x.Next(6)).Returns(4);
            var game = new Game();
            var userAvatar = new UserAvatar
            {
                Level = 1,
                Proficiency = new ThiefProficiency(mock.Object, mockRandom.Object)
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar,
                Name = "Majk"
            };
            var opponentAvatar = new UserAvatar
            {
                Level = 1,
                Proficiency = new NoOneProficiency(),
                TempPower = 2,
            };
            var opponent = new UserClass()
            {
                UserAvatar = opponentAvatar,
                Name = "Victim"
            };
            var opponentAvatar2 = new UserAvatar
            {
                Level = 1,
                Proficiency = new NoOneProficiency(),
                TempPower = 2,
            };
            var opponent2 = new UserClass()
            {
                UserAvatar = opponentAvatar2,
                Name = "Victim2"
            };
            var fightController = new FightController();
            var drawCardService = new DrawCardService(random);
            var stackCardGeneratorService = new StackCardGeneratorService();
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGeneratorService);
            var deckController = new DeckController(mock.Object);
            var makeActionController = new MakeActionController(game, fightController, prizeStackController, random, deckController, mock.Object, drawCardService);
            game.Users.Add(user);
            game.Users.Add(opponent);
            game.Users.Add(opponent2);
            //Act
            makeActionController.UseSpecialPower(user, null);
            //Assert
            opponent.UserAvatar.TempPower.Should().Be(2);
            opponent2.UserAvatar.TempPower.Should().Be(0);
            opponent.UserAvatar.WasBackstab.Should().BeFalse();
            opponent2.UserAvatar.WasBackstab.Should().BeTrue();
        }

        [Fact]
        public void UseSpecialPowerThiefStealItemSuccess()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns(new Queue<string>(new[] { "2", "1", "1", "1", "1", "1", "1" }).Dequeue);
            var random = new Random();
            var mockRandom = new Mock<Random>();
            mockRandom.Setup(x => x.Next(6)).Returns(5);
            var game = new Game();
            var userAvatar = new UserAvatar
            {
                Level = 1,
                Proficiency = new ThiefProficiency(mock.Object, mockRandom.Object)
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar,
                Name = "Majk"
            };
            var opponentAvatar = new UserAvatar
            {
                Level = 1,
                Proficiency = new NoOneProficiency(),
                TempPower = 2,
            };
            var opponent = new UserClass()
            {
                UserAvatar = opponentAvatar,
                Name = "Victim"
            };
            var fightController = new FightController();
            var drawCardService = new DrawCardService(random);
            var stackCardGeneratorService = new StackCardGeneratorService();
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGeneratorService);
            var deckController = new DeckController(mock.Object);
            var makeActionController = new MakeActionController(game, fightController, prizeStackController, random, deckController, mock.Object, drawCardService);
            var helmet = new ItemCard("Helmet", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Helmet, null, 300);
            opponent.Deck.Items.Add(helmet);
            game.Users.Add(user);
            game.Users.Add(opponent);
            //Act
            makeActionController.UseSpecialPower(user, null);
            //Assert
            opponent.Deck.Items.Count.Should().Be(0);
            user.Deck.Items.Should().HaveCount(1);
            user.Deck.Items[0].Should().BeSameAs(helmet);
        }

        [Fact]
        public void UseSpecialPowerThiefStealItemFail()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns(new Queue<string>(new[] { "2", "1", "1", "1", "1", "1", "1" }).Dequeue);
            var random = new Random();
            var mockRandom = new Mock<Random>();
            mockRandom.Setup(x => x.Next(6)).Returns(5);
            var game = new Game();
            var userAvatar = new UserAvatar
            {
                Level = 1,
                Proficiency = new ThiefProficiency(mock.Object, mockRandom.Object)
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar,
                Name = "Majk"
            };
            var opponentAvatar = new UserAvatar
            {
                Level = 1,
                Proficiency = new NoOneProficiency(),
                TempPower = 2,
                WasRob = true
            };
            var opponent = new UserClass()
            {
                UserAvatar = opponentAvatar,
                Name = "Victim"
            };
            var fightController = new FightController();
            var drawCardService = new DrawCardService(random);
            var stackCardGeneratorService = new StackCardGeneratorService();
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGeneratorService);
            var deckController = new DeckController(mock.Object);
            var makeActionController = new MakeActionController(game, fightController, prizeStackController, random, deckController, mock.Object, drawCardService);
            var helmet = new ItemCard("Helmet", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Helmet, null, 300);
            opponent.Deck.Items.Add(helmet);
            game.Users.Add(user);
            game.Users.Add(opponent);
            //Act
            makeActionController.UseSpecialPower(user, null);
            //Assert
            opponent.Deck.Items.Count.Should().Be(1);
            user.Deck.Items.Should().HaveCount(0);
        }

        [Fact]
        public void UseSpecialPowerThiefStealItemTwoEnemiesRobFirst()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns(new Queue<string>(new[] { "2", "1", "1", "1", "1", "1", "1" }).Dequeue);
            var random = new Random();
            var mockRandom = new Mock<Random>();
            mockRandom.Setup(x => x.Next(6)).Returns(5);
            var game = new Game();
            var userAvatar = new UserAvatar
            {
                Level = 1,
                Proficiency = new ThiefProficiency(mock.Object, mockRandom.Object)
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar,
                Name = "Majk"
            };
            var opponentAvatar = new UserAvatar
            {
                Level = 1,
                Proficiency = new NoOneProficiency(),
                TempPower = 2,
            };
            var opponent = new UserClass()
            {
                UserAvatar = opponentAvatar,
                Name = "Victim"
            };
            var opponentAvatar2 = new UserAvatar
            {
                Level = 1,
                Proficiency = new NoOneProficiency(),
                TempPower = 2,
            };
            var opponent2 = new UserClass()
            {
                UserAvatar = opponentAvatar2,
                Name = "Victim"
            };
            var fightController = new FightController();
            var drawCardService = new DrawCardService(random);
            var stackCardGeneratorService = new StackCardGeneratorService();
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGeneratorService);
            var deckController = new DeckController(mock.Object);
            var makeActionController = new MakeActionController(game, fightController, prizeStackController, random, deckController, mock.Object, drawCardService);
            var helmet = new ItemCard("Helmet", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Helmet, null, 300);
            opponent.Deck.Items.Add(helmet);
            opponent2.Deck.Items.Add(helmet);
            game.Users.Add(user);
            game.Users.Add(opponent);
            game.Users.Add(opponent2);
            //Act
            makeActionController.UseSpecialPower(user, null);
            //Assert
            opponent.Deck.Items.Count.Should().Be(0);
            opponent2.Deck.Items.Count.Should().Be(1);
            user.Deck.Items.Should().HaveCount(1);
        }

        [Fact]
        public void UseSpecialPowerThiefStealItemTwoEnemiesRobSecond()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns(new Queue<string>(new[] { "2", "2", "1", "1", "1", "1", "1" }).Dequeue);
            var random = new Random();
            var mockRandom = new Mock<Random>();
            mockRandom.Setup(x => x.Next(6)).Returns(5);
            var game = new Game();
            var userAvatar = new UserAvatar
            {
                Level = 1,
                Proficiency = new ThiefProficiency(mock.Object, mockRandom.Object)
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar,
                Name = "Majk"
            };
            var opponentAvatar = new UserAvatar
            {
                Level = 1,
                Proficiency = new NoOneProficiency(),
                TempPower = 2,
            };
            var opponent = new UserClass()
            {
                UserAvatar = opponentAvatar,
                Name = "Victim"
            };
            var opponentAvatar2 = new UserAvatar
            {
                Level = 1,
                Proficiency = new NoOneProficiency(),
                TempPower = 2,
            };
            var opponent2 = new UserClass()
            {
                UserAvatar = opponentAvatar2,
                Name = "Victim"
            };
            var fightController = new FightController();
            var drawCardService = new DrawCardService(random);
            var stackCardGeneratorService = new StackCardGeneratorService();
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGeneratorService);
            var deckController = new DeckController(mock.Object);
            var makeActionController = new MakeActionController(game, fightController, prizeStackController, random, deckController, mock.Object, drawCardService);
            var helmet = new ItemCard("Helmet", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Helmet, null, 300);
            opponent.Deck.Items.Add(helmet);
            opponent2.Deck.Items.Add(helmet);
            game.Users.Add(user);
            game.Users.Add(opponent);
            game.Users.Add(opponent2);
            //Act
            makeActionController.UseSpecialPower(user, null);
            //Assert
            opponent.Deck.Items.Count.Should().Be(1);
            opponent2.Deck.Items.Count.Should().Be(0);
            user.Deck.Items.Should().HaveCount(1);
        }

        [Fact]
        public void UseSpecialPowerThiefStealItemTryRobTwoTimes()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns(new Queue<string>(new[] { "2", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1" }).Dequeue);
            var random = new Random();
            var mockRandom = new Mock<Random>();
            mockRandom.Setup(x => x.Next(6)).Returns(5);
            var game = new Game();
            var userAvatar = new UserAvatar
            {
                Level = 1,
                Proficiency = new ThiefProficiency(mock.Object, mockRandom.Object)
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar,
                Name = "Majk"
            };
            var opponentAvatar = new UserAvatar
            {
                Level = 1,
                Proficiency = new NoOneProficiency(),
                TempPower = 2,
            };
            var opponent = new UserClass()
            {
                UserAvatar = opponentAvatar,
                Name = "Victim"
            };
            var fightController = new FightController();
            var drawCardService = new DrawCardService(random);
            var stackCardGeneratorService = new StackCardGeneratorService();
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGeneratorService);
            var deckController = new DeckController(mock.Object);
            var makeActionController = new MakeActionController(game, fightController, prizeStackController, random, deckController, mock.Object, drawCardService);
            var helmet = new ItemCard("Helmet", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Helmet, null, 300);
            opponent.Deck.Items.Add(helmet);
            opponent.Deck.Items.Add(helmet);
            game.Users.Add(user);
            game.Users.Add(opponent);
            //Act
            makeActionController.UseSpecialPower(user, null);
            makeActionController.UseSpecialPower(user, null);
            //Assert
            opponent.Deck.Items.Count.Should().Be(1);
            user.Deck.Items.Should().HaveCount(1);
        }
    }
}
