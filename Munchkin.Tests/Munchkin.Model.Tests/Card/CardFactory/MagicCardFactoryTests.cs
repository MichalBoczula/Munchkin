using FluentAssertions;
using Munchkin.Model.Card.ActionCard.SpecialCardType.MagicCards;
using Munchkin.Model.Card.CardFactory;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Munchkin.Tests.Munchkin.Model.Tests.Card.CardFactory
{
    public class MagicCardFactoryTests
    {
        [Fact]
        public void CreateWeaponCardTest()
        {
            //Arrange
            var magicCardFactory = new MagicCardFactory();
            //Act
            var m1 = magicCardFactory.CreateMagicCard(1);
            var m2 = magicCardFactory.CreateMagicCard(2);
            var m3 = magicCardFactory.CreateMagicCard(3);
            var m4 = magicCardFactory.CreateMagicCard(4);
            var m5 = magicCardFactory.CreateMagicCard(5);
            var m6 = magicCardFactory.CreateMagicCard(6);
            var m7 = magicCardFactory.CreateMagicCard(7);
            var m8 = magicCardFactory.CreateMagicCard(8);
            var m9 = magicCardFactory.CreateMagicCard(9);
            var m10 = magicCardFactory.CreateMagicCard(10);
            var m11 = magicCardFactory.CreateMagicCard(11);
            var m12 = magicCardFactory.CreateMagicCard(12);
            var m13 = magicCardFactory.CreateMagicCard(13);
            var m14 = magicCardFactory.CreateMagicCard(14);
            var m15 = magicCardFactory.CreateMagicCard(15);
            var m16 = magicCardFactory.CreateMagicCard(16);
            var m17 = magicCardFactory.CreateMagicCard(17);
            var m18 = magicCardFactory.CreateMagicCard(18);
            var m19 = magicCardFactory.CreateMagicCard(19);
            var m20 = magicCardFactory.CreateMagicCard(20);
            var m21 = magicCardFactory.CreateMagicCard(21);
            var m22 = magicCardFactory.CreateMagicCard(22);
            var m23 = magicCardFactory.CreateMagicCard(23);
            var m24 = magicCardFactory.CreateMagicCard(24);
            var m25 = magicCardFactory.CreateMagicCard(25);
            var m26 = magicCardFactory.CreateMagicCard(26);
            var m27 = magicCardFactory.CreateMagicCard(27);
            var m28 = magicCardFactory.CreateMagicCard(28);
            var m29 = magicCardFactory.CreateMagicCard(29);
            var m30 = magicCardFactory.CreateMagicCard(30);
            var m31 = magicCardFactory.CreateMagicCard(31);
            var m32 = magicCardFactory.CreateMagicCard(32);
            var m33 = magicCardFactory.CreateMagicCard(33);
            var m34 = magicCardFactory.CreateMagicCard(34);
            //Assert
            m1.Should().BeOfType<PayToHaron>();
            m2.Should().BeOfType<ToTheArea>();
            m3.Should().BeOfType<DamagedBoots>();
            m4.Should().BeOfType<DamagedHelmet>();
            m5.Should().BeOfType<HeroicSacrafice>();
            m6.Should().BeOfType<Friday13th>();
            m7.Should().BeOfType<ForgotHowToFight>();
            m8.Should().BeOfType<YouAreNoSkillBro>();
            m9.Should().BeOfType<Unlucky>();
            m10.Should().BeOfType<GodIsAngry>();
            m11.Should().BeOfType<LifeIsHard>();
            m12.Should().BeOfType<ItIsTooMuch>();
            m13.Should().BeOfType<YouMustToPayMorgage>();
            m14.Should().BeOfType<BackToSchool>();
            m15.Should().BeOfType<DamagedArmor>();
            m16.Should().BeOfType<DropWeapons>();
            m17.Should().BeOfType<ItIsTooHeavy>();
            m18.Should().BeOfType<FridayNightCurse>();
            m19.Should().BeOfType<YouHaveAccident>();
            m20.Should().BeOfType<LetsGoTogether>();
            m21.Should().BeOfType<MagicWind>();
            m22.Should().BeOfType<Titan>();
            m23.Should().BeOfType<LikeAGod>();
            m24.Should().BeOfType<Undead>();
            m25.Should().BeOfType<SecondLifeForMonster>();
            m26.Should().BeOfType<Crook>();
            m27.Should().BeOfType<Crook>();
            m28.Should().BeOfType<ItemFairy>();
            m29.Should().BeOfType<Gambling>();
            m30.Should().BeOfType<DrunkCurse>();
            m31.Should().BeOfType<WhatAMess>();
            m32.Should().BeOfType<AdditionalMonster>();
            m33.Should().BeOfType<AdditionalMonster>();
            m34.Should().BeOfType<AdditionalMonster>();
        }
    }
}
