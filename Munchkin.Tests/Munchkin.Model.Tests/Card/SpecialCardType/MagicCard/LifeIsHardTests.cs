using FluentAssertions;
using Munchkin.Model;
using Munchkin.Model.Card.ActionCard.SpecialCardType.MagicCards;
using Munchkin.Model.Character;
using Munchkin.Model.Character.Hero.Proficiency;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Munchkin.Tests.Munchkin.Model.Tests.Card.SpecialCardType.MagicCard
{
    public class LifeIsHardTests
    {
        [Fact]
        public void CastSpecialSpell()
        {
            //Arrange
            var game = new Game();
            var curse = new LifeIsHard("Life Is Hard", CardType.Curse);
            var userAvatar = new UserAvatar()
            {
                Proficiency = new MageProficiency()
            };
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            //Act
            curse.CastSpecialSpell(user: user, monster: null, game: null);
            //Assert
            user.UserAvatar.Proficiency.Should().BeOfType<NoOneProficiency>();
        }
    }
}
