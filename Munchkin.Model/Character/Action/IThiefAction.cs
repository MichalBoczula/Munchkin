using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Character
{
    public interface IThiefAction 
    {
        CardGameBase StealCard();
        bool BackStab();
    }
}
