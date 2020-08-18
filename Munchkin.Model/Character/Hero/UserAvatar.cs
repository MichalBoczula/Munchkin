using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Character
{
    public class UserAvatar
    {
        public int Id { get; }
        public string Name { get; set; }
        public Build Build { get; set; }
        public RaceBase Race { get; set; }
        public ProficiencyBase Proficiency { get; set; }
        public int Level { get; }
        public int Power { get; set; }

        public UserAvatar()
        {
            Level = 1;
        }

        public void CountPower()
        {
            Power += Level;
        }
    }
}
