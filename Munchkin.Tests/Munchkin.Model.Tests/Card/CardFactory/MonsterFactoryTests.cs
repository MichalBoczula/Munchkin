using FluentAssertions;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret;
using Munchkin.Model.Card.CardFactory;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Munchkin.Tests.Munchkin.Model.Tests.Card.CardFactory
{
    public class MonsterFactoryTests
    {
        [Fact]
        public void CreateWeaponCardTest()
        {
            //Arrange
            var monsterFactory = new MonsterFactory();
            //Act
            var m1 = monsterFactory.CreateMonster(1);
            var m2 = monsterFactory.CreateMonster(2);
            var m3 = monsterFactory.CreateMonster(3);
            var m4 = monsterFactory.CreateMonster(4);
            var m5 = monsterFactory.CreateMonster(5);
            var m6 = monsterFactory.CreateMonster(6);
            var m7 = monsterFactory.CreateMonster(7);
            var m8 = monsterFactory.CreateMonster(8);
            var m9 = monsterFactory.CreateMonster(9);
            var m10 = monsterFactory.CreateMonster(10);
            var m11 = monsterFactory.CreateMonster(11);
            var m12 = monsterFactory.CreateMonster(12);
            var m13 = monsterFactory.CreateMonster(13);
            var m14 = monsterFactory.CreateMonster(14);
            var m15 = monsterFactory.CreateMonster(15);
            var m16 = monsterFactory.CreateMonster(16);
            var m17 = monsterFactory.CreateMonster(17);
            var m18 = monsterFactory.CreateMonster(18);
            var m19 = monsterFactory.CreateMonster(19);
            var m20 = monsterFactory.CreateMonster(20);
            var m21 = monsterFactory.CreateMonster(21);
            var m22 = monsterFactory.CreateMonster(22);
            var m23 = monsterFactory.CreateMonster(23);
            var m24 = monsterFactory.CreateMonster(24);
            var m25 = monsterFactory.CreateMonster(25);
            var m26 = monsterFactory.CreateMonster(26);
            var m27 = monsterFactory.CreateMonster(27);
            var m28 = monsterFactory.CreateMonster(28);
            var m29 = monsterFactory.CreateMonster(29);
            var m30 = monsterFactory.CreateMonster(30);
            var m31 = monsterFactory.CreateMonster(31);
            var m32 = monsterFactory.CreateMonster(32);
            var m33 = monsterFactory.CreateMonster(33);
            var m34 = monsterFactory.CreateMonster(34);
            //Assert
            m1.Should().BeOfType<AntArmy>();
            m2.Should().BeOfType<BabaYaga>();
            m3.Should().BeOfType<BloodyMary>();
            m4.Should().BeOfType<BoogieManDanceFloorKing>();
            m5.Should().BeOfType<Cerber>();
            m6.Should().BeOfType<Creeps>();
            m7.Should().BeOfType<DemonicFly>();
            m8.Should().BeOfType<Fenrir>();
            m9.Should().BeOfType<FrozenGiant>();
            m10.Should().BeOfType<Furies>();
            m11.Should().BeOfType<GoldenEggsGoose>();
            m12.Should().BeOfType<Gremlin>();
            m13.Should().BeOfType<Grendel>();
            m14.Should().BeOfType<Gryphon>();
            m15.Should().BeOfType<Hades>();
            m16.Should().BeOfType<Jackarey>();
            m17.Should().BeOfType<Kraken>();
            m18.Should().BeOfType<LochNessMonster>();
            m19.Should().BeOfType<Loki>();
            m20.Should().BeOfType<Minotaur>();
            m21.Should().BeOfType<MonkeyGang>();
            m22.Should().BeOfType<MordredFallenKnight>();
            m23.Should().BeOfType<NonDecided>();
            m24.Should().BeOfType<NonHumanHunter>();
            m25.Should().BeOfType<Quetzalcoatl>();
            m26.Should().BeOfType<Scarabs>();
            m27.Should().BeOfType<Shaman>();
            m28.Should().BeOfType<Shiva>();
            m29.Should().BeOfType<Sirens>();
            m30.Should().BeOfType<SlenderMan>();
            m31.Should().BeOfType<StrangeDuck>();
            m32.Should().BeOfType<TomTumb>();
            m33.Should().BeOfType<Valkyries>();
            m34.Should().BeOfType<Witch>();
        }
    }
}
