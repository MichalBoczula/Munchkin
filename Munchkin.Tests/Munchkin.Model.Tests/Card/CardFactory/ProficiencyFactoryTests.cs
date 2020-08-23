using Munchkin.Model.Card.ActionCard.SpecialCardType;
using Munchkin.Model.Card.CardFactory;
using Munchkin.Model.Character.Hero.Proficiency;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;

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
            shouldBeMage.Should().BeOfType<ProficiencyCard>();
            shouldBeNoOne.Should().BeOfType<ProficiencyCard>();
            shouldBePriest.Should().BeOfType<ProficiencyCard>();
            shouldBeThief.Should().BeOfType<ProficiencyCard>();
            shouldBeWarrior.Should().BeOfType<ProficiencyCard>();
            //ProficiencyType
            shouldBeMage.Proficiency.Should().BeOfType<MageProficiency>();
            shouldBeNoOne.Proficiency.Should().BeOfType<NoOneProficiency>();
            shouldBePriest.Proficiency.Should().BeOfType<PriestProficiency>();
            shouldBeThief.Proficiency.Should().BeOfType<ThiefProficiency>();
            shouldBeWarrior.Proficiency.Should().BeOfType<WarriorProficiency>();
        }
    }
}
