using System.Collections.Generic;

namespace Munchkin.Model.Character
{
    public class Build
    {
        public int Id { get; set; }
        public Item Helmet { get; set; }
        public Item Armor { get; set; }
        public Item Boots { get; set; }
        public Item RightHandItem { get; set; }
        public Item LeftHandItem { get; set; }
        public List<Item> AdditionalItems { get; set; }
        public List<Item> SituationalItems { get; set; }

    }
}