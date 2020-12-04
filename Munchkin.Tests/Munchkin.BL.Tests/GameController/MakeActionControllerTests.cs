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
using Munchkin.Tests.Munchkin.BL.Tests.CardGenerator;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Munchkin.Tests.Munchkin.BL.Tests.GameController
{
    public class MakeActionControllerTests
    {
        [Fact]
        public void DeadEndOnlyOneMonster()
        {
            //Arrange
            var game = new Game();
            var fighFightController = new FightController();
            var makeActionController = new MakeActionController(game, fighFightController);
            var antArmy = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 5,
                HowManyLevels = 1,
                NumberOfPrizes = 2
            };
            var fight = new Fight();
            var user = new UserClass();
            var user2 = new UserClass();
            var userAvatar = new UserAvatar()
            {
                Power = 5,
                FleeChances = 3
            };
            var userAvatar2 = new UserAvatar()
            {
                Power = 4,
                FleeChances = 2
            };
            user.UserAvatar = userAvatar;
            user2.UserAvatar = userAvatar2;
            fight.Heros.Add(user);
            fight.Heros.Add(user2);
            fight.Monsters.Add(antArmy);
            //Act
            makeActionController.DeadEnd(fight);
            //Assert
            user.UserAvatar.Nerfs.FleeChances.Should().HaveCount(1);
            user.UserAvatar.Nerfs.FleeChances[0].Should().Be(1);
            user2.UserAvatar.Nerfs.FleeChances.Should().HaveCount(1);
            user2.UserAvatar.Nerfs.FleeChances[0].Should().Be(1);
        }

        [Fact]
        public void DeadEndTwoMonster()
        {
            //Arrange
            var game = new Game();
            var fighFightController = new FightController();
            var makeActionController = new MakeActionController(game, fighFightController);
            var antArmy = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 5,
                HowManyLevels = 1,
                NumberOfPrizes = 2
            };
            var antArmy2 = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 5,
                HowManyLevels = 1,
                NumberOfPrizes = 2
            };
            var fight = new Fight();
            var user = new UserClass();
            var user2 = new UserClass();
            var userAvatar = new UserAvatar()
            {
                Power = 5,
                FleeChances = 3
            };
            var userAvatar2 = new UserAvatar()
            {
                Power = 4,
                FleeChances = 2
            };
            user.UserAvatar = userAvatar;
            user2.UserAvatar = userAvatar2;
            fight.Heros.Add(user);
            fight.Heros.Add(user2);
            fight.Monsters.Add(antArmy);
            fight.Monsters.Add(antArmy2);
            //Act
            makeActionController.DeadEnd(fight);
            //Assert
            user.UserAvatar.Nerfs.FleeChances.Should().HaveCount(2);
            user.UserAvatar.Nerfs.FleeChances[0].Should().Be(1);
            user.UserAvatar.Nerfs.FleeChances[1].Should().Be(1);
            user2.UserAvatar.Nerfs.FleeChances.Should().HaveCount(2);
            user2.UserAvatar.Nerfs.FleeChances[0].Should().Be(1);
            user2.UserAvatar.Nerfs.FleeChances[1].Should().Be(1);
        }

        [Fact]
        public void GetPrizesOneHero()
        {
            //Arrange
            var random = new Random();
            var drawCardService = new DrawCardService(random);
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var stackCardGeneratorService = new StackCardGeneratorService();
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGeneratorService);
            var user = new UserClass();
            var fight = new Fight();
            var fightController = new FightController();
            var game = new Game();
            var antArmy = new AntArmy("Ant Army", CardType.Monster)
            {
                NumberOfPrizes = 2
            };
            var antArmy2 = new AntArmy("Ant Army", CardType.Monster)
            {
                NumberOfPrizes = 3
            };
            var makeActionController = new MakeActionController(game, fightController, prizeStackController, mock.Object);
            fight.Monsters.Add(antArmy);
            fight.Monsters.Add(antArmy2);
            fight.Heros.Add(user);
            prizeStackController.DrawCardsForStartDeck(user);
            //Act
            makeActionController.GetPrizes(fight);
            //Assert
            user.Deck.Items.Should().HaveCount(10);
        }

        [Fact]
        public void GetPrizesTwoHero()
        {
            //Arrange
            var random = new Random();
            var drawCardService = new DrawCardService(random);
            var stackCardGeneratorService = new StackCardGeneratorService();
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGeneratorService);
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var user = new UserClass();
            var user2 = new UserClass();
            var fight = new Fight();
            var fightController = new FightController();
            var game = new Game();
            var antArmy = new AntArmy("Ant Army", CardType.Monster)
            {
                NumberOfPrizes = 2
            };
            var antArmy2 = new AntArmy("Ant Army", CardType.Monster)
            {
                NumberOfPrizes = 3
            };
            var makeActionController = new MakeActionController(game, fightController, prizeStackController, mock.Object);
            fight.Monsters.Add(antArmy);
            fight.Monsters.Add(antArmy2);
            fight.Heros.Add(user);
            fight.Heros.Add(user2);
            prizeStackController.DrawCardsForStartDeck(user);
            prizeStackController.DrawCardsForStartDeck(user2);
            //Act
            makeActionController.GetPrizes(fight);
            //Assert
            user.Deck.Items.Should().HaveCount(8);
            user2.Deck.Items.Should().HaveCount(7);
        }

        [Fact]
        public void GetPrizesThreeHero()
        {
            //Arrange
            var random = new Random();
            var drawCardService = new DrawCardService(random);
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var stackCardGeneratorService = new StackCardGeneratorService();
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGeneratorService);
            var user = new UserClass();
            var user2 = new UserClass();
            var user3 = new UserClass();
            var fight = new Fight();
            var fightController = new FightController();
            var game = new Game();
            var antArmy = new AntArmy("Ant Army", CardType.Monster)
            {
                NumberOfPrizes = 2
            };
            var antArmy2 = new AntArmy("Ant Army", CardType.Monster)
            {
                NumberOfPrizes = 2
            };
            var makeActionController = new MakeActionController(game, fightController, prizeStackController, mock.Object);
            fight.Monsters.Add(antArmy);
            fight.Monsters.Add(antArmy2);
            fight.Heros.Add(user);
            fight.Heros.Add(user2);
            fight.Heros.Add(user3);
            prizeStackController.DrawCardsForStartDeck(user);
            prizeStackController.DrawCardsForStartDeck(user2);
            prizeStackController.DrawCardsForStartDeck(user3);
            //Act
            makeActionController.GetPrizes(fight);
            //Assert
            user.Deck.Items.Should().HaveCount(7);
            user2.Deck.Items.Should().HaveCount(6);
            user3.Deck.Items.Should().HaveCount(6);
        }

        [Fact]
        public void FleeTestTrueEqualToSix()
        {
            //Arrange
            var mockRandom = new Mock<Random>();
            var random = new Random();
            var game = new Game();
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var drawCardService = new DrawCardService(random);
            var fightController = new FightController();
            var stackCardGeneratorService = new StackCardGeneratorService();
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGeneratorService);
            var makeActionController = new MakeActionController(game, fightController, prizeStackController, mockRandom.Object);
            mockRandom.Setup(x => x.Next(6)).Returns(2);
            //Act
            var result = makeActionController.Flee(user);
            //Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void FleeTestFalse()
        {
            //Arrange
            var mockRandom = new Mock<Random>();
            var random = new Random();
            var game = new Game();
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var drawCardService = new DrawCardService(random);
            var fightController = new FightController();
            var stackCardGeneratorService = new StackCardGeneratorService();
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGeneratorService);
            var makeActionController = new MakeActionController(game, fightController, prizeStackController, mockRandom.Object);
            mockRandom.Setup(x => x.Next(6)).Returns(1);
            //Act
            var result = makeActionController.Flee(user);
            //Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void FleeTestTrueMoreThanSix()
        {
            //Arrange
            var mockRandom = new Mock<Random>();
            var random = new Random();
            var game = new Game();
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var drawCardService = new DrawCardService(random);
            var fightController = new FightController();
            var stackCardGeneratorService = new StackCardGeneratorService();
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGeneratorService);
            var makeActionController = new MakeActionController(game, fightController, prizeStackController, mockRandom.Object);
            mockRandom.Setup(x => x.Next(6)).Returns(3);
            //Act
            var result = makeActionController.Flee(user);
            //Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void SellItemTestsSuccess()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
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
            var sellItemController = new SellItemController(deckController, mock.Object);
            var makeActionController = new MakeActionController(game, fightController, prizeStackController, random, deckController, mock.Object, drawCardService, sellItemController);
            var helmet = new ItemCard("Helmet", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Helmet, null, 300);
            user.Deck.Items.Add(helmet);
            //Act
            makeActionController.SellItem(user);
            //Assert
            user.Deck.Items.Should().HaveCount(0);
            user.UserAvatar.Level.Should().Be(1);
            user.UserAvatar.Wallet.Should().Be(300);
        }

        [Fact]
        public void SellItemTestsSuccessAndNextLevel()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
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
            var sellItemController = new SellItemController(deckController, mock.Object);
            var makeActionController = new MakeActionController(game, fightController, prizeStackController, random, deckController, mock.Object, drawCardService, sellItemController);
            var helmet = new ItemCard("Helmet", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Helmet, null, 1000);
            user.Deck.Items.Add(helmet);
            //Act
            makeActionController.SellItem(user);
            //Assert
            user.Deck.Items.Should().HaveCount(0);
            user.UserAvatar.Level.Should().Be(2);
            user.UserAvatar.Wallet.Should().Be(0);
        }

        [Fact]
        public void SellItemTestsFail()
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
            var sellItemController = new SellItemController(deckController, mock.Object);
            var makeActionController = new MakeActionController(game, fightController, prizeStackController, random, deckController, mock.Object, drawCardService, sellItemController);
            var helmet = new ItemCard("Helmet", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Helmet, null, 300);
            user.Deck.Items.Add(helmet);
            //Act
            makeActionController.SellItem(user);
            //Assert
            user.Deck.Items.Should().HaveCount(1);
            user.UserAvatar.Level.Should().Be(1);
            user.UserAvatar.Wallet.Should().Be(0);
        }

        [Fact]
        public void SellItemTestsEmptyDeck()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
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
            var sellItemController = new SellItemController(deckController, mock.Object);
            var makeActionController = new MakeActionController(game, fightController, prizeStackController, random, deckController, mock.Object, drawCardService, sellItemController);
            //Act
            makeActionController.SellItem(user);
            //Assert
            user.Deck.Items.Should().HaveCount(0);
            user.UserAvatar.Level.Should().Be(1);
            user.UserAvatar.Wallet.Should().Be(0);
        }

        [Fact]
        public void UseSituationalCardTestNoFight()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
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
            var sellItemController = new SellItemController(deckController, mock.Object);
            var makeActionController = new MakeActionController(game,
                                                                fightController,
                                                                prizeStackController,
                                                                random,
                                                                deckController,
                                                                mock.Object,
                                                                drawCardService,
                                                                sellItemController);
            var card = new GoldenApple("GoldenApple",
                                                        CardType.Special,
                                                        PrizeCardType.Sitiuational,
                                                        0,
                                                        null,
                                                        false,
                                                        ItemType.Sitiuational,
                                                        null,
                                                        500);
            user.Deck.Items.Add(card);
            //Act
            makeActionController.UseSituationalCard(user, null);
            //Assert
            user.Deck.Items.Should().HaveCount(1);
        }

        [Fact]
        public void UseSituationalCardTestUsedCard()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
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
            var sellItemController = new SellItemController(deckController, mock.Object);
            var makeActionController = new MakeActionController(game,
                                                                fightController,
                                                                prizeStackController,
                                                                random,
                                                                deckController,
                                                                mock.Object,
                                                                drawCardService,
                                                                sellItemController);
            var card = new GoldenApple("GoldenApple",
                                                       CardType.Special,
                                                       PrizeCardType.Sitiuational,
                                                       0,
                                                       null,
                                                       false,
                                                       ItemType.Sitiuational,
                                                       null,
                                                       500);
            var antArmy = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 5,
                HowManyLevels = 1,
                NumberOfPrizes = 2
            };
            var fight = new Fight();
            fight.Heros.Add(user);
            fight.Monsters.Add(antArmy);
            user.Deck.Items.Add(card);
            user.UserAvatar.CountPower();
            //Act
            makeActionController.UseSituationalCard(user, fight);
            //Assert
            user.UserAvatar.Power.Should().Be(6);
            user.UserAvatar.Nerfs.Poisoned.Should().HaveCount(1);
            user.Deck.Items.Should().HaveCount(0);
        }

        [Fact]
        public void UseSituationalCardTestNoCards()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
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
            var sellItemController = new SellItemController(deckController, mock.Object);
            var makeActionController = new MakeActionController(game,
                                                                fightController,
                                                                prizeStackController,
                                                                random,
                                                                deckController,
                                                                mock.Object,
                                                                drawCardService,
                                                                sellItemController);
            var antArmy = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 5,
                HowManyLevels = 1,
                NumberOfPrizes = 2
            };
            var fight = new Fight();
            fight.Heros.Add(user);
            fight.Monsters.Add(antArmy);
            user.UserAvatar.CountPower();
            //Act
            makeActionController.UseSituationalCard(user, fight);
            //Assert
            user.UserAvatar.Power.Should().Be(1);
            user.UserAvatar.Nerfs.Poisoned.Should().HaveCount(0);
            user.Deck.Items.Should().HaveCount(0);
        }

        [Fact]
        public void UseSituationalCardTestTwoCardsUseFirstOne()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
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
            var sellItemController = new SellItemController(deckController, mock.Object);
            var makeActionController = new MakeActionController(game,
                                                                fightController,
                                                                prizeStackController,
                                                                random,
                                                                deckController,
                                                                mock.Object,
                                                                drawCardService,
                                                                sellItemController);
            var antArmy = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 5,
                HowManyLevels = 1,
                NumberOfPrizes = 2
            };
            var card = new GoldenApple("GoldenApple",
                                                      CardType.Special,
                                                      PrizeCardType.Sitiuational,
                                                      0,
                                                      null,
                                                      false,
                                                      ItemType.Sitiuational,
                                                      null,
                                                      500);
            var secondCard = new FireBall("FireBall",
                                          CardType.Special,
                                          PrizeCardType.Sitiuational,
                                          0,
                                          null,
                                          false,
                                          ItemType.Sitiuational,
                                          null,
                                          400);
            var fight = new Fight();
            fight.Heros.Add(user);
            fight.Monsters.Add(antArmy);
            user.UserAvatar.CountPower();
            user.Deck.Items.Add(card);
            user.Deck.Items.Add(secondCard);
            //Act
            makeActionController.UseSituationalCard(user, fight);
            //Assert
            user.UserAvatar.Power.Should().Be(6);
            user.UserAvatar.Nerfs.Poisoned.Should().HaveCount(1);
            user.Deck.Items.Should().HaveCount(1);
        }

        [Fact]
        public void UseSituationalCardTestTwoCardsUseSecondOne()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns(new Queue<string>(new[] { "2", "2", "1", "1", "1", "1" }).Dequeue);
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
            var sellItemController = new SellItemController(deckController, mock.Object);
            var makeActionController = new MakeActionController(game,
                                                                fightController,
                                                                prizeStackController,
                                                                random,
                                                                deckController,
                                                                mock.Object,
                                                                drawCardService,
                                                                sellItemController);
            var antArmy = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 5,
                HowManyLevels = 1,
                NumberOfPrizes = 2
            };
            var card = new GoldenApple("GoldenApple",
                                                      CardType.Special,
                                                      PrizeCardType.Sitiuational,
                                                      0,
                                                      null,
                                                      false,
                                                      ItemType.Sitiuational,
                                                      null,
                                                      500);
            var secondCard = new FireBall("FireBall",
                                          CardType.Special,
                                          PrizeCardType.Sitiuational,
                                          0,
                                          null,
                                          false,
                                          ItemType.Sitiuational,
                                          null,
                                          400);
            var fight = new Fight();
            fight.Heros.Add(user);
            fight.Monsters.Add(antArmy);
            user.UserAvatar.CountPower();
            user.Deck.Items.Add(card);
            user.Deck.Items.Add(secondCard);
            //Act
            makeActionController.UseSituationalCard(user, fight);
            //Assert
            user.UserAvatar.Power.Should().Be(4);
            user.UserAvatar.Nerfs.Poisoned.Should().HaveCount(0);
            user.Deck.Items.Should().HaveCount(1);
        }

        [Fact]
        public void UseSituationalCardTestAbort()
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
            var sellItemController = new SellItemController(deckController, mock.Object);
            var makeActionController = new MakeActionController(game,
                                                                fightController,
                                                                prizeStackController,
                                                                random,
                                                                deckController,
                                                                mock.Object,
                                                                drawCardService,
                                                                sellItemController);
            var antArmy = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 5,
                HowManyLevels = 1,
                NumberOfPrizes = 2
            };
            var card = new GoldenApple("GoldenApple",
                                                      CardType.Special,
                                                      PrizeCardType.Sitiuational,
                                                      0,
                                                      null,
                                                      false,
                                                      ItemType.Sitiuational,
                                                      null,
                                                      500);
            var fight = new Fight();
            fight.Heros.Add(user);
            fight.Monsters.Add(antArmy);
            user.UserAvatar.CountPower();
            user.Deck.Items.Add(card);
            //Act
            makeActionController.UseSituationalCard(user, fight);
            //Assert
            user.UserAvatar.Power.Should().Be(1);
            user.Deck.Items.Should().HaveCount(1);
        }

        [Fact]
        public void JoinFightTestSuccess()
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
            var sellItemController = new SellItemController(deckController, mock.Object);
            var makeActionController = new MakeActionController(game,
                                                                fightController,
                                                                prizeStackController,
                                                                random,
                                                                deckController,
                                                                mock.Object,
                                                                drawCardService,
                                                                sellItemController);
            var antArmy = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 5,
                HowManyLevels = 1,
                NumberOfPrizes = 2
            };
            var userAvatar2 = new UserAvatar
            {
                Level = 1
            };
            var userToJoin = new UserClass()
            {
                UserAvatar = userAvatar2
            };
            var fight = new Fight();
            fight.Heros.Add(user);
            fight.Monsters.Add(antArmy);
            //Act
            makeActionController.JoinToFight(userToJoin, fight);
            //Assert
            fight.Heros.Should().HaveCount(2);
            fight.Monsters.Should().HaveCount(1);
        }

        [Fact]
        public void AskForHelpOnePlayerJoin()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
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
            var sellItemController = new SellItemController(deckController, mock.Object);
            var makeActionController = new MakeActionController(game,
                                                                fightController,
                                                                prizeStackController,
                                                                random,
                                                                deckController,
                                                                mock.Object,
                                                                drawCardService,
                                                                sellItemController);
            var antArmy = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 5,
                HowManyLevels = 1,
                NumberOfPrizes = 2
            };
            var userAvatar2 = new UserAvatar
            {
                Level = 1
            };
            var userToJoin = new UserClass()
            {
                UserAvatar = userAvatar2
            };
            var fight = new Fight();
            game.Users.Add(user);
            game.Users.Add(userToJoin);
            fight.Heros.Add(user);
            fight.Monsters.Add(antArmy);
            //Act
            makeActionController.AskForHelp(user, fight);
            //Assert
            fight.Heros.Should().HaveCount(2);
            fight.Monsters.Should().HaveCount(1);
            game.Users.Count.Should().Be(2);
        }

        [Fact]
        public void AskForHelpAllPlayersJoin()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
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
            var sellItemController = new SellItemController(deckController, mock.Object);
            var makeActionController = new MakeActionController(game,
                                                                fightController,
                                                                prizeStackController,
                                                                random,
                                                                deckController,
                                                                mock.Object,
                                                                drawCardService,
                                                                sellItemController);
            var antArmy = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 5,
                HowManyLevels = 1,
                NumberOfPrizes = 2
            };
            var userAvatar2 = new UserAvatar
            {
                Level = 1
            };
            var userToJoin = new UserClass()
            {
                UserAvatar = userAvatar2
            };
            var userAvatar3 = new UserAvatar
            {
                Level = 1
            };
            var userToJoin2 = new UserClass()
            {
                UserAvatar = userAvatar2
            };
            var fight = new Fight();
            game.Users.Add(user);
            game.Users.Add(userToJoin);
            game.Users.Add(userToJoin2);
            fight.Heros.Add(user);
            fight.Monsters.Add(antArmy);
            //Act
            makeActionController.AskForHelp(user, fight);
            //Assert
            fight.Heros.Should().HaveCount(3);
            fight.Monsters.Should().HaveCount(1);
            game.Users.Count.Should().Be(3);
        }

        [Fact]
        public void AskForHelpFirstPlayerJoin()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns(new Queue<string>(new[] { "1", "2", "2", "2", "2" }).Dequeue);
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
            var sellItemController = new SellItemController(deckController, mock.Object);
            var makeActionController = new MakeActionController(game,
                                                                fightController,
                                                                prizeStackController,
                                                                random,
                                                                deckController,
                                                                mock.Object,
                                                                drawCardService,
                                                                sellItemController);
            var antArmy = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 5,
                HowManyLevels = 1,
                NumberOfPrizes = 2
            };
            var userAvatar2 = new UserAvatar
            {
                Level = 1
            };
            var userToJoin = new UserClass()
            {
                UserAvatar = userAvatar2
            };
            var userAvatar3 = new UserAvatar
            {
                Level = 1
            };
            var userToJoin2 = new UserClass()
            {
                UserAvatar = userAvatar2
            };
            var fight = new Fight();
            game.Users.Add(user);
            game.Users.Add(userToJoin);
            game.Users.Add(userToJoin2);
            fight.Heros.Add(user);
            fight.Monsters.Add(antArmy);
            //Act
            makeActionController.AskForHelp(user, fight);
            //Assert
            fight.Heros.Should().HaveCount(2);
            fight.Monsters.Should().HaveCount(1);
            game.Users.Count.Should().Be(3);
        }

        [Fact]
        public void AskForHelpSecondPlayerJoin()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns(new Queue<string>(new[] { "2", "2", "1", "2", "2" }).Dequeue);
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
            var sellItemController = new SellItemController(deckController, mock.Object);
            var makeActionController = new MakeActionController(game,
                                                                fightController,
                                                                prizeStackController,
                                                                random,
                                                                deckController,
                                                                mock.Object,
                                                                drawCardService,
                                                                sellItemController);
            var antArmy = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 5,
                HowManyLevels = 1,
                NumberOfPrizes = 2
            };
            var userAvatar2 = new UserAvatar
            {
                Level = 1
            };
            var userToJoin = new UserClass()
            {
                UserAvatar = userAvatar2
            };
            var userAvatar3 = new UserAvatar
            {
                Level = 1
            };
            var userToJoin2 = new UserClass()
            {
                UserAvatar = userAvatar2
            };
            var fight = new Fight();
            game.Users.Add(user);
            game.Users.Add(userToJoin);
            game.Users.Add(userToJoin2);
            fight.Heros.Add(user);
            fight.Monsters.Add(antArmy);
            //Act
            makeActionController.AskForHelp(user, fight);
            //Assert
            fight.Heros.Should().HaveCount(2);
            fight.Monsters.Should().HaveCount(1);
            game.Users.Count.Should().Be(3);
        }

        [Fact]
        public void UseMonsterCardThereIsNoFight()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
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
            var sellItemController = new SellItemController(deckController, mock.Object);
            var makeActionController = new MakeActionController(game,
                                                                fightController,
                                                                prizeStackController,
                                                                random,
                                                                deckController,
                                                                mock.Object,
                                                                drawCardService,
                                                                sellItemController);
            var antArmy = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 5,
                HowManyLevels = 1,
                NumberOfPrizes = 2,
                Undead = true
            };
            user.Deck.Monsters.Add(antArmy);
            //Act
            makeActionController.UseMonsterCard(user, null);
            //Assert
            user.Deck.Monsters.Count.Should().Be(1);
            user.Deck.Monsters[0].Should().BeSameAs(antArmy);
        }

        [Fact]
        public void UseMonsterCardAddUndeadMonster()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
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
            var sellItemController = new SellItemController(deckController, mock.Object);
            var makeActionController = new MakeActionController(game,
                                                                fightController,
                                                                prizeStackController,
                                                                random,
                                                                deckController,
                                                                mock.Object,
                                                                drawCardService,
                                                                sellItemController);
            var antArmy = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 5,
                HowManyLevels = 1,
                NumberOfPrizes = 2,
                Undead = true
            };
            user.Deck.Monsters.Add(antArmy);
            var fight = new Fight();
            //Act
            makeActionController.UseMonsterCard(user, fight);
            //Assert
            user.Deck.Monsters.Count.Should().Be(0);
            fight.Monsters.Should().HaveCount(1);
            fight.Monsters[0].Should().BeSameAs(antArmy);
        }

        [Fact]
        public void UseMonsterCardTwoUndeadMonsterInDeckAddFirstOne()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
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
            var sellItemController = new SellItemController(deckController, mock.Object);
            var makeActionController = new MakeActionController(game,
                                                                fightController,
                                                                prizeStackController,
                                                                random,
                                                                deckController,
                                                                mock.Object,
                                                                drawCardService,
                                                                sellItemController);
            var antArmy = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 5,
                HowManyLevels = 1,
                NumberOfPrizes = 2,
                Undead = true
            };
            var cerber = new Cerber("Cerber", CardType.Monster)
            {
                Power = 5,
                HowManyLevels = 1,
                NumberOfPrizes = 2,
                Undead = true
            };
            user.Deck.Monsters.Add(antArmy);
            user.Deck.Monsters.Add(cerber);
            var fight = new Fight();
            //Act
            makeActionController.UseMonsterCard(user, fight);
            //Assert
            user.Deck.Monsters.Count.Should().Be(1);
            fight.Monsters.Should().HaveCount(1);
            fight.Monsters[0].Should().BeSameAs(antArmy);
        }

        [Fact]
        public void UseMonsterCardTwoUndeadMonsterInDeckAddSecond()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("2");
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
            var sellItemController = new SellItemController(deckController, mock.Object);
            var makeActionController = new MakeActionController(game,
                                                                fightController,
                                                                prizeStackController,
                                                                random,
                                                                deckController,
                                                                mock.Object,
                                                                drawCardService,
                                                                sellItemController);
            var antArmy = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 5,
                HowManyLevels = 1,
                NumberOfPrizes = 2,
                Undead = true
            };
            var cerber = new Cerber("Cerber", CardType.Monster)
            {
                Power = 5,
                HowManyLevels = 1,
                NumberOfPrizes = 2,
                Undead = true
            };
            user.Deck.Monsters.Add(antArmy);
            user.Deck.Monsters.Add(cerber);
            var fight = new Fight();
            //Act
            makeActionController.UseMonsterCard(user, fight);
            //Assert
            user.Deck.Monsters.Count.Should().Be(1);
            fight.Monsters.Should().HaveCount(1);
            fight.Monsters[0].Should().BeSameAs(cerber);
        }

        [Fact]
        public void UseMonsterCardNormalMonsterNoAdditionalMonsterMagicCard()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
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
            var sellItemController = new SellItemController(deckController, mock.Object);
            var makeActionController = new MakeActionController(game,
                                                                fightController,
                                                                prizeStackController,
                                                                random,
                                                                deckController,
                                                                mock.Object,
                                                                drawCardService,
                                                                sellItemController);
            var antArmy = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 5,
                HowManyLevels = 1,
                NumberOfPrizes = 2,
            };
            user.Deck.Monsters.Add(antArmy);
            var fight = new Fight();
            //Act
            makeActionController.UseMonsterCard(user, fight);
            //Assert
            user.Deck.Monsters.Count.Should().Be(1);
            user.Deck.Monsters[0].Should().BeSameAs(antArmy);
            fight.Monsters.Should().HaveCount(0);
        }

        [Fact]
        public void UseMonsterCardNormalMonsterAndMagicCard()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
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
            var sellItemController = new SellItemController(deckController, mock.Object);
            var makeActionController = new MakeActionController(game,
                                                                fightController,
                                                                prizeStackController,
                                                                random,
                                                                deckController,
                                                                mock.Object,
                                                                drawCardService,
                                                                sellItemController);
            var antArmy = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 5,
                HowManyLevels = 1,
                NumberOfPrizes = 2,
            };
            var addMonster = new AdditionalMonster("AdditionalMonster", CardType.Special, mock.Object);
            user.Deck.Monsters.Add(antArmy);
            user.Deck.MagicCards.Add(addMonster);
            var fight = new Fight();
            //Act
            makeActionController.UseMonsterCard(user, fight);
            //Assert
            user.Deck.Monsters.Count.Should().Be(0);
            user.Deck.MagicCards.Count.Should().Be(0);
            fight.Monsters.Should().HaveCount(1);
            fight.Monsters[0].Should().BeSameAs(antArmy);
            game.DestroyedActionCards.Should().HaveCount(1);
            game.DestroyedActionCards[0].Should().Be(addMonster);
        }

        [Fact]
        public void UseMonsterCardTwoNormalMonsterAndMagicCardAddedFirst()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
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
            var sellItemController = new SellItemController(deckController, mock.Object);
            var makeActionController = new MakeActionController(game,
                                                                fightController,
                                                                prizeStackController,
                                                                random,
                                                                deckController,
                                                                mock.Object,
                                                                drawCardService,
                                                                sellItemController);
            var antArmy = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 5,
                HowManyLevels = 1,
                NumberOfPrizes = 2,
            };
            var cerber = new Cerber("Cerber", CardType.Monster)
            {
                Power = 5,
                HowManyLevels = 1,
                NumberOfPrizes = 2,
                Undead = true
            };
            var addMonster = new AdditionalMonster("AdditionalMonster", CardType.Special, mock.Object);
            user.Deck.Monsters.Add(antArmy);
            user.Deck.Monsters.Add(cerber);
            user.Deck.MagicCards.Add(addMonster);
            var fight = new Fight();
            //Act
            makeActionController.UseMonsterCard(user, fight);
            //Assert
            user.Deck.Monsters.Count.Should().Be(1);
            user.Deck.Monsters[0].Should().BeSameAs(cerber);
            user.Deck.MagicCards.Count.Should().Be(0);
            fight.Monsters.Should().HaveCount(1);
            fight.Monsters[0].Should().BeSameAs(antArmy);
            game.DestroyedActionCards.Should().HaveCount(1);
            game.DestroyedActionCards[0].Should().Be(addMonster);
        }

        [Fact]
        public void UseMonsterCardNormalMonsterAndMagicCardAddedSecond()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("2");
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
            var sellItemController = new SellItemController(deckController, mock.Object);
            var makeActionController = new MakeActionController(game,
                                                                fightController,
                                                                prizeStackController,
                                                                random,
                                                                deckController,
                                                                mock.Object,
                                                                drawCardService,
                                                                sellItemController);
            var antArmy = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 5,
                HowManyLevels = 1,
                NumberOfPrizes = 2,
            };
            var cerber = new Cerber("Cerber", CardType.Monster)
            {
                Power = 5,
                HowManyLevels = 1,
                NumberOfPrizes = 2
            };
            var addMonster = new AdditionalMonster("AdditionalMonster", CardType.Special, mock.Object);
            user.Deck.Monsters.Add(antArmy);
            user.Deck.Monsters.Add(cerber);
            user.Deck.MagicCards.Add(addMonster);
            var fight = new Fight();
            //Act
            makeActionController.UseMonsterCard(user, fight);
            //Assert
            user.Deck.Monsters.Count.Should().Be(1);
            user.Deck.Monsters[0].Should().BeSameAs(antArmy);
            user.Deck.MagicCards.Count.Should().Be(0);
            fight.Monsters.Should().HaveCount(1);
            fight.Monsters[0].Should().BeSameAs(cerber);
            game.DestroyedActionCards.Should().HaveCount(1);
            game.DestroyedActionCards[0].Should().Be(addMonster);
        }

        [Fact]
        public void UseMonsterCardTryToAddTwoMonsterOnlyOneMagicCard()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
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
            var sellItemController = new SellItemController(deckController, mock.Object);
            var makeActionController = new MakeActionController(game,
                                                                fightController,
                                                                prizeStackController,
                                                                random,
                                                                deckController,
                                                                mock.Object,
                                                                drawCardService,
                                                                sellItemController);
            var antArmy = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 5,
                HowManyLevels = 1,
                NumberOfPrizes = 2,
                Undead = false
            };
            var cerber = new Cerber("Cerber", CardType.Monster)
            {
                Power = 5,
                HowManyLevels = 1,
                NumberOfPrizes = 2,
                Undead = false
            };
            var addMonster = new AdditionalMonster("AdditionalMonster", CardType.Special, mock.Object);
            user.Deck.Monsters.Add(antArmy);
            user.Deck.Monsters.Add(cerber);
            user.Deck.MagicCards.Add(addMonster);
            var fight = new Fight();
            //Act
            makeActionController.UseMonsterCard(user, fight);
            makeActionController.UseMonsterCard(user, fight);
            //Assert
            user.Deck.Monsters.Count.Should().Be(1);
            user.Deck.Monsters[0].Should().BeSameAs(cerber);
            user.Deck.MagicCards.Count.Should().Be(0);
            fight.Monsters.Should().HaveCount(1);
            fight.Monsters[0].Should().BeSameAs(antArmy);
            game.DestroyedActionCards.Should().HaveCount(1);
            game.DestroyedActionCards[0].Should().Be(addMonster);
        }

        [Fact]
        public void UseMonsterCardTryToAddTwoMonsterTwoMagicCard()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
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
            var sellItemController = new SellItemController(deckController, mock.Object);
            var makeActionController = new MakeActionController(game,
                                                                fightController,
                                                                prizeStackController,
                                                                random,
                                                                deckController,
                                                                mock.Object,
                                                                drawCardService,
                                                                sellItemController);
            var antArmy = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 5,
                HowManyLevels = 1,
                NumberOfPrizes = 2,
                Undead = false
            };
            var cerber = new Cerber("Cerber", CardType.Monster)
            {
                Power = 5,
                HowManyLevels = 1,
                NumberOfPrizes = 2,
                Undead = false
            };
            var addMonster = new AdditionalMonster("AdditionalMonster", CardType.Special, mock.Object);
            user.Deck.Monsters.Add(antArmy);
            user.Deck.Monsters.Add(cerber);
            user.Deck.MagicCards.Add(addMonster);
            user.Deck.MagicCards.Add(addMonster);
            var fight = new Fight();
            //Act
            makeActionController.UseMonsterCard(user, fight);
            makeActionController.UseMonsterCard(user, fight);
            //Assert
            user.Deck.Monsters.Count.Should().Be(0);
            user.Deck.MagicCards.Count.Should().Be(0);
            fight.Monsters.Should().HaveCount(2);
            game.DestroyedActionCards.Should().HaveCount(2);
        }

        [Fact]
        public void UseMonsterCardThereAreNoMonsters()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
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
            var sellItemController = new SellItemController(deckController, mock.Object);
            var makeActionController = new MakeActionController(game,
                                                                fightController,
                                                                prizeStackController,
                                                                random,
                                                                deckController,
                                                                mock.Object,
                                                                drawCardService,
                                                                sellItemController);
            var addMonster = new AdditionalMonster("AdditionalMonster", CardType.Special, mock.Object);
            user.Deck.MagicCards.Add(addMonster);
            var fight = new Fight();
            //Act
            makeActionController.UseMonsterCard(user, fight);
            //Assert
            user.Deck.Monsters.Count.Should().Be(0);
            user.Deck.MagicCards.Count.Should().Be(1);
            fight.Monsters.Should().HaveCount(0);
            game.DestroyedActionCards.Should().HaveCount(0);
        }

        [Fact]
        public void UseMagicCardOnUserUsedOnEnemy()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var random = new Random();
            var game = new Game();
            var userAvatar = new UserAvatar
            {
                Level = 1
            };
            var user = new UserClass()
            {
                Name = "user",
                UserAvatar = userAvatar
            };
            var fightController = new FightController();
            var drawCardService = new DrawCardService(random);
            var stackCardGeneratorService = new StackCardGeneratorService();
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGeneratorService);
            var deckController = new DeckController(mock.Object);
            var sellItemController = new SellItemController(deckController, mock.Object);
            var makeActionController = new MakeActionController(game,
                                                                fightController,
                                                                prizeStackController,
                                                                random,
                                                                deckController,
                                                                mock.Object,
                                                                drawCardService,
                                                                sellItemController);
            var userAvatar2 = new UserAvatar
            {
                Level = 2
            };
            var enemy = new UserClass()
            {
                UserAvatar = userAvatar2,
                Name = "enemy"
            };
            game.Users.Add(enemy);
            game.Users.Add(user);
            var curse = new BackToSchool("BackToSchool", CardType.Curse);
            //Act
            makeActionController.UseMagicCardOnUser(curse, user);
            //Assert
            enemy.UserAvatar.Level.Should().Be(1);
            user.UserAvatar.Level.Should().Be(1);
        }

        [Fact]
        public void UseMagicCardOnUserAbort()
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
                Name = "user",
                UserAvatar = userAvatar
            };
            var fightController = new FightController();
            var drawCardService = new DrawCardService(random);
            var stackCardGeneratorService = new StackCardGeneratorService();
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGeneratorService);
            var deckController = new DeckController(mock.Object);
            var sellItemController = new SellItemController(deckController, mock.Object);
            var makeActionController = new MakeActionController(game,
                                                                fightController,
                                                                prizeStackController,
                                                                random,
                                                                deckController,
                                                                mock.Object,
                                                                drawCardService,
                                                                sellItemController);
            var userAvatar2 = new UserAvatar
            {
                Level = 2
            };
            var enemy = new UserClass()
            {
                UserAvatar = userAvatar2,
                Name = "enemy"
            };
            game.Users.Add(enemy);
            game.Users.Add(user);
            var curse = new BackToSchool("BackToSchool", CardType.Curse);
            //Act
            makeActionController.UseMagicCardOnUser(curse, user);
            //Assert
            enemy.UserAvatar.Level.Should().Be(2);
            user.UserAvatar.Level.Should().Be(1);
        }

        [Fact]
        public void UseMagicCardOnUserUsedOnUser()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("2");
            var random = new Random();
            var game = new Game();
            var userAvatar = new UserAvatar
            {
                Level = 1
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar,
                Name = "user"
            };
            var fightController = new FightController();
            var drawCardService = new DrawCardService(random);
            var stackCardGeneratorService = new StackCardGeneratorService();
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGeneratorService);
            var deckController = new DeckController(mock.Object);
            var sellItemController = new SellItemController(deckController, mock.Object);
            var makeActionController = new MakeActionController(game,
                                                                fightController,
                                                                prizeStackController,
                                                                random,
                                                                deckController,
                                                                mock.Object,
                                                                drawCardService,
                                                                sellItemController);
            var userAvatar2 = new UserAvatar
            {
                Level = 2
            };
            var enemy = new UserClass()
            {
                UserAvatar = userAvatar2,
                Name = "enemy"
            };
            game.Users.Add(enemy);
            game.Users.Add(user);
            var curse = new BackToSchool("BackToSchool", CardType.Curse);
            //Act
            makeActionController.UseMagicCardOnUser(curse, user);
            //Assert
            enemy.UserAvatar.Level.Should().Be(2);
            user.UserAvatar.Level.Should().Be(0);
        }

        [Fact]
        public void UseMagicCardOnUsedOnSecondEnemy()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("3");
            var random = new Random();
            var game = new Game();
            var userAvatar = new UserAvatar
            {
                Level = 1
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar,
                Name = "user"
            };
            var fightController = new FightController();
            var drawCardService = new DrawCardService(random);
            var stackCardGeneratorService = new StackCardGeneratorService();
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGeneratorService);
            var deckController = new DeckController(mock.Object);
            var sellItemController = new SellItemController(deckController, mock.Object);
            var makeActionController = new MakeActionController(game,
                                                                fightController,
                                                                prizeStackController,
                                                                random,
                                                                deckController,
                                                                mock.Object,
                                                                drawCardService,
                                                                sellItemController);
            var userAvatar2 = new UserAvatar
            {
                Level = 2
            };
            var enemy = new UserClass()
            {
                UserAvatar = userAvatar2,
                Name = "enemy"
            };
            var userAvatar3 = new UserAvatar
            {
                Level = 3
            };
            var enemy2 = new UserClass()
            {
                UserAvatar = userAvatar3,
                Name = "Second"
            };
            game.Users.Add(enemy);
            game.Users.Add(user);
            game.Users.Add(enemy2);
            var curse = new BackToSchool("BackToSchool", CardType.Curse);
            //Act
            makeActionController.UseMagicCardOnUser(curse, user);
            //Assert
            enemy2.UserAvatar.Level.Should().Be(2);
            enemy.UserAvatar.Level.Should().Be(2);
            user.UserAvatar.Level.Should().Be(1);
        }


        [Fact]
        public void UseMagicCardNoMagicCard()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var random = new Random();
            var game = new Game();
            var userAvatar = new UserAvatar
            {
                Level = 1
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar,
                Name = "user"
            };
            var fightController = new FightController();
            var drawCardService = new DrawCardService(random);
            var stackCardGeneratorService = new StackCardGeneratorService();
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGeneratorService);
            var deckController = new DeckController(mock.Object);
            var sellItemController = new SellItemController(deckController, mock.Object);
            var makeActionController = new MakeActionController(game,
                                                                fightController,
                                                                prizeStackController,
                                                                random,
                                                                deckController,
                                                                mock.Object,
                                                                drawCardService,
                                                                sellItemController);
            //Act
            makeActionController.UseMagicCard(user);
            //Assert
            user.Deck.MagicCards.Count.Should().Be(0);
        }

        [Fact]
        public void UseMagicCardOneMagicCard()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
            var random = new Random();
            var game = new Game();
            var userAvatar = new UserAvatar
            {
                Level = 1
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar,
                Name = "user"
            };
            var fightController = new FightController();
            var drawCardService = new DrawCardService(random);
            var stackCardGeneratorService = new StackCardGeneratorService();
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGeneratorService);
            var deckController = new DeckController(mock.Object);
            var sellItemController = new SellItemController(deckController, mock.Object);
            var makeActionController = new MakeActionController(game,
                                                                fightController,
                                                                prizeStackController,
                                                                random,
                                                                deckController,
                                                                mock.Object,
                                                                drawCardService,
                                                                sellItemController);
            var userAvatar2 = new UserAvatar
            {
                Level = 2
            };
            var enemy = new UserClass()
            {
                UserAvatar = userAvatar2,
                Name = "enemy"
            };
            game.Users.Add(enemy);
            game.Users.Add(user);
            var curse = new BackToSchool("BackToSchool", CardType.Curse);
            user.Deck.MagicCards.Add(curse);
            //Act
            makeActionController.UseMagicCard(user);
            //Assert
            enemy.UserAvatar.Level.Should().Be(1);
            user.UserAvatar.Level.Should().Be(1);
            game.DestroyedActionCards.Should().HaveCount(1);
        }

        [Fact]
        public void UseMagicCardFewMagicCard()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns(new Queue<string>(new[] { "3", "3", "1", "1", "1", "1" }).Dequeue);
            var random = new Random();
            var game = new Game();
            var userAvatar = new UserAvatar
            {
                Level = 1
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar,
                Name = "user"
            };
            var fightController = new FightController();
            var drawCardService = new DrawCardService(random);
            var stackCardGeneratorService = new StackCardGeneratorService();
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGeneratorService);
            var deckController = new DeckController(mock.Object);
            var sellItemController = new SellItemController(deckController, mock.Object);
            var makeActionController = new MakeActionController(game,
                                                                fightController,
                                                                prizeStackController,
                                                                random,
                                                                deckController,
                                                                mock.Object,
                                                                drawCardService,
                                                                sellItemController);
            var userAvatar2 = new UserAvatar
            {
                Level = 2
            };
            var enemy = new UserClass()
            {
                UserAvatar = userAvatar2,
                Name = "enemy"
            };
            game.Users.Add(enemy);
            game.Users.Add(user);
            var curse = new BackToSchool("BackToSchool", CardType.Curse);
            var damageArmor = new DamagedArmor("Damaged Armor", CardType.Curse);
            var damageBoots = new DamagedBoots("Damaged Boots", CardType.Curse);
            user.Deck.MagicCards.Add(damageArmor);
            user.Deck.MagicCards.Add(damageBoots);
            user.Deck.MagicCards.Add(curse);
            //Act
            makeActionController.UseMagicCard(user);
            //Assert
            enemy.UserAvatar.Level.Should().Be(1);
            user.UserAvatar.Level.Should().Be(1);
            game.DestroyedActionCards.Should().HaveCount(1);
        }

        [Fact]
        public void UseMagicCardAbort()
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
                UserAvatar = userAvatar,
                Name = "user"
            };
            var fightController = new FightController();
            var drawCardService = new DrawCardService(random);
            var stackCardGeneratorService = new StackCardGeneratorService();
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGeneratorService);
            var deckController = new DeckController(mock.Object);
            var sellItemController = new SellItemController(deckController, mock.Object);
            var makeActionController = new MakeActionController(game,
                                                                fightController,
                                                                prizeStackController,
                                                                random,
                                                                deckController,
                                                                mock.Object,
                                                                drawCardService,
                                                                sellItemController);
            var userAvatar2 = new UserAvatar
            {
                Level = 2
            };
            var enemy = new UserClass()
            {
                UserAvatar = userAvatar2,
                Name = "enemy"
            };
            game.Users.Add(enemy);
            game.Users.Add(user);
            var curse = new BackToSchool("BackToSchool", CardType.Curse);
            user.Deck.MagicCards.Add(curse);
            //Act
            makeActionController.UseMagicCard(user);
            //Assert
            enemy.UserAvatar.Level.Should().Be(2);
            user.UserAvatar.Level.Should().Be(1);
            user.Deck.MagicCards.Should().HaveCount(1);
            game.DestroyedActionCards.Should().HaveCount(0);
        }

        [Fact]
        public void ChooseFightActionAbort()
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
                UserAvatar = userAvatar,
                Name = "user"
            };
            var fightController = new FightController();
            var drawCardService = new DrawCardService(random);
            var stackCardGeneratorService = new StackCardGeneratorService();
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGeneratorService);
            var deckController = new DeckController(mock.Object);
            var sellItemController = new SellItemController(deckController, mock.Object);
            var makeActionController = new MakeActionController(game,
                                                                fightController,
                                                                prizeStackController,
                                                                random,
                                                                deckController,
                                                                mock.Object,
                                                                drawCardService,
                                                                sellItemController);

            game.Users.Add(user);
            var curse = new BackToSchool("BackToSchool", CardType.Curse);
            user.Deck.MagicCards.Add(curse);
            var fight = new Fight();
            //Act
            makeActionController.ChooseFightAction(user, fight);
            //Assert
            user.UserAvatar.Level.Should().Be(1);
            user.Deck.MagicCards.Should().HaveCount(1);
            game.DestroyedActionCards.Should().HaveCount(0);
        }

        [Fact]
        public void ChooseFightActionAskForHelp()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns("1");
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
            var sellItemController = new SellItemController(deckController, mock.Object);
            var makeActionController = new MakeActionController(game,
                                                                fightController,
                                                                prizeStackController,
                                                                random,
                                                                deckController,
                                                                mock.Object,
                                                                drawCardService,
                                                                sellItemController);
            var antArmy = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 5,
                HowManyLevels = 1,
                NumberOfPrizes = 2
            };
            var userAvatar2 = new UserAvatar
            {
                Level = 1
            };
            var userToJoin = new UserClass()
            {
                UserAvatar = userAvatar2
            };
            var fight = new Fight();
            game.Users.Add(user);
            game.Users.Add(userToJoin);
            fight.Heros.Add(user);
            fight.Monsters.Add(antArmy);
            //Act
            makeActionController.ChooseFightAction(user, fight);
            //Assert
            fight.Heros.Should().HaveCount(2);
            fight.Monsters.Should().HaveCount(1);
            game.Users.Count.Should().Be(2);
        }

        [Fact]
        public void ChooseFightActionUseSituationalCard()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns(new Queue<string>(new[] { "2", "1", "1", "1", "1", "1", "1", "1", "1" }).Dequeue);
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
            var sellItemController = new SellItemController(deckController, mock.Object);
            var makeActionController = new MakeActionController(game,
                                                                fightController,
                                                                prizeStackController,
                                                                random,
                                                                deckController,
                                                                mock.Object,
                                                                drawCardService,
                                                                sellItemController);
            var card = new GoldenApple("GoldenApple",
                                                       CardType.Special,
                                                       PrizeCardType.Sitiuational,
                                                       0,
                                                       null,
                                                       false,
                                                       ItemType.Sitiuational,
                                                       null,
                                                       500);
            var antArmy = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 5,
                HowManyLevels = 1,
                NumberOfPrizes = 2
            };
            var fight = new Fight();
            fight.Heros.Add(user);
            fight.Monsters.Add(antArmy);
            user.Deck.Items.Add(card);
            user.UserAvatar.CountPower();
            //Act
            makeActionController.ChooseFightAction(user, fight);
            //Assert
            user.UserAvatar.Power.Should().Be(6);
            user.UserAvatar.Nerfs.Poisoned.Should().HaveCount(1);
            user.Deck.Items.Should().HaveCount(0);
        }

        [Fact]
        public void UseSpecialPowerWarriorTestFullDeckUsedThreeTimes()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns(new Queue<string>(new[] { "3", "1", "1", "1", "1", "1", "1", "1", "1" }).Dequeue);
            var random = new Random();
            var game = new Game();
            var fightController = new FightController();
            var drawCardService = new DrawCardService(random);
            var stackCardGeneratorService = new StackCardGeneratorService();
            var prizeStackController = new PrizeStackController(drawCardService, stackCardGeneratorService);
            var deckController = new DeckController(mock.Object);
            var sellItemController = new SellItemController(deckController, mock.Object);
            var makeActionController = new MakeActionController(game,
                                                                fightController,
                                                                prizeStackController,
                                                                random,
                                                                deckController,
                                                                mock.Object,
                                                                drawCardService,
                                                                sellItemController);
            var userAvatar = new UserAvatar
            {
                Level = 1,
                Proficiency = new WarriorProficiency(mock.Object)
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
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
            makeActionController.ChooseFightAction(user, fight);
            //Assert
            user.UserAvatar.TempPower.Should().Be(2);
            game.DestroyedPrizeCards.Should().HaveCount(1);
            user.Deck.Items.Count.Should().Be(4);
        }

        [Fact]
        public void ChooseFightActionUseMonsterCard()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns(new Queue<string>(new[] { "4", "1", "1", "1", "1", "1", "1", "1", "1" }).Dequeue);
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
            var sellItemController = new SellItemController(deckController, mock.Object);
            var makeActionController = new MakeActionController(game,
                                                                fightController,
                                                                prizeStackController,
                                                                random,
                                                                deckController,
                                                                mock.Object,
                                                                drawCardService,
                                                                sellItemController);
            var undead = new AntArmy("Undead", CardType.Monster)
            {
                Power = 1,
                HowManyLevels = 1,
                NumberOfPrizes = 1,
                Undead = true
            };
            var antArmy = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 5,
                HowManyLevels = 1,
                NumberOfPrizes = 2
            };
            user.Deck.Monsters.Add(undead);
            var fight = new Fight();
            fight.Heros.Add(user);
            fight.Monsters.Add(antArmy);
            user.UserAvatar.CountPower();
            //Act
            makeActionController.ChooseFightAction(user, fight);
            //Assert
            user.Deck.Monsters.Count.Should().Be(0);
            fight.Monsters.Should().HaveCount(2);
            fight.Monsters[1].Should().BeSameAs(undead);
        }

        [Fact]
        public void ChooseNoFightActionUseMagicCard()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns(new Queue<string>(new[] { "1", "1", "1", "1", "1", "1", "1", "1", "1" }).Dequeue);
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
            var sellItemController = new SellItemController(deckController, mock.Object);
            var makeActionController = new MakeActionController(game,
                                                                fightController,
                                                                prizeStackController,
                                                                random,
                                                                deckController,
                                                                mock.Object,
                                                                drawCardService,
                                                                sellItemController);
            var enemyAva = new UserAvatar
            {
                Level = 1
            };
            var enemy = new UserClass()
            {
                UserAvatar = enemyAva
            };
            var curse = new BackToSchool("BackToSchool", CardType.Curse);
            var fight = new Fight();
            user.Deck.MagicCards.Add(curse);
            enemy.UserAvatar.CountPower();
            game.Users.Add(enemy);
            game.Users.Add(user);
            //Act
            makeActionController.ChooseNoFightAction(user, fight);
            //Assert
            enemy.UserAvatar.Level.Should().Be(0);
        }

        [Fact]
        public void ChooseNoFightActionUseSituationalCard()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns(new Queue<string>(new[] { "2", "1", "1", "1", "1", "1", "1", "1", "1" }).Dequeue);
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
            var sellItemController = new SellItemController(deckController, mock.Object);
            var makeActionController = new MakeActionController(game,
                                                                fightController,
                                                                prizeStackController,
                                                                random,
                                                                deckController,
                                                                mock.Object,
                                                                drawCardService,
                                                                sellItemController);
            var card = new GoldenApple("GoldenApple",
                                                       CardType.Special,
                                                       PrizeCardType.Sitiuational,
                                                       0,
                                                       null,
                                                       false,
                                                       ItemType.Sitiuational,
                                                       null,
                                                       500);
            var antArmy = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 5,
                HowManyLevels = 1,
                NumberOfPrizes = 2
            };
            var fight = new Fight();
            fight.Heros.Add(user);
            fight.Monsters.Add(antArmy);
            user.Deck.Items.Add(card);
            user.UserAvatar.CountPower();
            //Act
            makeActionController.ChooseNoFightAction(user, fight);
            //Assert
            user.UserAvatar.Power.Should().Be(6);
            user.UserAvatar.Nerfs.Poisoned.Should().HaveCount(1);
            user.Deck.Items.Should().HaveCount(0);
            game.DestroyedPrizeCards.Should().HaveCount(1);
        }

        [Fact]
        public void ChooseNoFightActionUseSkill()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns(new Queue<string>(new[] { "3", "1", "1", "1", "1", "1", "1", "1", "1" }).Dequeue);
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
            var sellItemController = new SellItemController(deckController, mock.Object);
            var makeActionController = new MakeActionController(game,
                                                                fightController,
                                                                prizeStackController,
                                                                random,
                                                                deckController,
                                                                mock.Object,
                                                                drawCardService,
                                                                sellItemController);
            var antArmy = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 5,
                HowManyLevels = 1,
                NumberOfPrizes = 2
            };
            var fight = new Fight();
            fight.Heros.Add(user);
            fight.Monsters.Add(antArmy);
            var item = new ItemCard("g", CardType.Prize, PrizeCardType.Item, 3, null, false, ItemType.Weapon, null, 300);
            user.Deck.Items.Add(item);
            user.UserAvatar.CountPower();
            //Act
            makeActionController.ChooseNoFightAction(user, fight);
            //Assert
            user.UserAvatar.TempPower.Should().Be(2);
            game.DestroyedPrizeCards.Should().HaveCount(1);
            user.Deck.Items.Count.Should().Be(0);
        }

        [Fact]
        public void ChooseNoFightActionUseMonsterCard()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns(new Queue<string>(new[] { "4", "1", "1", "1", "1", "1", "1", "1", "1" }).Dequeue);
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
            var sellItemController = new SellItemController(deckController, mock.Object);
            var makeActionController = new MakeActionController(game,
                                                                fightController,
                                                                prizeStackController,
                                                                random,
                                                                deckController,
                                                                mock.Object,
                                                                drawCardService,
                                                                sellItemController);
            var undead = new AntArmy("Undead", CardType.Monster)
            {
                Power = 1,
                HowManyLevels = 1,
                NumberOfPrizes = 1,
                Undead = true
            };
            var antArmy = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 5,
                HowManyLevels = 1,
                NumberOfPrizes = 2
            };
            user.Deck.Monsters.Add(undead);
            var fight = new Fight();
            fight.Heros.Add(user);
            fight.Monsters.Add(antArmy);
            //Act
            makeActionController.ChooseNoFightAction(user, fight);
            //Assert
            user.Deck.Monsters.Count.Should().Be(0);
            fight.Monsters.Should().HaveCount(2);
            fight.Monsters[1].Should().BeSameAs(undead);
        }

        [Fact]
        public void ChooseNoFightActionAbort()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns(new Queue<string>(new[] { "0", "1", "1", "1", "1", "1", "1", "1", "1" }).Dequeue);
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
            var sellItemController = new SellItemController(deckController, mock.Object);
            var makeActionController = new MakeActionController(game,
                                                                fightController,
                                                                prizeStackController,
                                                                random,
                                                                deckController,
                                                                mock.Object,
                                                                drawCardService,
                                                                sellItemController);
            var card = new GoldenApple("GoldenApple",
                                                       CardType.Special,
                                                       PrizeCardType.Sitiuational,
                                                       0,
                                                       null,
                                                       false,
                                                       ItemType.Sitiuational,
                                                       null,
                                                       500);
            var antArmy = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 5,
                HowManyLevels = 1,
                NumberOfPrizes = 2
            };
            var fight = new Fight();
            fight.Heros.Add(user);
            fight.Monsters.Add(antArmy);
            user.Deck.Items.Add(card);
            user.UserAvatar.CountPower();
            //Act
            makeActionController.ChooseNoFightAction(user, fight);
            //Assert
            user.UserAvatar.Power.Should().Be(1);
            user.Deck.Items.Should().HaveCount(1);
            game.DestroyedPrizeCards.Should().HaveCount(0);
        }

        [Fact]
        public void EnemyChooseActionUseSituationalCardOnUser()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns(new Queue<string>(new[] { "1", "2", "1", "1", "0", "0", "0", "0", "0" }).Dequeue);
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
            var sellItemController = new SellItemController(deckController, mock.Object);
            var makeActionController = new MakeActionController(game,
                                                                fightController,
                                                                prizeStackController,
                                                                random,
                                                                deckController,
                                                                mock.Object,
                                                                drawCardService,
                                                                sellItemController);
            var card = new GoldenApple("GoldenApple",
                                                       CardType.Special,
                                                       PrizeCardType.Sitiuational,
                                                       0,
                                                       null,
                                                       false,
                                                       ItemType.Sitiuational,
                                                       null,
                                                       500);
            var antArmy = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 5,
                HowManyLevels = 1,
                NumberOfPrizes = 2
            };
            var fight = new Fight();
            fight.Heros.Add(user);
            fight.Monsters.Add(antArmy);
            user.UserAvatar.CountPower();
            var enemyAvater = new UserAvatar
            {
                Level = 1
            };
            var enemy = new UserClass()
            {
                UserAvatar = enemyAvater
            };
            enemy.Deck.Items.Add(card);
            game.Users.Add(user);
            game.Users.Add(enemy);
            //Act
            makeActionController.EnemyChooseAction(user, fight);
            //Assert
            user.UserAvatar.Power.Should().Be(6);
            enemy.Deck.Items.Should().HaveCount(0);
            game.DestroyedPrizeCards.Should().HaveCount(1);
        }

        [Fact]
        public void EnemyChooseActionAbort()
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
            var sellItemController = new SellItemController(deckController, mock.Object);
            var makeActionController = new MakeActionController(game,
                                                                fightController,
                                                                prizeStackController,
                                                                random,
                                                                deckController,
                                                                mock.Object,
                                                                drawCardService,
                                                                sellItemController);
            var card = new GoldenApple("GoldenApple",
                                                       CardType.Special,
                                                       PrizeCardType.Sitiuational,
                                                       0,
                                                       null,
                                                       false,
                                                       ItemType.Sitiuational,
                                                       null,
                                                       500);
            var antArmy = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 5,
                HowManyLevels = 1,
                NumberOfPrizes = 2
            };
            var fight = new Fight();
            fight.Heros.Add(user);
            fight.Monsters.Add(antArmy);
            user.UserAvatar.CountPower();
            var enemyAvater = new UserAvatar
            {
                Level = 1
            };
            var enemy = new UserClass()
            {
                UserAvatar = enemyAvater
            };
            enemy.Deck.Items.Add(card);
            game.Users.Add(user);
            game.Users.Add(enemy);
            //Act
            makeActionController.EnemyChooseAction(user, fight);
            //Assert
            user.UserAvatar.Power.Should().Be(1);
            enemy.Deck.Items.Should().HaveCount(1);
            game.DestroyedPrizeCards.Should().HaveCount(0);
        }

        [Fact]
        public void EnemyChooseActionUseMagicCardOnUser()
        {
            //Arrange
            var mock = new Mock<ReadLineOverride>();
            mock.Setup(x => x.GetNextString()).Returns(new Queue<string>(new[] { "1", "1", "1", "1", "0", "0", "0", "0", "0" }).Dequeue);
            var random = new Random();
            var game = new Game();
            var userAvatar = new UserAvatar
            {
                Level = 2
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
            var sellItemController = new SellItemController(deckController, mock.Object);
            var makeActionController = new MakeActionController(game,
                                                                fightController,
                                                                prizeStackController,
                                                                random,
                                                                deckController,
                                                                mock.Object,
                                                                drawCardService,
                                                                sellItemController);
            var curse = new BackToSchool("BackToSchool", CardType.Curse);
            var antArmy = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 5,
                HowManyLevels = 1,
                NumberOfPrizes = 2
            };
            var fight = new Fight();
            fight.Heros.Add(user);
            fight.Monsters.Add(antArmy);
            user.UserAvatar.CountPower();
            var enemyAvater = new UserAvatar
            {
                Level = 1
            };
            var enemy = new UserClass()
            {
                UserAvatar = enemyAvater
            };
            enemy.Deck.MagicCards.Add(curse);
            game.Users.Add(user);
            game.Users.Add(enemy);
            //Act
            makeActionController.EnemyChooseAction(user, fight);
            //Assert
            user.UserAvatar.Level.Should().Be(1);
            enemy.Deck.Items.Should().HaveCount(0);
            game.DestroyedActionCards.Should().HaveCount(1);
        }
    }
}
