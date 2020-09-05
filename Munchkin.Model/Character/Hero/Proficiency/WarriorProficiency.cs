using Munchkin.Model.Character.Action;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Character.Hero.Proficiency
{
    public class WarriorProficiency : ProficiencyBase, IWarriorAction
    {
        private readonly InformationModelWarriorProficiency _informationModelWarriorProficiency;

        public WarriorProficiency()
        {
            Name = "Warrior";
            _informationModelWarriorProficiency = new InformationModelWarriorProficiency();
        }

        public override void BeStronger(UserClass user, int cardToThrowId)
        {
            if (user.UserAvatar.HowManyCardsThrowToUseSkill < 3)
            {
                if (user.Deck != null && user.Deck.Count() > 0)
                {
                    if (ThrowOutCart(cardToThrowId, user))
                    {
                        user.UserAvatar.HowManyCardsThrowToUseSkill++;
                        user.UserAvatar.TempPower++;
                        Console.WriteLine(_informationModelWarriorProficiency.Success);
                        //Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine(_informationModelWarriorProficiency.NotEnoughCards);
                    //Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine(_informationModelWarriorProficiency.SkillHasBeenUsedMaxTimes);
                //Console.ReadLine();
            }
        }
    }
}
