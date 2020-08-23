using Munchkin.Model.Character.Action;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Character.Hero.Proficiency
{
    public class MageProficiency : ProficiencyBase, IMageAction
    {
        private readonly InformationModelMageProficiency _informationModel;

        public MageProficiency()
        {
            Name = "Mage";
            _informationModel = new InformationModelMageProficiency();
        }

        public override void FleeSpell(UserClass user, int cardToThrowId)
        {
            if (user.UserAvatar.HowManyCardsThrowToUseSkill < 3)
            {
                if (user.Deck != null && user.Deck.Count > 0)
                {
                    if (ThrowOutCart(cardToThrowId, user))
                    {
                        user.UserAvatar.HowManyCardsThrowToUseSkill++;
                        user.UserAvatar.FleeChances++;
                        Console.WriteLine(_informationModel.SuccessPowerUpFlee);
                        //Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine(_informationModel.NotEnoughCards);
                    //Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine(_informationModel.SkillHasBeenUsedMaxTimes);
                //Console.ReadLine();
            }
        }

        public override bool CharmSpell(UserClass user)
        {
            Console.WriteLine(_informationModel.CastCharmSpell());
            //Console.ReadLine();
            bool result;
            if (user.Deck.Count > 3)
            {
                Console.WriteLine(_informationModel.CharmSpellSuccess());
                user.Deck.Clear();
                //Console.ReadLine();
                result = true;
            }
            else
            {
                Console.WriteLine(_informationModel.CharmSpellfailure());
                //Console.ReadLine();
                result = false;
            }
            return result;
        }
    }
}
