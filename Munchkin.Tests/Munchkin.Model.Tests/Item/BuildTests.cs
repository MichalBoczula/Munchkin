using FluentAssertions;
using Munchkin.Model;
using Munchkin.Model.Card.PrizeCard;
using Munchkin.Model.Character;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Munchkin.Tests.Munchkin.Model.Tests.Item
{
    public class BuildTests
    {
        [Fact]
        public void CastSpecialSpell()
        {
            //Arrange
            var userAvatar = new UserAvatar();
            var item = new ItemCard("leatherArmor", CardType.Prize, PrizeCardType.Item, 5, null, false, ItemType.Armor, null, 300);
            userAvatar.Build.IsItACrook = true;
            //Act
            userAvatar.Build.SetCrookItem(item);
            //Assert
            userAvatar.Build.Crook.Should().BeSameAs(item);
        }
    }
}
