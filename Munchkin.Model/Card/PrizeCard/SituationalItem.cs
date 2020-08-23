using Munchkin.Model.Card.PrizeCard;
using Munchkin.Model.Character;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.PrizeCard
{
    public class SituationalItem : PrizeCardBase
    {
        public int Power { get; set; }
        public Dictionary<bool, RaceBase> RaceRestriction { get; set; }
        public Dictionary<bool, ProficiencyBase> ProficiencyRestriction { get; set; }

        public SituationalItem(string name,
                               CardType cardType,
                               PrizeCardType prizeCardType,
                               int power,
                               Dictionary<bool, RaceBase> raceRestriction,
                               Dictionary<bool, ProficiencyBase> proficiencyRestriction) 
            : base(name, cardType, prizeCardType)
        {
            Power = power;
            RaceRestriction = raceRestriction;
            ProficiencyRestriction = proficiencyRestriction;
        }

        public void SpecialEffect()
        {

        }
    }
}
