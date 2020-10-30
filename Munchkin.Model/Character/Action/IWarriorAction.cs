﻿using Munchkin.Model.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Character.Action
{
    public interface IWarriorAction
    {
        DestroyedCards BeStronger(UserClass user, int cardToThrowId);
    }
}
