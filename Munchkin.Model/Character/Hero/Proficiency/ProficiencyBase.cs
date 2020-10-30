using Munchkin.BL.Helper;
using Munchkin.Model.Card.ActionCard;
using Munchkin.Model.Card.ActionCard.SpecialCardType.Monsters.Abstract;
using Munchkin.Model.Card.PrizeCard;
using Munchkin.Model.Character.Action;
using Munchkin.Model.Character.Hero.Proficiency;
using Munchkin.Model.Helper;
using Munchkin.Model.User;
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
        public ReadLineOverride readLineOverride { get; set; }


        public virtual void FleeSpell(UserClass user, int cardToThrowId)
        {
            throw new NotImplementedException();
        }

        public virtual bool CharmSpell(UserClass user)
        {
            throw new NotImplementedException();
        }

        public bool ThrowOutCart(int whichOne, UserClass user)
        {
            whichOne -= 1;
            ItemCard item;
            MonsterCardBase monster;
            ActionCardBase magicCard;
            if (whichOne < user.Deck.Items.Count)
            {
                item = user.Deck.Items[whichOne];
                user.Deck.Items.Remove(item);
                Console.WriteLine(informationModel.CardRemovedMsg());
            }
            else
            {
                whichOne -= user.Deck.Items.Count;
                if (whichOne < user.Deck.Monsters.Count)
                {
                    monster = user.Deck.Monsters[whichOne];
                    user.Deck.Monsters.Remove(monster);
                    Console.WriteLine(informationModel.CardRemovedMsg());
                }
                else
                {
                    whichOne -= user.Deck.Monsters.Count;
                    if (whichOne < user.Deck.MagicCards.Count)
                    {
                        magicCard = user.Deck.MagicCards[whichOne];
                        user.Deck.MagicCards.Remove(magicCard);
                        Console.WriteLine(informationModel.CardRemovedMsg());
                    }
                    else
                    {

                        Console.WriteLine(informationModel.WrongNumberMsg());
                        readLineOverride.GetNextString();
                        return false;
                    }
                }
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

        public virtual DestroyedCards BeStronger(UserClass user, int cardToThrowId)
        {
            throw new NotImplementedException();
        }

#nullable enable
        public virtual DestroyedCards MakeMonsterAPet(UserClass user, Fight? fight)
        {
            throw new NotImplementedException();
        }
#nullable disable

        public virtual void RestoreCard()
        {
            throw new NotImplementedException();
        }
    }
}
