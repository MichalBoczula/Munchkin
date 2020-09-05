using FluentAssertions;
using Moq;
using Munchkin.BL.CardGenerator;
using Munchkin.BL.CharacterCreator;
using Munchkin.BL.GameController;
using Munchkin.BL.InformationModel;
using Munchkin.Model.Character;
using Munchkin.Model.User;
using Munchkin.Tests.Munchkin.Model.Tests.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Munchkin.Tests.Munchkin.BL.Tests.GameController
{
    public class CreateCharacterControllerTests
    {
        [Fact]
        public void CreateCharacterWithNameTest()
        {
            //Arrange
            var game = new Game();
            var createInformationModel = new CreateInformationModel();
            var stackCardGeneratorService = new StackCardGeneratorService();
            var random = new Random();
            var mockTestReadLine = new Mock<TestReadLine>();
            mockTestReadLine.Setup(x => x.GetNextString()).Returns("");
            var drawCardService = new DrawCardService(random);
            var characterCreatorControlerService = new CharacterCreatorControlerService(stackCardGeneratorService, drawCardService);
            var createCharacterController = new CreateCharacterController(createInformationModel, characterCreatorControlerService, game, mockTestReadLine.Object);
            var name = "Someone";
            //Act
            var user = createCharacterController.CreateUser(name);
            //Assert
            user.Name.Should().Be(name);
        }
        
        [Fact]
        public void CreateUserTests()
        {
            //Arrange
            var game = new Game();
            var createInformationModel = new CreateInformationModel();
            var stackCardGeneratorService = new StackCardGeneratorService();
            var random = new Random();
            var mockTestReadLine = new Mock<TestReadLine>();
            mockTestReadLine.Setup(x => x.GetNextString()).Returns("");
            var drawCardService = new DrawCardService(random);
            var characterCreatorControlerService = new CharacterCreatorControlerService(stackCardGeneratorService, drawCardService);
            var createCharacterController = new CreateCharacterController(createInformationModel, characterCreatorControlerService, game, mockTestReadLine.Object);
            var name = "Someone";
            var user = createCharacterController.CreateUser(name);
            //Act
            user = createCharacterController.CreateCharacter(user);
            //Assert

            user.UserAvatar.Race.Should().NotBeNull();
            user.UserAvatar.Proficiency.Should().NotBeNull();
        }
    }
}
