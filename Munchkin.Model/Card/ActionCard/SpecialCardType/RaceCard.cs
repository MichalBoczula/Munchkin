using Munchkin.Model.Character;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard.SpecialCardType
{
    public class RaceCard : SpecialCard
    {
        public RaceBase Race{ get; set; }

        public RaceCard(string name, CardType cardType, RaceBase race) : base(name, cardType)
        {
            Race = race;
        }

        public override void SpecialEffect(UserClass user)
        {
            try
            {
                if(user.Character.Race == null)
                {
                    user.Character.Race = Race;
                }
                else
                {
                    Console.WriteLine($"Sorry Bro you have Race: {user.Character.Race}. In Munchkin there is NOT \"Each Race Movement\"");
                }
            }
            catch(NullReferenceException)
            {
                    Console.WriteLine("Class: RaceCard, Method: SpecialEffects, Message: User is null");
            }
        }
    }
}
