using FluentAssertions;
using Moq;
using Munchkin.BL.CardGenerator;
using Munchkin.BL.CharacterCreator;
using Munchkin.BL.GameController;
using Munchkin.Model;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret;
using Munchkin.Model.Character;
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
            var makeActionController = new MakeActionController(game, fightController, prizeStackController);
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
            var makeActionController = new MakeActionController(game, fightController, prizeStackController);
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
            var makeActionController = new MakeActionController(game, fightController, prizeStackController);
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
    }
}
