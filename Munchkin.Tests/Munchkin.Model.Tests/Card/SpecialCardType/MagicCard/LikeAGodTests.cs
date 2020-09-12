using FluentAssertions;
using Munchkin.Model;
using Munchkin.Model.Card.ActionCard.SpecialCardType.MagicCards;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret;
using Munchkin.Model.Character;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Munchkin.Tests.Munchkin.Model.Tests.Card.SpecialCardType.MagicCard
{
    public class LikeAGodTests
    {
        [Fact]
        public void CreateMagicCard()
        {
            //Arrange
            var game = new Game();
            var curse = new LikeAGod("Like A God", CardType.Curse);
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var monster = new AntArmy("Ant Army", CardType.Monster);
            //Act
            curse.CastSpecialSpell(user: user, monster: monster, game: game);
            //Assert
            monster.Power.Should().Be(18);
            monster.NumberOfPrizes.Should().Be(4);
        }
    }
}
