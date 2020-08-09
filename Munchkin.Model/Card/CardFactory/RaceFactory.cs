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
                RaceType.ElfRace => new RaceCard("elf card", CardType.Action, elf),
                RaceType.DwarfRace => new RaceCard("dwarf card", CardType.Action, dwarf),
                RaceType.HalfingRace => new RaceCard("halfing card", CardType.Action, halfing),
                RaceType.HumaRace => new RaceCard("human card", CardType.Action, human),
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
