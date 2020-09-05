using Munchkin.BL.Helper;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Concret;
using Munchkin.Model.Card.PrizeCard;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Card.CardFactory
{
    public class MonstersFactory
    {
        public MonsterCardBase CreateMonster(int num)
        {
            var readLineOverride = new ReadLineOverride();
            var random = new Random();
            MonsterCardBase result = num switch
            {
                1 => new AntArmy("AntArmy", CardType.Action),
                2 => new BabaYaga("BabaYaga", CardType.Action),
                3 => new BloodyMary("BloodyMary", CardType.Action),
                4 => new BoogieManDanceFloorKing("BoogieManDanceFloorKing", CardType.Action),
                5 => new Cerber("Cerber", CardType.Action),
                6 => new Creeps("Creeps", CardType.Action),
                7 => new DemonicFly("DemonicFly", CardType.Action),
                8 => new Fenrir("Fenrir", CardType.Action),
                9 => new FrozenGiant("FrozenGiant", CardType.Action),
                10 => new Furies("Furies", CardType.Action),
                11 => new GoldenEggsGoose("GoldenEggsGoose", CardType.Action, readLineOverride),
                12 => new Gremlin("Gremlin", CardType.Action),
                13 => new Grendel("Grendel", CardType.Action),
                14 => new Gryphon("Gryphon", CardType.Action),
                15 => new Hades("Hades", CardType.Action),
                16 => new Jackarey("Jackarey", CardType.Action),
                17 => new Kraken("Kraken", CardType.Action),
                18 => new LochNessMonster("LochNessMonster", CardType.Action),
                19 => new Loki("Loki", CardType.Action),
                20 => new Minotaur("Minotaur", CardType.Action),
                21 => new MonkeyGang("MonkeyGang", CardType.Action, random),
                22 => new MordredFallenKnight("MordredFallenKnight", CardType.Action),
                23 => new NonDecided("NonDecided", CardType.Action, readLineOverride),
                24 => new NonHumanHunter("NonHumanHunter", CardType.Action),
                25 => new Quetzalcoatl("Quetzalcoatl", CardType.Action),
                26 => new Scarabs("Scarabs", CardType.Action),
                27 => new Shaman("Shaman", CardType.Action),
                28 => new Shiva("Shiva", CardType.Action),
                29 => new Sirens("Sirens", CardType.Action),
                30 => new SlenderMan("SlenderMan", CardType.Action),
                31 => new StrangeDuck("StrangeDuck", CardType.Action),
                32 => new TomTumb("TomTumb", CardType.Action),
                33 => new Valkyries("Valkyries", CardType.Action),
                34 => new Witch("Witch", CardType.Action),
                _ => null
            };
            return result;
        }
    }
}
