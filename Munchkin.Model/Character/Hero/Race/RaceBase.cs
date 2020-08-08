namespace Munchkin.Model.Character
{
    public abstract class RaceBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        protected RaceBase(string name)
        {
            Name = name;
        }

        public abstract void SpecialSkill();
    }
}