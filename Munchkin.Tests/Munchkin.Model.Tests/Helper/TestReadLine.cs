using Munchkin.BL.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Tests.Munchkin.Model.Tests.Helper
{
    public class TestReadLine : ReadLineOverride
    {
        public override string GetNextString()
        {
            return "";
        }
    }
}
