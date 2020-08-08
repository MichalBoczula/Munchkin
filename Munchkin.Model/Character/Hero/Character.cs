using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Character
{
    public class Character
    {
        public int Id { get; }
        public string Name { get; }
        public Build Build { get; }
        public RaceBase Race { get; }
        public ProficiencyBase Proficiency { get; }
        public int Level { get; }
        public int Power { get; set; }

        public Character(string name, Build build, RaceBase race)
        {
            Name = name;
            Build = build;
            Race = race;
            Level = 1;
        }

        public void CountPower()
        {
            Power += Level;
        }
    }
}
