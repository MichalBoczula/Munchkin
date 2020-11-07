using Munchkin.Model.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Character.Action
{
    public interface IMageAction
    {
        DestroyedCards FleeSpell(UserClass user);
        DestroyedCards InstantKill(UserClass user);
    }
}
