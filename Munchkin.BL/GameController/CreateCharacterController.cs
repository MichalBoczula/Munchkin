using Munchkin.BL.CharacterCreator;
using Munchkin.BL.Helper;
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
        private ReadLineOverride readLineOverride;

        public CreateCharacterController(
            CreateInformationModel createInformationModel,
            CharacterCreatorControlerService characterCreatorControlerService,
            Game game,
            ReadLineOverride readLineOverride)
        {
            this.createInformationModel = createInformationModel;
            this.characterCreatorControlerService = characterCreatorControlerService;
            this.game = game;
            this.readLineOverride = readLineOverride;
        }

        public string ReadName()
        {
            var random = new Random();
            Console.WriteLine(createInformationModel.InputName);
            var name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                name = "Nameless" + random.Next(10) +1;
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
            readLineOverride.GetNextString();

            Console.WriteLine(createInformationModel.DrawCardRaceCard);
            var raceCard = characterCreatorControlerService.DrawRaceCard();
            Console.WriteLine(createInformationModel.ShowRaceInforamtion(raceCard));
            Console.WriteLine(createInformationModel.PressKeyMessage);
            readLineOverride.GetNextString();

            raceCard.SpecialEffect(user);
            Console.WriteLine(createInformationModel.PressKeyMessage);
            readLineOverride.GetNextString();

            Console.WriteLine(createInformationModel.DrawCardProficiencyCard);
            var proficiencyCard = characterCreatorControlerService.DrawProficiencyCard();
            Console.WriteLine(createInformationModel.ShowProficiencyInforamtion(proficiencyCard));
            Console.WriteLine(createInformationModel.PressKeyMessage);
            readLineOverride.GetNextString();
            proficiencyCard.SpecialEffect(user);

            Console.WriteLine(createInformationModel.BeginJourney);
            Console.WriteLine(createInformationModel.PressKeyMessage);
            readLineOverride.GetNextString();

            return user;
        }

        public UserClass ModifiedCharacter()
        {
            throw new NotImplementedException();
        }

        public void DeleteCharacter(string name)
        {
            foreach (var user in game.Users)
            {
                if (user.Name.ToLower().Equals(name.ToLower()))
                {
                    game.Users.Remove(user);
                }
            }
        }
    }
}
