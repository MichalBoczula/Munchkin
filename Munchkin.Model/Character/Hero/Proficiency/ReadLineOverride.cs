using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Character.Hero.Proficiency
{
    public class ReadLineOverride
    {
        public virtual string GetNextString()
        {
            return Console.ReadLine();
        }
    }
}
