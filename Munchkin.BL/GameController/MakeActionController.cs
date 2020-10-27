using Munchkin.Model;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.Character;
using Munchkin.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.BL.GameController
{
    public class MakeActionController
    {
        public Game Game;
        public GameAction GameAction;
        public FightController FightController { get; set; }

        public MakeActionController(Game game, FightController fightController)
        {
            Game = game;
            GameAction = new GameAction();
            FightController = fightController;
        }

        public void OpenMisteryDoor(UserClass user)
        {
            if (GameAction.IsFirstTime)
            {
                GameAction.IsFirstTime = false;
                var action = Game.ActionCards[0];
                if (action.CardType is CardType.Monster)
                {
                    GameAction.IsFight = true;
                    var fight = new Fight();
                    fight.Heros.Add(user.UserAvatar);
                    fight.Monsters.Add((MonsterCardBase)action);
                    if (FightController.WhoWinFight(fight))
                    {

                    }
                    else
                    {

                    }
                }

                Game.ActionCards.Remove(action);
                Game.DestroyedActionCards.Add(action);
            }
            //else
            //{
            //    IsFirstTime = false;
            //    var action = Game.ActionCards[0];
            //    if (action.CardType is CardType.Monster)
            //    {
            //        IsFight = true;
            //        //Fight
            //    }
            //    else
            //    {
            //        user.Deck.MagicCards.Add(action);
            //    }
            //    Game.ActionCards.Remove(action);
            //    Game.DestroyedActionCards.Add(action);
            //}

            //if (!IsFight)
            //{
            //    IsFight = true;
            //    OpenMisteryDoor(user, monster);
            //}
        }

        public List<UserAvatar> AskForHelp()
        {
            return null;
        }

        public void UseSpecialPower()
        {
        }

        public bool Flee()
        {
            return false;
        }

        public void UseSituationalCard()
        {
        }

    }
}
