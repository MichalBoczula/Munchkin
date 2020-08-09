using Munchkin.Model.Character.Action;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Character.Hero.Proficiency
{
    public class MageProficiency : ProficiencyBase, IMageAction
    {
        public MageProficiency()
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
