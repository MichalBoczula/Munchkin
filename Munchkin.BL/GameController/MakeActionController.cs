using Munchkin.Model;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.BL.GameController
{
    public class MakeActionController
    {
        public Game game;
        public bool IsFirstTime;
        public bool IsFight;

        public MakeActionController(Game game)
        {
            this.game = game;
            IsFirstTime = true;
            IsFight = false;
        }

        public void OpenMisteryDoor(UserClass user, MonsterCardBase monster)
        {
            if (IsFirstTime)
            {
                IsFirstTime = false;
                var action = game.ActionCards[0];
                if (action.CardType is CardType.Monster)
                {
                    IsFight = true;
                    //Fight
                }
                else if (action.CardType is CardType.Special)
                {
                    user.Deck.MagicCards.Add(action);
                }
                else
                {
                    action.CastSpecialSpell(user, monster, game);
                }
                game.ActionCards.Remove(action);
                game.DestroyedActionCards.Add(action);
            }
            else
            {
                IsFirstTime = false;
                var action = game.ActionCards[0];
                if (action.CardType is CardType.Monster)
                {
                    IsFight = true;
                    //Fight
                }
                else
                {
                    user.Deck.MagicCards.Add(action);
                }
                game.ActionCards.Remove(action);
                game.DestroyedActionCards.Add(action);
            }

            if (!IsFight)
            {
                IsFight = true;
                OpenMisteryDoor(user, monster);
            }
        }
    }
}
