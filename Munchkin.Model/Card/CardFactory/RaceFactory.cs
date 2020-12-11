using Munchkin.Model.Card.ActionCard.SpecialCardType;
using Munchkin.Model.Character.Hero.Race;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.CardFactory
{
    public class RaceFactory
    {
        public RaceCard MakeRaceCard(RaceType cardType)
        {
            var elf = new Elf("Elf");
            var dwarf = new Dwarf("Dwarf");
            var halfing = new Halfling("Halfing");
            var human = new Human("Human");

            var result = cardType switch
            {
                RaceType.ElfRace => new RaceCard("Elf card", CardType.Initial, elf),
                RaceType.DwarfRace => new RaceCard("Dwarf card", CardType.Initial, dwarf),
                RaceType.HalfingRace => new RaceCard("Halfing card", CardType.Initial, halfing),
                RaceType.HumaRace => new RaceCard("Human card", CardType.Initial, human),
                _ => null
            };
            return result;
        }
    }

    public enum RaceType
    {
        ElfRace,
        DwarfRace,
        HalfingRace,
        HumaRace
    }
}
