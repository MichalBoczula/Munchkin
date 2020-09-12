using System.Collections.Generic;

namespace Munchkin.Model.Character
{
    public class NerfType
    {
        public List<int> Power { get; set; }
        public List<int> FleeChances { get; set; }
        public bool BrokenLegs { get; set; }
        public bool BrokenRibs { get; set; }
        public bool DamagedHead { get; set; }
        public List<bool> TornOffArms { get; set; }
        public List<bool> Wounded { get; set; }
        public List<bool> Poisoned { get; set; }

        public NerfType()
        {
            Power = new List<int>();
            FleeChances = new List<int>();
            BrokenLegs = false;
            TornOffArms = new List<bool>();
            Wounded = new List<bool>();
            Poisoned = new List<bool>();
        }
    }
}
