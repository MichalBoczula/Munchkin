using FluentAssertions;
using Munchkin.BL.GameController;
using Munchkin.Model;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret;
using Munchkin.Model.Character;
using Munchkin.Model.Character.Hero.Proficiency;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Munchkin.Tests.Munchkin.BL.Tests.GameController
{
    public class FightControllerTests
    {
        [Fact]
        public void WhoWinFightHeroWinTest()
        {
            //Arrange
            var fight = new Fight();
            var fightController = new FightController();
            var userClass = new UserClass();
            var userAvatar = new UserAvatar()
            {
                Power = 6
            };
            userClass.UserAvatar = userAvatar;
            var monster = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 5
            };
            fight.Heros.Add(userClass);
            fight.Monsters.Add(monster);
            //Act
            var result = fightController.WhoWinFight(fight);
            //Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void WhoWinFightHeroLoseTest()
        {
            //Arrange
            var fight = new Fight();
            var fightController = new FightController();
            var userClass = new UserClass();
            var userAvatar = new UserAvatar()
            {
                Power = 4
            };
            userClass.UserAvatar = userAvatar;
            var monster = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 5
            };
            fight.Heros.Add(userClass);
            fight.Monsters.Add(monster);
            //Act
            var result = fightController.WhoWinFight(fight);
            //Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void WhoWinFightHeroLoseEqualPowerTest()
        {
            //Arrange
            var fight = new Fight();
            var fightController = new FightController();
            var userClass = new UserClass();
            var userAvatar = new UserAvatar()
            {
                Power = 5
            };
            userClass.UserAvatar = userAvatar;
            var monster = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 5
            };
            fight.Heros.Add(userClass);
            fight.Monsters.Add(monster);
            //Act
            var result = fightController.WhoWinFight(fight);
            //Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void WhoWinFightHeroWinEqualPowerWarriorProficiencyTest()
        {
            //Arrange
            var fight = new Fight();
            var fightController = new FightController();
            var userClass = new UserClass();
            var userAvatar = new UserAvatar()
            {
                Power = 5,
                Proficiency = new WarriorProficiency()
            };
            userClass.UserAvatar = userAvatar;
            var monster = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 5
            };
            fight.Heros.Add(userClass);
            fight.Monsters.Add(monster);
            //Act
            var result = fightController.WhoWinFight(fight);
            //Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void WhoWinFightHerosWinTest()
        {
            //Arrange
            var fight = new Fight();
            var fightController = new FightController();
            var userClass = new UserClass();
            var userAvatar = new UserAvatar()
            {
                Power = 5
            };
            var userClass2 = new UserClass();
            var userAvatar2 = new UserAvatar()
            {
                Power = 3
            };
            userClass.UserAvatar = userAvatar;
            userClass2.UserAvatar = userAvatar2;
            var monster = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 5
            };
            fight.Heros.Add(userClass);
            fight.Heros.Add(userClass2);
            fight.Monsters.Add(monster);
            //Act
            var result = fightController.WhoWinFight(fight);
            //Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void WhoWinFightMonstersWinTest()
        {
            //Arrange
            var fight = new Fight();
            var fightController = new FightController();
            var userClass = new UserClass();
            var userAvatar = new UserAvatar()
            {
                Power = 5
            };
            userClass.UserAvatar = userAvatar;
            var monster = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 5
            };
            var monster2 = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 3
            };
            fight.Heros.Add(userClass);
            fight.Monsters.Add(monster);
            fight.Monsters.Add(monster2);
            //Act
            var result = fightController.WhoWinFight(fight);
            //Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void WhoWinFightManyHeroseAndMonsterHeroesWinTest()
        {
            //Arrange
            var fight = new Fight();
            var fightController = new FightController();
            var userClass = new UserClass();
            var userClass2 = new UserClass();
            var userAvatar = new UserAvatar()
            {
                Power = 5
            };
            var userAvatar2 = new UserAvatar()
            {
                Power = 6
            };
            userClass.UserAvatar = userAvatar;
            userClass2.UserAvatar = userAvatar2;
            var monster = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 5
            };
            var monster2 = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 3
            };
            var monster3 = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 2
            };
            fight.Heros.Add(userClass);
            fight.Heros.Add(userClass2);
            fight.Monsters.Add(monster);
            fight.Monsters.Add(monster2);
            fight.Monsters.Add(monster3);
            //Act
            var result = fightController.WhoWinFight(fight);
            //Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void WhoWinFightManyHeroseAndMonsterMonstrsWinTest()
        {
            //Arrange
            var fight = new Fight();
            var fightController = new FightController();
            var userClass = new UserClass();
            var userClass2 = new UserClass();
            var userAvatar = new UserAvatar()
            {
                Power = 5
            };
            var userAvatar2 = new UserAvatar()
            {
                Power = 4
            };
            userClass.UserAvatar = userAvatar;
            userClass2.UserAvatar = userAvatar2;
            var monster = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 5
            };
            var monster2 = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 3
            };
            var monster3 = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 2
            };
            fight.Heros.Add(userClass);
            fight.Heros.Add(userClass2);
            fight.Monsters.Add(monster);
            fight.Monsters.Add(monster2);
            fight.Monsters.Add(monster3);
            //Act
            var result = fightController.WhoWinFight(fight);
            //Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void WhoWinFightManyHeroseAndMonsterMonstrsWinEqualPowerTest()
        {
            //Arrange
            var fight = new Fight();
            var fightController = new FightController();
            var userClass = new UserClass();
            var userClass2 = new UserClass();
            var userAvatar = new UserAvatar()
            {
                Power = 5
            };
            var userAvatar2 = new UserAvatar()
            {
                Power = 5
            };
            userClass.UserAvatar = userAvatar;
            userClass2.UserAvatar = userAvatar2;
            var monster = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 5
            };
            var monster2 = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 3
            };
            var monster3 = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 2
            };
            fight.Heros.Add(userClass);
            fight.Heros.Add(userClass2);
            fight.Monsters.Add(monster);
            fight.Monsters.Add(monster2);
            fight.Monsters.Add(monster3);
            //Act
            var result = fightController.WhoWinFight(fight);
            //Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void WhoWinFightManyHeroseAndMonsterMonstrsWinEqualPowerAndOneWarriorTest()
        {
            //Arrange
            var fight = new Fight();
            var fightController = new FightController();
            var userClass = new UserClass();
            var userClass2 = new UserClass();
            var userAvatar = new UserAvatar()
            {
                Power = 5,
                Proficiency = new WarriorProficiency()
            };
            var userAvatar2 = new UserAvatar()
            {
                Power = 5
            };
            userClass.UserAvatar = userAvatar;
            userClass2.UserAvatar = userAvatar2;
            var monster = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 5
            };
            var monster2 = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 3
            };
            var monster3 = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 2
            };
            fight.Heros.Add(userClass);
            fight.Heros.Add(userClass2);
            fight.Monsters.Add(monster);
            fight.Monsters.Add(monster2);
            fight.Monsters.Add(monster3);
            //Act
            var result = fightController.WhoWinFight(fight);
            //Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void WhoWinFightManyHeroseAndMonsterMonstrsWinEqualPowerAndOnlyWarriorsTest()
        {
            //Arrange
            var fight = new Fight();
            var fightController = new FightController();
            var userClass = new UserClass();
            var userClass2 = new UserClass();
            var userAvatar = new UserAvatar()
            {
                Power = 5,
                Proficiency = new WarriorProficiency()
            };
            var userAvatar2 = new UserAvatar()
            {
                Power = 5,
                Proficiency = new WarriorProficiency()
            };
            userClass.UserAvatar = userAvatar;
            userClass2.UserAvatar = userAvatar2;
            var monster = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 5
            };
            var monster2 = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 3
            };
            var monster3 = new AntArmy("Ant Army", CardType.Monster)
            {
                Power = 2
            };
            fight.Heros.Add(userClass);
            fight.Heros.Add(userClass2);
            fight.Monsters.Add(monster);
            fight.Monsters.Add(monster2);
            fight.Monsters.Add(monster3);
            //Act
            var result = fightController.WhoWinFight(fight);
            //Assert
            result.Should().BeTrue();
        }
    }
}
