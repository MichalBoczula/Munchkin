﻿using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret
{
    public class AntArmy : MonsterCardBase
    {
        public AntArmy(string name, CardType cardType) : base(name, cardType)
        {
            Power = 8;
            HowManyLevels = 1;
            NumberOfPrizes = 2;
        }

        public override void DeadEnd(Game game, UserClass user)
        {
            if(user.UserAvatar.Build.Boots != null)
            {
                var item = user.UserAvatar.Build.Boots;
                game.DestroyedPrizeCards.Add(item);
                user.UserAvatar.Build.Boots = null;
            }
            user.UserAvatar.Nerfs.FleeChances.Add(1);
        }

        public override void SpecialPower(Game game, UserClass user)
        {
            user.UserAvatar.FleeChances = -999;
        }

        public override string Description()
        {
            return "Monster: AntArmy\n" +
                $"Power: {Power}, Prizes: {NumberOfPrizes}, Levels: {HowManyLevels}\n" +
                "SpecialPower: Player Flee Chances = -999\n" +
                "Dead End: Player Flee Chances Nerf += 1 && Destroy Boots";
        }
    }
}
