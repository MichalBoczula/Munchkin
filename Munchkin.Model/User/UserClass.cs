using Munchkin.Model.Character;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model
{
    public class UserClass
    {
        public int Id { get; set; }
        public Character.Character Character { get; set; }
        public List<CardGameBase> Deck { get; set; }
    }
}
