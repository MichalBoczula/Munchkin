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
            var elf = new Elf("elf");
            var dwarf = new Dwarf("dwarf");
            var halfing = new Halfling("halfing");
            var human = new Human("human");

            var result = cardType switch
            {
                RaceType.ElfRace => new RaceCard("elf card", CardType.Initial, elf),
                RaceType.DwarfRace => new RaceCard("dwarf card", CardType.Initial, dwarf),
                RaceType.HalfingRace => new RaceCard("halfing card", CardType.Initial, halfing),
                RaceType.HumaRace => new RaceCard("human card", CardType.Initial, human),
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
