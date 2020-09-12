using FluentAssertions;
using Munchkin.Model;
using Munchkin.Model.Card.ActionCard.SpecialCardType.MagicCards;
using Munchkin.Model.Character;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Munchkin.Tests.Munchkin.Model.Tests.Card.SpecialCardType.MagicCard
{
    public class YouHaveAccidentTests
    {
        [Fact]
        public void YouHaveAccident()
        {
            //Arrange
            var game = new Game();
            var curse = new YouHaveAccident("You Have Accident", CardType.Curse);
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            curse.CastSpecialSpell(user, null, game);
            //Assert
            user.UserAvatar.Nerfs.Wounded.Should().HaveCount(1);
            user.UserAvatar.Nerfs.Wounded[0].Should().BeTrue();
        }
    }
}
