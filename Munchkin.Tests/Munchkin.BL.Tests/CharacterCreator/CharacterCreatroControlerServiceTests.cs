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
            Assert.IsType<Elf>(character.Race);
            Assert.IsType<MageProficiency>(character.Proficiency);
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
            Assert.IsType<Dwarf>(character.Race);
            Assert.IsType<NoOneProficiency>(character.Proficiency);
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
            Assert.IsType<Halfling>(character.Race);
            Assert.IsType<PriestProficiency>(character.Proficiency);
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
            Assert.IsType<Human>(character.Race);
            Assert.IsType<ThiefProficiency>(character.Proficiency);
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
            Assert.IsType<WarriorProficiency>(character.Proficiency);
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
            //Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => characterCreatroControlerService.CreateCharacter());
        }

    }
}
