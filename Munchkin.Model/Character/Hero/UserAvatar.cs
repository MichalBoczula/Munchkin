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
        public int Level { get; set; }
        public int Power { get; set; }
        public int FleeChances { get; set; }
        public int TempPower { get; set; }
        public bool WasBackstab { get; set; }
        public bool WasRob { get; set; }
        public int HowManyCardsThrowToUseSkill { get; set; }
        public NerfType Nerfs { get; set; }
        public bool IsDied { get; set; }

        public UserAvatar()
        {
            Level = 1;
            FleeChances = 3;
            TempPower = Power;
            WasBackstab = false;
            WasRob = false;
            HowManyCardsThrowToUseSkill = 0;
            Nerfs = new NerfType();
            IsDied = false;
            CountPower();
        }

        public void CountPower()
        {
            Power = Level;
            if (Build != null)
            {
                if (Build.Helmet != null)
                {
                    Power += Build.Helmet.Power;
                }
                if (Build.LeftHandItem != null)
                {
                    Power += Build.LeftHandItem.Power;
                }
                if (Build.RightHandItem != null)
                {
                    Power += Build.RightHandItem.Power;
                }
                if (Build.Boots != null)
                {
                    Power += Build.Boots.Power;
                }
                if (Build.AdditionalItems != null)
                {
                    foreach (var item in Build.AdditionalItems)
                    {
                        Power += item.Power;
                    }
                }

            }
            if (Nerfs.Power.Count > 0)
            {
                foreach (var ele in Nerfs.Power)
                {
                    Power -= ele;
                }
            }
            if (Nerfs.Wounded.Count == 1)
            {
                Power -= 2;
            }
            TempPower = Power;
        }

        public void CountFleeChances()
        {
            FleeChances = 3;
            if (Nerfs.FleeChances.Count > 0)
            {
                foreach (var ele in Nerfs.FleeChances)
                {
                    FleeChances -= ele;
                }
            }
            if (Nerfs.Wounded.Count == 1)
            {
                FleeChances -= 1;
            }
        }

        public void CheckWounds()
        {
            if (Nerfs.Wounded.Count == 2)
            {
                IsDied = true;
            }
        }

        public void EndTurn()
        {
            CountFleeChances();
            CountPower();
            TempPower = Power;
            WasBackstab = false;
            WasRob = false;
            HowManyCardsThrowToUseSkill = 0;
            CheckWounds();
        }
    }

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
