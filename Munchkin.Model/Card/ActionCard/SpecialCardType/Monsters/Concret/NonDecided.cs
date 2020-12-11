using Munchkin.BL.Helper;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret
{
    public class NonDecided : MonsterCardBase
    {
        private ReadLineOverride _readLineOverride;
        private NonDecidedInformationModel _nonDecidedInformationModel;
        public NonDecided(string name, CardType cardType, ReadLineOverride readLineOverride) : base(name, cardType)
        {
            Power = 4;
            HowManyLevels = 0;
            NumberOfPrizes = 2;
            _readLineOverride = readLineOverride;
            _nonDecidedInformationModel = new NonDecidedInformationModel();
        }

        public override void DeadEnd(Game game, UserClass user)
        {
            user.UserAvatar.Nerfs.Power.Add(1);
            user.UserAvatar.Nerfs.FleeChances.Add(1);
            user.UserAvatar.Level -= 1;
        }

        public override void SpecialPower(Game game, UserClass user)
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine();
                if (Int32.TryParse(_readLineOverride.GetNextString(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine(_nonDecidedInformationModel.FightMsg);
                            _readLineOverride.GetNextString();
                            HowManyLevels = 1;
                            flag = false;
                            break;
                        case 2:
                            Console.WriteLine(_nonDecidedInformationModel.NoFightMsg);
                            _readLineOverride.GetNextString();
                            flag = false;
                            break;
                        default:
                            Console.WriteLine(_nonDecidedInformationModel.FailMsg);
                            _readLineOverride.GetNextString();
                            break;
                    }
                }
            }
        }

        public override string Description()
        {
            return "Monster: NonDecided\n" +
                $"Power: {Power}, Prizes: {NumberOfPrizes}, Levels: {HowManyLevels}" +
                "SpecialPower: Player can decide fight or not.\n" +
                "Dead End: Player Level -= 1 && Player Power Nerf += 1 && Player Flee Chances Nerf += 1.";
        }
    }

    public class NonDecidedInformationModel
    {
        public string InitMsg { get => "Would you like to fight?\n1. Yes\n2. No"; }
        public string FightMsg { get => "Let's fight.\nPress any key..."; }
        public string NoFightMsg { get => "Monster has gone away prizes is yours.\nPress any key..."; }
        public string FailMsg { get => "Broo you have two option 1 or 2, choose propertly!!!\nPress any key..."; }
    }
}
