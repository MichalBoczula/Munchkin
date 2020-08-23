using FluentAssertions;
using Moq;
using Munchkin.BL.CardGenerator;
using Munchkin.BL.CharacterCreator;
using Munchkin.BL.GameController;
using Munchkin.BL.InformationModel;
using Munchkin.Model.Character;
using Munchkin.Model.User;
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
            var drawCardService = new DrawCardService(random);
            var characterCreatorControlerService = new CharacterCreatorControlerService(stackCardGeneratorService, drawCardService);
            var createCharacterController = new CreateCharacterController(createInformationModel, characterCreatorControlerService, game);
            var name = "Someone";
            //Act
            var user = createCharacterController.CreateUser(name);
            //Assert
            user.Name.Should().Be(name);
        }

        
        //[Fact(Skip = "Remember about comment Console.ReadLine in method Create User in CreateCharacterController before tests")]
        [Fact]
        public void CreateUserTests()
        {
            //Arrange
            var game = new Game();
            var createInformationModel = new CreateInformationModel();
            var stackCardGeneratorService = new StackCardGeneratorService();
            var random = new Random();
            var drawCardService = new DrawCardService(random);
            var characterCreatorControlerService = new CharacterCreatorControlerService(stackCardGeneratorService, drawCardService);
            var createCharacterController = new CreateCharacterController(createInformationModel, characterCreatorControlerService, game);
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
