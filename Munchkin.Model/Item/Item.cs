using Munchkin.Model.Card.PrizeCard;

namespace Munchkin.Model.Character
{
    public class Item
    {
        public int Id { get; set; }
        public ItemCard Card { get;}

        public Item(ItemCard card)
        {
            Card = card;
        }
    }
}