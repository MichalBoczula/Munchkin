using Munchkin.BL.Helper;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard.SpecialCardType.MagicCards
{
    public class AdditionalMonster : ActionCardBase
    {
        private ReadLineOverride readLineOverride;

        public AdditionalMonster(string name, CardType cardType, ReadLineOverride readLineOverride) : base(name, cardType)
        {
            this.readLineOverride = readLineOverride;
        }

        public override void CastSpecialSpell(UserClass user, Game game, Fight fight)
        {
            if (user.Deck.Monsters.Count == 0)
            {
                System.Console.WriteLine("You doesn't have monster bro and destroyed great card... Great Job!!! Press any key");
                readLineOverride.GetNextString();
            }
            else if (user.Deck.Monsters.Count == 1)
            {
                var card = user.Deck.Monsters[0];
                user.Deck.Monsters.Remove(card);
                fight.Monsters.Add(card);
            }
            else
            {
                while (true)
                {
                    for (int i = 0; i < user.Deck.Monsters.Count; i++)
                    {
                        System.Console.WriteLine($"{i + 1}. Name : {user.Deck.Monsters[i].Name}" +
                            $"\nPower: {user.Deck.Monsters[i].Power}" +
                            $"\nPrizes: {user.Deck.Monsters[i].NumberOfPrizes}" +
                            $"\nLevels: {user.Deck.Monsters[i].HowManyLevels}");
                    }

                    if (Int32.TryParse(readLineOverride.GetNextString(), out int num))
                    {
                        var card = user.Deck.Monsters[num];
                        user.Deck.Monsters.Remove(card);
                        fight.Monsters.Add(card);
                        System.Console.WriteLine("Monster added to fight. Press any key");
                        readLineOverride.GetNextString();
                        return;
                    }
                    else
                    {
                        System.Console.WriteLine("Brooo look on choice and choice one of them!!! Press any key");
                        readLineOverride.GetNextString();
                    }
                }
            }
        }
    }

}
