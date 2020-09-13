using Munchkin.Model.Card.PrizeCard;
using System;
using System.Collections.Generic;

namespace Munchkin.Model.Character
{
    public class Build
    {
        public int Id { get; set; }
        public ItemCard Helmet { get; set; }
        public ItemCard Armor { get; set; }
        public ItemCard Boots { get; set; }
        public ItemCard RightHandItem { get; set; }
        public ItemCard LeftHandItem { get; set; }
        public ItemCard Crook { get; private set; }
        public bool IsItACrook { get; set; }
        public List<ItemCard> AdditionalItems { get; set; }
        public List<ItemCard> SituationalItems { get; set; }

        public Build()
        {
            IsItACrook = false;
        }

        public void SetCrookItem(ItemCard item)
        {
            if (IsItACrook)
            {
                Crook = item;
            }
        }
    }
}