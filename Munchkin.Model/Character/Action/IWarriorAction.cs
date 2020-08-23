using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Character.Action
{
    public interface IWarriorAction
    {
        void BeStronger(UserClass user, int cardToThrowId);
    }
}
