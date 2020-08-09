using Munchkin.Model.Character.Action;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Character.Hero.Proficiency
{
    public class WarriorProficiency : ProficiencyBase, IWarriorAction
    {
        public WarriorProficiency()
        {
            Name = "Warrior";
        }

        public List<CardGameBase> BeStronger()
        {
            throw new NotImplementedException();
        }
    }
}
