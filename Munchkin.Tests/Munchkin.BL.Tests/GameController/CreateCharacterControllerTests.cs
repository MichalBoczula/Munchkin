using Moq;
using Munchkin.BL.CardGenerator;
using Munchkin.BL.CharacterCreator;
using Munchkin.BL.GameController;
using Munchkin.BL.InformationModel;
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
            Assert.Equal(name, user.Name);
        }

        
        [Fact(Skip = "Remember about comment Console.ReadLine in method Create User in CreateCharacterController before tests")]
        //
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
            Assert.NotNull(user.UserAvatar.Race);
            Assert.NotNull(user.UserAvatar.Proficiency);
        }
    }
}
