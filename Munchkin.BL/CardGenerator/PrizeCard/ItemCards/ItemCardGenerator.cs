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
        private readonly List<ItemCard> _additional;

        public ItemCardGenerator()
        {
            _itemFactory = new ItemFactory();
            _weapons = new List<ItemCard>();
            _armors = new List<ItemCard>();
            _boots = new List<ItemCard>();
            _helmets = new List<ItemCard>();
            _additional = new List<ItemCard>();
        }

        public List<ItemCard> GenerateWeaponCards()
        {
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
            _weapons.Add(mirrorShield);
            _weapons.Add(lambas);
            _weapons.Add(excalibur);
            _weapons.Add(graal);
            _weapons.Add(egida);
            _weapons.Add(orpheusHarp);
            _weapons.Add(powerAxe);
            _weapons.Add(lighting);
            _weapons.Add(trident);
            _weapons.Add(maceOfDestraction);
            _weapons.Add(herculesBow);
            _weapons.Add(sooLongBow);
            _weapons.Add(magicFagot);
            _weapons.Add(esculapsStaff);
            _weapons.Add(thorsHammer);
            return _weapons;
        }
        public List<ItemCard> GenerateArmorCards()
        {
            var ElfGoldenArmor = _itemFactory.CreateArmorCard("ElfGoldenArmor");
            var Robe = _itemFactory.CreateArmorCard("Robe");
            var MoiraArmor = _itemFactory.CreateArmorCard("MoiraArmor");
            var PlateArmor = _itemFactory.CreateArmorCard("PlateArmor");
            var GodsArmor = _itemFactory.CreateArmorCard("GodsArmor");
            _armors.Add(ElfGoldenArmor);
            _armors.Add(Robe);
            _armors.Add(MoiraArmor);
            _armors.Add(PlateArmor);
            _armors.Add(GodsArmor);
            return _armors;
        }

        public List<ItemCard> GenerateBootsCards()
        {
            var BootsOfHaste = _itemFactory.CreateBootsCard("BootsOfHaste");
            var GlassBoots = _itemFactory.CreateBootsCard("GlassBoots");
            var DragonSkinsSandal = _itemFactory.CreateBootsCard("DragonSkinsSandal");
            var MagicBoots = _itemFactory.CreateBootsCard("MagicBoots");
            var NormalBoot = _itemFactory.CreateBootsCard("NormalBoot");
            _boots.Add(BootsOfHaste);
            _boots.Add(GlassBoots);
            _boots.Add(DragonSkinsSandal);
            _boots.Add(MagicBoots);
            _boots.Add(NormalBoot);
            return _boots;
        }

        public List<ItemCard> GenerateHelmetCards()
        {
            var ritualHelmet = _itemFactory.CreateHelmetCard("RitualHelmet");
            var warHelmet = _itemFactory.CreateHelmetCard("WarHelmet");
            var maskOfDead = _itemFactory.CreateHelmetCard("MaskOfDead");
            var laurelWreath = _itemFactory.CreateHelmetCard("LaurelWreath");
            var leatherHelmet = _itemFactory.CreateHelmetCard("LeatherHelmet");
            _helmets.Add(ritualHelmet);
            _helmets.Add(warHelmet);
            _helmets.Add(maskOfDead);
            _helmets.Add(laurelWreath);
            _helmets.Add(leatherHelmet);
            return _helmets;
        }

        public List<ItemCard> GenerateAdditionalCards()
        {
            var CyberCoat = _itemFactory.CreateAdditionalItemCard("CyberCoat");
            var GodsHelp = _itemFactory.CreateAdditionalItemCard("GodsHelp");
            var BetterDefenceSpray = _itemFactory.CreateAdditionalItemCard("BetterDefenceSpray");
            var RepairKit = _itemFactory.CreateAdditionalItemCard("RepairKit");
            var Dog = _itemFactory.CreateAdditionalItemCard("Dog");
            var Henchman = _itemFactory.CreateAdditionalItemCard("Henchman");
            _additional.Add(CyberCoat);
            _additional.Add(GodsHelp);
            _additional.Add(BetterDefenceSpray);
            _additional.Add(RepairKit);
            _additional.Add(Dog);
            _additional.Add(Henchman);
            return _additional;
        }
    }
}
