using Munchkin.BL.Helper;
using Munchkin.Model.Card.PrizeCard;
using Munchkin.Model.Character.Action;
using Munchkin.Model.Character.Hero.Proficiency;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Model.Character
{
    public abstract class ProficiencyBase : IBaseAction, IMageAction, IThiefAction, IWarriorAction
    {
        private readonly InformationModelProficiencyBase informationModel = new InformationModelProficiencyBase();

        public int Id { get; set; }
        public string Name { get; set; }

        public CardGameBase TakeCard()
        {
            throw new NotImplementedException();
        }

        public int RunAway()
        {
            throw new NotImplementedException();
        }

        public bool Fight()
        {
            throw new NotImplementedException();
        }

        public bool AskForHelp()
        {
            throw new NotImplementedException();
        }

        public CardGameBase ThrowCard()
        {
            throw new NotImplementedException();
        }

        public CardGameBase UseCardFromDeck()
        {
            throw new NotImplementedException();
        }

        public bool TakeAction()
        {
            throw new NotImplementedException();
        }

        public virtual void FleeSpell(UserClass user, int cardToThrowId)
        {
            throw new NotImplementedException();
        }

        public virtual bool CharmSpell(UserClass user)
        {
            throw new NotImplementedException();
        }

        protected int ChooseCardToThrowOut(UserClass user)
        {
            Console.WriteLine(informationModel.ChooseCardToRemoveMsg());
            try
            {
                Int32.TryParse(Console.ReadLine(), out int num);
                return num;

            }
            catch (Exception)
            {
                Console.WriteLine("Wrong input Bro, INPUT NUMBER");
                return ChooseCardToThrowOut(user);
            }
        }

        protected bool ThrowOutCart(int whichOne, UserClass user)
        {
            var item = user.Deck[whichOne-1];
            try
            {
                user.Deck.Remove(item);
                Console.WriteLine(informationModel.CardRemovedMsg());
                //Console.ReadLine();

            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine(informationModel.WrongNumberMsg());
                //Console.ReadLine();
                return false;
            }
            return true;
        }

        public virtual void StealCard(UserClass thief, UserClass victim, Random random, ReadLineOverride readLine)
        {
            throw new NotImplementedException();
        }

        public virtual bool BackStab(UserClass victim, Random random)
        {
            throw new NotImplementedException();
        }

        public int RollDice(Random random)
        {
            return random.Next(6) + 1;
        }

        public virtual void BeStronger(UserClass user, int cardToThrowId)
        {
            throw new NotImplementedException();
        }
    }
}
