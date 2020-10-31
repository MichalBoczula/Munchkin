using Munchkin.BL.Helper;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.Character.Action;
using Munchkin.Model.Helper;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Character.Hero.Proficiency
{
    public class PriestProficiency : ProficiencyBase, IPriestAction
    {
        public new ReadLineOverride readLineOverride;

        public PriestProficiency(ReadLineOverride readLineOverride)
        {
            Name = "Priest";
            this.readLineOverride = readLineOverride;
        }

#nullable enable
        public override DestroyedCards MakeMonsterAPet(UserClass user, Fight? fight)
        {
            var destroyedCards = new DestroyedCards();
            if (fight == null) return destroyedCards;
            System.Console.WriteLine("You are trying to cast spell, to cast it you need 3 cards and more. Press enter to continue to check cards");
            readLineOverride.GetNextString();
            if (user.Deck.Count() >= 3)
            {
                while (true)
                {

                    System.Console.WriteLine("You have enough cards do you want cast spell. Remember you will lose you whole deck.\n" +
                        "Choose option:\n1.Yes\n2.No");
                    readLineOverride.GetNextString();
                    if (Int32.TryParse(readLineOverride.GetNextString(), out int result))
                    {
                        if (result == 1)
                        {
                            destroyedCards.DestroyedPrizeCards.AddRange(user.Deck.Items);
                            destroyedCards.DestroyedActionCards.AddRange(user.Deck.Monsters);
                            destroyedCards.DestroyedActionCards.AddRange(user.Deck.MagicCards);
                            user.Deck.Clear();
                            MonsterCardBase monster = fight.Monsters[0];
                            foreach (var mon in fight.Monsters)
                            {
                                if (mon.Power > monster.Power)
                                {
                                    monster = mon;
                                }
                            }
                            user.Deck.Monsters.Add(monster);
                            return destroyedCards;
                        }
                        else if (result == 2)
                        {
                            System.Console.WriteLine("You didn't cast a spell. Press enter to continue");
                            readLineOverride.GetNextString();
                            return destroyedCards;
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("Choose one option 1 or 2. Press enter to continue.");
                        readLineOverride.GetNextString();
                    }
                }

            }
            else
            {
                System.Console.WriteLine("You don't have enough cards to cast spell. Press enter to continue");
                readLineOverride.GetNextString();
                return destroyedCards;
            }
        }
#nullable disable

        public override void RestoreCard(Game game)
        {
            throw new NotImplementedException();
        }
    }
}
