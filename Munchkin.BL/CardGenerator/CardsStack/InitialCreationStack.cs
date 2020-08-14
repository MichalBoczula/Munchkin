using Munchkin.Model.Card.ActionCard.SpecialCardType;
using System.Collections.Generic;

namespace Munchkin.BL.CardGenerator.CardsStack
{
    public class InitialCreationStack
    {
        public List<RaceCard> Races { get; }
        public List<ProficiencyCard> Proficiencies { get;}

        public InitialCreationStack(List<RaceCard> races, List<ProficiencyCard> proficiencies)
        {
            Races = races;
            Proficiencies = proficiencies;
        }

    }
}
