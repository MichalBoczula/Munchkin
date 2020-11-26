using Munchkin.BL.Helper;
using Munchkin.Model.Character;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.PrizeCard.SituationalItems
{
    public class SnowBall : SituationalItem
    {
        private ReadLineOverride readLineOverride;

        public SnowBall(string name, CardType cardType, PrizeCardType prizeCardType, int power, Dictionary<bool, RaceBase> raceRestriction, bool isTwoHanded, ItemType itemType, Dictionary<bool, ProficiencyBase> proficiencyRestriction, int price, ReadLineOverride readLineOverride) : base(name, cardType, prizeCardType, power, raceRestriction, isTwoHanded, itemType, proficiencyRestriction, price)
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
                                        fight.Heros[choice - 1].UserAvatar.Power -= 1;
                                        fight.Heros[choice - 1].UserAvatar.Nerfs.FleeChances.Add(1);
                                        Console.WriteLine($"{fight.Heros[choice - 1].Name} Hero lose 1 point of power and 1 point of flee chances.");
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
                            fight.Heros[0].UserAvatar.Power -= 1;
                            fight.Heros[0].UserAvatar.Nerfs.FleeChances.Add(1);
                            Console.WriteLine($"{fight.Heros[0].Name} Hero lose 1 point of power and 1 point of flee chances.");
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
                                        fight.Monsters[choice - 1].Power -= 1;
                                        Console.WriteLine($"{fight.Monsters[choice - 1].Name} Monster lose 1 point of power.");
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
                            fight.Monsters[0].Power -= 1;
                            Console.WriteLine($"{fight.Monsters[0].Name} Monster lose 1 point of power.");
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

        public override string Description()
        {
            return "SnowBall decrease monster power by 1 or decrease user power and flee chances by 1:" +
                "\nUser lose 1 points of power and 1 point of flee chances. Player Power -= 1 && Player Flee Chances -= 1" +
                "\nMonster lose 1 points of power. Monster Power -= 1";
        }
    }
}
