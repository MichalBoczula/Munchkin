using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Character.Hero.Proficiency
{
    public class InformationModelMageProficiency
    {
        public string FleeSpellWelcomeMsg(UserClass user)
        {
            return $"Choose card to throw, input number form 1 to {user.Deck.Count}.";
        }

        public string PowerUpMsg(UserClass user)
        {
            return $"POWER UP. Now power is: {user.UserAvatar.FleeChances}.\nPress key to continue";
        }

        public string MaxPowerUpMsg()
        {
            return "Bro you have max power of Flee spell. Press any key to continue...";
        }

        public string WarningMaxCard()
        {
            return "3 is max number card to throw. That quamtity will be remove if it is possible. Press key to continue...";
        }

        public string NotPossibleMsg()
        {
            return "Number must be greater than 0";
        }

        public string NextCardMsg()
        {
            return "Would you like to throw out next card";
        }

        public string NextCardInputMsg()
        {
            return "Input: \n 1. if you want and input \n 0. if you doesn't want";
        }

        public string NotEnoughCardsMsg()
        {
            return "Sorry Bro you don't have cards to throw. \nPress any key to continue...";
        }

        public string CastCharmSpell()
        {
            return "Cast spell to charm monster. Press any key to continue...";
        }

        public string CharmSpellSuccess()
        {
            return "Charm spell success. You have charmed monster. Press any key to continue...";
        }

        public string CharmSpellfailure()
        {
            return "Charm spell failure. Moster ruch towards you!!! Press any key to continue...";
        }
    }
}
