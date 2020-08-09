using Munchkin.Model.Character;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard.SpecialCardType
{
    public class ProficiencyCard : SpecialCard
    {
        public ProficiencyBase Proficiency { get; set; }

        public ProficiencyCard(string name, CardType cardType, ProficiencyBase proficiency) : base(name, cardType)
        {
            Proficiency = proficiency;
        }

        public override void SpecialEffect(UserClass user)
        {
            try
            {
                user.Character.Proficiency = Proficiency;
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Class: ProficiencyCard, Method: SpecialEffects, Message: User is null");
            }
        }
    }
}
