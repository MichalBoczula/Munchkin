using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Character.Action
{
    public interface IMageAction
    {
        void FleeSpell(UserClass user, int num);
        bool CharmSpell(UserClass user);
    }
}
