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
                        System.Console.WriteLine("Heroes FleeChances is 0 points");
                        return;
                    }
                    else if (result == 2)
                    {
                        foreach (var hero in fight.Heros)
                        {
                            hero.UserAvatar.FleeChances = 6;
                        }
                        System.Console.WriteLine("Heroes FleeChances is 6 points");
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

        public override void Description()
        {
            System.Console.WriteLine("IcePotion, blood in your vines freeze, card can be use on player or monster:" +
                "\nPlayer loose all flee chances: Player FleeChances = 0" +
                "\nUse on monster and you can flee without problems: Player FleeChances = 6");
        }
    }
}
