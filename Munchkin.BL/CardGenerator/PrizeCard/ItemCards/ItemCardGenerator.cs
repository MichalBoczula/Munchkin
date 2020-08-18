using Munchkin.Model.Card.CardFactory;
using System;
using System.Collections.Generic;
using Munchkin.Model.Card.PrizeCard;

namespace Munchkin.BL.CardGenerator.PrizeCard.ItemCards
{
    public class ItemCardGenerator
    {
        private readonly ItemFactory _itemFactory;
        private readonly List<ItemCard> _weapons;
        private readonly List<ItemCard> _armors;
        private readonly List<ItemCard> _boots;
        private readonly List<ItemCard> _helmets;

        public ItemCardGenerator()
        {
            _itemFactory = new ItemFactory();
            _weapons = new List<ItemCard>();
            _armors = new List<ItemCard>();
            _boots = new List<ItemCard>();
            _helmets = new List<ItemCard>();
        }

        public List<ItemCard> GenerateWeaponCards()
        {
            
            var sword2H = _itemFactory.CreateWeaponCard("sword2H");
            var sword1H = _itemFactory.CreateWeaponCard("sword1H");
            var khazaDumHammer = _itemFactory.CreateWeaponCard("khazaDumHammer");
            var axe = _itemFactory.CreateWeaponCard("axe");
            var thorsHammer = _itemFactory.CreateWeaponCard("thorsHammer");
            _weapons.Add(sword2H);
            _weapons.Add(sword1H);
            _weapons.Add(khazaDumHammer);
            _weapons.Add(axe);
            _weapons.Add(thorsHammer);
            return _weapons;
        }
        public List<ItemCard> GenerateArmorCards()
        {
            var leatherArmor = _itemFactory.CreateArmorCard("leatherArmor");
            var robe = _itemFactory.CreateArmorCard("robe");
            var moiraArmor = _itemFactory.CreateArmorCard("moiraArmor");
            var plateArmor = _itemFactory.CreateArmorCard("plateArmor");
            var godsArmor = _itemFactory.CreateArmorCard("godsArmor");
            _armors.Add(leatherArmor);
            _armors.Add(robe);
            _armors.Add(moiraArmor);
            _armors.Add(plateArmor);
            _armors.Add(godsArmor);
            return _armors;
        }

        public List<ItemCard> GenerateBootsCards()
        {
            var bootsOfHaste = _itemFactory.CreateBootsCard("bootsOfHaste");
            var plateBoots = _itemFactory.CreateBootsCard("plateBoots");
            var dragonSkinsSandal = _itemFactory.CreateBootsCard("dragonSkinsSandal");
            var magicBoots = _itemFactory.CreateBootsCard("magicBoots");
            var normalBoot = _itemFactory.CreateBootsCard("normalBoot");
            _boots.Add(bootsOfHaste);
            _boots.Add(plateBoots);
            _boots.Add(dragonSkinsSandal);
            _boots.Add(magicBoots);
            _boots.Add(normalBoot);
            return _boots;
        }

        public List<ItemCard> GenerateHelmetCards()
        {
            var thiefHoodie = _itemFactory.CreateHelmetCard("thiefHoodie");
            var wizardHat = _itemFactory.CreateHelmetCard("wizardHat");
            var elfGoldHelmet = _itemFactory.CreateHelmetCard("elfGoldHelmet");
            var plateHelmet = _itemFactory.CreateHelmetCard("plateHelmet");
            var leatherHelmet = _itemFactory.CreateHelmetCard("leatherHelmet");
            _helmets.Add(thiefHoodie);
            _helmets.Add(wizardHat);
            _helmets.Add(elfGoldHelmet);
            _helmets.Add(plateHelmet);
            _helmets.Add(leatherHelmet);
            return _helmets;
        }
    }
}
