using Munchkin.Model.Character.Action;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Character.Hero.Proficiency
{
    public class PriestProfiency : ProficiencyBase, IPriestAction
    {
        public PriestProfiency()
        {
            Name = "Priest";
        }

        public List<CardGameBase> BeStrongerAganistUndead()
        {
            throw new NotImplementedException();
        }

        public CardGameBase RestoreCard()
        {
            throw new NotImplementedException();
        }
    }
}
