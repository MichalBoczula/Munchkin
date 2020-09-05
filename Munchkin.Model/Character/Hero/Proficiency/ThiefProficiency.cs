using Munchkin.BL.Helper;
using Munchkin.Model.Card.PrizeCard;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Character.Hero.Proficiency
{
    public class ThiefProficiency : ProficiencyBase, IThiefAction
    {
        private readonly InformationModelThiefProficiency _informationModelThiefProficiency;
        private ReadLineOverride readLineOverride { get; set; }

        public ThiefProficiency(ReadLineOverride readLineOverride)
        {
            Name = "Thief";
            _informationModelThiefProficiency = new InformationModelThiefProficiency();
            this.readLineOverride = readLineOverride;
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
                        readLineOverride.GetNextString();
                        int choice;
                        while (true)
                        {
                            Console.WriteLine(_informationModelThiefProficiency.StealWelcomeMsg(information));
                            if (!Int32.TryParse(readLine.GetNextString(), out choice))
                            {
                                Console.WriteLine(_informationModelThiefProficiency.StealInvalidInput);
                                readLineOverride.GetNextString();
                                continue;
                            }

                            if (choice > information.ItemCount || choice < 0)
                            {
                                Console.WriteLine(_informationModelThiefProficiency.InvalidNumber(information));
                                readLineOverride.GetNextString();
                            }
                            else if (choice <= information.ItemCount || choice > 0)
                            {
                                break;
                            }
                        }
                        MoveItemFromVictimToThief(thief, victim, choice);
                        Console.WriteLine(_informationModelThiefProficiency.StealSuccessfully);
                        readLineOverride.GetNextString();
                    }
                    else
                    {
                        Console.WriteLine(_informationModelThiefProficiency.StealFail);
                        readLineOverride.GetNextString();
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
            thief.Deck.Items.Add(stolen);
        }

        public override bool BackStab(UserClass victim, Random random)
        {
            bool result = false;

            if (!victim.UserAvatar.WasBackstab)
            {
                Console.WriteLine(_informationModelThiefProficiency.BackStabMsg);
                readLineOverride.GetNextString();
                var num = RollDice(random);
                if (num > 3)
                {
                    victim.UserAvatar.TempPower -= 2;
                    result = true;
                    victim.UserAvatar.WasBackstab = true;
                    Console.WriteLine(_informationModelThiefProficiency.BackSuccessMsg);
                    readLineOverride.GetNextString();
                }
                else
                {
                    Console.WriteLine(_informationModelThiefProficiency.BackFailMsg);
                    readLineOverride.GetNextString();
                }
            }
            else
            {
                Console.WriteLine(_informationModelThiefProficiency.CanNotBackStabTwoTimes);
                readLineOverride.GetNextString();
            }
            return result;
        }
    }
}
