using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Character.Hero.Race
{
    public class Halfling : RaceBase
    {
        public Halfling(string name) : base(name)
        {
        }

        public override void SpecialSkill()
        {
            throw new NotImplementedException();
        }
    }
}
