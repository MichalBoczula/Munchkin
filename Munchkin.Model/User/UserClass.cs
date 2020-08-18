using Munchkin.Model.Character;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model
{
    public class UserClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UserAvatar UserAvatar{ get; set; }
        public List<CardGameBase> Deck { get; set; }
        public bool IsDeckInicialize = false;
    }
}
