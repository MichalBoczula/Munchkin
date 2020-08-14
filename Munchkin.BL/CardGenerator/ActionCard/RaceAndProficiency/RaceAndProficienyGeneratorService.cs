using Munchkin.Model;
using Munchkin.Model.Card.ActionCard.SpecialCardType;
using Munchkin.Model.Card.CardFactory;
using Munchkin.Model.Character.Hero.Proficiency;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.BL.CardGenerator.ActionCard.RaceAndProficiency
{
    public class RaceAndProficienyGeneratorService
    {
        private readonly RaceFactory _raceFactory;
        private readonly ProficiencyFactory _proficiencyFactory;
        private readonly List<RaceCard> Races = new List<RaceCard>();
        private readonly List<ProficiencyCard> Proficiencies = new List<ProficiencyCard>();

        public RaceAndProficienyGeneratorService()
        {
            _raceFactory = new RaceFactory();
            _proficiencyFactory = new ProficiencyFactory();
        }

        public List<RaceCard> GenerateRace()
        {
            var ElfRaceCard = _raceFactory.MakeRaceCard(RaceType.ElfRace);
            var DwarfRaceCard = _raceFactory.MakeRaceCard(RaceType.DwarfRace);
            var HalfingRaceCard = _raceFactory.MakeRaceCard(RaceType.HalfingRace);
            var HumanRaceCard = _raceFactory.MakeRaceCard(RaceType.HumaRace);
            Races.Add(ElfRaceCard);
            Races.Add(DwarfRaceCard);
            Races.Add(HalfingRaceCard);
            Races.Add(HumanRaceCard);
            return Races;
        }

        public List<ProficiencyCard> GenerateProfiecy()
        {
            var MageProficiency = _proficiencyFactory.MakeRaceCard(ProfiencyType.Mage);
            var PriestProficiency = _proficiencyFactory.MakeRaceCard(ProfiencyType.Priest);
            var WarriorProficiency = _proficiencyFactory.MakeRaceCard(ProfiencyType.Warrior);
            var ThiefProficiency = _proficiencyFactory.MakeRaceCard(ProfiencyType.Thief);
            var NoOneProficiency = _proficiencyFactory.MakeRaceCard(ProfiencyType.NoOne);
            Proficiencies.Add(MageProficiency);
            Proficiencies.Add(NoOneProficiency);
            Proficiencies.Add(PriestProficiency);
            Proficiencies.Add(ThiefProficiency);
            Proficiencies.Add(WarriorProficiency);
            return Proficiencies;
        }
    }
}
