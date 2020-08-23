using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Character.Hero.Proficiency
{
    public class InformationModelThiefProficiency
    {
        //BackStab
        public string BackStabMsg { get => "Try backstab your opponent.\nPress key to roll  a dice"; }
        public string BackSuccessMsg { get => "Success! You have backstabbed your opponent.\nPress key to continue"; }
        public string BackFailMsg { get => "Unfortunetly! You opponent defence himself, you haven't backstabbed him.\nPress key to continue"; }
        public string CanNotBackStabTwoTimes { get => "Sorry a victim can NOT be backstab 2 times.\n Press any key to continue..."; }

        //Steal
        public string StealInvalidInput { get => "Invalid input! Chosse number!\nPress enter to continue..."; }
        public string StealSuccessfully { get => "Success you have stolen a item. Now Check your Deck!!!\nPress enter to continue..."; }
        public string StealFail { get => "Fail you haven't stolen a item. Next time will be better.\nPress enter to continue..."; }

        public string StealWelcomeMsg(InformationModelData information)
        {
            return $"Choose item to steal. Input number form 1 to {information.ItemCount}.";
        }
        public InformationModelData ShowItemsToSteal(Build build)
        {
            int i = 1;
            StringBuilder strBuilder = new StringBuilder();
            //Helmet
            strBuilder.Append($"{i}. ");
            strBuilder.Append($"Name: {build.Helmet.Name}, Power: {build.Helmet.Power}, ");
            strBuilder.Append(build.Helmet.RaceRestriction == null ?
                "" :
                build.Helmet.RaceRestriction[true] != null ?
                    $"{build.Helmet.RaceRestriction[true].Name}: true, " :
                    $"{build.Helmet.RaceRestriction[false].Name}: false, ");
            strBuilder.Append(build.Helmet.ProficiencyRestriction == null ?
                "" :
                build.Helmet.ProficiencyRestriction[true] != null ?
                    $"{build.Helmet.ProficiencyRestriction[true].Name}: true" :
                    $"{build.Helmet.ProficiencyRestriction[false].Name}: false");
            //Armor
            i++;
            strBuilder.Append($"{i}. ");
            strBuilder.Append($"Name: {build.Armor.Name}, Power: {build.Armor.Power}, ");
            strBuilder.Append(build.Armor.RaceRestriction == null ?
                "" :
                build.Armor.RaceRestriction[true] != null ?
                    $"{build.Armor.RaceRestriction[true].Name}: true, " :
                    $"{build.Armor.RaceRestriction[false].Name}: false, ");
            strBuilder.Append(build.Armor.ProficiencyRestriction == null ?
                "" :
                build.Armor.ProficiencyRestriction[true] != null ?
                    $"{build.Armor.ProficiencyRestriction[true].Name}: true" :
                    $"{build.Armor.ProficiencyRestriction[false].Name}: false");
            //Boots
            i++;
            strBuilder.Append($"{i}. ");
            strBuilder.Append($"Name: {build.Boots.Name}, Power: {build.Boots.Power}, ");
            strBuilder.Append(build.Boots.RaceRestriction == null ?
                "" :
                build.Boots.RaceRestriction[true] != null ?
                    $"{build.Boots.RaceRestriction[true].Name}: true, " :
                    $"{build.Boots.RaceRestriction[false].Name}: false, ");
            strBuilder.Append(build.Boots.ProficiencyRestriction == null ?
                "" :
                build.Boots.ProficiencyRestriction[true] != null ?
                    $"{build.Boots.ProficiencyRestriction[true].Name}: true" :
                    $"{build.Boots.ProficiencyRestriction[false].Name}: false");
            //LeftHandItem
            i++;
            strBuilder.Append($"{i}. ");
            strBuilder.Append($"Name: {build.LeftHandItem.Name}, Power: {build.LeftHandItem.Power}, IsTwoHanded: {build.RightHandItem.IsTwoHanded}");
            strBuilder.Append(build.LeftHandItem.RaceRestriction == null ?
                "" :
                build.LeftHandItem.RaceRestriction[true] != null ?
                    $"{build.LeftHandItem.RaceRestriction[true].Name}: true, " :
                    $"{build.LeftHandItem.RaceRestriction[false].Name}: false, ");
            strBuilder.Append(build.LeftHandItem.ProficiencyRestriction == null ?
                "" :
                build.LeftHandItem.ProficiencyRestriction[true] != null ?
                    $"{build.LeftHandItem.ProficiencyRestriction[true].Name}: true" :
                    $"{build.LeftHandItem.ProficiencyRestriction[false].Name}: false");
            //RightHandItem
            i++;
            strBuilder.Append($"{i}. ");
            strBuilder.Append($"Name: {build.RightHandItem.Name}, Power: {build.RightHandItem.Power}, IsTwoHanded: {build.RightHandItem.IsTwoHanded}");
            strBuilder.Append(build.RightHandItem.RaceRestriction == null ?
                "" :
                build.RightHandItem.RaceRestriction[true] != null ?
                    $"{build.RightHandItem.RaceRestriction[true].Name}: true, " :
                    $"{build.RightHandItem.RaceRestriction[false].Name}: false, ");
            strBuilder.Append(build.RightHandItem.ProficiencyRestriction == null ?
                "" :
                build.RightHandItem.ProficiencyRestriction[true] != null ?
                    $"{build.RightHandItem.ProficiencyRestriction[true].Name}: true" :
                    $"{build.RightHandItem.ProficiencyRestriction[false].Name}: false");
            //AdditionalItems
            foreach (var item in build.AdditionalItems)
            {
                i++;
                strBuilder.Append($"{i}. ");
                strBuilder.Append($"Name: {item.Name}, Power: {item.Power}");
                strBuilder.Append(item.RaceRestriction == null ?
                    "" :
                    item.RaceRestriction[true] != null ?
                        $"{item.RaceRestriction[true].Name}: true, " :
                        $"{item.RaceRestriction[false].Name}: false, ");
                strBuilder.Append(item.ProficiencyRestriction == null ?
                    "" :
                   item.ProficiencyRestriction[true] != null ?
                        $"{item.ProficiencyRestriction[true].Name}: true" :
                        $"{item.ProficiencyRestriction[false].Name}: false");
            }
            strBuilder.Append("Press enter to continue...");
            
            var informationModelData = new InformationModelData()
            {
                ItemDescription = strBuilder.ToString(),
                ItemCount = i
            };
            return informationModelData;
        }

        public string InvalidNumber(InformationModelData information)
        {
            return $"Man it is easy. You must number from 1 to {information.ItemCount} do it correctly this time!\nPress enter to continue...";
        }
    }

    public class InformationModelData
    {
        public string ItemDescription { get; set; }
        public int ItemCount { get; set; }
    }
}
