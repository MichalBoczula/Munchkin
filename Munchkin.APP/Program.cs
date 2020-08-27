using Munchkin.BL.CardGenerator;
using Munchkin.BL.CardGenerator.CardsStack;
using Munchkin.BL.CharacterCreator;
using Munchkin.BL.GameController;
using Munchkin.BL.InformationModel;
using Munchkin.Model;
using Munchkin.Model.Card.PrizeCard;
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
            ////Arrange
            //var game = new Game();
            //var createInformationModel = new CreateInformationModel();
            //var stackCardGeneratorService = new StackCardGeneratorService();
            //var random = new Random();
            //var drawCardService = new DrawCardService(random);
            //var characterCreatorControlerService = new CharacterCreatorControlerService(stackCardGeneratorService, drawCardService);
            //var createCharacterController = new CreateCharacterController(createInformationModel, characterCreatorControlerService, game);
            ////Act
            //var name = createCharacterController.ReadName();
            //var user = createCharacterController.CreateUser(name);
            //user = createCharacterController.CreateCharacter(user);





            var informationModelThiefProficiency = new InformationModelThiefProficiency();
            var thief = new ThiefProficiency();
            var dwarf = new Dwarf("dwarf");
            var userAvatar = new UserAvatar()
            {
                Proficiency = thief,
                Build = new Build(),
                Race = dwarf

            };
            var thiefChar = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var khazaDumRestrictions = new Dictionary<bool, RaceBase>
            {
                { true, new Dwarf("dwarf") }
            };
            thiefChar.UserAvatar.Build.LeftHandItem = new ItemCard("khazaDumHammer", CardType.Prize, PrizeCardType.Item, 3, khazaDumRestrictions, true, ItemType.Weapon, null);
            var additionalItems = new List<ItemCard>()
            {
                new ItemCard("healthPotion", CardType.Prize, PrizeCardType.Additional, 4, null, false, ItemType.Additional, null),
                new ItemCard("manaPotion", CardType.Prize, PrizeCardType.Additional, 2, null, false, ItemType.Additional, null),
            };
            thiefChar.UserAvatar.Build.AdditionalItems = additionalItems;
            //Act
            var result = informationModelThiefProficiency.ShowItemsToSteal(thiefChar.UserAvatar.Build);
            var arr = result.ItemDescription.Split(";");

            foreach (var ele in arr)
            {
                Console.WriteLine(ele);
            }
        }
    }
}
