using Munchkin.Model;
using Munchkin.Model.Card.ActionCard.SpecialCardType;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.BL.InformationModel
{
    public class CreateInformationModel
    {
        public string InputName { get => "Input your name Stranger"; }
        public string PressKeyMessage { get => "Press any Enter..."; }
        public string BeginJourney { get => "Start to begin your journey!!! Remember to win you need reach 5th level. Good Luck!!!"; }
        public string DrawCardRaceCard { get => "Now it's time to choose your Race"; }
        public string DrawCardProficiencyCard { get => "Next step into Munchkin world is train to be hero"; }

        public string Welcome(UserClass user)
        {
            return $"Hello {user.Name} it's time to be part of great Journey ";
        }

        public string ShowRaceInforamtion(RaceCard raceCard)
        {
            return $"You'are {raceCard.Race.Name}";
        }

        public string ShowProficiencyInforamtion(ProficiencyCard proficiencyCard)
        {
            return $"You'are {proficiencyCard.Proficiency.Name}";
        }

        public string NameIsEmptyMessage()
        {
            return $"You don't input name, so you are Nameless";
        }

        public string ReturnNameMessage(string name)
        {
            return $"You'are {name}";
        }

        public string GreetingsMessage(string name)
        {
            return $"Greetings {name}";
        }
    }
}
