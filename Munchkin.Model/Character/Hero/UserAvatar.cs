using Munchkin.Model.Character.Hero.Proficiency;
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
        public Curses Curses;
        public int Wallet { get; set; }
        public bool DidItemSell { get; set; }

        public UserAvatar()
        {
            Proficiency = new NoOneProficiency();
            Build = new Build();
            Level = 1;
            FleeChances = 3;
            TempPower = Power;
            WasBackstab = false;
            WasRob = false;
            HowManyCardsThrowToUseSkill = 0;
            Nerfs = new NerfType();
            Curses = new Curses();
            IsDied = false;
            CountPower();
            Wallet = 0;
            DidItemSell = false;
        }

        public void CountPower()
        {
            Power = 0;
            if (Build != null)
            {
                if (Build.Helmet != null)
                {
                    Power += Build.Helmet.Power;
                }
                if (Build.Armor != null)
                {
                    Power += Build.Armor.Power;
                }
                if (Build.Boots != null)
                {
                    Power += Build.Boots.Power;
                }
                if (Build.LeftHandItem != null)
                {
                    Power += Build.LeftHandItem.Power;
                }
                if (Build.RightHandItem != null)
                {
                    Power += Build.RightHandItem.Power;
                }
                if (Build.AdditionalItems != null)
                {
                    foreach (var item in Build.AdditionalItems)
                    {
                        Power += item.Power;
                    }
                }
            }
            CheckPoison();
            CheckWounds();
            CheckNerfs();
            CheckCurses();
            Power += Level;
            TempPower = Power;
        }

        public void CheckPoison()
        {
            if (Nerfs.Poisoned.Count > 2)
            {
                IsDied = true;
            }
            else
            {
                foreach (var ele in Nerfs.Poisoned)
                {
                    Power -= 1;
                    Level -= 1;
                }
            }
        }

        public void CheckWounds()
        {
            if (Nerfs.Wounded.Count == 1)
            {
                Power -= 2;
            }
            else if (Nerfs.Wounded.Count > 1)
            {
                IsDied = true;
            }
        }

        public void CheckNerfs()
        {
            if (Nerfs.Power.Count > 0)
            {
                foreach (var ele in Nerfs.Power)
                {
                    Power -= ele;
                }
            }
        }

        public void CheckCurses()
        {
            if (Curses.NoDefence)
            {
                GlatorsDontHaveDefence();
                Curses.NoDefence = false;
            }
        }

        public void GlatorsDontHaveDefence()
        {
            if (Build.Helmet != null)
            {
                Power -= Build.Helmet.Power;
            }
            if (Build.Armor != null)
            {
                Power -= Build.Armor.Power;
            }
            if (Build.Boots != null)
            {
                Power -= Build.Boots.Power;
            }
        }

        public void CountFleeChances()
        {
            FleeChances = 3;
            if (Nerfs.FleeChances.Count > 0)
            {
                foreach (var ele in Nerfs.FleeChances)
                {
                    if (FleeChances == 0) return;
                    FleeChances -= ele;
                }
            }
            if (Nerfs.Wounded.Count == 1)
            {
                FleeChances -= 1;
            }
        }

        public void EndTurn()
        {
            CountPower();
            CountFleeChances();
            TempPower = Power;
            WasBackstab = false;
            WasRob = false;
            HowManyCardsThrowToUseSkill = 0;
            Proficiency.CleanAfterTurn();
            DidItemSell = false;
        }

        public bool ItIsOver()
        {
            return Level >= 10 ? true : false;
        }

        public void DisplayAvatarInfo()
        {
            System.Console.WriteLine($"Proficiency: {Proficiency.Name}");
            System.Console.WriteLine($"Race: {Race.Name}");
            System.Console.WriteLine($"Level: {Level}");
            System.Console.WriteLine($"Power: {Power}");
            System.Console.WriteLine($"Helmet: {Build.Helmet.Name}");
            System.Console.WriteLine($"Armor: {Build.Armor.Name}");
            System.Console.WriteLine($"Boots: {Build.Boots.Name}");
            System.Console.WriteLine($"LeftHandItem: {Build.LeftHandItem.Name}");
            System.Console.WriteLine($"RightHandItem: {Build.RightHandItem.Name}");
            foreach(var add in Build.AdditionalItems)
            {
                System.Console.WriteLine($"AdditionalItem: {add.Name}");
            }
            System.Console.WriteLine($"Nerfs, DamagedHead: {Nerfs.DamagedHead}");
            System.Console.WriteLine($"Nerfs, BrokenRibs: {Nerfs.BrokenRibs}");
            System.Console.WriteLine($"Nerfs, BrokenLegs: {Nerfs.BrokenLegs}");
            System.Console.WriteLine($"Nerfs, TornOffArms: {Nerfs.TornOffArms.Count}");
            System.Console.WriteLine($"Nerfs, Poisoned: {Nerfs.Poisoned.Count}");
            System.Console.WriteLine($"Nerfs, Wounded: {Nerfs.Wounded.Count}");
        }
    }
}
