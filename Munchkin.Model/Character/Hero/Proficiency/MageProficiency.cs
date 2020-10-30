using Munchkin.BL.Helper;
using Munchkin.Model.Character.Action;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Character.Hero.Proficiency
{
    public class MageProficiency : ProficiencyBase, IMageAction
    {
        private readonly InformationModelMageProficiency _informationModel;
        public new ReadLineOverride readLineOverride;

        public MageProficiency(ReadLineOverride readLineOverride)
        {
            Name = "Mage";
            _informationModel = new InformationModelMageProficiency();
            this.readLineOverride = readLineOverride;
        }

        public override void FleeSpell(UserClass user, int cardToThrowId)
        {
            if (user.UserAvatar.HowManyCardsThrowToUseSkill < 3)
            {
                if (user.Deck != null && user.Deck.Count()> 0)
                {
                    if (ThrowOutCart(cardToThrowId, user))
                    {
                        user.UserAvatar.HowManyCardsThrowToUseSkill++;
                        user.UserAvatar.FleeChances++;
                        Console.WriteLine(_informationModel.SuccessPowerUpFlee);
                        readLineOverride.GetNextString();
                    }
                }
                else
                {
                    Console.WriteLine(_informationModel.NotEnoughCards);
                    readLineOverride.GetNextString();
                }
            }
            else
            {
                Console.WriteLine(_informationModel.SkillHasBeenUsedMaxTimes);
                readLineOverride.GetNextString();
            }
        }

        public override bool CharmSpell(UserClass user)
        {
            Console.WriteLine(_informationModel.CastCharmSpell());
            readLineOverride.GetNextString();
            bool result;
            if (user.Deck.Count() > 3)
            {
                Console.WriteLine(_informationModel.CharmSpellSuccess());
                user.Deck.Clear();
                readLineOverride.GetNextString();
                result = true;
            }
            else
            {
                Console.WriteLine(_informationModel.CharmSpellfailure());
                readLineOverride.GetNextString();
                result = false;
            }
            return result;
        }
    }
}
