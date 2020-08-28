﻿using Munchkin.BL.Helper;
using Munchkin.Model.Card.PrizeCard;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Character.Hero.Proficiency
{
    public class ThiefProficiency : ProficiencyBase, IThiefAction
    {
        private readonly InformationModelThiefProficiency _informationModelThiefProficiency;

        public ThiefProficiency()
        {
            Name = "Thief";
            _informationModelThiefProficiency = new InformationModelThiefProficiency();
        }

        public override void StealCard(UserClass thief, UserClass victim, Random random, ReadLineOverride readLine)
        {
            if (!victim.UserAvatar.WasRob)
            {
                victim.UserAvatar.WasRob = true;
                if (victim.UserAvatar.Build != null)
                {
                    var num = RollDice(random);
                    if (num > 4)
                    {
                        var information = _informationModelThiefProficiency.ShowItemsToSteal(victim.UserAvatar.Build);
                        Console.WriteLine(information.ItemDescription);
                        //Console.ReadLine();
                        int choice;
                        while (true)
                        {
                            Console.WriteLine(_informationModelThiefProficiency.StealWelcomeMsg(information));
                            if (!Int32.TryParse(readLine.GetNextString(), out choice))
                            {
                                Console.WriteLine(_informationModelThiefProficiency.StealInvalidInput);
                                //Console.ReadLine();
                                continue;
                            }

                            if(choice > information.ItemCount || choice < 0)
                            {
                                Console.WriteLine(_informationModelThiefProficiency.InvalidNumber(information));
                                //Console.ReadLine();
                            }
                            else if(choice <= information.ItemCount || choice > 0)
                            {
                                break;
                            }
                        }
                        MoveItemFromVictimToThief(thief, victim, choice);
                        Console.WriteLine(_informationModelThiefProficiency.StealSuccessfully);
                        //Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine(_informationModelThiefProficiency.StealFail);
                        //Console.ReadLine();
                    }
                }
            }
        }

        public void MoveItemFromVictimToThief(UserClass thief, UserClass victim, int choice)
        {
            ItemCard stolen = null;
            if (choice > 5)
            {
                stolen = victim.UserAvatar.Build.AdditionalItems[choice - 6];
                victim.UserAvatar.Build.AdditionalItems.Remove(stolen);
            }
            else
            {
                switch (choice)
                {
                    case 1:
                        stolen = victim.UserAvatar.Build.Helmet;
                        victim.UserAvatar.Build.Helmet = null;
                        break;
                    case 2:
                        stolen = victim.UserAvatar.Build.Armor;
                        victim.UserAvatar.Build.Armor = null;
                        break;
                    case 3:
                        stolen = victim.UserAvatar.Build.Boots;
                        victim.UserAvatar.Build.Boots = null;
                        break;
                    case 4:
                        stolen = victim.UserAvatar.Build.LeftHandItem;
                        victim.UserAvatar.Build.LeftHandItem = null;
                        break;
                    case 5:
                        stolen = victim.UserAvatar.Build.RightHandItem;
                        victim.UserAvatar.Build.RightHandItem = null;
                        break;
                }
            }
            thief.Deck.Add(stolen);
        }

        public override bool BackStab(UserClass victim, Random random)
        {
            bool result = false;

            if (!victim.UserAvatar.WasBackstab)
            {
                Console.WriteLine(_informationModelThiefProficiency.BackStabMsg);
                //Console.ReadLine();
                var num = RollDice(random);
                if (num > 3)
                {
                    victim.UserAvatar.TempPower -= 2;
                    result = true;
                    victim.UserAvatar.WasBackstab = true;
                    Console.WriteLine(_informationModelThiefProficiency.BackSuccessMsg);
                    //Console.ReadLine();
                }
                else
                {
                    Console.WriteLine(_informationModelThiefProficiency.BackFailMsg);
                    //Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine(_informationModelThiefProficiency.CanNotBackStabTwoTimes);
                //Console.ReadLine();
            }
            return result;
        }
    }
}
