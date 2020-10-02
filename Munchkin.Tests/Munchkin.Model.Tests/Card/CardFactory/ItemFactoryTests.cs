using FluentAssertions;
using Munchkin.Model.Card.CardFactory;
using Munchkin.Model.Card.PrizeCard;
using Munchkin.Model.Character.Hero.Proficiency;
using Munchkin.Model.Character.Hero.Race;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Munchkin.Tests.Munchkin.Model.Tests.Card.CardFactory
{
    public class ItemFactoryTests
    {
        private readonly ItemFactory _itemFactory;

        public ItemFactoryTests()
        {
            //arrange
            _itemFactory = new ItemFactory();
        }

        [Fact]
        public void CreateWeaponCardTest()
        {
            //In contructor
            //Act
            var shouldBeSword2H = _itemFactory.CreateWeaponCard("sword2H");
            var sholudBeSword1H = _itemFactory.CreateWeaponCard("sword1H");
            var shouldBeKhazaDumHammer = _itemFactory.CreateWeaponCard("khazaDumHammer");
            var shouldBeAxe = _itemFactory.CreateWeaponCard("axe");
            var shouldBeThorsHammer = _itemFactory.CreateWeaponCard("thorsHammer");
            //Assert
            //Name
            shouldBeSword2H.Name.Should().Be("sword2H");
            sholudBeSword1H.Name.Should().Be("sword1H");
            shouldBeKhazaDumHammer.Name.Should().Be("khazaDumHammer");
            shouldBeAxe.Name.Should().Be("axe");
            shouldBeThorsHammer.Name.Should().Be("thorsHammer");
            //Type
            shouldBeSword2H.ItemType.Should().Be(ItemType.Weapon);
            sholudBeSword1H.ItemType.Should().Be(ItemType.Weapon);
            shouldBeKhazaDumHammer.ItemType.Should().Be(ItemType.Weapon);
            shouldBeAxe.ItemType.Should().Be(ItemType.Weapon);
            shouldBeThorsHammer.ItemType.Should().Be(ItemType.Weapon);
        }

        [Fact]
        public void CreateArmorCardTest()
        {
            //In contructor
            //Act
            var ElfGoldenArmor = _itemFactory.CreateArmorCard("ElfGoldenArmor");
            var Robe = _itemFactory.CreateArmorCard("Robe");
            var MoiraArmor = _itemFactory.CreateArmorCard("MoiraArmor");
            var PlateArmor = _itemFactory.CreateArmorCard("PlateArmor");
            var GodsArmor = _itemFactory.CreateArmorCard("GodsArmor");
            //Assert
            //Name
            ElfGoldenArmor.Name.Should().Be("ElfGoldenArmor");
            Robe.Name.Should().Be("Robe");
            MoiraArmor.Name.Should().Be("MoiraArmor");
            PlateArmor.Name.Should().Be("PlateArmor");
            GodsArmor.Name.Should().Be("GodsArmor");
            //Type
            ElfGoldenArmor.ItemType.Should().Be(ItemType.Armor);
            Robe.ItemType.Should().Be(ItemType.Armor);
            MoiraArmor.ItemType.Should().Be(ItemType.Armor);
            PlateArmor.ItemType.Should().Be(ItemType.Armor);
            GodsArmor.ItemType.Should().Be(ItemType.Armor);
            //Restriction
            ElfGoldenArmor.ProficiencyRestriction.Should().BeNull();
            Robe.ProficiencyRestriction.Should().BeNull();
            MoiraArmor.ProficiencyRestriction.Should().BeNull();
            PlateArmor.ProficiencyRestriction.Should().BeNull();
            GodsArmor.ProficiencyRestriction[true].Should().BeOfType<WarriorProficiency>();
            ElfGoldenArmor.RaceRestriction[true].Should().BeOfType<Elf>();
            Robe.RaceRestriction.Should().BeNull();
            MoiraArmor.RaceRestriction[true].Should().BeOfType<Dwarf>();
            PlateArmor.RaceRestriction.Should().BeNull();
            GodsArmor.RaceRestriction.Should().BeNull();
            //Power
            ElfGoldenArmor.Power.Should().Be(5);
            Robe.Power.Should().Be(3);
            MoiraArmor.Power.Should().Be(4);
            PlateArmor.Power.Should().Be(3);
            GodsArmor.Power.Should().Be(6);
            //Price
            ElfGoldenArmor.Price.Should().Be(600);
            Robe.Price.Should().Be(300);
            MoiraArmor.Price.Should().Be(400);
            PlateArmor.Price.Should().Be(300);
            GodsArmor.Price.Should().Be(600);
        }

        [Fact]
        public void CreateBootsCardTest()
        {
            //In contructor
            //Act
            var BootsOfHaste = _itemFactory.CreateBootsCard("BootsOfHaste");
            var GlassBoots = _itemFactory.CreateBootsCard("GlassBoots");
            var DragonSkinsSandal = _itemFactory.CreateBootsCard("DragonSkinsSandal");
            var MagicBoots = _itemFactory.CreateBootsCard("MagicBoots");
            var NormalBoot = _itemFactory.CreateBootsCard("NormalBoot");
            //Assert
            //Name
            BootsOfHaste.Name.Should().Be("BootsOfHaste");
            GlassBoots.Name.Should().Be("GlassBoots");
            DragonSkinsSandal.Name.Should().Be("DragonSkinsSandal");
            MagicBoots.Name.Should().Be("MagicBoots");
            NormalBoot.Name.Should().Be("NormalBoot");
            //Type
            BootsOfHaste.ItemType.Should().Be(ItemType.Boots);
            GlassBoots.ItemType.Should().Be(ItemType.Boots);
            DragonSkinsSandal.ItemType.Should().Be(ItemType.Boots);
            MagicBoots.ItemType.Should().Be(ItemType.Boots);
            NormalBoot.ItemType.Should().Be(ItemType.Boots);
            //Restriction
            BootsOfHaste.ProficiencyRestriction.Should().BeNull();
            GlassBoots.ProficiencyRestriction.Should().BeNull();
            DragonSkinsSandal.ProficiencyRestriction.Should().BeNull();
            MagicBoots.ProficiencyRestriction.Should().BeNull();
            NormalBoot.ProficiencyRestriction.Should().BeNull();
            BootsOfHaste.RaceRestriction.Should().BeNull();
            GlassBoots.RaceRestriction.Should().BeNull();
            DragonSkinsSandal.RaceRestriction.Should().BeNull();
            MagicBoots.RaceRestriction.Should().BeNull();
            NormalBoot.RaceRestriction.Should().BeNull();
            //Power
            BootsOfHaste.Power.Should().Be(2);
            GlassBoots.Power.Should().Be(3);
            DragonSkinsSandal.Power.Should().Be(4);
            MagicBoots.Power.Should().Be(4);
            NormalBoot.Power.Should().Be(1);
            //Price
            BootsOfHaste.Price.Should().Be(200);
            GlassBoots.Price.Should().Be(300);
            DragonSkinsSandal.Price.Should().Be(600);
            MagicBoots.Price.Should().Be(500);
            NormalBoot.Price.Should().Be(100);
        }

        [Fact]
        public void CreateHelmetCardTest()
        {
            //In contructor
            //Act
            var ritualHelmet = _itemFactory.CreateHelmetCard("RitualHelmet");
            var warHelmet = _itemFactory.CreateHelmetCard("WarHelmet");
            var maskOfDead = _itemFactory.CreateHelmetCard("MaskOfDead");
            var laurelWreath = _itemFactory.CreateHelmetCard("LaurelWreath");
            var leatherHelmet = _itemFactory.CreateHelmetCard("LeatherHelmet");
            //Assert
            //Name
            ritualHelmet.Name.Should().Be("RitualHelmet");
            warHelmet.Name.Should().Be("WarHelmet");
            maskOfDead.Name.Should().Be("MaskOfDead");
            laurelWreath.Name.Should().Be("LaurelWreath");
            leatherHelmet.Name.Should().Be("LeatherHelmet");
            //Type
            ritualHelmet.ItemType.Should().Be(ItemType.Helmet);
            warHelmet.ItemType.Should().Be(ItemType.Helmet);
            maskOfDead.ItemType.Should().Be(ItemType.Helmet);
            laurelWreath.ItemType.Should().Be(ItemType.Helmet);
            leatherHelmet.ItemType.Should().Be(ItemType.Helmet);
            //Restriction
            ritualHelmet.ProficiencyRestriction[true].Should().BeOfType<PriestProficiency>();
            warHelmet.ProficiencyRestriction.Should().BeNull();
            maskOfDead.ProficiencyRestriction[false].Should().BeOfType<PriestProficiency>();
            laurelWreath.ProficiencyRestriction.Should().BeNull();
            leatherHelmet.ProficiencyRestriction.Should().BeNull();
            ritualHelmet.RaceRestriction.Should().BeNull();
            warHelmet.RaceRestriction.Should().BeNull();
            maskOfDead.RaceRestriction.Should().BeNull();
            laurelWreath.RaceRestriction.Should().BeNull();
            leatherHelmet.RaceRestriction.Should().BeNull();
            //Power
            ritualHelmet.Power.Should().Be(4);
            warHelmet.Power.Should().Be(3);
            maskOfDead.Power.Should().Be(4);
            laurelWreath.Power.Should().Be(1);
            leatherHelmet.Power.Should().Be(2);
            //Price
            ritualHelmet.Price.Should().Be(500);
            warHelmet.Price.Should().Be(400);
            maskOfDead.Price.Should().Be(600);
            laurelWreath.Price.Should().Be(100);
            leatherHelmet.Price.Should().Be(300);
        }
    }
}
