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
    public class Friday13thTests
    {
        [Fact]
        public void CastSpecialSpell()
        {
            //Arrange
            var game = new Game();
            var curse = new Friday13th("Friday 13th", CardType.Curse);
            var userAvatar = new UserAvatar()
            {
                Level = 2
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            curse.CastSpecialSpell(user: user, monster: null, game: null);
            user.UserAvatar.EndTurn();
            //Assert
            user.UserAvatar.FleeChances.Should().Be(2);
            user.UserAvatar.Power.Should().Be(0);
            user.UserAvatar.Level.Should().Be(1);
        }
    }
}
