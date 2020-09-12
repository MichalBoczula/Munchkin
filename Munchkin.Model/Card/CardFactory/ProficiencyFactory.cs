using Munchkin.Model.Character.Hero.Proficiency;
using Munchkin.Model.Card.ActionCard.SpecialCardType;
using System;
using System.Collections.Generic;
using System.Text;
using Munchkin.BL.Helper;

namespace Munchkin.Model.Card.CardFactory
{
    public class ProficiencyFactory 
    {
        public ProficiencyCard MakeRaceCard(ProfiencyType cardType)
        {
            var mage = new MageProficiency();
            var priest = new PriestProficiency();
            var thief = new ThiefProficiency(new ReadLineOverride());
            var warrior = new WarriorProficiency();
            var noOne = new NoOneProficiency();

            var result = cardType switch
            {
                ProfiencyType.Mage => new ProficiencyCard("mage card", CardType.Initial, mage),
                ProfiencyType.Priest => new ProficiencyCard("priest card", CardType.Initial, priest),
                ProfiencyType.Thief => new ProficiencyCard("thief card", CardType.Initial, thief),
                ProfiencyType.Warrior => new ProficiencyCard("warrior card", CardType.Initial, warrior),
                ProfiencyType.NoOne => new ProficiencyCard("noOne card", CardType.Initial, noOne),
                _=> null
            };
            return result;
        }
    }

    public enum ProfiencyType
    {
        Mage,
        Priest,
        Thief,
        Warrior,
        NoOne
    }
}

