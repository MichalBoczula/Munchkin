using Munchkin.BL.CardGenerator;
using Munchkin.BL.CharacterCreator;
using Munchkin.BL.Helper;
using Munchkin.BL.InformationModel;
using Munchkin.Model.Character.Hero.Proficiency;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.BL.GameController
{
    public class GameFlowController
    {
        private CreateCharacterController createCharacterController;
        private Game game;
        private ReadLineOverride readLineOverride;
        private PrizeStackController prizeStackController;
        private GameFlowInformation gameFlowInformation;
        private StackCardGeneratorService stackCardGeneratorService;
        private DrawCardService drawCardService;
        private MakeActionController makeActionController;

        public GameFlowController(CreateCharacterController createCharacterController,
                                  Game game,
                                  ReadLineOverride readLineOverride,
                                  PrizeStackController prizeStackController,
                                  StackCardGeneratorService stackCardGeneratorService,
                                  DrawCardService drawCardService,
                                  MakeActionController makeActionController)
        {
            this.createCharacterController = createCharacterController;
            this.game = game;
            this.readLineOverride = readLineOverride;
            this.prizeStackController = prizeStackController;
            this.stackCardGeneratorService = stackCardGeneratorService;
            this.drawCardService = drawCardService;
            gameFlowInformation = new GameFlowInformation();
            this.makeActionController = makeActionController;
        }

        public void CreateUsers()
        {
            int num;
            while (true)
            {
                Console.WriteLine(gameFlowInformation.InputNumOfPlayers);
                if (Int32.TryParse(Console.ReadLine(), out num))
                {
                    break;
                }
                else
                {
                    Console.WriteLine(gameFlowInformation.WrongInput);
                    readLineOverride.GetNextString();
                }
            }
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine(gameFlowInformation.InputNameForUser(i));
                var name = createCharacterController.ReadName();
                if (!ValidateUserName(name))
                {
                    i--;
                    Console.WriteLine(gameFlowInformation.NameOccupied);
                    readLineOverride.GetNextString();
                }
                else
                {
                    var user = createCharacterController.CreateUser(name);
                    user = createCharacterController.CreateCharacter(user);
                    game.Users.Add(user);
                    Console.WriteLine(gameFlowInformation.SuccesfullyCreated(user));
                    readLineOverride.GetNextString();
                }
            }
        }

        public void CreateCharacters()
        {
            for (int i = 0; i < game.Users.Count; i++)
            {
                game.Users[i] = createCharacterController.CreateCharacter(game.Users[i]);
            }
        }

        public void InitializeDeckForUsers()
        {
            for (int i = 0; i < game.Users.Count; i++)
            {
                game.Users[i] = prizeStackController.DrawCardsForStartDeck(game.Users[i]);
            }
        }

        public bool ValidateUserName(string name)
        {
            foreach (var user in game.Users)
            {
                if (user.Name.ToLower().Equals(name.ToLower()))
                {
                    return false;
                }
            }
            return true;
        }

        public void InitializeMonsterCards()
        {
            game.ActionCards.AddRange(stackCardGeneratorService.GenerateMonsterCards());
            drawCardService.Shuffle(game.ActionCards);
        }

        public void PlayTheGame()
        {
            foreach (var user in game.Users)
            {
                makeActionController.OpenMisteryDoor(user, null);
            }
        }
    }
}
