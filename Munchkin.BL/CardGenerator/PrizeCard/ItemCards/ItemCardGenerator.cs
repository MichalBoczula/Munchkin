using Munchkin.Model.Card.CardFactory;
using System;
using System.Collections.Generic;
using Munchkin.Model.Card.PrizeCard;

namespace Munchkin.BL.CardGenerator.PrizeCard.ItemCards
{
    public class ItemCardGenerator
    {
        private readonly ItemFactory _itemFactory;

        public ItemCardGenerator(ItemFactory itemFactory)
        {
            _itemFactory = itemFactory;
        }

        public List<ItemCard> GenerateWeaponCards()
        {
            List<ItemCard> weapons = new List<ItemCard>();
            var sword2H = _itemFactory.CreateWeaponCard("sword2H");
            var sword1H = _itemFactory.CreateWeaponCard("sword1H");
            var khazaDumHammer = _itemFactory.CreateWeaponCard("khazaDumHammer");
            var axe = _itemFactory.CreateWeaponCard("axe");
            var thorsHammer = _itemFactory.CreateWeaponCard("thorsHammer");
            weapons.Add(sword2H);
            weapons.Add(sword1H);
            weapons.Add(khazaDumHammer);
            weapons.Add(axe);
            weapons.Add(thorsHammer);
            return weapons;
        }
        public List<ItemCard> GenerateArmorCards()
        {
            List<ItemCard> armors = new List<ItemCard>();
            var leatherArmor = _itemFactory.CreateArmorCard("leatherArmor");
            var robe = _itemFactory.CreateArmorCard("robe");
            var moiraArmor = _itemFactory.CreateArmorCard("moiraArmor");
            var plateArmor = _itemFactory.CreateArmorCard("plateArmor");
            var godsArmor = _itemFactory.CreateArmorCard("godsArmor");
            armors.Add(leatherArmor);
            armors.Add(robe);
            armors.Add(moiraArmor);
            armors.Add(plateArmor);
            armors.Add(godsArmor);
            return armors;
        }

        public List<ItemCard> GenerateBootsCards()
        {
            List<ItemCard> boots = new List<ItemCard>();
            var bootsOfHaste = _itemFactory.CreateBootsCard("bootsOfHaste");
            var plateBoots = _itemFactory.CreateBootsCard("plateBoots");
            var dragonSkinsSandal = _itemFactory.CreateBootsCard("dragonSkinsSandal");
            var magicBoots = _itemFactory.CreateBootsCard("magicBoots");
            var normalBoot = _itemFactory.CreateBootsCard("normalBoot");
            boots.Add(bootsOfHaste);
            boots.Add(plateBoots);
            boots.Add(dragonSkinsSandal);
            boots.Add(magicBoots);
            boots.Add(normalBoot);
            return boots;
        }

        public List<ItemCard> GenerateHelmetCards()
        {
            List<ItemCard> helmets = new List<ItemCard>();
            var thiefHoodie = _itemFactory.CreateHelmetCard("thiefHoodie");
            var wizardHat = _itemFactory.CreateHelmetCard("wizardHat");
            var elfGoldHelmet = _itemFactory.CreateHelmetCard("elfGoldHelmet");
            var plateHelmet = _itemFactory.CreateHelmetCard("plateHelmet");
            var leatherHelmet = _itemFactory.CreateHelmetCard("leatherHelmet");
            helmets.Add(thiefHoodie);
            helmets.Add(wizardHat);
            helmets.Add(elfGoldHelmet);
            helmets.Add(plateHelmet);
            helmets.Add(leatherHelmet);
            return helmets;
        }
    }
}
