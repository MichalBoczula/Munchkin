using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Moq;
using Munchkin.BL.CardGenerator;
using Munchkin.BL.CharacterCreator;
using Munchkin.BL.GameController;
using Munchkin.Model;
using Munchkin.Model.Character;
using Munchkin.Model.Character.Hero.Proficiency;
using Xunit;

namespace Munchkin.Tests.Munchkin.Model.Tests.Character.Hero.Proficiency
{
    public class ThiefProficiencyTests
    {
        [Fact]
        public void StealHelmetSuccessTest()
        {

        }

        [Fact]
        public void StealArmorSuccessTest()
        {

        }

        [Fact]
        public void StealBootsSuccessTest()
        {

        }

        [Fact]
        public void StealLeftHandItemSuccessTest()
        {

        }

        [Fact]
        public void StealRightHandItemSuccessTest()
        {

        }

        [Fact]
        public void StealAdditionalItemSuccessTest()
        {

        }

        [Fact]
        public void StealFailTest()
        {

        }

        [Fact]
        public void BackStabSuccessTest()
        {
            //Arrange
            var mockRandom = new Mock<Random>();
            mockRandom.Setup(m => m.Next(6)).Returns(4);
            var thief = new ThiefProficiency();
            var avatar1 = new UserAvatar()
            {
                Proficiency = thief
            };
            var user1 = new UserClass()
            {
                UserAvatar = avatar1
            };

            var mage2 = new MageProficiency();
            var avatar2 = new UserAvatar()
            {
                Proficiency = mage2
            };
            var victim = new UserClass()
            {
                UserAvatar = avatar2
            };
            //Act
            var result = user1.UserAvatar.Proficiency.BackStab(victim, mockRandom.Object);
            //Assert
            result.Should().BeTrue();
            victim.UserAvatar.TempPower.Should().Be(-1);
        }

        [Fact]
        public void BackStabFailTest()
        {
            //Arrange
            var mockRandom = new Mock<Random>();
            mockRandom.Setup(m => m.Next(6)).Returns(1);
            var thief = new ThiefProficiency();
            var avatar1 = new UserAvatar()
            {
                Proficiency = thief
            };
            var user1 = new UserClass()
            {
                UserAvatar = avatar1
            };

            var mage2 = new MageProficiency();
            var avatar2 = new UserAvatar()
            {
                Proficiency = mage2
            };
            var victim = new UserClass()
            {
                UserAvatar = avatar2
            };
            //Act
            var result = user1.UserAvatar.Proficiency.BackStab(victim, mockRandom.Object);
            //Assert
            result.Should().BeFalse();
            victim.UserAvatar.TempPower.Should().Be(1);
        }

        [Fact]
        public void BackStabFailCantTwiceTest()
        {
            //Arrange
            var mockRandom = new Mock<Random>();
            mockRandom.Setup(m => m.Next(6)).Returns(4);
            var thief = new ThiefProficiency();
            var avatar1 = new UserAvatar()
            {
                Proficiency = thief
            };
            var user1 = new UserClass()
            {
                UserAvatar = avatar1
            };

            var mage2 = new MageProficiency();
            var avatar2 = new UserAvatar()
            {
                Proficiency = mage2
            };
            var victim = new UserClass()
            {
                UserAvatar = avatar2
            };
            //Act
            var firstBackStab = user1.UserAvatar.Proficiency.BackStab(victim, mockRandom.Object);
            var secondBackStab = user1.UserAvatar.Proficiency.BackStab(victim, mockRandom.Object);
            //Assert
            firstBackStab.Should().BeTrue();
            secondBackStab.Should().BeFalse();
            victim.UserAvatar.TempPower.Should().Be(-1);
        }
    }
}
