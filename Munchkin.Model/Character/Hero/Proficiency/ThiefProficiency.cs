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
        private new ReadLineOverride readLineOverride { get; set; }
        public Random random { get; set; }
        public bool AreYouSteal { get; set; }
        public bool AreYouBackStab { get; set; }

        public ThiefProficiency(ReadLineOverride readLineOverride, Random random)
        {
            Name = "Thief";
            _informationModelThiefProficiency = new InformationModelThiefProficiency();
            this.readLineOverride = readLineOverride;
            this.random = random;
            AreYouSteal = false;
            AreYouBackStab = false;
        }

        public override void StealCard(UserClass thief, UserClass victim)
        {
            if (!AreYouSteal)
            {
                AreYouSteal = true;
                if (!victim.UserAvatar.WasRob && victim.Deck.Count() > 0)
                {
                    var num = RollDice(random);
                    if (num > 4)
                    {
                        if(victim.Deck.Items.Count == 0)
                        {
                            System.Console.WriteLine("You can't steal item beacuse item doesn't have. Press enter to continue");
                            readLineOverride.GetNextString();
                        }
                        else
                        {
                            victim.UserAvatar.WasRob = true;
                            var item = victim.Deck.Items[random.Next(victim.Deck.Items.Count)];
                            victim.Deck.Items.Remove(item);
                            thief.Deck.Items.Add(item);
                            System.Console.WriteLine("You stole item from you enemy. Press enter to continue");
                            readLineOverride.GetNextString();
                        }
                    }
                }
            }
            else
            {
                System.Console.WriteLine("You can't steal more items. Press enter to continue");
                readLineOverride.GetNextString();
            }
        }

        public override bool BackStab(UserClass victim)
        {
            if (!AreYouBackStab)
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
                        AreYouBackStab = true;
                        victim.UserAvatar.WasBackstab = true;
                        Console.WriteLine(_informationModelThiefProficiency.BackSuccessMsg);
                        readLineOverride.GetNextString();
                    }
                    else
                    {
                        AreYouBackStab = true;
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
            else
            {
                Console.WriteLine("You can only once per turn use back stab skill Press enter to continue");
                readLineOverride.GetNextString();
                return false;
            }
        }

        public override void CleanAfterTurn()
        {
            AreYouSteal = false;
            AreYouBackStab = false;
        }
    }
}
