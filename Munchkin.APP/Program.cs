using Munchkin.BL.CardGenerator;
using Munchkin.BL.CardGenerator.CardsStack;
using Munchkin.BL.CharacterCreator;
using Munchkin.BL.GameController;
using Munchkin.BL.Helper;
using Munchkin.BL.InformationModel;
using Munchkin.Model;
using Munchkin.Model.Card.ActionCard;
using Munchkin.Model.Card.ActionCard.SpecialCardType.MagicCards;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret;
using Munchkin.Model.Card.PrizeCard;
using Munchkin.Model.Card.PrizeCard.SituationalItems;
using Munchkin.Model.Character;
using Munchkin.Model.Character.Hero.Proficiency;
using Munchkin.Model.Character.Hero.Race;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;

namespace Munchkin.APP
{
    class Program
    {
        static void Main(string[] args)
        {
            //Arrange
            //var random = new Random();
            //var drawCardService = new DrawCardService(random);
            //var stackCardGeneratorService = new StackCardGeneratorService();
            //var characterCreatorControlerService = new CharacterCreatorControlerService(stackCardGeneratorService, drawCardService);

            //var game = new Game();
            //var readLineOverride = new ReadLineOverride();
            //var createInformationModel = new CreateInformationModel();
            //var createCharacterController = new CreateCharacterController(createInformationModel, characterCreatorControlerService, game, readLineOverride);
            //var makeActionController = new MakeActionController(game);

            //var prizeStackController = new PrizeStackController(drawCardService, stackCardGeneratorService);
            //var gameFlowController = new GameFlowController(createCharacterController, game, readLineOverride,
            //                                                prizeStackController, stackCardGeneratorService,
            //                                                drawCardService, makeActionController);

            ////Act
            //gameFlowController.CreateUsers();
            //gameFlowController.InitializeDeckForUsers();
            //gameFlowController.InitializeMonsterCards();

            //var deckController = new DeckController();

            var readLineOverride = new ReadLineOverride();
            var random = new Random();
            var drawCard = new DrawCardService(random);
            var stackCardGeneratorService = new StackCardGeneratorService();
            var prizeStackGenerator = new PrizeStackController(drawCard, stackCardGeneratorService);
            var warrior = new WarriorProficiency(readLineOverride);
            var userAvatar = new UserAvatar()
            {
                Proficiency = warrior
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var monster = new AntArmy("Ant Army", CardType.Monster);
            var magic = new BackToSchool("BackToSchool", CardType.Curse);
            user = prizeStackGenerator.DrawCardsForStartDeck(user);
            user.Deck.Items.RemoveAt(0);
            user.Deck.Items.RemoveAt(0);
            user.Deck.Items.RemoveAt(0);
            user.Deck.Items.RemoveAt(0);
            user.Deck.Monsters.Add(monster);
            user.Deck.MagicCards.Add(magic);
            var deckController = new DeckController(readLineOverride);
            deckController.LookOnCard(user);
        }
    }
}
