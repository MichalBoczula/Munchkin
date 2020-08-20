using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Character.Hero.Proficiency
{
    public class InformationModelProficiencyBase
    {
        public string CardRemovedMsg()
        {
            return "Card has been removed.\nPress any key to continue...";
        }

        public string WrongNumberMsg()
        {
            return "There is no card in your deck on this position. Pls check inputed number and input again. \nPress any key and choose again...";
        }

        public string  ChooseCardToRemoveMsg()
        {
            return "Choose card to throw out...";
        }
    }
}
