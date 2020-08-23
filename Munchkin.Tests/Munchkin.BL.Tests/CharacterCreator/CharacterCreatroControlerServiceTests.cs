using Munchkin.BL.CardGenerator;
using Munchkin.BL.CharacterCreator;
using Munchkin.Model.Character;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using Munchkin.Model.Character.Hero.Race;
using Munchkin.Model.Character.Hero.Proficiency;
using FluentAssertions;

namespace Munchkin.Tests.Munchkin.BL.Tests.CharacterCreator
{
    public class CharacterCreatroControlerServiceTests
    {
        [Fact]
        public void CreateCharacterShouldReturnElfAndMageTest()
        {
            //Arrange
            var stackCardGeneratorService = new StackCardGeneratorService();
            var mockRandom = new Mock<Random>();
            var drawCardService = new DrawCardService(mockRandom.Object);
            var characterCreatroControlerService =
                 new CharacterCreatorControlerService(
                 stackCardGeneratorService,
                 drawCardService);
            mockRandom.Setup(x => x.Next(4)).Returns(0);
            mockRandom.Setup(x => x.Next(5)).Returns(0);
            //Act
            var character = characterCreatroControlerService.CreateCharacter();
            //Assert
            character.UserAvatar.Race.Should().BeOfType<Elf>();
            character.UserAvatar.Proficiency.Should().BeOfType<MageProficiency>();
        }

        [Fact]
        public void CreateCharacterShouldReturnDwarfAndNoOneTest()
        {
            //Arrange
            var stackCardGeneratorService = new StackCardGeneratorService();
            var mockRandom = new Mock<Random>();
            var drawCardService = new DrawCardService(mockRandom.Object);
            var characterCreatroControlerService =
                 new CharacterCreatorControlerService(
                 stackCardGeneratorService,
                 drawCardService);
            mockRandom.Setup(x => x.Next(4)).Returns(1);
            mockRandom.Setup(x => x.Next(5)).Returns(1);
            //Act
            var character = characterCreatroControlerService.CreateCharacter();
            //Assert
            character.UserAvatar.Race.Should().BeOfType<Dwarf>();
            character.UserAvatar.Proficiency.Should().BeOfType<NoOneProficiency>();
        }

        [Fact]
        public void CreateCharacterShouldReturnHalfingfAndPriestTest()
        {
            //Arrange
            var stackCardGeneratorService = new StackCardGeneratorService();
            var mockRandom = new Mock<Random>();
            var drawCardService = new DrawCardService(mockRandom.Object);
            var characterCreatroControlerService =
                 new CharacterCreatorControlerService(
                 stackCardGeneratorService,
                 drawCardService);
            mockRandom.Setup(x => x.Next(4)).Returns(2);
            mockRandom.Setup(x => x.Next(5)).Returns(2);
            //Act
            var character = characterCreatroControlerService.CreateCharacter();
            //Assert
            character.UserAvatar.Race.Should().BeOfType<Halfling>();
            character.UserAvatar.Proficiency.Should().BeOfType<PriestProficiency>();
        }

        [Fact]
        public void CreateCharacterShouldReturnHumanAndThiefTest()
        {
            //Arrange
            var stackCardGeneratorService = new StackCardGeneratorService();
            var mockRandom = new Mock<Random>();
            var drawCardService = new DrawCardService(mockRandom.Object);
            var characterCreatroControlerService =
                 new CharacterCreatorControlerService(
                 stackCardGeneratorService,
                 drawCardService);
            mockRandom.Setup(x => x.Next(4)).Returns(3);
            mockRandom.Setup(x => x.Next(5)).Returns(3);
            //Act
            var character = characterCreatroControlerService.CreateCharacter();
            //Assert
            character.UserAvatar.Race.Should().BeOfType<Human>();
            character.UserAvatar.Proficiency.Should().BeOfType<ThiefProficiency>();
        }

        [Fact]
        public void CreateCharacterShouldReturnHumanAndWarriorTest()
        {
            //Arrange
            var stackCardGeneratorService = new StackCardGeneratorService();
            var mockRandom = new Mock<Random>();
            var drawCardService = new DrawCardService(mockRandom.Object);
            var characterCreatroControlerService =
                 new CharacterCreatorControlerService(
                 stackCardGeneratorService,
                 drawCardService);
            mockRandom.Setup(x => x.Next(5)).Returns(4);
            //Act
            var character = characterCreatroControlerService.CreateCharacter();
            //Assert
            character.UserAvatar.Proficiency.Should().BeOfType<WarriorProficiency>();
        }

        [Fact]
        public void CreateCharacterShouldThrowArgumentOutOfRangeExceptionTest()
        {
            //Arrange
            var stackCardGeneratorService = new StackCardGeneratorService();
            var mockRandom = new Mock<Random>();
            var drawCardService = new DrawCardService(mockRandom.Object);
            var characterCreatroControlerService =
                 new CharacterCreatorControlerService(
                 stackCardGeneratorService,
                 drawCardService);
            mockRandom.Setup(x => x.Next(4)).Returns(4);
            //Act
            Action exception = () => characterCreatroControlerService.CreateCharacter();
            //Assert
            exception.Should().Throw<ArgumentOutOfRangeException>();
        }

    }
}
