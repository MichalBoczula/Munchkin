namespace Munchkin.Model
{
    public abstract class CardGameBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CardType CardType { get; set; }

        public CardGameBase(string name, CardType cardType)
        {
            Name = name;
            CardType = cardType;
        }
    }
}