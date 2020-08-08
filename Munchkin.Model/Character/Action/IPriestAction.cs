using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Character.Action
{
    public interface IPriestAction
    {
        List<CardGameBase> BeStrongerAganistUndead();
        CardGameBase RestoreCard();
    }
}
