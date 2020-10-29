using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.Character;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.User
{
    public class Fight
    {
        public List<UserClass> Heros{ get; set; }
        public List<MonsterCardBase> Monsters{ get; set; }

        public Fight()
        {
            Heros = new List<UserClass>();
            Monsters = new List<MonsterCardBase>();
        }
    }
}
