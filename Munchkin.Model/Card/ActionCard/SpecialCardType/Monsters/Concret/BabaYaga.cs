using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.Character;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret
{
    public class BabaYaga : MonsterCardBase
    {
        public BabaYaga(string name, CardType cardType) : base(name, cardType)
        {
            Power = 18;
            HowManyLevels = 2;
            NumberOfPrizes = 4;
        }

        public override void DeadEnd(Game game, UserClass user)
        {
            user.Deck.Clear();
        }

        public override void SpecialPower(Game game, UserClass user)
        {
            user.UserAvatar.Nerfs.Wounded.Add(true);
        }

        public override string Description()
        {
            return "Monster: BabaYaga\n" +
                "SpecialPower: Player Wound Nerf += 1\n" +
                "Dead End: Player Lose all cards from deck";
        }
    }
}
