using Munchkin.Model.Card.ActionCard;
using Munchkin.Model.Card.ActionCard.SpecialCardType.MagicCards;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.CardFactory
{
    public class MagicCardFactory
    {
        public ActionCardBase CreateMagicCard(int num)
        {
            ActionCardBase result = num switch
            {
                1 => new PayToHaron("PayToHaron", CardType.Curse),
                2 => new ToTheArea("To The Area", CardType.Curse),
                3 => new DamagedBoots("Damaged Boots", CardType.Curse),
                4 => new DamagedHelmet("Damaged Helmet", CardType.Curse),
                5 => new HeroicSacrafice("Heroic Sacrafice", CardType.Curse),
                6 => new Friday13th("Friday 13th", CardType.Curse),
                7 => new ForgotHowToFight("Damaged Head", CardType.Curse),
                8 => new YouAreNoSkillBro("You Are No Skill Bro", CardType.Curse),
                9 => new Unlucky("Unlucky", CardType.Curse),
                10 => new GodIsAngry("Unlucky", CardType.Curse),
                11 => new LifeIsHard("Life Is Hard", CardType.Curse),
                12 => new ItIsTooMuch("It Is Too Much", CardType.Curse),
                13 => new YouMustToPayMorgage("You Must To Pay Morgage", CardType.Curse),
                14 => new BackToSchool("BackToSchool", CardType.Curse),
                15 => new DamagedArmor("Damaged Armor", CardType.Curse),
                16 => new DropWeapons("Drop Weapons", CardType.Curse),
                17 => new ItIsTooHeavy("It Is Too Heavy", CardType.Curse),
                18 => new FridayNightCurse("Friday Night Curse", CardType.Curse),
                19 => new YouHaveAccident("You Have Accident", CardType.Curse),
                20 => new LetsGoTogether("Lets Go Together", CardType.Curse),
                21 => new MagicWind("Magic Wind", CardType.Curse),
                22 => new Titan("Titan", CardType.Curse),
                23 => new LikeAGod("Like A God", CardType.Curse),
                24 => new Undead("Undead", CardType.Curse),
                25 => new SecondLifeForMonster("Second Life For Monster", CardType.Curse),
                _ => null
            };
            return result;
        }
    }
}
