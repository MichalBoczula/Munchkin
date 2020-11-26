using Munchkin.BL.Helper;
using Munchkin.Model.Character;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.PrizeCard.SituationalItems
{
    public class DionisiosWine : SituationalItem
    {
        private ReadLineOverride readLineOverride;

        public DionisiosWine(string name, CardType cardType, PrizeCardType prizeCardType, int power, Dictionary<bool, RaceBase> raceRestriction, bool isTwoHanded, ItemType itemType, Dictionary<bool, ProficiencyBase> proficiencyRestriction, int price, ReadLineOverride readLineOverride) : base(name, cardType, prizeCardType, power, raceRestriction, isTwoHanded, itemType, proficiencyRestriction, price)
        {
            this.readLineOverride = readLineOverride;
        }

        public override void SpecialEffect(Fight fight)
        {
            while (true)
            {
                Console.WriteLine("Choose heros or monster:\n1.Heros\n2.Monster");
                if(Int32.TryParse(readLineOverride.GetNextString(), out int choice))
                {
                    if(choice == 1)
                    {
                        foreach(var hero in fight.Heros)
                        {
                            hero.UserAvatar.Power += 3;
                            hero.UserAvatar.FleeChances -= 2;
                        }
                        System.Console.WriteLine("Heroes get 3 power boots and lose 2 point of flee chances");
                        return;
                    }
                    else if (choice == 2)
                    {
                        foreach (var monster in fight.Monsters)
                        {
                            monster.Power += 3;
                        }
                        foreach (var hero in fight.Heros)
                        {
                            hero.UserAvatar.FleeChances += 2;
                        }
                        System.Console.WriteLine("Monsters get 3 power boots and Users gain 2 point of flee chances");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Maaannnn choose one option from list!!!\nPress enter to continue...");
                    readLineOverride.GetNextString();
                }
            }
        }

        public override void Description()
        {
            System.Console.WriteLine("DionisiosWine used make drunk you or monster can be use on user or monster:" +
                "\nUser get 3 points of power and lose 2 poison flee chances. Player Power += 3 && Player FleeChances -= 2" +
                "\nMonster get 3 points of power but Player chances to flee increased by 2 points. Monster Power += 3 && Player FleeChances += 2");
        }
    }
}
