using Munchkin.Model.Card.ActionCard.SpecialCardType;
using Munchkin.Model.Card.CardFactory;
using Munchkin.Model.Character.Hero.Proficiency;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Munchkin.Tests.Munchkin.Model.Tests.Card.CardFactory
{
    public class ProficiencyFactoryTests
    {
        [Fact]
        public void MakeRaceCardTest()
        {
            //Arrange
            var proficiencyFactory = new ProficiencyFactory();
            //Act
            var shouldBeMage = proficiencyFactory.MakeRaceCard(ProfiencyType.Mage);
            var shouldBeNoOne = proficiencyFactory.MakeRaceCard(ProfiencyType.NoOne);
            var shouldBePriest = proficiencyFactory.MakeRaceCard(ProfiencyType.Priest);
            var shouldBeThief = proficiencyFactory.MakeRaceCard(ProfiencyType.Thief);
            var shouldBeWarrior = proficiencyFactory.MakeRaceCard(ProfiencyType.Warrior);
            //Assert
            //CardType
            Assert.IsType<ProficiencyCard>(shouldBeMage);
            Assert.IsType<ProficiencyCard>(shouldBeNoOne);
            Assert.IsType<ProficiencyCard>(shouldBePriest);
            Assert.IsType<ProficiencyCard>(shouldBeThief);
            Assert.IsType<ProficiencyCard>(shouldBeWarrior);
            //ProficiencyType
            Assert.IsType<MageProficiency>(shouldBeMage.Proficiency);
            Assert.IsType<NoOneProficiency>(shouldBeNoOne.Proficiency);
            Assert.IsType<PriestProficiency>(shouldBePriest.Proficiency);
            Assert.IsType<ThiefProficiency>(shouldBeThief.Proficiency);
            Assert.IsType<WarriorProficiency>(shouldBeWarrior.Proficiency);
        }
    }
}
