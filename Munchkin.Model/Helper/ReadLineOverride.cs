using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.BL.Helper
{
    public class ReadLineOverride
    {
        public virtual string GetNextString()
        {
            return Console.ReadLine();
        }
    }
}
