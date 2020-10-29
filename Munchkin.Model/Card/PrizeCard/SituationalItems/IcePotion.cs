using Munchkin.BL.Helper;
using Munchkin.Model.Character;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.PrizeCard.SituationalItems
{
    public class IcePotion : SituationalItem
    {
        private ReadLineOverride readLineOverride;
        public IcePotion(string name, CardType cardType, PrizeCardType prizeCardType, int power, Dictionary<bool, RaceBase> raceRestriction, bool isTwoHanded, ItemType itemType, Dictionary<bool, ProficiencyBase> proficiencyRestriction, int price, ReadLineOverride readLineOverride) : base(name, cardType, prizeCardType, power, raceRestriction, isTwoHanded, itemType, proficiencyRestriction, price)
        {
            this.readLineOverride = readLineOverride;
        }

        public override void SpecialEffect(Fight fight)
        {
            while (true)
            {
                Console.WriteLine("Choose one option:\n1. Use on Heroes\n2. Use on Monsters");
                if (Int32.TryParse(readLineOverride.GetNextString(), out int result))
                {
                    if (result == 1)
                    {
                        foreach(var hero in fight.Heros)
                        {
                            hero.UserAvatar.FleeChances = 0;
                        }
                        return;
                    }
                    else if (result == 2)
                    {
                        foreach (var hero in fight.Heros)
                        {
                            hero.UserAvatar.FleeChances = 6;
                        }
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Broo choose propertly there are two options. Press enter to continue...");
                        readLineOverride.GetNextString();
                    }
                }
                else
                {
                    Console.WriteLine("Broo choose propertly there are two options. Press enter to continue...");
                    readLineOverride.GetNextString();
                }
            }
        }
    }
}
