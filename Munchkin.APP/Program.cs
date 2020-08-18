using Munchkin.BL.CardGenerator;
using Munchkin.BL.CharacterCreator;
using Munchkin.BL.GameController;
using Munchkin.BL.InformationModel;
using Munchkin.Model.User;
using System;

namespace Munchkin.APP
{
    class Program
    {
        static void Main(string[] args)
        {
            //Arrange
            var game = new Game();
            var createInformationModel = new CreateInformationModel();
            var stackCardGeneratorService = new StackCardGeneratorService();
            var random = new Random();
            var drawCardService = new DrawCardService(random);
            var characterCreatorControlerService = new CharacterCreatorControlerService(stackCardGeneratorService, drawCardService);
            var createCharacterController = new CreateCharacterController(createInformationModel, characterCreatorControlerService, game);
            //Act
            var name = createCharacterController.ReadName();
            var user = createCharacterController.CreateUser(name);
            user = createCharacterController.CreateCharacter(user);
        }
    }
}
