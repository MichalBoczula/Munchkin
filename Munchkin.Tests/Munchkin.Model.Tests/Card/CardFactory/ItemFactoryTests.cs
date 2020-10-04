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
        public void CreateHandsCardTest()
        {
            //In contructor
            //Act
            var mirrorShield = _itemFactory.CreateHandsCard("MirrorShield");
            var lambas = _itemFactory.CreateHandsCard("Lambas");
            var excalibur = _itemFactory.CreateHandsCard("Excalibur");
            var graal = _itemFactory.CreateHandsCard("Graal");
            var egida = _itemFactory.CreateHandsCard("Egida");
            var orpheusHarp = _itemFactory.CreateHandsCard("OrpheusHarp");
            var powerAxe = _itemFactory.CreateHandsCard("PowerAxe");
            var lighting = _itemFactory.CreateHandsCard("Lighting");
            var trident = _itemFactory.CreateHandsCard("Trident");
            var maceOfDestraction = _itemFactory.CreateHandsCard("MaceOfDestraction");
            var herculesBow = _itemFactory.CreateHandsCard("HerculesBow");
            var sooLongBow = _itemFactory.CreateHandsCard("SooLongBow");
            var magicFagot = _itemFactory.CreateHandsCard("MagicFagot");
            var esculapsStaff = _itemFactory.CreateHandsCard("EsculapsStaff");
            var thorsHammer = _itemFactory.CreateHandsCard("ThorsHammer");
            //Assert
            //Name
            mirrorShield.Name.Should().Be("MirrorShield");
            lambas.Name.Should().Be("Lambas");
            excalibur.Name.Should().Be("Excalibur");
            graal.Name.Should().Be("Graal");
            egida.Name.Should().Be("Egida");
            orpheusHarp.Name.Should().Be("OrpheusHarp");
            powerAxe.Name.Should().Be("PowerAxe");
            lighting.Name.Should().Be("Lighting");
            trident.Name.Should().Be("Trident");
            maceOfDestraction.Name.Should().Be("MaceOfDestraction");
            herculesBow.Name.Should().Be("HerculesBow");
            sooLongBow.Name.Should().Be("SooLongBow");
            magicFagot.Name.Should().Be("MagicFagot");
            esculapsStaff.Name.Should().Be("EsculapsStaff");
            thorsHammer.Name.Should().Be("ThorsHammer");
            //Type
            mirrorShield.ItemType.Should().Be(ItemType.Weapon);
            lambas.ItemType.Should().Be(ItemType.Weapon);
            excalibur.ItemType.Should().Be(ItemType.Weapon);
            graal.ItemType.Should().Be(ItemType.Weapon);
            egida.ItemType.Should().Be(ItemType.Weapon);
            orpheusHarp.ItemType.Should().Be(ItemType.Weapon);
            powerAxe.ItemType.Should().Be(ItemType.Weapon);
            lighting.ItemType.Should().Be(ItemType.Weapon);
            trident.ItemType.Should().Be(ItemType.Weapon);
            maceOfDestraction.ItemType.Should().Be(ItemType.Weapon);
            herculesBow.ItemType.Should().Be(ItemType.Weapon);
            sooLongBow.ItemType.Should().Be(ItemType.Weapon);
            magicFagot.ItemType.Should().Be(ItemType.Weapon);
            esculapsStaff.ItemType.Should().Be(ItemType.Weapon);
            thorsHammer.ItemType.Should().Be(ItemType.Weapon);
            //Restriction
            mirrorShield.ProficiencyRestriction.Should().BeNull();
            lambas.ProficiencyRestriction.Should().BeNull();
            excalibur.ProficiencyRestriction[false].Should().BeOfType<MageProficiency>();
            graal.ProficiencyRestriction.Should().BeNull();
            egida.ProficiencyRestriction.Should().BeNull();
            orpheusHarp.ProficiencyRestriction.Should().BeNull();
            powerAxe.ProficiencyRestriction.Should().BeNull();
            lighting.ProficiencyRestriction[true].Should().BeOfType<MageProficiency>();
            trident.ProficiencyRestriction.Should().BeNull();
            maceOfDestraction.ProficiencyRestriction.Should().BeNull();
            herculesBow.ProficiencyRestriction.Should().BeNull();
            sooLongBow.ProficiencyRestriction.Should().BeNull();
            magicFagot.ProficiencyRestriction.Should().BeNull();
            esculapsStaff.ProficiencyRestriction.Should().BeNull();
            thorsHammer.ProficiencyRestriction[true].Should().BeOfType<WarriorProficiency>();
            mirrorShield.RaceRestriction.Should().BeNull();
            lambas.RaceRestriction[true].Should().BeOfType<Halfling>();
            excalibur.RaceRestriction.Should().BeNull();
            graal.RaceRestriction.Should().BeNull();
            egida.RaceRestriction.Should().BeNull();
            orpheusHarp.RaceRestriction.Should().BeNull();
            powerAxe.RaceRestriction.Should().BeNull();
            lighting.RaceRestriction.Should().BeNull();
            trident.RaceRestriction[false].Should().BeOfType<Halfling>();
            maceOfDestraction.RaceRestriction.Should().BeNull();
            herculesBow.RaceRestriction.Should().BeNull();
            sooLongBow.RaceRestriction[false].Should().BeOfType<Dwarf>();
            magicFagot.RaceRestriction.Should().BeNull();
            esculapsStaff.RaceRestriction.Should().BeNull();
            thorsHammer.RaceRestriction.Should().BeNull();
            //Power
            mirrorShield.Power.Should().Be(2);
            lambas.Power.Should().Be(5);
            excalibur.Power.Should().Be(4);
            graal.Power.Should().Be(3);
            egida.Power.Should().Be(3);
            orpheusHarp.Power.Should().Be(3);
            powerAxe.Power.Should().Be(4);
            lighting.Power.Should().Be(3);
            trident.Power.Should().Be(3);
            maceOfDestraction.Power.Should().Be(5);
            herculesBow.Power.Should().Be(4);
            sooLongBow.Power.Should().Be(3);
            magicFagot.Power.Should().Be(4);
            esculapsStaff.Power.Should().Be(2);
            thorsHammer.Power.Should().Be(6);
            //Price
            mirrorShield.Price.Should().Be(400);
            lambas.Price.Should().Be(300);
            excalibur.Price.Should().Be(600);
            graal.Price.Should().Be(300);
            egida.Price.Should().Be(500);
            orpheusHarp.Price.Should().Be(300);
            powerAxe.Price.Should().Be(600);
            lighting.Price.Should().Be(100);
            trident.Price.Should().Be(300);
            maceOfDestraction.Price.Should().Be(600);
            herculesBow.Price.Should().Be(700);
            sooLongBow.Price.Should().Be(400);
            magicFagot.Price.Should().Be(600);
            esculapsStaff.Price.Should().Be(500);
            thorsHammer.Price.Should().Be(700);
        }

        [Fact]
        public void CreateAdditionalItemsCardTest()
        {
            //In contructor
            //Act
            var CyberCoat = _itemFactory.CreateAdditionalItemCard("CyberCoat");
            var GodsHelp = _itemFactory.CreateAdditionalItemCard("GodsHelp");
            var BetterDefenceSpray = _itemFactory.CreateAdditionalItemCard("BetterDefenceSpray");
            var RepairKit = _itemFactory.CreateAdditionalItemCard("RepairKit");
            var Dog = _itemFactory.CreateAdditionalItemCard("Dog");
            var Henchman = _itemFactory.CreateAdditionalItemCard("Henchman");
            //Assert
            //Name
            CyberCoat.Name.Should().Be("CyberCoat");
            GodsHelp.Name.Should().Be("GodsHelp");
            BetterDefenceSpray.Name.Should().Be("BetterDefenceSpray");
            RepairKit.Name.Should().Be("RepairKit");
            Dog.Name.Should().Be("Dog");
            Henchman.Name.Should().Be("Henchman");
            //Type
            CyberCoat.ItemType.Should().Be(ItemType.Additional);
            GodsHelp.ItemType.Should().Be(ItemType.Additional);
            BetterDefenceSpray.ItemType.Should().Be(ItemType.Additional);
            RepairKit.ItemType.Should().Be(ItemType.Additional);
            Dog.ItemType.Should().Be(ItemType.Additional);
            Henchman.ItemType.Should().Be(ItemType.Additional);
            //Restriction
            CyberCoat.ProficiencyRestriction.Should().BeNull();
            GodsHelp.ProficiencyRestriction.Should().BeNull();
            BetterDefenceSpray.ProficiencyRestriction[false].Should().BeOfType<WarriorProficiency>();
            RepairKit.ProficiencyRestriction.Should().BeNull();
            Dog.ProficiencyRestriction.Should().BeNull();
            Henchman.ProficiencyRestriction.Should().BeNull();
            CyberCoat.RaceRestriction[false].Should().BeOfType<Elf>();
            GodsHelp.RaceRestriction.Should().BeNull();
            BetterDefenceSpray.RaceRestriction.Should().BeNull();
            RepairKit.RaceRestriction.Should().BeNull();
            Dog.RaceRestriction.Should().BeNull();
            Henchman.RaceRestriction.Should().BeNull();
            //Power
            CyberCoat.Power.Should().Be(2);
            GodsHelp.Power.Should().Be(3);
            BetterDefenceSpray.Power.Should().Be(4);
            RepairKit.Power.Should().Be(1);
            Dog.Power.Should().Be(1);
            Henchman.Power.Should().Be(2);
            //Price
            CyberCoat.Price.Should().Be(300);
            GodsHelp.Price.Should().Be(0);
            BetterDefenceSpray.Price.Should().Be(400);
            RepairKit.Price.Should().Be(200);
            Dog.Price.Should().Be(100);
            Henchman.Price.Should().Be(500);
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
