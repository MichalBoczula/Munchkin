using FluentAssertions;
using Munchkin.Model.Card.CardFactory;
using Munchkin.Model.Card.PrizeCard;
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
            var leatherArmor = _itemFactory.CreateArmorCard("leatherArmor");
            var robe = _itemFactory.CreateArmorCard("robe");
            var moiraArmor = _itemFactory.CreateArmorCard("moiraArmor");
            var plateArmor = _itemFactory.CreateArmorCard("plateArmor");
            var godsArmor = _itemFactory.CreateArmorCard("godsArmor");
            //Assert
            //Name
            leatherArmor.Name.Should().Be("leatherArmor");
            robe.Name.Should().Be("robe");
            moiraArmor.Name.Should().Be("moiraArmor");
            plateArmor.Name.Should().Be("plateArmor");
            godsArmor.Name.Should().Be("godsArmor");
            //Type
            leatherArmor.ItemType.Should().Be(ItemType.Armor);
            robe.ItemType.Should().Be(ItemType.Armor);
            moiraArmor.ItemType.Should().Be(ItemType.Armor);
            plateArmor.ItemType.Should().Be(ItemType.Armor);
            godsArmor.ItemType.Should().Be(ItemType.Armor);
        }

        [Fact]
        public void CreateBootsCardTest()
        {
            //In contructor
            //Act
            var bootsOfHaste = _itemFactory.CreateBootsCard("bootsOfHaste");
            var plateBoots = _itemFactory.CreateBootsCard("plateBoots");
            var dragonSkinsSandal = _itemFactory.CreateBootsCard("dragonSkinsSandal");
            var magicBoots = _itemFactory.CreateBootsCard("magicBoots");
            var normalBoot = _itemFactory.CreateBootsCard("normalBoot");
            //Assert
            //Name
            bootsOfHaste.Name.Should().Be("bootsOfHaste");
            plateBoots.Name.Should().Be("plateBoots");
            dragonSkinsSandal.Name.Should().Be("dragonSkinsSandal");
            magicBoots.Name.Should().Be("magicBoots");
            normalBoot.Name.Should().Be("normalBoot");
            //Type
            bootsOfHaste.ItemType.Should().Be(ItemType.Boots);
            plateBoots.ItemType.Should().Be(ItemType.Boots);
            dragonSkinsSandal.ItemType.Should().Be(ItemType.Boots);
            magicBoots.ItemType.Should().Be(ItemType.Boots);
            normalBoot.ItemType.Should().Be(ItemType.Boots);
        }

        [Fact]
        public void CreateHelmetCardTest()
        {
            //In contructor
            //Act
            var thiefHoodie = _itemFactory.CreateHelmetCard("thiefHoodie");
            var wizardHat = _itemFactory.CreateHelmetCard("wizardHat");
            var elfGoldHelmet = _itemFactory.CreateHelmetCard("elfGoldHelmet");
            var plateHelmet = _itemFactory.CreateHelmetCard("plateHelmet");
            var leatherHelmet = _itemFactory.CreateHelmetCard("leatherHelmet");
            //Assert
            //Name
            thiefHoodie.Name.Should().Be("thiefHoodie");
            wizardHat.Name.Should().Be("wizardHat");
            elfGoldHelmet.Name.Should().Be("elfGoldHelmet");
            plateHelmet.Name.Should().Be("plateHelmet");
            leatherHelmet.Name.Should().Be("leatherHelmet");
            //Type
            thiefHoodie.ItemType.Should().Be(ItemType.Helmet);
            wizardHat.ItemType.Should().Be(ItemType.Helmet);
            elfGoldHelmet.ItemType.Should().Be(ItemType.Helmet);
            plateHelmet.ItemType.Should().Be(ItemType.Helmet);
            leatherHelmet.ItemType.Should().Be(ItemType.Helmet);
        }
    }
}
