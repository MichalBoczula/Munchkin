using Munchkin.Model.Character.Action;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Character.Hero.Proficiency
{
    public class MageProficiency : ProficiencyBase, IMageAction
    {
        private readonly InformationModelMageProficiency informationModel;

        public MageProficiency()
        {
            Name = "Mage";
            informationModel = new InformationModelMageProficiency();
        }

        public override void FleeSpell(UserClass user, int num)
        {
            if (num > 3)
            {
                Console.WriteLine(informationModel.WarningMaxCard());
                //Console.ReadLine();
            }
            else if (num <= 0)
            {
                Console.WriteLine(informationModel.NotPossibleMsg());
                return;
            }
            Console.WriteLine(informationModel.FleeSpellWelcomeMsg(user));

            for (int i = 0; i < num; i++)
            {
                if (user.Deck.Count > 0)
                {
                    //Console.ReadLine();
                    if (ThrowOutCart(num, user))
                    {
                        user.UserAvatar.FleeChances += 1;
                        Console.WriteLine(informationModel.PowerUpMsg(user));
                        //Console.ReadLine();
                        if (user.UserAvatar.FleeChances == 6)
                        {
                            Console.WriteLine(informationModel.MaxPowerUpMsg());
                            //Console.ReadLine();
                            return;
                        }
                    }
                }
                else
                {
                    Console.WriteLine(informationModel.NotEnoughCardsMsg());
                    //Console.ReadLine();
                    return;
                }
            }

        }

        public override bool CharmSpell(UserClass user)
        {
            Console.WriteLine(informationModel.CastCharmSpell());
            //Console.ReadLine();
            bool result;
            if (user.Deck.Count > 3)
            {
                Console.WriteLine(informationModel.CharmSpellSuccess());
                //Console.ReadLine();
                result = true;
            }
            else
            {
                Console.WriteLine(informationModel.CharmSpellfailure());
                //Console.ReadLine();
                result = false;
            }
            return result;
        }
    }
}
