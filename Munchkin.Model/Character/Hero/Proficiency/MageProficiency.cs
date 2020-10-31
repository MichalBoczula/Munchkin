using Munchkin.BL.Helper;
using Munchkin.Model.Character.Action;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Character.Hero.Proficiency
{
    public class MageProficiency : ProficiencyBase, IMageAction
    {
        private readonly InformationModelMageProficiency _informationModel;
        public new ReadLineOverride readLineOverride;

        public MageProficiency(ReadLineOverride readLineOverride)
        {
            Name = "Mage";
            _informationModel = new InformationModelMageProficiency();
            this.readLineOverride = readLineOverride;
        }

        public override bool InstantKill(UserClass user)
        {
            Console.WriteLine(_informationModel.CastCharmSpell());
            readLineOverride.GetNextString();
            bool result;
            if (user.Deck.Count() > 3)
            {
                Console.WriteLine(_informationModel.CharmSpellSuccess());
                user.Deck.Clear();
                readLineOverride.GetNextString();
                result = true;
            }
            else
            {
                Console.WriteLine(_informationModel.CharmSpellfailure());
                readLineOverride.GetNextString();
                result = false;
            }
            return result;
        }

        public override void FleeSpell(UserClass user)
        {
            if (user.UserAvatar.HowManyCardsThrowToUseSkill < 3)
            {
                if (user.Deck != null && user.Deck.Count()> 0)
                {
                        user.UserAvatar.HowManyCardsThrowToUseSkill++;
                        user.UserAvatar.FleeChances++;
                        Console.WriteLine(_informationModel.SuccessPowerUpFlee);
                        readLineOverride.GetNextString();
                }
                else
                {
                    Console.WriteLine(_informationModel.NotEnoughCards);
                    readLineOverride.GetNextString();
                }
            }
            else
            {
                Console.WriteLine(_informationModel.SkillHasBeenUsedMaxTimes);
                readLineOverride.GetNextString();
            }
        }

        public string LookOnItemsCard(UserClass user, ref int i)
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append("Items\n");
            strBuilder.Append("___________________________________________________________________\n");
            foreach (var card in user.Deck.Items)
            {
                strBuilder.Append($"{i}. ");
                strBuilder.Append($"Name: {card.Name}, Power: {card.Power} ");
                strBuilder.Append($"ItemType: {card.ItemType}, CardType: {card.CardType}");
                if (card.RaceRestriction != null)
                {
                    if (card.RaceRestriction.TryGetValue(true, out RaceBase value))
                    {
                        strBuilder.Append($", {value.Name}: true, ");
                    }
                    else
                    {
                        strBuilder.Append($", {card.RaceRestriction[false].Name}: false, ");
                    }
                }
                if (card.ProficiencyRestriction != null)
                {
                    if (card.ProficiencyRestriction.TryGetValue(true, out ProficiencyBase value))
                    {
                        strBuilder.Append($", {value.Name}: true, ");
                    }
                    else
                    {
                        strBuilder.Append($", {card.ProficiencyRestriction[false].Name}: false");
                    }
                }
                strBuilder.Append(";\n");
                i++;
            }
            return strBuilder.ToString();
        }

        public string LookOnMagicCardsCard(UserClass user, ref int i)
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append("Magic Cards\n");
            strBuilder.Append("___________________________________________________________________\n");
            foreach (var card in user.Deck.MagicCards)
            {
                strBuilder.Append($"{i}. ");
                strBuilder.Append($"Name: {card.Name}");
                strBuilder.Append($"Description: {card.Name}");
                strBuilder.Append(";\n");
                i++;
            }
            return strBuilder.ToString();
        }

        public string LookOnMonstersCard(UserClass user, ref int i)
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append("Monsters\n");
            strBuilder.Append("___________________________________________________________________\n");
            foreach (var card in user.Deck.Monsters)
            {
                strBuilder.Append($"{i}. ");
                strBuilder.Append($"Name: {card.Name}, Power: {card.Power}, Undead: { card.Undead}, ");
                strBuilder.Append($"Levels after fight: {card.HowManyLevels}");
                strBuilder.Append($"Prizes: {card.NumberOfPrizes}");
                strBuilder.Append(";\n");
                i++;
            }
            return strBuilder.ToString();
        }
    }
}
