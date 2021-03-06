﻿using Munchkin.BL.Helper;
using Munchkin.Model.Card.PrizeCard;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Character
{
    public interface IThiefAction 
    {
        void StealCard(UserClass thief, UserClass victim);
        bool BackStab(UserClass victim);
    }
}
