using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.Card.CardFactory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.BL.CardGenerator.ActionCard.Monsters
{
    public class MonstersGenerator
    {
        private readonly MonstersFactory _monstersFactory;
        private readonly HashSet<MonsterCardBase> _monsters;

        public MonstersGenerator()
        {
            _monstersFactory = new MonstersFactory();
            _monsters = new HashSet<MonsterCardBase>();
        }

        public HashSet<MonsterCardBase> GenerateMonsterCards()
        {
            for(int i = 1; i < 35; i++)
            {
                _monsters.Add(_monstersFactory.CreateMonster(i));
            }
            return _monsters;
        }
    }
}
