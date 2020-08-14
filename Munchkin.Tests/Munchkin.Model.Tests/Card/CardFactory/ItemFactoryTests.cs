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
            Assert.Equal("sword2H", shouldBeSword2H.Name);
            Assert.Equal("sword1H", sholudBeSword1H.Name);
            Assert.Equal("khazaDumHammer", shouldBeKhazaDumHammer.Name);
            Assert.Equal("axe", shouldBeAxe.Name);
            Assert.Equal("thorsHammer", shouldBeThorsHammer.Name);
            //Type
            Assert.Equal(ItemType.Weapon, shouldBeSword2H.ItemType);
            Assert.Equal(ItemType.Weapon, sholudBeSword1H.ItemType);
            Assert.Equal(ItemType.Weapon, shouldBeKhazaDumHammer.ItemType);
            Assert.Equal(ItemType.Weapon, shouldBeAxe.ItemType);
            Assert.Equal(ItemType.Weapon, shouldBeThorsHammer.ItemType);
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
            Assert.Equal("leatherArmor", leatherArmor.Name);
            Assert.Equal("robe", robe.Name);
            Assert.Equal("moiraArmor", moiraArmor.Name);
            Assert.Equal("plateArmor", plateArmor.Name);
            Assert.Equal("godsArmor", godsArmor.Name);
            //Type
            Assert.Equal(ItemType.Armor, leatherArmor.ItemType);
            Assert.Equal(ItemType.Armor, robe.ItemType);
            Assert.Equal(ItemType.Armor, moiraArmor.ItemType);
            Assert.Equal(ItemType.Armor, plateArmor.ItemType);
            Assert.Equal(ItemType.Armor, godsArmor.ItemType);
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
            Assert.Equal("bootsOfHaste", bootsOfHaste.Name);
            Assert.Equal("plateBoots", plateBoots.Name);
            Assert.Equal("dragonSkinsSandal", dragonSkinsSandal.Name);
            Assert.Equal("magicBoots", magicBoots.Name);
            Assert.Equal("normalBoot", normalBoot.Name);
            //Type
            Assert.Equal(ItemType.Boots, bootsOfHaste.ItemType);
            Assert.Equal(ItemType.Boots, plateBoots.ItemType);
            Assert.Equal(ItemType.Boots, dragonSkinsSandal.ItemType);
            Assert.Equal(ItemType.Boots, magicBoots.ItemType);
            Assert.Equal(ItemType.Boots, normalBoot.ItemType);
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
            Assert.Equal("thiefHoodie", thiefHoodie.Name);
            Assert.Equal("wizardHat", wizardHat.Name);
            Assert.Equal("elfGoldHelmet", elfGoldHelmet.Name);
            Assert.Equal("plateHelmet", plateHelmet.Name);
            Assert.Equal("leatherHelmet", leatherHelmet.Name);
            //Type
            Assert.Equal(ItemType.Helmet, thiefHoodie.ItemType);
            Assert.Equal(ItemType.Helmet, wizardHat.ItemType);
            Assert.Equal(ItemType.Helmet, elfGoldHelmet.ItemType);
            Assert.Equal(ItemType.Helmet, plateHelmet.ItemType);
            Assert.Equal(ItemType.Helmet, leatherHelmet.ItemType);
        }
    }
}
