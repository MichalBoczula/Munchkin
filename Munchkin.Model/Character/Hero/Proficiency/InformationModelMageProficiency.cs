using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Character.Hero.Proficiency
{
    public class InformationModelMageProficiency
    {
        public string SuccessPowerUpFlee { get => "You are stronger BRO!!!\n Press any key to continue..."; }
        public string NotEnoughCards { get => "You don't have cards BRO!!!\n Press any key to continue..."; }
        public string SkillHasBeenUsedMaxTimes { get => "This skill has been cast 3 times, so you have used max times this skill!!!\n Press any key to continue..."; }

        public string CastCharmSpell()
        {
            return "Cast spell to charm monster.\n Press any key to continue...";
        }

        public string CharmSpellSuccess()
        {
            return "Instant kill spell success. You have killed monster.\n Press any key to continue...";
        }

        public string CharmSpellfailure()
        {
            return "Instant kill failure. Moster rush towards you!!!\n Press any key to continue...";
        }
    }
}
