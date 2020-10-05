using Munchkin.BL.Helper;
using Munchkin.Model.Character;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.PrizeCard.SituationalItems
{
    public class DeadlyBerries : SituationalItem
    {
        private ReadLineOverride readLineOverride;

        public DeadlyBerries(string name, CardType cardType, PrizeCardType prizeCardType, int power, Dictionary<bool, RaceBase> raceRestriction, bool isTwoHanded, ItemType itemType, Dictionary<bool, ProficiencyBase> proficiencyRestriction, int price, ReadLineOverride readLineOverride) : base(name, cardType, prizeCardType, power, raceRestriction, isTwoHanded, itemType, proficiencyRestriction, price)
        {
            this.readLineOverride = readLineOverride;
        }

        public override void SpecialEffect(Fight fight)
        {
            while (true)
            {
                Console.WriteLine("Choose one of option:\n1.Use on Hero\n2.Use on Monster");
                if (Int32.TryParse(readLineOverride.GetNextString(), out int result))
                {
                    if (result == 1)
                    {
                        if (fight.Heros.Count > 1)
                        {
                            while (true)
                            {
                                Console.WriteLine("Choose one of Herose:");
                                for (int i = 0; i < fight.Heros.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1}. {fight.Heros[i].Name}");
                                }
                                if (Int32.TryParse(readLineOverride.GetNextString(), out int choice))
                                {
                                    if (choice - 1 <= fight.Heros.Count - 1)
                                    {
                                        fight.Heros[choice - 1].Power -= 2;
                                        fight.Heros[choice - 1].Nerfs.Poisoned.Add(true);
                                        return;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Choose one option from List");
                                        readLineOverride.GetNextString();
                                    }
                                }
                            }
                        }
                        else
                        {
                            fight.Heros[0].Power -= 2;
                            fight.Heros[0].Nerfs.Poisoned.Add(true);
                            return;
                        }
                    }
                    else if (result == 2)
                    {
                        if (fight.Monsters.Count > 1)
                        {
                            while (true)
                            {
                                Console.WriteLine("Choose one of Herose:");
                                for (int i = 0; i < fight.Monsters.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1}. {fight.Monsters[i].Name}");
                                }
                                if (Int32.TryParse(readLineOverride.GetNextString(), out int choice))
                                {
                                    if (choice - 1 <= fight.Monsters.Count - 1)
                                    {
                                        fight.Monsters[choice - 1].Power -= 3;
                                        return;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Choose one option from List");
                                        readLineOverride.GetNextString();
                                    }
                                }
                            }
                        }
                        else
                        {
                            fight.Monsters[0].Power -= 3;
                            return;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Bro Choose one option Hero or Monster.");
                    readLineOverride.GetNextString();
                }
            }
        }
    }
}
