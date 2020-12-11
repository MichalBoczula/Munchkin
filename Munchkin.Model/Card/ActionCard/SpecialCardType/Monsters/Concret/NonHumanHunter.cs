using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.Character.Hero.Race;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret
{
    public class NonHumanHunter : MonsterCardBase
    {
        public NonHumanHunter(string name, CardType cardType) : base(name, cardType)
        {
            Power = 2;
            HowManyLevels = 1;
            NumberOfPrizes = 1;
        }

        public override void DeadEnd(Game game, UserClass user)
        {
            if (user.UserAvatar.Build == null) return;
            if (user.UserAvatar.Build.Armor != null)
            {
                var item = user.UserAvatar.Build.Armor;
                user.UserAvatar.Build.Armor = null;
                game.DestroyedPrizeCards.Add(item);
            }
        }

        public override void SpecialPower(Game game, UserClass user)
        {
            if (user.UserAvatar.Race != null && !(user.UserAvatar.Race is Human))
            {
                Power += 5;
            }
        }

        public override string Description()
        {
            return "Monster: NonDecided\n" +
                $"Power: {Power}, Prizes: {NumberOfPrizes}, Levels: {HowManyLevels}\n" +
                "SpecialPower: If player race is diffrent then human, Monster gain 5 power.\n" +
                "Dead End: Player lose armor.";
        }
    }
}
