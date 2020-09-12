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
    public class MagicWindTests
    {
        [Fact]
        public void CastSpecialSpell()
        {
            //Arrange
            var game = new Game();
            var curse = new MagicWind("Magic Wind", CardType.Curse);
            var userAvatar = new UserAvatar();
            var user = new UserClass()
            {
                UserAvatar = userAvatar
            };
            var monster = new AntArmy("Ant Army", CardType.Monster);
            //Act
            curse.CastSpecialSpell(user: user, monster: monster, game: game);
            //Assert
            user.Deck.Monsters.Should().HaveCount(1);
            user.Deck.Monsters[0].Should().BeSameAs(monster);
        }
    }
}
