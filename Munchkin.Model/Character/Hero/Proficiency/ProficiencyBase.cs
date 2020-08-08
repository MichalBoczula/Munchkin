using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Character
{
    public abstract class ProficiencyBase : IBaseAction
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public CardGameBase TakeCard()
        {
            throw new NotImplementedException();
        }

        public int RunAway()
        {
            throw new NotImplementedException();
        }

        public bool Fight()
        {
            throw new NotImplementedException();
        }

        public bool AskForHelp()
        {
            throw new NotImplementedException();
        }

        public CardGameBase ThrowCard()
        {
            throw new NotImplementedException();
        }

        public CardGameBase UseCardFromDeck()
        {
            throw new NotImplementedException();
        }

        public bool TakeAction()
        {
            throw new NotImplementedException();
        }
    }
}
