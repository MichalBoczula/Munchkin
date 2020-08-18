using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.User
{
    public class Game
    {
        public int Id { get; set; }
        public List<UserClass> Users{ get; set; }

        public Game()
        {
            Users = new List<UserClass>();
        }
    }
}
