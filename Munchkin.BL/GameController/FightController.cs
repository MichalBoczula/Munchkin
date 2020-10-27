using Munchkin.Model.Character.Hero.Proficiency;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.BL.GameController
{
    public class FightController
    {
        public bool WhoWinFight(Fight fight)
        {
            int num = fight.Heros.Count >= fight.Monsters.Count ? fight.Heros.Count : fight.Monsters.Count;
            int monsterPower = 0;
            int heroPower = 0;
            for (int i = 0; i < num; i++)
            {
                if (i <= fight.Heros.Count - 1)
                {
                    heroPower += fight.Heros[i].Power;
                }
                if (i <= fight.Monsters.Count - 1)
                {
                    monsterPower += fight.Monsters[i].Power;
                }
            }

            if (heroPower > monsterPower)
            {
                return true;
            }
            if (heroPower == monsterPower)
            {
                foreach(var hero in fight.Heros)
                {
                    if(!(hero.Proficiency is WarriorProficiency))
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
    }
}
