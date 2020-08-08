using Munchkin.Model.Character.Action;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Character.Hero.Proficiency
{
    public class MageProfiency : ProficiencyBase, IMageAction
    {
        public MageProfiency()
        {
            Name = "Mage";
        }

        public List<CardGameBase> FleeSpell()
        {
            throw new NotImplementedException();
        }

        public List<CardGameBase> CharmSpell()
        {
            throw new NotImplementedException();
        }
    }
}
