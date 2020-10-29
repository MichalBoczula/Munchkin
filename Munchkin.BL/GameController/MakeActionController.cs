using Munchkin.Model;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.Card.PrizeCard;
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
        public PrizeStackController PrizeStackController;

        public MakeActionController(Game game, FightController fightController)
        {
            Game = game;
            GameAction = new GameAction();
            FightController = fightController;
        }

        public MakeActionController(Game game, FightController fightController, PrizeStackController prizeStackController)
        {
            Game = game;
            GameAction = new GameAction();
            FightController = fightController;
            PrizeStackController = prizeStackController;
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
                    action.SpecialPower(Game, user);
                    var fight = new Fight();
                    fight.Heros.Add(user);
                    fight.Monsters.Add((MonsterCardBase)action);
                    if (FightController.WhoWinFight(fight))
                    {
                        GetPrizes(fight);
                    }
                    else
                    {
                        DeadEnd(fight);
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

        public void DeadEnd(Fight fight)
        {
            foreach (var monster in fight.Monsters)
            {
                foreach (var hero in fight.Heros)
                {
                    monster.DeadEnd(Game, hero);
                }
            }
        }

        public void GetPrizes(Fight fight)
        {
            if (fight.Heros.Count == 1)
            {
                var prizes = 0;
                foreach (var monster in fight.Monsters)
                {
                    prizes += monster.NumberOfPrizes;
                }

                while (prizes > 0)
                {
                    var card = PrizeStackController.DrawCard();
                    fight.Heros[0].Deck.Items.Add(card);
                    prizes--;
                }
            }
            else if (fight.Heros.Count > 1)
            {
                var list = new List<ItemCard>();
                var prizes = 0;
                foreach (var monster in fight.Monsters)
                {
                    prizes += monster.NumberOfPrizes;
                }

                while (prizes > 0)
                {
                    foreach (var hero in fight.Heros)
                    {
                        if (prizes == 0) return;
                        var card = PrizeStackController.DrawCard();
                        hero.Deck.Items.Add(card);
                        prizes--;
                    }
                }
            }
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
