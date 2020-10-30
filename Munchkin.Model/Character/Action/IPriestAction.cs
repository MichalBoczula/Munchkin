using Munchkin.Model.Helper;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Character.Action
{
    public interface IPriestAction
    {
#nullable enable
        DestroyedCards MakeMonsterAPet(UserClass user, Fight? fight);
#nullable disable
        void RestoreCard();
    }
}
