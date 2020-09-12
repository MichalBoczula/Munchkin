using Munchkin.BL.Helper;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret;
using Munchkin.Model.Card.PrizeCard;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.CardFactory
{
    public class MonsterFactory
    {
        public MonsterCardBase CreateMonster(int num)
        {
            var readLineOverride = new ReadLineOverride();
            var random = new Random();
            MonsterCardBase result = num switch
            {
                1 => new AntArmy("AntArmy", CardType.Monster),
                2 => new BabaYaga("BabaYaga", CardType.Monster),
                3 => new BloodyMary("BloodyMary", CardType.Monster),
                4 => new BoogieManDanceFloorKing("BoogieManDanceFloorKing", CardType.Monster),
                5 => new Cerber("Cerber", CardType.Monster),
                6 => new Creeps("Creeps", CardType.Monster),
                7 => new DemonicFly("DemonicFly", CardType.Monster),
                8 => new Fenrir("Fenrir", CardType.Monster),
                9 => new FrozenGiant("FrozenGiant", CardType.Monster),
                10 => new Furies("Furies", CardType.Monster),
                11 => new GoldenEggsGoose("GoldenEggsGoose", CardType.Monster, readLineOverride),
                12 => new Gremlin("Gremlin", CardType.Monster),
                13 => new Grendel("Grendel", CardType.Monster),
                14 => new Gryphon("Gryphon", CardType.Monster),
                15 => new Hades("Hades", CardType.Monster),
                16 => new Jackarey("Jackarey", CardType.Monster),
                17 => new Kraken("Kraken", CardType.Monster),
                18 => new LochNessMonster("LochNessMonster", CardType.Monster),
                19 => new Loki("Loki", CardType.Monster),
                20 => new Minotaur("Minotaur", CardType.Monster),
                21 => new MonkeyGang("MonkeyGang", CardType.Monster, random),
                22 => new MordredFallenKnight("MordredFallenKnight", CardType.Monster),
                23 => new NonDecided("NonDecided", CardType.Monster, readLineOverride),
                24 => new NonHumanHunter("NonHumanHunter", CardType.Monster),
                25 => new Quetzalcoatl("Quetzalcoatl", CardType.Monster),
                26 => new Scarabs("Scarabs", CardType.Monster),
                27 => new Shaman("Shaman", CardType.Monster),
                28 => new Shiva("Shiva", CardType.Monster),
                29 => new Sirens("Sirens", CardType.Monster),
                30 => new SlenderMan("SlenderMan", CardType.Monster),
                31 => new StrangeDuck("StrangeDuck", CardType.Monster),
                32 => new TomTumb("TomTumb", CardType.Monster),
                33 => new Valkyries("Valkyries", CardType.Monster),
                34 => new Witch("Witch", CardType.Monster),
                _ => null
            };
            return result;
        }
    }
}
