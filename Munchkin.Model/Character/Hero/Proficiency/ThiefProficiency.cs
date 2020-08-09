using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Character.Hero.Proficiency
{
    public class ThiefProficiency : ProficiencyBase, IThiefAction
    {
        public ThiefProficiency()
        {
            Name = "Thief";
        }

        public CardGameBase StealCard()
        {
            throw new NotImplementedException();
        }

        public bool BackStab()
        {
            throw new NotImplementedException();
        }
    }
}
