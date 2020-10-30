using Munchkin.BL.Helper;
using Munchkin.Model.Character.Action;
using Munchkin.Model.Helper;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace Munchkin.Model.Character.Hero.Proficiency
{
    public class WarriorProficiency : ProficiencyBase, IWarriorAction
    {
        private readonly InformationModelWarriorProficiency _informationModelWarriorProficiency;
        private new ReadLineOverride readLineOverride { get; set; }
        public WarriorProficiency(ReadLineOverride readLineOverride)
        {
            Name = "Warrior";
            _informationModelWarriorProficiency = new InformationModelWarriorProficiency();
            this.readLineOverride = readLineOverride;
        }

        public override DestroyedCards BeStronger(UserClass user, int cardToThrow)
        {
            var destroyedCards = new DestroyedCards();
            if (user.UserAvatar.HowManyCardsThrowToUseSkill < 3)
            {
                if (user.Deck != null && user.Deck.Count() > 0)
                {
                    //while (cardToThrow > 0)
                    //{
                    //    cardToThrow--;
                    //}
                }
                else
                {
                    Console.WriteLine(_informationModelWarriorProficiency.NotEnoughCards);
                    readLineOverride.GetNextString();
                    return destroyedCards;
                }
            }
            else
            {
                Console.WriteLine(_informationModelWarriorProficiency.SkillHasBeenUsedMaxTimes);
                readLineOverride.GetNextString();
                return destroyedCards;
            }
            return destroyedCards;
        }
    }
}
