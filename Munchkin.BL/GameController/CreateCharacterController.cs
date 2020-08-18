using Munchkin.BL.CharacterCreator;
using Munchkin.BL.InformationModel;
using Munchkin.Model;
using Munchkin.Model.Character;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.BL.GameController
{
    public class CreateCharacterController
    {
        private CreateInformationModel createInformationModel;
        private CharacterCreatorControlerService characterCreatorControlerService;
        private Game game;

        public CreateCharacterController(
            CreateInformationModel createInformationModel,
            CharacterCreatorControlerService characterCreatorControlerService,
            Game game)
        {
            this.createInformationModel = createInformationModel;
            this.characterCreatorControlerService = characterCreatorControlerService;
            this.game = game;
        }

        public string ReadName()
        {
            Console.WriteLine(createInformationModel.InputName);
            var name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                name = "Nameless";
                Console.WriteLine(createInformationModel.NameIsEmptyMessage());
            }
            Console.WriteLine(createInformationModel.ReturnNameMessage(name));
            return name;
        }

        public UserClass CreateUser(string name)
        {
            var user = new UserClass
            {
                Name = name
            };
            Console.WriteLine(createInformationModel.GreetingsMessage(name));
            return user;
        }

        public UserClass CreateCharacter(UserClass user)
        {
            user.UserAvatar = new UserAvatar();
            Console.WriteLine(createInformationModel.Welcome(user));
            Console.WriteLine(createInformationModel.PressKeyMessage);
            Console.ReadLine();

            Console.WriteLine(createInformationModel.DrawCardRaceCard);
            var raceCard = characterCreatorControlerService.DrawRaceCard();
            Console.WriteLine(createInformationModel.ShowRaceInforamtion(raceCard));
            Console.WriteLine(createInformationModel.PressKeyMessage);
            Console.ReadLine();
            raceCard.SpecialEffect(user);
            Console.WriteLine(createInformationModel.PressKeyMessage);
            Console.ReadLine();

            Console.WriteLine(createInformationModel.DrawCardProficiencyCard);
            var proficiencyCard = characterCreatorControlerService.DrawProficiencyCard();
            Console.WriteLine(createInformationModel.ShowProficiencyInforamtion(proficiencyCard));
            Console.WriteLine(createInformationModel.PressKeyMessage);
            Console.ReadLine();
            proficiencyCard.SpecialEffect(user);

            Console.WriteLine(createInformationModel.BeginJourney);
            Console.WriteLine(createInformationModel.PressKeyMessage);
            Console.ReadLine();

            return user;
        }

        public UserClass ModifiedCharacter()
        {
            throw new NotImplementedException();
        }

        public UserClass DeleteCharacter()
        {
            throw new NotImplementedException();
        }
    }
}
