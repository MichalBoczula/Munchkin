using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.User
{
    public class GameAction
    {
        public bool IsFirstTime;
        public bool IsFight;

        public GameAction()
        {
            IsFirstTime = true;
            IsFight = false;
        }
    }
}
