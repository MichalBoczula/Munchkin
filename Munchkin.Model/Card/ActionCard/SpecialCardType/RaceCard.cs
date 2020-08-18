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
                user.UserAvatar.Race = Race;
            }
            catch(NullReferenceException)
            {
                 Console.WriteLine("Class: RaceCard, Method: SpecialEffects, Message: User is null");
            }
        }
    }
}
