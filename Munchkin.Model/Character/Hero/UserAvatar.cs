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
        public int FleeChances { get; set; }
        public int TempPower;

        public UserAvatar()
        {
            Level = 1;
            FleeChances = 3;
            TempPower = Power;
        }

        public void CountPower()
        {
            Power = Level;
            if (Build.Helmet != null)
            {
                Power += Build.Helmet.Card.Power;
            }
            if(Build.LeftHandItem == null)
            {
                Power += Build.LeftHandItem.Card.Power;
            }
            if (Build.RightHandItem == null)
            {
                Power += Build.RightHandItem.Card.Power;
            }
            if (Build.Boots == null)
            {
                Power += Build.Boots.Card.Power;
            }
            if (Build.AdditionalItems != null && Build.AdditionalItems.Count > 0)
            {
                foreach(var item in Build.AdditionalItems)
                {
                    Power += item.Card.Power;
                }
            }

        }

        public void IncreaseFleeChances()
        {
            FleeChances += 1;
        }

        public void EndTurn()
        {
            FleeChances = 3;
            TempPower = Power;
            CountPower();
        }

        public void IncreaseTempPower(int num)
        {
            if(Build.SituationalItems != null && Build.SituationalItems.Count > 0)
            {
                foreach(var item in Build.SituationalItems)
                {
                    TempPower += item.Card.Power;
                }
            }
        }
    }
}
