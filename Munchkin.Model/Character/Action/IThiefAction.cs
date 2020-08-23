﻿using Munchkin.Model.Card.PrizeCard;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Character
{
    public interface IThiefAction 
    {
        void StealCard(UserClass thief, UserClass victim, Random random);
        bool BackStab(UserClass victim, Random random);
    }
}
