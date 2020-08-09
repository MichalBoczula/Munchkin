using Munchkin.Model.Character.Hero.Proficiency;
using Munchkin.Model.Card.ActionCard.SpecialCardType;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.CardFactory
{
    public class ProficiencyFactory
    {
        public CardGameBase MakeRaceCard(ProfiencyType cardType)
        {
            var mage = new MageProficiency();
            var priest = new PriestProficiency();
            var thief = new ThiefProficiency();
            var warrior = new WarriorProficiency();
            var noOne = new NoOneProficiency();

            var result = cardType switch
            {
                ProfiencyType.Mage => new ProficiencyCard("mage card", CardType.Action, mage),
                ProfiencyType.Priest => new ProficiencyCard("priest card", CardType.Action, priest),
                ProfiencyType.Thief => new ProficiencyCard("thief card", CardType.Action, thief),
                ProfiencyType.Warrior => new ProficiencyCard("warrior card", CardType.Action, warrior),
                _ => new ProficiencyCard("noOne card", CardType.Action, noOne),
            };
            return null;
        }
    }

    public enum ProfiencyType
    {
        Mage,
        Priest,
        Thief,
        Warrior
    }
}

