using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret
{
    public class Minotaur : MonsterCardBase
    {
        public Minotaur(string name, CardType cardType) : base(name, cardType)
        {
            Power = 4;
            HowManyLevels = 1;
            NumberOfPrizes = 2;
        }

        public override void DeadEnd(Game game, UserClass user)
        {
            if (user.UserAvatar.Build.Helmet != null)
            {
                var item = user.UserAvatar.Build.Helmet;
                user.UserAvatar.Build.Helmet = null;
                game.DestroyedPrizeCards.Add(item);
            }
            user.UserAvatar.Nerfs.DamagedHead = true;
        }

        public override void SpecialPower(Game game, UserClass user)
        {
            if (user.UserAvatar.Build.Helmet != null)
            {
                Power += 2;
            }
        }

        public override string Description()
        {
            return "Monster: Minotaur\n" +
                $"Power: {Power}, Prizes: {NumberOfPrizes}, Levels: {HowManyLevels}\n" +
                "SpecialPower: If Player don't have helmet, Monsters power increase by 2.\n" +
                "Dead End: Player lose helmet and has damaged head and can't use helmet anymore.";
        }
    }
}
