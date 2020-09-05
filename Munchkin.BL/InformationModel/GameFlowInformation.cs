using Munchkin.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.BL.InformationModel
{
    public class GameFlowInformation
    {
        public string InputNumOfPlayers { get => "Input number of players"; }
        public string WrongInput { get => "Input number!!! Try again...\nPress enter and try again."; }
        public string NameOccupied { get => "This name is occupied...\nPress enter and try again."; }

        public string SuccesfullyCreated(UserClass user)
        {
            return $"User {user.Name} added succesfully to game.\nPress enter to continue";
        }

        public string InputNameForUser(int i)
        {
            return $"Input Name of {i + 1} user";
        }
    }
}
